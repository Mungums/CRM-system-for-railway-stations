using System;
using System.Windows.Forms;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class AddEmployeeForm : Form
    {
        private DatabaseService db;

        public AddEmployeeForm()
        {
            InitializeComponent();
            db = new DatabaseService();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            cmbStation.DataSource = db.GetStationsList();
            cmbStation.DisplayMember = "Value";
            cmbStation.ValueMember = "Key";

            cmbPosition.DataSource = db.GetPositionsList();
            cmbPosition.DisplayMember = "Value";
            cmbPosition.ValueMember = "Key";

            cmbCrew.DataSource = db.GetCrewsList();
            cmbCrew.DisplayMember = "Value";
            cmbCrew.ValueMember = "Key";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStation.SelectedValue == null || cmbPosition.SelectedValue == null || cmbCrew.SelectedValue == null)
            {
                MessageBox.Show("Выберите станцию, должность и бригаду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int stationId = (int)cmbStation.SelectedValue;
            int positionId = (int)cmbPosition.SelectedValue;
            int crewId = (int)cmbCrew.SelectedValue;

            if (db.InsertEmployee(stationId, txtFullName.Text, positionId, crewId))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(db.LastError ?? "Не удалось добавить сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}