using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timerClock.Start(); // Start the timer
            UpdateDateTime();   // Display current date and time immediately
        }
        private void UpdateDateTime()
        {
            lblDate.Text = "Date: " + DateTime.Now.ToString("dddd, MMMM dd, yyyy"); // Day, Month dd, yyyy
            lblTime.Text = "Time: " + DateTime.Now.ToString("hh:mm:ss tt");        // hh:mm:ss AM/PM
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}
