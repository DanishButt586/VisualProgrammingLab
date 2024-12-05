namespace VisualProgrammingLab8_Final_
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.CmboBoxCountry = new System.Windows.Forms.ComboBox();
            this.GrpBoxGender = new System.Windows.Forms.GroupBox();
            this.BtnMale = new System.Windows.Forms.RadioButton();
            this.BtnFemale = new System.Windows.Forms.RadioButton();
            this.GrpBoxHobby = new System.Windows.Forms.GroupBox();
            this.ChkBoxReading = new System.Windows.Forms.CheckBox();
            this.ChkBoxWriting = new System.Windows.Forms.CheckBox();
            this.GrpBoxStatus = new System.Windows.Forms.GroupBox();
            this.BtnUnmarried = new System.Windows.Forms.RadioButton();
            this.BtnMarried = new System.Windows.Forms.RadioButton();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GrpBoxGender.SuspendLayout();
            this.GrpBoxHobby.SuspendLayout();
            this.GrpBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.lblID.Location = new System.Drawing.Point(12, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(38, 30);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            this.lblID.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.lblName.Location = new System.Drawing.Point(7, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 30);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);
            this.lblCountry.Location = new System.Drawing.Point(7, 119);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(103, 30);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Country";
            // 
            // txtBoxId
            // 
            this.txtBoxId.Location = new System.Drawing.Point(112, 29);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(165, 20);
            this.txtBoxId.TabIndex = 3;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(112, 79);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(165, 20);
            this.txtBoxName.TabIndex = 4;
            // 
            // CmboBoxCountry
            // 
            this.CmboBoxCountry.FormattingEnabled = true;
            this.CmboBoxCountry.Location = new System.Drawing.Point(112, 128);
            this.CmboBoxCountry.Name = "CmboBoxCountry";
            this.CmboBoxCountry.Size = new System.Drawing.Size(165, 21);
            this.CmboBoxCountry.TabIndex = 5;
            // 
            // GrpBoxGender
            // 
            this.GrpBoxGender.Controls.Add(this.BtnFemale);
            this.GrpBoxGender.Controls.Add(this.BtnMale);
            this.GrpBoxGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.GrpBoxGender.Location = new System.Drawing.Point(283, 19);
            this.GrpBoxGender.Name = "GrpBoxGender";
            this.GrpBoxGender.Size = new System.Drawing.Size(191, 109);
            this.GrpBoxGender.TabIndex = 6;
            this.GrpBoxGender.TabStop = false;
            this.GrpBoxGender.Text = "Gender";
            this.GrpBoxGender.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BtnMale
            // 
            this.BtnMale.AutoSize = true;
            this.BtnMale.Location = new System.Drawing.Point(6, 28);
            this.BtnMale.Name = "BtnMale";
            this.BtnMale.Size = new System.Drawing.Size(69, 28);
            this.BtnMale.TabIndex = 0;
            this.BtnMale.TabStop = true;
            this.BtnMale.Text = "Male";
            this.BtnMale.UseVisualStyleBackColor = true;
            // 
            // BtnFemale
            // 
            this.BtnFemale.AutoSize = true;
            this.BtnFemale.Location = new System.Drawing.Point(6, 62);
            this.BtnFemale.Name = "BtnFemale";
            this.BtnFemale.Size = new System.Drawing.Size(92, 28);
            this.BtnFemale.TabIndex = 1;
            this.BtnFemale.TabStop = true;
            this.BtnFemale.Text = "Female";
            this.BtnFemale.UseVisualStyleBackColor = true;
            // 
            // GrpBoxHobby
            // 
            this.GrpBoxHobby.Controls.Add(this.ChkBoxWriting);
            this.GrpBoxHobby.Controls.Add(this.ChkBoxReading);
            this.GrpBoxHobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.GrpBoxHobby.Location = new System.Drawing.Point(480, 19);
            this.GrpBoxHobby.Name = "GrpBoxHobby";
            this.GrpBoxHobby.Size = new System.Drawing.Size(191, 109);
            this.GrpBoxHobby.TabIndex = 7;
            this.GrpBoxHobby.TabStop = false;
            this.GrpBoxHobby.Text = "Hobby";
            // 
            // ChkBoxReading
            // 
            this.ChkBoxReading.AutoSize = true;
            this.ChkBoxReading.Location = new System.Drawing.Point(6, 28);
            this.ChkBoxReading.Name = "ChkBoxReading";
            this.ChkBoxReading.Size = new System.Drawing.Size(100, 28);
            this.ChkBoxReading.TabIndex = 0;
            this.ChkBoxReading.Text = "Reading";
            this.ChkBoxReading.UseVisualStyleBackColor = true;
            // 
            // ChkBoxWriting
            // 
            this.ChkBoxWriting.AutoSize = true;
            this.ChkBoxWriting.Location = new System.Drawing.Point(6, 62);
            this.ChkBoxWriting.Name = "ChkBoxWriting";
            this.ChkBoxWriting.Size = new System.Drawing.Size(87, 28);
            this.ChkBoxWriting.TabIndex = 1;
            this.ChkBoxWriting.Text = "Writing";
            this.ChkBoxWriting.UseVisualStyleBackColor = true;
            // 
            // GrpBoxStatus
            // 
            this.GrpBoxStatus.Controls.Add(this.BtnUnmarried);
            this.GrpBoxStatus.Controls.Add(this.BtnMarried);
            this.GrpBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.GrpBoxStatus.Location = new System.Drawing.Point(677, 19);
            this.GrpBoxStatus.Name = "GrpBoxStatus";
            this.GrpBoxStatus.Size = new System.Drawing.Size(191, 109);
            this.GrpBoxStatus.TabIndex = 7;
            this.GrpBoxStatus.TabStop = false;
            this.GrpBoxStatus.Text = "Martial Status";
            // 
            // BtnUnmarried
            // 
            this.BtnUnmarried.AutoSize = true;
            this.BtnUnmarried.Location = new System.Drawing.Point(6, 62);
            this.BtnUnmarried.Name = "BtnUnmarried";
            this.BtnUnmarried.Size = new System.Drawing.Size(116, 28);
            this.BtnUnmarried.TabIndex = 1;
            this.BtnUnmarried.TabStop = true;
            this.BtnUnmarried.Text = "Unmarried";
            this.BtnUnmarried.UseVisualStyleBackColor = true;
            // 
            // BtnMarried
            // 
            this.BtnMarried.AutoSize = true;
            this.BtnMarried.Location = new System.Drawing.Point(6, 28);
            this.BtnMarried.Name = "BtnMarried";
            this.BtnMarried.Size = new System.Drawing.Size(92, 28);
            this.BtnMarried.TabIndex = 0;
            this.BtnMarried.TabStop = true;
            this.BtnMarried.Text = "Married";
            this.BtnMarried.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnPreview.Location = new System.Drawing.Point(677, 134);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(113, 47);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnAdd.Location = new System.Drawing.Point(319, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 47);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnDelete.Location = new System.Drawing.Point(438, 134);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 47);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnUpdate.Location = new System.Drawing.Point(558, 134);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(113, 47);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(778, 311);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 535);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.GrpBoxStatus);
            this.Controls.Add(this.GrpBoxHobby);
            this.Controls.Add(this.GrpBoxGender);
            this.Controls.Add(this.CmboBoxCountry);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.txtBoxId);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GrpBoxGender.ResumeLayout(false);
            this.GrpBoxGender.PerformLayout();
            this.GrpBoxHobby.ResumeLayout(false);
            this.GrpBoxHobby.PerformLayout();
            this.GrpBoxStatus.ResumeLayout(false);
            this.GrpBoxStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.ComboBox CmboBoxCountry;
        private System.Windows.Forms.GroupBox GrpBoxGender;
        private System.Windows.Forms.RadioButton BtnFemale;
        private System.Windows.Forms.RadioButton BtnMale;
        private System.Windows.Forms.GroupBox GrpBoxHobby;
        private System.Windows.Forms.CheckBox ChkBoxWriting;
        private System.Windows.Forms.CheckBox ChkBoxReading;
        private System.Windows.Forms.GroupBox GrpBoxStatus;
        private System.Windows.Forms.RadioButton BtnUnmarried;
        private System.Windows.Forms.RadioButton BtnMarried;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

