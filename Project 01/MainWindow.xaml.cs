using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Inventory_Management_System_SFML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private TextBox passwordTextBox;
        public MainWindow()
        {
            InitializeComponent();
            InitializePasswordTextBox();
        }
        private void InitializePasswordTextBox()
        {
            passwordTextBox = new TextBox
            {
                Width = txtPassword.Width,
                Height = txtPassword.Height,
                Padding = txtPassword.Padding,
                FontSize = txtPassword.FontSize,
                Margin = txtPassword.Margin,
                Visibility = Visibility.Collapsed // Start hidden
            };

            // Insert the TextBox into the StackPanel
            stackPanel.Children.Insert(5, passwordTextBox); // Assuming the PasswordBox is at index 5
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get the username and password
            string username = txtUsername.Text;
            string password = txtPassword.Password; // Use Password property for PasswordBox

            // Check if the username is empty
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both your username and password to proceed.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("The username field cannot be left blank. Please enter your username.", "Username Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("The password field cannot be empty. Please enter your password.", "Password Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Example validation logic (replace with your actual logic)
            if (username == "Danish" && password == "Danish123") // Replace with actual validation
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                try
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("The credentials you entered are incorrect. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            // Store the current password in a temporary variable
            string password = txtPassword.Password;

            // Hide the PasswordBox and show the TextBox with the password
            txtPassword.Visibility = Visibility.Collapsed;
            passwordTextBox.Text = password;
            passwordTextBox.Visibility = Visibility.Visible;  // Show the TextBox
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Store the text from the TextBox (if visible)
            string password = string.Empty;

            // Check if the TextBox is visible, and retrieve the password
            if (passwordTextBox.Visibility == Visibility.Visible)
            {
                password = passwordTextBox.Text;
                passwordTextBox.Visibility = Visibility.Collapsed; // Hide the TextBox
            }

            // Set the password back to the PasswordBox
            txtPassword.Password = password;

            // Show the PasswordBox
            txtPassword.Visibility = Visibility.Visible;
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Closed += (s, args) => this.Show(); // Show the login window again when registration window is closed
            registerWindow.Show();
            this.Hide(); // Optionally hide the login window
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Password = string.Empty;
            passwordTextBox.Text = string.Empty; // If you are using this for any reason
        }
    }
}


