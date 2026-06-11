using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using WinFormsApp1.Models;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentTable = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;   // элементы один под другим
            flowLayoutPanel1.WrapContents = false;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employees_Click(object sender, EventArgs e)
        {
            label1.Text = "Сотрудники";
            currentTable = "Employees";
            DatabaseService db = new DatabaseService();
            List<EmployeeModel> employees = db.GetEmployeeModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var emp in employees)
            {
                Panel card = CardRender.CreateEmployeeCard(
                    emp.Id.ToString(),
                    emp.StationName,
                    emp.FullName,
                    emp.PositionName,
                    emp.CrewName
                );
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void Stations_Click(object sender, EventArgs e)
        {
            label1.Text = "Вокзалы";
            currentTable = "Stations";
            DatabaseService db = new DatabaseService();
            List<StationModel> stations = db.GetStationModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var station in stations)
            {
                Panel card = CardRender.CreateStationCard(
                    station.Id.ToString(),
                    station.Name,
                    station.Inn,
                    station.Adress
                );
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Routes_Click(object sender, EventArgs e)
        {
            label1.Text = "Маршруты";
            currentTable = "Routes";
            DatabaseService db = new DatabaseService();
            List<RouteModel> routes = db.GetRouteModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var route in routes)
            {
                Panel card = CardRender.CreateRouteCard(
                    route.Id,
                    route.OwnerStationName,
                    route.TrainName,
                    route.DepartureStationName,
                    route.ArrivalStationName,
                    route.DepartureTime,
                    route.ArrivalTime,
                    route.CrewName
                );
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string test = idForDelete.Text;

            if (string.IsNullOrWhiteSpace(test))
            {
                MessageBox.Show("Введите ID записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(test, out int id))
            {
                MessageBox.Show("ID должен быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseService db = new DatabaseService();
            string message = "";
            bool recordExists = false;

            switch (currentTable)
            {
                case "Employees":
                    var emp = db.GetEmployeeById(id);
                    if (emp != null)
                    {
                        message = $"Вы действительно хотите удалить сотрудника \"{emp.FullName}\"?";
                        recordExists = true;
                    }
                    break;
                case "Stations":
                    var station = db.GetStationById(id);
                    if (station != null)
                    {
                        message = $"Вы действительно хотите удалить станцию \"{station.Name}\"?";
                        recordExists = true;
                    }
                    break;
                case "Routes":
                    var route = db.GetRouteById(id);
                    if (route != null)
                    {
                        message = $"Удалить маршрут ID {route.Id}: поезд \"{route.TrainName}\", {route.DepartureStationName} → {route.ArrivalStationName}?";
                        recordExists = true;
                    }
                    break;
                default:
                    MessageBox.Show("Сначала выберите таблицу (нажмите Сотрудники, Вокзалы или Маршруты).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            if (!recordExists)
            {
                MessageBox.Show("Запись с таким ID не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(message, "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool deleted = false;
                switch (currentTable)
                {
                    case "Employees":
                        deleted = db.DeleteEmployee(id);
                        if (deleted) Employees_Click(sender, e); // обновляем список
                        break;
                    case "Stations":
                        deleted = db.DeleteStation(id);
                        if (deleted) Stations_Click(sender, e);
                        break;
                    case "Routes":
                        deleted = db.DeleteRoute(id);
                        if (deleted) Routes_Click(sender, e);
                        break;
                }

                if (deleted)
                {
                    MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idForDelete.Clear(); // очищаем поле
                }
                else
                {
                    string errorMsg = !string.IsNullOrEmpty(db.LastError) ? db.LastError : "Не удалось удалить запись.";
                    MessageBox.Show(errorMsg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddRouteForm form = new AddRouteForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Routes_Click(sender, e);
                }
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            using (AddEmployeeForm form = new AddEmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Employees_Click(sender, e);
                }
            }
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            using (AddStationForm form = new AddStationForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Stations_Click(sender, e); // обновить список станций
                }
            }
        }
    }
}
