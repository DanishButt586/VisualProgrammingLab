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
using System.Windows.Shapes;

namespace Inventory_Management_System_SFML
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;
            // Basic validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Here you would typically save the username and password to a database or file
            // For demonstration, we will just show a success message
            MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            // Show both passwords as plain text
            txtNewPassword.Visibility = Visibility.Collapsed;
            txtNewPasswordTextBox.Visibility = Visibility.Visible;
            txtNewPasswordTextBox.Text = txtNewPassword.Password;

            txtConfirmPassword.Visibility = Visibility.Collapsed;
            txtConfirmPasswordTextBox.Visibility = Visibility.Visible;
            txtConfirmPasswordTextBox.Text = txtConfirmPassword.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Hide the TextBoxes and show the PasswordBoxes again
            txtNewPasswordTextBox.Visibility = Visibility.Collapsed;
            txtNewPassword.Visibility = Visibility.Visible;

            txtConfirmPasswordTextBox.Visibility = Visibility.Collapsed;
            txtConfirmPassword.Visibility = Visibility.Visible;
        }

        private void txtNewPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the PasswordBox when the TextBox changes
            txtNewPassword.Password = txtNewPasswordTextBox.Text;
        }

        private void txtConfirmPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the PasswordBox when the TextBox changes
            txtConfirmPassword.Password = txtConfirmPasswordTextBox.Text;
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
