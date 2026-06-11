using System;
using System.Windows.Forms;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class AddStationForm : Form
    {
        public AddStationForm()
        {
            InitializeComponent();
        }
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtInn.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseService db = new DatabaseService();
            if (db.InsertStation(txtName.Text, txtInn.Text, txtAddress.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(db.LastError ?? "Не удалось добавить станцию.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}