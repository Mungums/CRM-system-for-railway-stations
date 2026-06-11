namespace WinFormsApp1
{
    partial class AddRouteForm
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
            cmbOwnerStation = new ComboBox();
            cmbTrain = new ComboBox();
            cmbDepartureStation = new ComboBox();
            cmbCrew = new ComboBox();
            cmbArrivalStation = new ComboBox();
            dtpArrivalTime = new DateTimePicker();
            dtpDepartureTime = new DateTimePicker();
            btnCancel = new Button();
            btnOk = new Button();
            SuspendLayout();
            // 
            // cmbOwnerStation
            // 
            cmbOwnerStation.FormattingEnabled = true;
            cmbOwnerStation.Location = new Point(40, 23);
            cmbOwnerStation.Name = "cmbOwnerStation";
            cmbOwnerStation.Size = new Size(182, 33);
            cmbOwnerStation.TabIndex = 0;
            // 
            // cmbTrain
            // 
            cmbTrain.FormattingEnabled = true;
            cmbTrain.Location = new Point(40, 87);
            cmbTrain.Name = "cmbTrain";
            cmbTrain.Size = new Size(182, 33);
            cmbTrain.TabIndex = 1;
            // 
            // cmbDepartureStation
            // 
            cmbDepartureStation.FormattingEnabled = true;
            cmbDepartureStation.Location = new Point(285, 23);
            cmbDepartureStation.Name = "cmbDepartureStation";
            cmbDepartureStation.Size = new Size(182, 33);
            cmbDepartureStation.TabIndex = 2;
            // 
            // cmbCrew
            // 
            cmbCrew.FormattingEnabled = true;
            cmbCrew.Location = new Point(534, 23);
            cmbCrew.Name = "cmbCrew";
            cmbCrew.Size = new Size(182, 33);
            cmbCrew.TabIndex = 3;
            // 
            // cmbArrivalStation
            // 
            cmbArrivalStation.FormattingEnabled = true;
            cmbArrivalStation.Location = new Point(285, 87);
            cmbArrivalStation.Name = "cmbArrivalStation";
            cmbArrivalStation.Size = new Size(182, 33);
            cmbArrivalStation.TabIndex = 4;
            // 
            // dtpArrivalTime
            // 
            dtpArrivalTime.Format = DateTimePickerFormat.Time;
            dtpArrivalTime.Location = new Point(416, 173);
            dtpArrivalTime.Name = "dtpArrivalTime";
            dtpArrivalTime.Size = new Size(300, 31);
            dtpArrivalTime.TabIndex = 5;
            // 
            // dtpDepartureTime
            // 
            dtpDepartureTime.Format = DateTimePickerFormat.Time;
            dtpDepartureTime.Location = new Point(40, 173);
            dtpDepartureTime.Name = "dtpDepartureTime";
            dtpDepartureTime.Size = new Size(300, 31);
            dtpDepartureTime.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(534, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(130, 290);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(112, 34);
            btnOk.TabIndex = 8;
            btnOk.Text = "Добавить";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // AddRouteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(dtpDepartureTime);
            Controls.Add(dtpArrivalTime);
            Controls.Add(cmbArrivalStation);
            Controls.Add(cmbCrew);
            Controls.Add(cmbDepartureStation);
            Controls.Add(cmbTrain);
            Controls.Add(cmbOwnerStation);
            Name = "AddRouteForm";
            Text = "AddRouteForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbOwnerStation;
        private ComboBox cmbTrain;
        private ComboBox cmbDepartureStation;
        private ComboBox cmbCrew;
        private ComboBox cmbArrivalStation;
        private DateTimePicker dtpArrivalTime;
        private DateTimePicker dtpDepartureTime;
        private Button btnCancel;
        private Button btnOk;
    }
}