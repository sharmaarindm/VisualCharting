/* ======================================================== */
/* PROJECT     : Business Intelligence A1					*/
/* FILE NAME   : Form1.cs                                   */
/* PURPOSE	   : this file contains all the code to create  */
/*               and present 4 different types of charts: 	*/
/*               Line chart, Pareto Diagram, Pie Chart and  */
/*               Control chart                              */
/* DATE		   : 2017-09-21							    	*/
/* PROGRAMMER  : ARINDM SHARMA								*/
/* ======================================================== */

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace asharma_BI_A1
{
    /*
    class header comment
    class name: Form1
    purpose: this class is used to display 4 different types of charts using MSChart:
    Line Chart
    Pie Chart
    Pareto Diagram
    Control Chart
    */
    public partial class Form1 : Form
    {

        DataTable table1 = new DataTable();

        // Data arrays.
        string[] seriesArray = { "Dogs", "Cats", "Elephants", "Fishes", "Birds" };
        string[] lastarray = { "Dogs", "Cats", "Elephants", "Fishes", "Birds" };
        double[] amountArray = { 15, 10, 35, 25, 15 };
        double[] amountArray2 = { 10, 20, 15, 5, 25 };

        int datagridHeight = 45;
        double frequencySum = 0;
        public static int UcL = 30, UwL = 25, cL = 20, LwL = 15, LcL = 10;
        double sumPrevFreq = 0;
        string dmp = "";

        /*  -- CONSTRUCTOR Comment
        Name	:   Form1
        Purpose :   Default constructor for the class Form1; to do the initial setup.
        Inputs	:	NONE
        Outputs	:	NONE
        Returns	:	NOTHING
        */
        public Form1()
        {
            InitializeComponent();
            for (int j = 0; j < 5; j++)
            {
                table1.Columns.Add(seriesArray[j]);
            }

            //start with te pie chart selected
            titleLabel.Text = "Pie Chart";
            PieRadioButton.Checked = true;

            desiredLimitEdit.Enabled = false;

            //update the data grid according to the amount array
            updateTheDataGrid();
            //read from the data grid and update the amount array, this step can be excluded
            readFromDataGrid();

            //make changes to the datagridview
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Height = datagridHeight;

            // Set palette color.
            this.chart1.Palette = ChartColorPalette.Bright;

            //set the chart type
            this.chart1.Series["Series1"].ChartType = SeriesChartType.Pie;

            // Set title.
            this.chart1.Titles.Add("amount of defective toys");
            //display the pie chart
            updatePieChart();
        }


        /*  -- METHOD Header Comment
        Name	:   updateTheDataGrid
        Purpose :   this method is responsible for the updation of the dataGridAccording to the specific species percentages.
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void updateTheDataGrid()
        {
            DataRow dr = null;

            dr = table1.NewRow(); // have new row on each iteration

            for(int i =0;i<5;i++)
            {
                dr[seriesArray[i]] = amountArray[i].ToString(); //read all the data from the amount array into the datatable.
            }
            table1.Rows.Add(dr);//add the row to the datatable.
           
            dataGridView1.DataSource = table1;//set datagrid datasource to datatable.
        }

        /*  -- METHOD Header Comment
        Name	:   readFromDataGrid
        Purpose :   this method is responsible for reading from the data grid 
                    and update the amount array accordingly
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void readFromDataGrid()
        {
            for (int i =0;i<5;i++)
            {
               Double.TryParse(dataGridView1.Rows[0].Cells[i].Value.ToString(),out amountArray[i]);//read all the data from datagrid into amout array
           }
            if(dataGridView1.Rows[1].Cells[1].Value!=null)
            {
                for (int i = 0; i < 5; i++)
                {
                     Double.TryParse(dataGridView1.Rows[1].Cells[i].Value.ToString(),out amountArray2[i]);
                }
            }
         
        }

        /*  -- METHOD Header Comment
        Name	:   Update_Click
        Purpose :   this method acts as a handle for the Update button click event
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void Update_Click(object sender, EventArgs e)
        {
            //read all data from data grid
            readFromDataGrid();

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            //update the specific chart depending on the radio button that is clicked
            if (PieRadioButton.Checked)
            {
                updatePieChart();
            }
            else if(ParetoRadioButton.Checked)
            {
                updatePareto();
            }
            else if (ControlRadioButton.Checked)
            {
                updateControlChart();
            }
            else if(LineRadioButton.Checked)
            {
                updateLineChart();
            }
        }

        /*  -- METHOD Header Comment
        Name	:   updatePieChart
        Purpose :   this method is responsible for creating a pie chart 
                    according to the data stored in the amountArray
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void updatePieChart()
        {
            this.chart1.Series.Clear();
            Series series = this.chart1.Series.Add(seriesArray[0]);
            this.chart1.Series[seriesArray[0]].ChartType = SeriesChartType.Pie;
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add point.
                series.Points.Add(amountArray[i]);
                this.chart1.Series[seriesArray[0]].Points[i].AxisLabel = seriesArray[i];
            }
        }

        /*  -- METHOD Header Comment
        Name	:   updatePareto
        Purpose :   this method is responsible for creating a pareto diagram 
                    according to the data stored in the amountArray
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void updatePareto()
        {
            //calculate the total of frequency
            calcFreq();
            //clear the chart series
            this.chart1.Series.Clear();

            //create new series
            Series series = this.chart1.Series.Add("Defective species");
            Series series2 = this.chart1.Series.Add("%age of defect");
            //set specific chart types for specific series
            this.chart1.Series["Defective species"].ChartType = SeriesChartType.Column;
            this.chart1.Series["%age of defect"].ChartType = SeriesChartType.Spline;
            // add a Y2 axis 
            chart1.ChartAreas[0].AxisX.Title = "animal names";
            chart1.ChartAreas[0].AxisY.Title = "Defect amount";
            chart1.ChartAreas[0].AxisY2.Title = "Cumulative %age of defects";
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

            //set the axis to specific series.
            chart1.Series[0].YAxisType = AxisType.Primary;
            chart1.Series[1].YAxisType = AxisType.Secondary;

            //set the chart area properties
            chart1.ChartAreas[0].AxisY2.LineColor = Color.Red;
            chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisY2.IsStartedFromZero = chart1.ChartAreas[0].AxisY.IsStartedFromZero;

            double temp;

            //sort the array in descending order
            Array.Sort(amountArray);
            Array.Reverse(amountArray);

            Dictionary<string, string> dic = new Dictionary<string, string>(); //instantiate a new dictionary

            //add data to the dicitonary 
            for(int i = 0; i < 5; i++)
            {
                dic.Add(seriesArray[i], dataGridView1.Rows[0].Cells[i].Value.ToString());
            }
            
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add point.
                series.Points.Add(amountArray[i]);

                
                foreach (KeyValuePair<string, string> pair in dic)
                {
                    if((amountArray[i].ToString() == pair.Value) )
                    {
                        if (i == 0)
                        {
                            
                            lastarray[i] = pair.Key;
                            dmp = pair.Key;
                        }
                        else
                        {
                            if (lastarray[i - 1] != pair.Key)//to check if names have been repeated
                            {
                                lastarray[i] = pair.Key;
                                dmp = pair.Key;
                            }
                        }
                    }
                }
                
            
                this.chart1.Series["Defective species"].Points[i].AxisLabel = dmp;

                //calculate cumulative frequency percentage for this iteration
         
                temp = calcCumFreqPercentage(amountArray[i]);
                series2.Points.Add(temp);
                series2.Points[i].MarkerColor = Color.Blue;
                series2.Points[i].MarkerStyle = MarkerStyle.Circle;
                series2.Points[i].MarkerSize = 10;
            }
           
            lastarray[0] = "Dogs";
            lastarray[1] = "Cats";
            lastarray[2] = "Babies";
            lastarray[3] = "Fishes";
            lastarray[4] = "Birds";
            sumPrevFreq = 0;
        }
        /*  -- METHOD Header Comment
        Name	:   updateLineChart
        Purpose :   this method is responsible for creating a Line chart 
                    according to the data stored in the amountArray
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void updateLineChart()
        {
            this.chart1.Series.Clear();
            Series series = this.chart1.Series.Add("depiction of expected data");
            Series series2 = this.chart1.Series.Add("depiction of actual data");
            this.chart1.Series["depiction of expected data"].ChartType = SeriesChartType.Line;
            this.chart1.Series["depiction of actual data"].ChartType = SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Title = "animal names";
            chart1.ChartAreas[0].AxisY.Title = "Defect amount";
            chart1.ChartAreas[0].AxisY2.Title = "Defect amount";
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {

                // Add point.
                series.Points.Add(amountArray[i]);
                series2.Points.Add(amountArray2[i]);
                this.chart1.Series["depiction of expected data"].Points[i].AxisLabel = seriesArray[i];
            }
        }

        /*  -- METHOD Header Comment
        Name	:   updateControlChart
        Purpose :   this method is responsible for creating a control chart 
                    according to the data stored in the amountArray
        PARAMETERS	:	NONE
        Returns	:	NOTHING
        */
        void updateControlChart()
        {

            this.chart1.Series.Clear();
            Series series = this.chart1.Series.Add("UCL");
            this.chart1.Series["UCL"].ChartType = SeriesChartType.Line;


            //create and setup various step lines to run across the graph
            StripLine UCL = new StripLine();
            UCL.StripWidth = 0;
            UCL.BorderColor = Color.Red;
            UCL.BorderWidth = 3;
            UCL.Interval = 0;
            UCL.IntervalOffset = UcL;
            UCL.Text = "UCL";

            StripLine UWL = new StripLine();
            UWL.StripWidth = 0;
            UWL.BorderColor = Color.Yellow;
            UWL.BorderWidth = 3;
            UWL.Interval = 0;
            UWL.IntervalOffset = UwL;
            UWL.Text = "UWL";

            StripLine CL = new StripLine();
            CL.StripWidth = 0;
            CL.BorderColor = Color.Black;
            CL.BorderWidth = 3;
            CL.Interval = 0;
            CL.IntervalOffset = cL;
            CL.Text = "CL";

            StripLine LWL = new StripLine();
            LWL.StripWidth = 0;
            LWL.BorderColor = Color.Yellow;
            LWL.BorderWidth = 3;
            LWL.Interval = 0;
            LWL.IntervalOffset = LwL;
            LWL.Text = "LWL";

            StripLine LCL = new StripLine();
            LCL.StripWidth = 0;
            LCL.BorderColor = Color.Red;
            LCL.BorderWidth = 3;
            LCL.Interval = 0;
            LCL.IntervalOffset = LcL;
            LCL.Text = "LCL";

            //add the different stripline to the chartarea
            chart1.ChartAreas[0].AxisY.StripLines.Add(UCL);
            chart1.ChartAreas[0].AxisY.StripLines.Add(UWL);
            chart1.ChartAreas[0].AxisY.StripLines.Add(CL);
            chart1.ChartAreas[0].AxisY.StripLines.Add(LWL);
            chart1.ChartAreas[0].AxisY.StripLines.Add(LCL);
            chart1.ChartAreas[0].AxisX.Title = "animal names";
            chart1.ChartAreas[0].AxisY.Title = "Defect amount";
            chart1.ChartAreas[0].AxisY2.Title = "Defect amount";
            //Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Add point.
                series.Points.Add(amountArray[i]);

                series.Points[i].MarkerColor = Color.Blue;
                series.Points[i].MarkerStyle = MarkerStyle.Circle;
                series.Points[i].MarkerSize = 10;
                this.chart1.Series["UCL"].Points[i].AxisLabel = seriesArray[i];
            }
        }

        /*  -- METHOD Header Comment
        Name	:   PieRadioButton_CheckedChanged
        Purpose :   this method acts as a handle for the radio button 
                    check event for the Pie Chart radio button.
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void PieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            desiredLimitEdit.Enabled = false;
            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            dataGridView1.Height = datagridHeight;
            LineRadioButton.Checked = false;
            ParetoRadioButton.Checked = false;
            ControlRadioButton.Checked = false;
            titleLabel.Text = "Pie Chart";

            readFromDataGrid();
            updatePieChart();
        }

        /*  -- METHOD Header Comment
        Name	:   LineRadioButton_CheckedChanged
        Purpose :   this method acts as a handle for the radio button 
                    check event for the Line Chart radio button.
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void LineRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            desiredLimitEdit.Enabled = false;
            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            ParetoRadioButton.Checked = false;
            ControlRadioButton.Checked = false;
            PieRadioButton.Checked = false;
            titleLabel.Text = "Line Chart";

            //read from datagrid and update the line chart
            readFromDataGrid();
            updateLineChart();

            dataGridView1.Height = datagridHeight+20;

            DataRow dr = null;

            dr = table1.NewRow(); // have new row on each iteration

            for (int i = 0; i < 5; i++)
            {
                dr[seriesArray[i]] = amountArray2[i].ToString();
            }
            table1.Rows.Add(dr);

            dataGridView1.DataSource = table1;

        }

        /*  -- METHOD Header Comment
        Name	:   ParetoRadioButton_CheckedChanged
        Purpose :   this method acts as a handle for the radio button 
                    check event for the Pareto Diagram radio button.
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void ParetoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            desiredLimitEdit.Enabled = false;
            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            dataGridView1.Height = datagridHeight;
            LineRadioButton.Checked = false;
            ControlRadioButton.Checked = false;
            PieRadioButton.Checked = false;
            titleLabel.Text = "Pareto Diagram";

            readFromDataGrid();
            updatePareto();
        }

        /*  -- METHOD Header Comment
        Name	:   ControlRadioButton_CheckedChanged
        Purpose :   this method acts as a handle for the radio button 
                    check event for the Control Chart radio button.
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void ControlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            desiredLimitEdit.Enabled = true;
            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            dataGridView1.Height = datagridHeight;
            LineRadioButton.Checked = false;
            ParetoRadioButton.Checked = false;
            PieRadioButton.Checked = false;
            titleLabel.Text = "Control Chart";

            readFromDataGrid();
            updateControlChart();
        }

        /*  -- METHOD Header Comment
        Name	:   calcFreq
        Purpose :   this method calculates the frequencysum i.e. sum of 
                    all the frequencies in the frequency array
        PARAMETERS	: NOTHING
        Returns	:	NOTHING
        */
        void calcFreq()
        {
            double retVal = 0;
            for (int i = 0; i < amountArray.Length; i++)
            {
                retVal += amountArray[i];
            }
            frequencySum = retVal;
        }

        /*  -- METHOD Header Comment
        Name	:   calcCumFreqPercentage
        Purpose :   this method calculates the cumulative frequency for 
                    the frequencies in the frequency array.
        PARAMETERS	: double currFreq - frequency that needs the cumulative frequency.
        Returns	:	NOTHING
        */
        double calcCumFreqPercentage(double currFreq)
        {
            double retVal = 0;
            sumPrevFreq += currFreq;
            retVal = (sumPrevFreq / frequencySum) * 100;
            return retVal;
        }

        /*  -- METHOD Header Comment
        Name	:   desiredLimitEdit_Click
        Purpose :   this method acts as the event handle for the 
                    desired limit editing button click.
        PARAMETERS	: object sender, EventArgs e
        Returns	:	NOTHING
        */
        private void desiredLimitEdit_Click(object sender, EventArgs e)
        {
            editDesired edit = new editDesired(); 
            edit.Show(); //display the editDesired form.
        }
    }
}
