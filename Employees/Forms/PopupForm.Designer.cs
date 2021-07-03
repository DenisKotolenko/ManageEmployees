namespace Employees.Forms
{
    partial class PopupForm
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
            this.genderGroupBox = new System.Windows.Forms.GroupBox();
            this.FemaleRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleRadioButton = new System.Windows.Forms.RadioButton();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.InactiveRadioButton = new System.Windows.Forms.RadioButton();
            this.ActiveRadioButton = new System.Windows.Forms.RadioButton();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.genderGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.Controls.Add(this.FemaleRadioButton);
            this.genderGroupBox.Controls.Add(this.MaleRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(129, 143);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Size = new System.Drawing.Size(150, 49);
            this.genderGroupBox.TabIndex = 26;
            this.genderGroupBox.TabStop = false;
            this.genderGroupBox.Text = "Gender";
            // 
            // FemaleRadioButton
            // 
            this.FemaleRadioButton.AutoSize = true;
            this.FemaleRadioButton.Location = new System.Drawing.Point(67, 19);
            this.FemaleRadioButton.Name = "FemaleRadioButton";
            this.FemaleRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleRadioButton.TabIndex = 1;
            this.FemaleRadioButton.Text = "Female";
            this.FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleRadioButton
            // 
            this.MaleRadioButton.AutoSize = true;
            this.MaleRadioButton.Checked = true;
            this.MaleRadioButton.Location = new System.Drawing.Point(6, 19);
            this.MaleRadioButton.Name = "MaleRadioButton";
            this.MaleRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleRadioButton.TabIndex = 0;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(255, 313);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(148, 48);
            this.AddEmployeeButton.TabIndex = 27;
            this.AddEmployeeButton.Text = "Save";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.InactiveRadioButton);
            this.statusGroupBox.Controls.Add(this.ActiveRadioButton);
            this.statusGroupBox.Location = new System.Drawing.Point(129, 198);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(150, 48);
            this.statusGroupBox.TabIndex = 25;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Status";
            // 
            // InactiveRadioButton
            // 
            this.InactiveRadioButton.AutoSize = true;
            this.InactiveRadioButton.Location = new System.Drawing.Point(67, 19);
            this.InactiveRadioButton.Name = "InactiveRadioButton";
            this.InactiveRadioButton.Size = new System.Drawing.Size(63, 17);
            this.InactiveRadioButton.TabIndex = 1;
            this.InactiveRadioButton.Text = "Inactive";
            this.InactiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // ActiveRadioButton
            // 
            this.ActiveRadioButton.AutoSize = true;
            this.ActiveRadioButton.Checked = true;
            this.ActiveRadioButton.Location = new System.Drawing.Point(6, 19);
            this.ActiveRadioButton.Name = "ActiveRadioButton";
            this.ActiveRadioButton.Size = new System.Drawing.Size(55, 17);
            this.ActiveRadioButton.TabIndex = 0;
            this.ActiveRadioButton.TabStop = true;
            this.ActiveRadioButton.Text = "Active";
            this.ActiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(179, 117);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBox.TabIndex = 24;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(179, 91);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Name:";
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 479);
            this.Controls.Add(this.genderGroupBox);
            this.Controls.Add(this.AddEmployeeButton);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "PopupForm";
            this.Text = "PopupForm";
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox genderGroupBox;
        private System.Windows.Forms.RadioButton FemaleRadioButton;
        private System.Windows.Forms.RadioButton MaleRadioButton;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.RadioButton InactiveRadioButton;
        private System.Windows.Forms.RadioButton ActiveRadioButton;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}