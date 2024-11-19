using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateSquares()
        {
            // Clear the ListBox to avoid duplicate entries
            lstSquares.Items.Clear();

            // Loop through the first 10 numbers
            for (int i = 1; i <= 10; i++)
            {
                int square = i * i; // Calculate square of the number
                string result = $"{i}\t{square}"; // Format result as "Number    Square"

                // Add the result to the ListBox
                lstSquares.Items.Add(result);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateSquares();

        }
    }
}
