using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long CalculateFactorial(int number)
        {
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i; // Multiply result by current number
            }
            return result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber.Text, out int number) && number >= 0)
            {
                // Call the factorial function
                long factorial = CalculateFactorial(number);
                // Display the result
                lblResult.Text = $"Factorial of {number} is: {factorial}";
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid non-negative integer.", "Input Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}
