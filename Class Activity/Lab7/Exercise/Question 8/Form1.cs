using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] photoFiles;  // Array to store photo file paths
        private int currentIndex;     // Current index of the photo being displayed


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadPhotos(string folderPath)
        {
            // Get all image files from the folder
            photoFiles = System.IO.Directory.GetFiles(folderPath, "*.jpg;*.png;*.jpeg;*.bmp", System.IO.SearchOption.TopDirectoryOnly);

            // Update the total photos label
            lblTotalPhotos.Text = $"Total Photos: {photoFiles.Length}";

            // Reset the index and display the first photo
            currentIndex = 0;
            if (photoFiles.Length > 0)
            {
                DisplayPhoto(currentIndex);
            }
            else
            {
                MessageBox.Show("No photos found in the selected folder.", "Error");
            }
        }
        private void DisplayPhoto(int index)
        {
            if (photoFiles != null && photoFiles.Length > 0 && index >= 0 && index < photoFiles.Length)
            {
                pictureBox.Image = System.Drawing.Image.FromFile(photoFiles[index]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (photoFiles != null && currentIndex < photoFiles.Length - 1)
            {
                currentIndex++;
                DisplayPhoto(currentIndex);
            }
            else
            {
                MessageBox.Show("No more photos to display.", "End of Photos");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (photoFiles != null && currentIndex > 0)
            {
                currentIndex--;
                DisplayPhoto(currentIndex);
            }
            else
            {
                MessageBox.Show("You are at the first photo.", "Start of Photos");
            }
        }

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the folder path in the TextBox
                    txtFolderPath.Text = folderDialog.SelectedPath;

                    // Load photos from the selected folder
                    LoadPhotos(folderDialog.SelectedPath);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
