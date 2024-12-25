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

namespace _24_12_2024_Visual_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Optionally, you can call QueryHighScores here if you want to show scores on startup
        }

        private void ShowHighScores_Click(object sender, RoutedEventArgs e)
        {
            StudentClass sc = new StudentClass();
            var highScores = sc.QueryHighScores(1, 90); // Get high scores for exam 1 with a score threshold of 90

            HighScoresListBox.Items.Clear(); // Clear previous items

            foreach (var item in highScores)
            {
                HighScoresListBox.Items.Add($"{item.Name}: {item.Score}");
            }
        }
    }

    public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public GradeLevel Year { get; set; }
        public List<int> ExamScores { get; set; }
    }

    public class StudentClass
    {
        protected static List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", ID = 120, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", ID = 117, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", ID = 115, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113 , Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", ID = 119, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", ID = 122, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 94, 92, 91, 91 }},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 96, 85, 91, 60}}
        };

        // Helper method, used in QueryHighScores.
        protected static int GetPercentile(Student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)(avg / 10) : 0;
        }

        public IEnumerable<dynamic> QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

            return highScores.ToList(); // Return the high scores as a list
        }
    }


}




