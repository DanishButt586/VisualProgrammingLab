using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int countdownTime; // Time in seconds
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSeconds.Text, out countdownTime) && countdownTime > 0)
            {
                // Disable input and start button
                txtSeconds.Enabled = false;
                btnStart.Enabled = false;

                // Display initial countdown time
                lblCountdown.Text = $"Time Left: {countdownTime} seconds";

                // Start the timer
                timerCountdown.Start();
            }
            else
            {
                // Show an error message if input is invalid
                MessageBox.Show("Please enter a valid positive integer for the countdown time.", "Input Error");
            }
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            // Decrement the countdown time
            countdownTime--;

            // Update the label
            lblCountdown.Text = $"Time Left: {countdownTime} seconds";

            // Check if time is up
            if (countdownTime <= 0)
            {
                // Stop the timer
                timerCountdown.Stop();

                // Re-enable input and buttons
                txtSeconds.Enabled = true;
                btnStart.Enabled = true;

                // Reset the label
                lblCountdown.Text = "Time's Up!";

                // Show a message box
                MessageBox.Show("Time is up!", "Countdown Complete");
            }

        }
    }
}
