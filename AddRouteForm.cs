using System;
using System.Windows.Forms;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class AddRouteForm : Form
    {
        private DatabaseService db;

        public AddRouteForm()
        {
            InitializeComponent();
            db = new DatabaseService();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cmbOwnerStation.DataSource = db.GetStationsList();
            cmbOwnerStation.DisplayMember = "Value";
            cmbOwnerStation.ValueMember = "Key";

            cmbTrain.DataSource = db.GetTrainsList();
            cmbTrain.DisplayMember = "Value";
            cmbTrain.ValueMember = "Key";

            cmbDepartureStation.DataSource = db.GetStationsList();
            cmbDepartureStation.DisplayMember = "Value";
            cmbDepartureStation.ValueMember = "Key";

            cmbArrivalStation.DataSource = db.GetStationsList();
            cmbArrivalStation.DisplayMember = "Value";
            cmbArrivalStation.ValueMember = "Key";

            cmbCrew.DataSource = db.GetCrewsList();
            cmbCrew.DisplayMember = "Value";
            cmbCrew.ValueMember = "Key";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmbOwnerStation.SelectedValue == null || cmbTrain.SelectedValue == null ||
                cmbDepartureStation.SelectedValue == null || cmbArrivalStation.SelectedValue == null ||
                cmbCrew.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля выбора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ownerStationId = (int)cmbOwnerStation.SelectedValue;
            int trainId = (int)cmbTrain.SelectedValue;
            int departureStationId = (int)cmbDepartureStation.SelectedValue;
            int arrivalStationId = (int)cmbArrivalStation.SelectedValue;
            int crewId = (int)cmbCrew.SelectedValue;
            TimeSpan departureTime = dtpDepartureTime.Value.TimeOfDay;
            TimeSpan arrivalTime = dtpArrivalTime.Value.TimeOfDay;

            if (db.InsertRoute(ownerStationId, trainId, departureStationId, arrivalStationId,
                               departureTime, arrivalTime, crewId))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(db.LastError ?? "Не удалось добавить маршрут.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}