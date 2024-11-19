using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int MaxCharacters = 160; // Define the maximum character limit
        private void Form1_Load(object sender, EventArgs e)
        {
            txtInput.TextChanged += txtInput_TextChanged; // Attach the event handler
            lblCharCount.Text = $"Characters Left: {MaxCharacters}"; // Initialize label
        }

        private void lblCharCount_Click(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            // Check the current length of the input text
            int charactersTyped = txtInput.Text.Length;

            // Update the remaining character count
            lblCharCount.Text = $"Characters Left: {MaxCharacters - charactersTyped}";

            // Trim the text if it exceeds the limit
            if (charactersTyped > MaxCharacters)
            {
                txtInput.Text = txtInput.Text.Substring(0, MaxCharacters);
                txtInput.SelectionStart = txtInput.Text.Length; // Move the cursor to the end
            }
        }
    }
}
