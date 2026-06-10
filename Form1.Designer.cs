namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            Employees = new Button();
            Stations = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(256, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 350);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // Employees
            // 
            Employees.AutoSize = true;
            Employees.Location = new Point(123, 434);
            Employees.Name = "Employees";
            Employees.Size = new Size(120, 35);
            Employees.TabIndex = 2;
            Employees.Text = "Сотрудники";
            Employees.UseVisualStyleBackColor = true;
            Employees.Click += Employees_Click;
            // 
            // Stations
            // 
            Stations.AutoSize = true;
            Stations.Location = new Point(301, 435);
            Stations.Name = "Stations";
            Stations.Size = new Size(112, 35);
            Stations.TabIndex = 3;
            Stations.Text = "Станции";
            Stations.UseVisualStyleBackColor = true;
            Stations.Click += Stations_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 777);
            Controls.Add(Stations);
            Controls.Add(Employees);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Employees;
        private Button Stations;
    }
}
