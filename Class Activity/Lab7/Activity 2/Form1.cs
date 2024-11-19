using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonThickCrust_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            string pizzaSize = comboBoxSize.SelectedItem?.ToString() ?? "None selected";

            // Gather the selected toppings
            List<string> selectedToppings = new List<string>();
            if (checkBoxCheese.Checked) selectedToppings.Add("Cheese");
            if (checkBoxPepperoni.Checked) selectedToppings.Add("Pepperoni");
            if (checkBoxMushrooms.Checked) selectedToppings.Add("Mushrooms");

            string toppings = selectedToppings.Count > 0 ? string.Join(", ", selectedToppings) : "No toppings selected";

            // Gather the selected crust type
            string crustType = radioButtonThinCrust.Checked ? "Thin Crust" :
                                radioButtonThickCrust.Checked ? "Thick Crust" : "None selected";

            // Display the order summary in the label
            labelOrderSummary.Text = $"Pizza Size: {pizzaSize}\nToppings: {toppings}\nCrust Type: {crustType}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
