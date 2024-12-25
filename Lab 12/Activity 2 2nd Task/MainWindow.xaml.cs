using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
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
using System.Windows.Threading;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

namespace _24_12_2024_Visual_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString;
            LoadCourses();
            LoadStudents();
        }

        private void LoadCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CourseID, CourseCode, CourseName FROM Course", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var course = new Course
                    {
                        CourseID = reader.GetInt32(0),
                        CourseCode = reader.GetString(1),
                        CourseName = reader.GetString(2)
                    };
                    courses.Add(course);
                }
            }

            CoursesDataGrid.ItemsSource = courses;

            // Populate the Courses ComboBox
            CoursesComboBox.ItemsSource = courses;
            CoursesComboBox.DisplayMemberPath = "CourseCode"; // Display course code
            CoursesComboBox.SelectedValuePath = "CourseID"; // Use CourseID as the value
        }

        private void LoadStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT StudentID, StudentName, StudentRegID FROM Student", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student
                    {
                        StudentID = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        StudentRegID = reader.GetString(2)
                    };
                    students.Add(student);
                }
            }

            StudentsDataGrid.ItemsSource = students;

            // Populate the Students ComboBox
            StudentsComboBox.ItemsSource = students;
            StudentsComboBox.DisplayMemberPath = "StudentName"; // Display student name
            StudentsComboBox.SelectedValuePath = "StudentID"; // Use StudentID as the value
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            string courseCode = CourseCodeTextBox.Text;
            string courseName = CourseNameTextBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Course (CourseCode, CourseName) VALUES (@CourseCode, @CourseName)", connection);
                command.Parameters.AddWithValue("@CourseCode", courseCode);
                command.Parameters.AddWithValue("@CourseName", courseName);
                command.ExecuteNonQuery();
            }

            LoadCourses(); // Refresh the data grid
            CourseCodeTextBox.Clear();
            CourseNameTextBox.Clear();
        }

        private void EnrollButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected student and course
            if (StudentsComboBox.SelectedValue is int studentId && CoursesComboBox.SelectedValue is int courseId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO StudentCourses (StudentID, CourseID) VALUES (@StudentID, @CourseID )", connection);
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@CourseID", courseId);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Please select both a student and a course to enroll.");
            }
        }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentRegID { get; set; }
    }

    public class LengthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int length)
            {
                return length == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}





