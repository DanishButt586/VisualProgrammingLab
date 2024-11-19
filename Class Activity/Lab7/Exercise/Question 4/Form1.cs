using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9; // Conversion formula
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtFahrenheit.Text, out double fahrenheit))
            {
                // Call the conversion function
                double celsius = ConvertFahrenheitToCelsius(fahrenheit);
                // Display the result in lblResult
                lblResult.Text = $"Celsius: {celsius:F2}";
            }
            else
            {
                // Show an error message if the input is invalid
                MessageBox.Show("Please enter a valid numeric value for Fahrenheit.", "Input Error");
            }
        }
    }
}
