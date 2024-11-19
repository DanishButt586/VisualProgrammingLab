using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_No_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = string.Empty;

        private void DigitFunction(Button btn)
        {
            txtDisplay.Text += btn.Text; // Append the button's text to the display
        }
        private void OperationFunction(Button btn)
        {
            firstNumber = Convert.ToDouble(txtDisplay.Text); // Save the first number
            operation = btn.Text; // Save the operation (e.g., "+", "-", "*", "/")
            txtDisplay.Clear(); // Clear the display for the next input
        }
        private void EqualsFunction()
        {
            secondNumber = Convert.ToDouble(txtDisplay.Text); // Save the second number

            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Division by zero is not allowed!");
                        txtDisplay.Clear();
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            txtDisplay.Text = result.ToString(); // Display the result
            firstNumber = result; // Optionally store the result for further calculations
        }
        private void ClearFunction()
        {
            txtDisplay.Clear(); // Clear the display
            firstNumber = 0;
            secondNumber = 0;
            operation = ""; // Reset the operation
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DigitFunction(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DigitFunction(button3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DigitFunction(button5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DigitFunction(button1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            EqualsFunction();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DigitFunction(button4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DigitFunction(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DigitFunction(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DigitFunction(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DigitFunction(button9);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DigitFunction(button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ClearFunction();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OperationFunction(button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OperationFunction(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OperationFunction(button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OperationFunction(button13);
        }
    }
}
