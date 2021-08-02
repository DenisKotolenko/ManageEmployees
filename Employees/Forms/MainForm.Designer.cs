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
            this.ViewTabPage = new System.Windows.Forms.TabPage();
            this.ClearButton = new System.Windows.Forms.Button();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.BackPageButton = new System.Windows.Forms.Button();
            this.CurrentPageLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GenderSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.FemaleGenderSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.MaleGenderSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.StatusSearchGroupBox = new System.Windows.Forms.GroupBox();
            this.InactiveStatusSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.ActiveStatusSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.ViewEmployeeDataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.IdSearchTextBox = new System.Windows.Forms.TextBox();
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
            this.ViewTabPage.SuspendLayout();
            this.GenderSearchGroupBox.SuspendLayout();
            this.StatusSearchGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewEmployeeDataGridView)).BeginInit();
            this.AddTabPage.SuspendLayout();
            this.genderGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(840, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Made by Denis Kotolenko";
            // 
            // ViewTabPage
            // 
            this.ViewTabPage.Controls.Add(this.ClearButton);
            this.ViewTabPage.Controls.Add(this.NextPageButton);
            this.ViewTabPage.Controls.Add(this.BackPageButton);
            this.ViewTabPage.Controls.Add(this.CurrentPageLabel);
            this.ViewTabPage.Controls.Add(this.label5);
            this.ViewTabPage.Controls.Add(this.GenderSearchGroupBox);
            this.ViewTabPage.Controls.Add(this.StatusSearchGroupBox);
            this.ViewTabPage.Controls.Add(this.ViewEmployeeDataGridView);
            this.ViewTabPage.Controls.Add(this.SearchButton);
            this.ViewTabPage.Controls.Add(this.label6);
            this.ViewTabPage.Controls.Add(this.IdSearchTextBox);
            this.ViewTabPage.Controls.Add(this.NameSearchTextBox);
            this.ViewTabPage.Controls.Add(this.label4);
            this.ViewTabPage.Controls.Add(this.ExportToCsvButton);
            this.ViewTabPage.Location = new System.Drawing.Point(4, 24);
            this.ViewTabPage.Name = "ViewTabPage";
            this.ViewTabPage.Size = new System.Drawing.Size(1059, 453);
            this.ViewTabPage.TabIndex = 3;
            this.ViewTabPage.Text = "View";
            this.ViewTabPage.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(6, 182);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(63, 39);
            this.ClearButton.TabIndex = 27;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Location = new System.Drawing.Point(941, 412);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(75, 23);
            this.NextPageButton.TabIndex = 26;
            this.NextPageButton.Text = "Next Page";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // BackPageButton
            // 
            this.BackPageButton.Location = new System.Drawing.Point(167, 412);
            this.BackPageButton.Name = "BackPageButton";
            this.BackPageButton.Size = new System.Drawing.Size(75, 23);
            this.BackPageButton.TabIndex = 25;
            this.BackPageButton.Text = "Back Page";
            this.BackPageButton.UseVisualStyleBackColor = true;
            this.BackPageButton.Click += new System.EventHandler(this.BackPageButton_Click);
            // 
            // CurrentPageLabel
            // 
            this.CurrentPageLabel.AutoSize = true;
            this.CurrentPageLabel.Location = new System.Drawing.Point(618, 417);
            this.CurrentPageLabel.Name = "CurrentPageLabel";
            this.CurrentPageLabel.Size = new System.Drawing.Size(0, 16);
            this.CurrentPageLabel.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(533, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Current Page:";
            // 
            // GenderSearchGroupBox
            // 
            this.GenderSearchGroupBox.Controls.Add(this.FemaleGenderSearchRadioButton);
            this.GenderSearchGroupBox.Controls.Add(this.MaleGenderSearchRadioButton);
            this.GenderSearchGroupBox.Location = new System.Drawing.Point(6, 66);
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
            this.FemaleGenderSearchRadioButton.Size = new System.Drawing.Size(72, 20);
            this.FemaleGenderSearchRadioButton.TabIndex = 1;
            this.FemaleGenderSearchRadioButton.Text = "Female";
            this.FemaleGenderSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaleGenderSearchRadioButton
            // 
            this.MaleGenderSearchRadioButton.AutoSize = true;
            this.MaleGenderSearchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.MaleGenderSearchRadioButton.Name = "MaleGenderSearchRadioButton";
            this.MaleGenderSearchRadioButton.Size = new System.Drawing.Size(56, 20);
            this.MaleGenderSearchRadioButton.TabIndex = 0;
            this.MaleGenderSearchRadioButton.Text = "Male";
            this.MaleGenderSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // StatusSearchGroupBox
            // 
            this.StatusSearchGroupBox.Controls.Add(this.InactiveStatusSearchRadioButton);
            this.StatusSearchGroupBox.Controls.Add(this.ActiveStatusSearchRadioButton);
            this.StatusSearchGroupBox.Location = new System.Drawing.Point(6, 121);
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
            this.InactiveStatusSearchRadioButton.Size = new System.Drawing.Size(72, 20);
            this.InactiveStatusSearchRadioButton.TabIndex = 1;
            this.InactiveStatusSearchRadioButton.Text = "Inactive";
            this.InactiveStatusSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // ActiveStatusSearchRadioButton
            // 
            this.ActiveStatusSearchRadioButton.AutoSize = true;
            this.ActiveStatusSearchRadioButton.Location = new System.Drawing.Point(6, 19);
            this.ActiveStatusSearchRadioButton.Name = "ActiveStatusSearchRadioButton";
            this.ActiveStatusSearchRadioButton.Size = new System.Drawing.Size(63, 20);
            this.ActiveStatusSearchRadioButton.TabIndex = 0;
            this.ActiveStatusSearchRadioButton.Text = "Active";
            this.ActiveStatusSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // ViewEmployeeDataGridView
            // 
            this.ViewEmployeeDataGridView.AllowUserToAddRows = false;
            this.ViewEmployeeDataGridView.AllowUserToDeleteRows = false;
            this.ViewEmployeeDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ViewEmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewEmployeeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.NameColumn,
            this.EmailColumn,
            this.GenderColumn,
            this.StatusColumn});
            this.ViewEmployeeDataGridView.Location = new System.Drawing.Point(167, 15);
            this.ViewEmployeeDataGridView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ViewEmployeeDataGridView.Name = "ViewEmployeeDataGridView";
            this.ViewEmployeeDataGridView.ReadOnly = true;
            this.ViewEmployeeDataGridView.RowHeadersWidth = 10;
            this.ViewEmployeeDataGridView.Size = new System.Drawing.Size(849, 384);
            this.ViewEmployeeDataGridView.TabIndex = 10;
            this.ViewEmployeeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ViewEmployeeDataGridView_CellContentClick);
            // 
            // IdColumn
            // 
            this.IdColumn.HeaderText = "ID";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 50;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 200;
            // 
            // EmailColumn
            // 
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 200;
            // 
            // GenderColumn
            // 
            this.GenderColumn.HeaderText = "Gender";
            this.GenderColumn.Name = "GenderColumn";
            this.GenderColumn.ReadOnly = true;
            this.GenderColumn.Width = 80;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 80;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(89, 182);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(67, 39);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.ViewTabSearchButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "ID:";
            // 
            // IdSearchTextBox
            // 
            this.IdSearchTextBox.Location = new System.Drawing.Point(49, 12);
            this.IdSearchTextBox.Name = "IdSearchTextBox";
            this.IdSearchTextBox.Size = new System.Drawing.Size(107, 22);
            this.IdSearchTextBox.TabIndex = 6;
            // 
            // NameSearchTextBox
            // 
            this.NameSearchTextBox.Location = new System.Drawing.Point(49, 38);
            this.NameSearchTextBox.Name = "NameSearchTextBox";
            this.NameSearchTextBox.Size = new System.Drawing.Size(107, 22);
            this.NameSearchTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // ExportToCsvButton
            // 
            this.ExportToCsvButton.Location = new System.Drawing.Point(6, 292);
            this.ExportToCsvButton.Name = "ExportToCsvButton";
            this.ExportToCsvButton.Size = new System.Drawing.Size(150, 39);
            this.ExportToCsvButton.TabIndex = 0;
            this.ExportToCsvButton.Text = "Export Grid To CSV";
            this.ExportToCsvButton.UseVisualStyleBackColor = true;
            this.ExportToCsvButton.Click += new System.EventHandler(this.ExportToCsvButton_Click);
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
            this.AddTabPage.Location = new System.Drawing.Point(4, 24);
            this.AddTabPage.Name = "AddTabPage";
            this.AddTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddTabPage.Size = new System.Drawing.Size(1059, 453);
            this.AddTabPage.TabIndex = 0;
            this.AddTabPage.Text = "Add";
            this.AddTabPage.UseVisualStyleBackColor = true;
            // 
            // genderGroupBox
            // 
            this.genderGroupBox.Controls.Add(this.FemaleRadioButton);
            this.genderGroupBox.Controls.Add(this.MaleRadioButton);
            this.genderGroupBox.Location = new System.Drawing.Point(429, 166);
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
            this.FemaleRadioButton.Size = new System.Drawing.Size(72, 20);
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
            this.MaleRadioButton.Size = new System.Drawing.Size(56, 20);
            this.MaleRadioButton.TabIndex = 0;
            this.MaleRadioButton.TabStop = true;
            this.MaleRadioButton.Text = "Male";
            this.MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(429, 314);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(150, 48);
            this.AddEmployeeButton.TabIndex = 20;
            this.AddEmployeeButton.Text = "Add Employee";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click_1);
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.InactiveRadioButton);
            this.statusGroupBox.Controls.Add(this.ActiveRadioButton);
            this.statusGroupBox.Location = new System.Drawing.Point(429, 236);
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
            this.InactiveRadioButton.Size = new System.Drawing.Size(72, 20);
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
            this.ActiveRadioButton.Size = new System.Drawing.Size(63, 20);
            this.ActiveRadioButton.TabIndex = 0;
            this.ActiveRadioButton.TabStop = true;
            this.ActiveRadioButton.Text = "Active";
            this.ActiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(479, 124);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 22);
            this.EmailTextBox.TabIndex = 17;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(479, 98);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 22);
            this.NameTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddTabPage);
            this.tabControl1.Controls.Add(this.ViewTabPage);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 20);
            this.tabControl1.Location = new System.Drawing.Point(2, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 481);
            this.tabControl1.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 518);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ViewTabPage.ResumeLayout(false);
            this.ViewTabPage.PerformLayout();
            this.GenderSearchGroupBox.ResumeLayout(false);
            this.GenderSearchGroupBox.PerformLayout();
            this.StatusSearchGroupBox.ResumeLayout(false);
            this.StatusSearchGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewEmployeeDataGridView)).EndInit();
            this.AddTabPage.ResumeLayout(false);
            this.AddTabPage.PerformLayout();
            this.genderGroupBox.ResumeLayout(false);
            this.genderGroupBox.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox GenderSearchGroupBox;
        private System.Windows.Forms.RadioButton FemaleGenderSearchRadioButton;
        private System.Windows.Forms.RadioButton MaleGenderSearchRadioButton;
        private System.Windows.Forms.GroupBox StatusSearchGroupBox;
        private System.Windows.Forms.RadioButton InactiveStatusSearchRadioButton;
        private System.Windows.Forms.RadioButton ActiveStatusSearchRadioButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button BackPageButton;
        private System.Windows.Forms.Label CurrentPageLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
    }
}