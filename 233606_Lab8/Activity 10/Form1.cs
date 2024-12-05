using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace VisualProgrammingLab8_Final_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // Connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL query to select data
                string query = "SELECT * FROM CustomerTable";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Bind the DataTable to the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate the ComboBox with sample countries
            CmboBoxCountry.Items.Add("United States");
            CmboBoxCountry.Items.Add("Canada");
            CmboBoxCountry.Items.Add("United Kingdom");
            CmboBoxCountry.Items.Add("Australia");
            CmboBoxCountry.Items.Add("India");
            CmboBoxCountry.Items.Add("Germany");
            CmboBoxCountry.Items.Add("France");
            CmboBoxCountry.Items.Add("Japan");

            // Load data into the DataGridView
            LoadData(); // Call the method to load data
        }


        private void label1_Click(object sender, EventArgs e)
        {
            // This method can be used for label click events if needed
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // This method can be used for group box enter events if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gather input data
            string id = txtBoxId.Text;
            string name = txtBoxName.Text;
            string country = CmboBoxCountry.SelectedItem?.ToString() ?? "Not Selected";
            string gender = BtnMale.Checked ? "Male" : BtnFemale.Checked ? "Female" : "Not Specified";
            string hobbies = (ChkBoxReading.Checked ? "Reading " : "") + (ChkBoxWriting.Checked ? "Writing" : "").Trim();
            string maritalStatus = BtnMarried.Checked ? "Married" : BtnUnmarried.Checked ? "Unmarried" : "Not Specified";

            // Display the gathered information in a message box
            string message = $"ID: {id}\nName: {name}\nCountry: {country}\nGender: {gender}\nHobbies: {hobbies}\nMarital Status: {maritalStatus}";
            MessageBox.Show(message, "Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CustomerTable (Id, CustomerName, Country, Gender, Hobby, Married) VALUES (@Id, @Name, @Country, @Gender, @Hobbies, @MaritalStatus)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", txtBoxId.Text);
                    command.Parameters.AddWithValue("@Name", txtBoxName.Text);
                    command.Parameters.AddWithValue("@Country", CmboBoxCountry.SelectedItem?.ToString() ?? "Not Selected");
                    command.Parameters.AddWithValue("@Gender", BtnMale.Checked ? "Male" : "Female");
                    command.Parameters.AddWithValue("@Hobbies", (ChkBoxReading.Checked ? "Reading " : "") + (ChkBoxWriting.Checked ? "Writing" : "").Trim());
                    command.Parameters.AddWithValue("@MaritalStatus", BtnMarried.Checked ? "Married" : "Unmarried");

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record added successfully.");
                        LoadData(); // Refresh the DataGridView
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show("SQL Error: " + sqlEx.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CustomerTable WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", txtBoxId.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID.");
                        }
                        LoadData(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CustomerTable SET CustomerName = @Name, Country = @Country, Gender = @Gender, Hobby = @Hobbies, Married = @MaritalStatus WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", txtBoxId.Text);
                    command.Parameters.AddWithValue("@Name", txtBoxName.Text);
                    command.Parameters.AddWithValue("@Country", CmboBoxCountry.SelectedItem?.ToString() ?? "Not Selected");
                    command.Parameters.AddWithValue("@Gender", BtnMale.Checked ? "Male" : "Female");
                    command.Parameters.AddWithValue("@Hobbies", (ChkBoxReading.Checked ? "Reading " : "") + (ChkBoxWriting.Checked ? "Writing" : "").Trim());
                    command.Parameters.AddWithValue("@MaritalStatus", BtnMarried.Checked ? "Married" : "Unmarried");

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID.");
                        }
                        LoadData(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}