namespace Employees.Forms
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.Button();
            this.ViewTabPage = new System.Windows.Forms.TabPage();
            this.NameSearchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ExportToCsvButton = new System.Windows.Forms.Button();
            this.AddTabPage = new System.Windows.Forms.TabPage();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.IdSearchTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ViewEmployeeDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.FemaleGenderSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleGenderSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.StatusSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.InactiveStatusSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.ActiveStatusSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.ViewTabPage.SuspendLayout();
            this.AddTabPage.SuspendLayout();
            this.genderGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewEmployeeDataGridView)).BeginInit();
            this.GenderSearchGroupBox.SuspendLayout();
            this.StatusSearchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Made by Denis Kotolenko";
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(510, 1);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(40, 28);
            this.InfoButton.TabIndex = 14;
            this.InfoButton.Text = "Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            // 
            // ViewTabPage
            // 
            this.ViewTabPage.Controls.Add(this.GenderSearchGroupBox);
            this.ViewTabPage.Controls.Add(this.StatusSearchGroupBox);
            this.ViewTabPage.Controls.Add(this.ViewEmployeeDataGridView);
            this.ViewTabPage.Controls.Add(this.SearchButton);
            this.ViewTabPage.Controls.Add(this.label6);
            this.ViewTabPage.Controls.Add(this.IdSearchTextBox);
            this.ViewTabPage.Controls.Add(this.NameSearchTextBox);
            this.ViewTabPage.Controls.Add(this.label4);
            this.ViewTabPage.Controls.Add(this.ExportToCsvButton);
            this.ViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.ViewTabPage.Name = "ViewTabPage";
            this.ViewTabPage.Size = new System.Drawing.Size(1049, 523);
            this.ViewTabPage.TabIndex = 3;
            this.ViewTabPage.Text = "View";
            this.ViewTabPage.UseVisualStyleBackColor = true;
            // 
            // NameSearchTextBox
            // 
            this.NameSearchTextBox.Location = new System.Drawing.Point(49, 38);
            this.NameSearchTextBox.Name = "NameSearchTextBox";
            this.NameSearchTextBox.Size = new System.Drawing.Size(107, 20);
            this.NameSearchTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // ExportToCsvButton
            // 
            this.ExportToCsvButton.Location = new System.Drawing.Point(61, 304);
            this.ExportToCsvButton.Name = "ExportToCsvButton";
            this.ExportToCsvButton.Size = new System.Drawing.Size(100, 39);
            this.ExportToCsvButton.TabIndex = 0;
            this.ExportToCsvButton.Text = "Export To CSV";
            this.ExportToCsvButton.UseVisualStyleBackColor = true;
            // 
            // AddTabPage
            // 
            this.AddTabPage.Controls.Add(this.genderGroupBox);
            this.AddTabPage.Controls.Add(this.AddEmployeeButton);
            this.AddTabPage.Controls.Add(this.statusGroupBox);
            this.AddTabPage.Controls.Add(this.EmailTextBox);
            this.AddTabPage.Controls.Add(this.NameTextBox);
            this.AddTabPage.Controls.Add(this.label2);
            this.AddTabPage.Controls.Add(this.label3);
            this.AddTabPage.Location = new System.Drawing.Point(4, 22);
            this.AddTabPage.Name = "AddTabPage";
            this.AddTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddTabPage.Size = new System.Drawing.Size(1049, 523);
            this.AddTabPage.TabIndex = 0;
            this.AddTabPage.Text = "Add";
            this.AddTabPage.UseVisualStyleBackColor = true;
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.Controls.Add(this.FemaleRadioButton);
            this.genderGroupBox.Controls.Add(this.MaleRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(168, 134);
            this.genderGroupBox.Name = "genderGroupBox";
            this.genderGroupBox.Size = new System.Drawing.Size(150, 49);
            this.genderGroupBox.TabIndex = 19;
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
            this.AddEmployeeButton.Location = new System.Drawing.Point(340, 340);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(148, 48);
            this.AddEmployeeButton.TabIndex = 20;
            this.AddEmployeeButton.Text = "Add Employee";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click_1);
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.InactiveRadioButton);
            this.statusGroupBox.Controls.Add(this.ActiveRadioButton);
            this.statusGroupBox.Location = new System.Drawing.Point(168, 189);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(150, 48);
            this.statusGroupBox.TabIndex = 18;
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
            this.EmailTextBox.Location = new System.Drawing.Point(218, 108);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBox.TabIndex = 17;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(218, 82);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddTabPage);
            this.tabControl1.Controls.Add(this.ViewTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1057, 549);
            this.tabControl1.TabIndex = 16;
            // 
            // IdSearchTextBox
            // 
            this.IdSearchTextBox.Location = new System.Drawing.Point(49, 12);
            this.IdSearchTextBox.Name = "IdSearchTextBox";
            this.IdSearchTextBox.Size = new System.Drawing.Size(107, 20);
            this.IdSearchTextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Id:";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(61, 173);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 39);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.ViewTabSearchButton_Click);
            // 
            // ViewEmployeeDataGridView
            // 
            this.ViewEmployeeDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ViewEmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewEmployeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Email,
            this.Gender,
            this.Status,
            this.Created,
            this.Updated,
            this.Edit,
            this.Delete});
            this.ViewEmployeeDataGridView.Location = new System.Drawing.Point(167, 15);
            this.ViewEmployeeDataGridView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ViewEmployeeDataGridView.Name = "ViewEmployeeDataGridView";
            this.ViewEmployeeDataGridView.RowHeadersWidth = 10;
            this.ViewEmployeeDataGridView.Size = new System.Drawing.Size(663, 384);
            this.ViewEmployeeDataGridView.TabIndex = 10;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Width = 50;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 50;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 150;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 50;
            // 
            // Created
            // 
            this.Created.HeaderText = "Created";
            this.Created.Name = "Created";
            this.Created.Width = 50;
            // 
            // Updated
            // 
            this.Updated.HeaderText = "Updated";
            this.Updated.Name = "Updated";
            this.Updated.Width = 50;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // GenderSearchGroupBox
            // 
            this.GenderSearchGroupBox.Controls.Add(this.FemaleGenderSearchRadioButton);
            this.GenderSearchGroupBox.Controls.Add(this.MaleGenderSearchRadioButton);
            this.GenderSearchGroupBox.Location = new System.Drawing.Point(6, 64);
            this.GenderSearchGroupBox.Name = "GenderSearchGroupBox";
            this.GenderSearchGroupBox.Size = new System.Drawing.Size(150, 49);
            this.GenderSearchGroupBox.TabIndex = 21;
            this.GenderSearchGroupBox.TabStop = false;
            this.GenderSearchGroupBox.Text = "Gender";
            // 
            // FemaleGenderSearchRadioButton
            // 
            this.FemaleGenderSearchRadioButton.AutoSize = true;
            this.FemaleGenderSearchRadioButton.Location = new System.Drawing.Point(67, 19);
            this.FemaleGenderSearchRadioButton.Name = "FemaleGenderSearchRadioButton";
            this.FemaleGenderSearchRadioButton.Size = new System.Drawing.Size(59, 17);
            this.FemaleGenderSearchRadioButton.TabIndex = 1;
            this.FemaleGenderSearchRadioButton.Text = "Female";
            this.FemaleGenderSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleGenderSearchRadioButton
            // 
            this.MaleGenderSearchRadioButton.AutoSize = true;
            this.MaleGenderSearchRadioButton.Checked = true;
            this.MaleGenderSearchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.MaleGenderSearchRadioButton.Name = "MaleGenderSearchRadioButton";
            this.MaleGenderSearchRadioButton.Size = new System.Drawing.Size(48, 17);
            this.MaleGenderSearchRadioButton.TabIndex = 0;
            this.MaleGenderSearchRadioButton.TabStop = true;
            this.MaleGenderSearchRadioButton.Text = "Male";
            this.MaleGenderSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // StatusSearchGroupBox
            // 
            this.StatusSearchGroupBox.Controls.Add(this.InactiveStatusSearchRadioButton);
            this.StatusSearchGroupBox.Controls.Add(this.ActiveStatusSearchRadioButton);
            this.StatusSearchGroupBox.Location = new System.Drawing.Point(6, 119);
            this.StatusSearchGroupBox.Name = "StatusSearchGroupBox";
            this.StatusSearchGroupBox.Size = new System.Drawing.Size(150, 48);
            this.StatusSearchGroupBox.TabIndex = 20;
            this.StatusSearchGroupBox.TabStop = false;
            this.StatusSearchGroupBox.Text = "Status";
            // 
            // InactiveStatusSearchRadioButton
            // 
            this.InactiveStatusSearchRadioButton.AutoSize = true;
            this.InactiveStatusSearchRadioButton.Location = new System.Drawing.Point(67, 19);
            this.InactiveStatusSearchRadioButton.Name = "InactiveStatusSearchRadioButton";
            this.InactiveStatusSearchRadioButton.Size = new System.Drawing.Size(63, 17);
            this.InactiveStatusSearchRadioButton.TabIndex = 1;
            this.InactiveStatusSearchRadioButton.Text = "Inactive";
            this.InactiveStatusSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // ActiveStatusSearchRadioButton
            // 
            this.ActiveStatusSearchRadioButton.AutoSize = true;
            this.ActiveStatusSearchRadioButton.Checked = true;
            this.ActiveStatusSearchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.ActiveStatusSearchRadioButton.Name = "ActiveStatusSearchRadioButton";
            this.ActiveStatusSearchRadioButton.Size = new System.Drawing.Size(55, 17);
            this.ActiveStatusSearchRadioButton.TabIndex = 0;
            this.ActiveStatusSearchRadioButton.TabStop = true;
            this.ActiveStatusSearchRadioButton.Text = "Active";
            this.ActiveStatusSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 584);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoButton);
            this.Text = "MainForm";
            this.ViewTabPage.ResumeLayout(false);
            this.ViewTabPage.PerformLayout();
            this.AddTabPage.ResumeLayout(false);
            this.AddTabPage.PerformLayout();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewEmployeeDataGridView)).EndInit();
            this.GenderSearchGroupBox.ResumeLayout(false);
            this.GenderSearchGroupBox.PerformLayout();
            this.StatusSearchGroupBox.ResumeLayout(false);
            this.StatusSearchGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.TabPage ViewTabPage;
        private System.Windows.Forms.TabPage AddTabPage;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox NameSearchTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ExportToCsvButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IdSearchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView ViewEmployeeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn Updated;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delete;
        private System.Windows.Forms.GroupBox GenderSearchGroupBox;
        private System.Windows.Forms.RadioButton FemaleGenderSearchRadioButton;
        private System.Windows.Forms.RadioButton MaleGenderSearchRadioButton;
        private System.Windows.Forms.GroupBox StatusSearchGroupBox;
        private System.Windows.Forms.RadioButton InactiveStatusSearchRadioButton;
        private System.Windows.Forms.RadioButton ActiveStatusSearchRadioButton;
    }
}