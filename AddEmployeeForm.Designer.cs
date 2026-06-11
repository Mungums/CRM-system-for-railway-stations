namespace WinFormsApp1
{
    partial class AddEmployeeForm
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
            cmbStation = new ComboBox();
            txtFullName = new TextBox();
            cmbPosition = new ComboBox();
            cmbCrew = new ComboBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbStation
            // 
            cmbStation.FormattingEnabled = true;
            cmbStation.Location = new Point(41, 84);
            cmbStation.Name = "cmbStation";
            cmbStation.Size = new Size(271, 33);
            cmbStation.TabIndex = 0;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(41, 33);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "ФИО";
            txtFullName.Size = new Size(271, 31);
            txtFullName.TabIndex = 1;
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(41, 137);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(271, 33);
            cmbPosition.TabIndex = 2;
            // 
            // cmbCrew
            // 
            cmbCrew.FormattingEnabled = true;
            cmbCrew.Location = new Point(41, 192);
            cmbCrew.Name = "cmbCrew";
            cmbCrew.Size = new Size(271, 33);
            cmbCrew.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(41, 253);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 4;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(200, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 327);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cmbCrew);
            Controls.Add(cmbPosition);
            Controls.Add(txtFullName);
            Controls.Add(cmbStation);
            Name = "AddEmployeeForm";
            Text = "AddEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStation;
        private TextBox txtFullName;
        private ComboBox cmbPosition;
        private ComboBox cmbCrew;
        private Button btnOk;
        private Button btnCancel;
    }
}