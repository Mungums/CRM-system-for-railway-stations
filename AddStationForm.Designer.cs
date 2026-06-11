namespace WinFormsApp1
{
    partial class AddStationForm
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
            txtName = new TextBox();
            txtInn = new TextBox();
            txtAddress = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(41, 12);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Название станции";
            txtName.Size = new Size(287, 31);
            txtName.TabIndex = 0;
            // 
            // txtInn
            // 
            txtInn.Location = new Point(41, 63);
            txtInn.Name = "txtInn";
            txtInn.PlaceholderText = "ИНН";
            txtInn.Size = new Size(287, 31);
            txtInn.TabIndex = 1;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(41, 111);
            txtAddress.Name = "txtAddress";
            txtAddress.PlaceholderText = "Адрес";
            txtAddress.Size = new Size(287, 31);
            txtAddress.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(216, 195);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(41, 195);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 4;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // AddStationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 266);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(txtAddress);
            Controls.Add(txtInn);
            Controls.Add(txtName);
            Name = "AddStationForm";
            Text = "AddStationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtInn;
        private TextBox txtAddress;
        private Button btnCancel;
        private Button btnOk;
    }
}