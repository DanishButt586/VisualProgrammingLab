namespace Question_6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Time in Seconds :";
            // 
            // txtSeconds
            // 
            this.txtSeconds.Location = new System.Drawing.Point(304, 99);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(100, 20);
            this.txtSeconds.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(304, 202);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Countdown";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Location = new System.Drawing.Point(225, 151);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(54, 13);
            this.lblCountdown.TabIndex = 3;
            this.lblCountdown.Text = "Time Left:";
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Timer timerCountdown;
    }
}

