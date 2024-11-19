using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19_11_2024_Lab_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonGreet_Click(object sender, EventArgs e)
        {
            // Check if the user has entered a name
            if (!string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                // Display a personalized greeting message
                labelMessage.Text = $"Hello, {textBoxName.Text}! Welcome!";
            }
            else
            {
                // Ask the user to enter a name if the TextBox is empty
                labelMessage.Text = "Please enter your name.";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
