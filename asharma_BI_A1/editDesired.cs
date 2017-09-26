/* ======================================================== */
/* PROJECT     : Business Intelligence A1					*/
/* FILE NAME   : editDesired.cs                             */
/* PURPOSE	   : this file contains teh code for the form   */
/*               that serves the purpose of editing the     */
/*               different UCL, UWL, CL, LWL and LCL values */
/*                                                          */
/* DATE		   : 2017-09-21							    	*/
/* PROGRAMMER  : ARINDM SHARMA								*/
/* ======================================================== */

using System;
using System.Windows.Forms;

namespace asharma_BI_A1
{
    /*
    class header comment
    class name: editDesired
    purpose: this class is used to take the different 
    UCL, UWL, CL, LWL and LCL values from the user
    */
    public partial class editDesired : Form
    {
        /*  -- CONSTRUCTOR Comment
        Name	:   editDesired
        Purpose :   Default constructor for the class editDesired; to perform the initial setup.
        Inputs	:	NONE
        Outputs	:	NONE
        Returns	:	NOTHING
        */
        public editDesired()
        {
            InitializeComponent();

            //display the current UCL,UWL,Cl,LWL and LCL values in their respective text fields. 
            textBox1.Text = Form1.UcL.ToString();
            textBox2.Text = Form1.UwL.ToString();
            textBox3.Text = Form1.cL.ToString();
            textBox4.Text = Form1.LwL.ToString();
            textBox5.Text = Form1.LcL.ToString();
        }

        /*  -- METHOD Header Comment
        Name	:   Update_Click
        Purpose :   this method acts as a handle for the button1 button click event
        PARAMETERS	: object sender, EventArgs e	
        Returns	:	NOTHING
        */
        private void button1_Click(object sender, EventArgs e)
        {
            //read the new UCL,UWL,Cl,LWL and LCL values from their respective 
            //text fields into their respective variables. 
            Form1.UcL = Int32.Parse(textBox1.Text);
            Form1.UwL = Int32.Parse(textBox2.Text);
            Form1.cL = Int32.Parse(textBox2.Text);
            Form1.LwL = Int32.Parse(textBox2.Text);
            Form1.LcL = Int32.Parse(textBox2.Text);
            this.Close();//close the form after reading data.
        }
    }
}
