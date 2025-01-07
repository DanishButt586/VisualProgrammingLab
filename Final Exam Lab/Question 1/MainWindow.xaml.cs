using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Question_1_Final_Exam
{
    public partial class MainWindow : Window
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["QuizDBConnection"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestions(); // Load questions when the application starts
        }

        private void LoadQuestions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Questions", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                QuestionsDataGrid.ItemsSource = dataTable.DefaultView; // Bind DataTable to DataGrid
            }
        }

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            // Here you would typically collect data from input fields
            // For demonstration, we are adding a static question
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Questions (QuestionText, Options, CorrectAnswer, AssignedMarks, TimeLimit, Topic, Difficulty) " +
                               "VALUES (@QuestionText, @Options, @CorrectAnswer, @AssignedMarks, @TimeLimit, @Topic, @Difficulty)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QuestionText", "New Question?");
                    command.Parameters.AddWithValue("@Options", "1. Option1; 2. Option2; 3. Option3; 4. Option4");
                    command.Parameters.AddWithValue("@CorrectAnswer", "1. Option1");
                    command.Parameters.AddWithValue("@AssignedMarks", 1);
                    command.Parameters.AddWithValue("@TimeLimit", 30);
                    command.Parameters.AddWithValue("@Topic", "General");
                    command.Parameters.AddWithValue("@Difficulty", "Easy");

                    connection.Open();
                    command.ExecuteNonQuery(); // Execute the insert command
                }
            }
            LoadQuestions(); // Refresh the DataGrid
        }

        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is DataRowView selectedRow)
            {
                int questionId = Convert.ToInt32(selectedRow["Id"]);
                string newQuestionText = "Updated Question?"; // Get this from user input
                // Collect other updated values similarly...

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Questions SET QuestionText = @QuestionText WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@QuestionText", newQuestionText);
                        command.Parameters.AddWithValue("@Id", questionId);

                        connection.Open();
                        command.ExecuteNonQuery(); // Execute the update command
                    }
                }
                LoadQuestions(); // Refresh the DataGrid
            }
        }

        private void DeleteQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionsDataGrid.SelectedItem is DataRowView selectedRow)
            {
                int questionId = Convert.ToInt32(selectedRow["Id"]);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Questions WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", questionId);

                        connection.Open();
                        command.ExecuteNonQuery(); // Execute the delete command
                    }
                }
                LoadQuestions(); // Refresh the DataGrid
            }
        }

        private void TopicComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement filtering based on topic selection
            // You would filter the DataGrid based on the selected topic
        }

        private void DifficultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Implement filtering based on difficulty selection
            // You would filter the DataGrid based on the selected difficulty
        }
    }
}
