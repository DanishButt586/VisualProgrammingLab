using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_1
{
    public partial class Form1 : Form
    {
        private double Add(double a, double b)
        {
            return a + b;
        }

        private double Subtract(double a, double b)
        {
            return a - b;
        }

        private double Multiply(double a, double b)
        {
            return a * b;
        }

        private double Divide(double a, double b)
        {
            if (b == 0)
            {
                MessageBox.Show("Division by zero is not allowed!");
                return 0;
            }
            return a / b;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(txtFirstNumber.Text);
            double num2 = Convert.ToDouble(txtSecondNumber.Text);
            txtResult.Text = Add(num1, num2).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtFirstNumber.Text);
            double num2 = double.Parse(txtResult.Text);
            double result = Subtract(num1, num2);
            txtResult.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtFirstNumber.Text);
            double num2 = double.Parse(txtResult.Text);
            double result = Multiply(num1, num2);
            txtResult.Text = result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtFirstNumber.Text);
            double num2 = double.Parse(txtResult.Text);
            double result = Divide(num1, num2);
            txtResult.Text = result.ToString();
        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
