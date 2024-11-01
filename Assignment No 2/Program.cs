using System;
using System.Windows.Forms;

public class MyForm : Form
{
    public MyForm()
    {
        this.Text = "Control Test";

        // MessageBox
        MessageBox.Show("Welcome to Control Test!");

        // Label
        Label label = new Label();
        label.Text = "Enter your name:";
        label.Location = new System.Drawing.Point(20, 20);
        this.Controls.Add(label);

        // TextBox
        TextBox textBox = new TextBox();
        textBox.Location = new System.Drawing.Point(20, 50);
        this.Controls.Add(textBox);

        // RichTextBox
        RichTextBox richTextBox = new RichTextBox();
        richTextBox.Location = new System.Drawing.Point(20, 80);
        richTextBox.Size = new System.Drawing.Size(200, 50);
        this.Controls.Add(richTextBox);

        // CheckBox
        CheckBox checkBox = new CheckBox();
        checkBox.Text = "Check me!";
        checkBox.Location = new System.Drawing.Point(20, 140);
        this.Controls.Add(checkBox);

        // RadioButton
        RadioButton radioButton = new RadioButton();
        radioButton.Text = "Radio me!";
        radioButton.Location = new System.Drawing.Point(20, 170);
        this.Controls.Add(radioButton);

        // ComboBox
        ComboBox comboBox = new ComboBox();
        comboBox.Items.AddRange(new string[] { "Option 1", "Option 2", "Option 3" });
        comboBox.Location = new System.Drawing.Point(20, 200);
        this.Controls.Add(comboBox);

        // NumericUpDown
        NumericUpDown numericUpDown = new NumericUpDown();
        numericUpDown.Location = new System.Drawing.Point(20, 230);
        this.Controls.Add(numericUpDown);

        // DateTimePicker
        DateTimePicker dateTimePicker = new DateTimePicker();
        dateTimePicker.Location = new System.Drawing.Point(20, 260);
        this.Controls.Add(dateTimePicker);

        // MonthCalendar
        MonthCalendar monthCalendar = new MonthCalendar();
        monthCalendar.Location = new System.Drawing.Point(250, 20);
        this.Controls.Add(monthCalendar);

        // PictureBox
        PictureBox pictureBox = new PictureBox();
        pictureBox.ImageLocation = "path_to_your_image.jpg";
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox.Location = new System.Drawing.Point(250, 200);
        pictureBox.Size = new System.Drawing.Size(100, 100);
        this.Controls.Add(pictureBox);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new MyForm());
    }
}
