using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using WinFormsApp1.Models;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Panel CreateEmployeeCard(string id, string station, string fullName, string position, string crew)
        {
            Panel panel = new Panel
            {
                Width = 700,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblFullName = new Label
            {
                Text = fullName,
                Location = new Point(5, 5),
                AutoSize = true
            };

            Label lblStation = new Label
            {
                Text = "Станция: " + station,
                Location = new Point(5, 25),
                AutoSize = true
            };

            Label lblPosition = new Label
            {
                Text = "Должность: " + position,
                Location = new Point(5, 45),
                AutoSize = true
            };

            Label lblCrew = new Label
            {
                Text = "Бригада: " + crew,
                Location = new Point(5, 65),
                AutoSize = true
            };

            panel.Controls.Add(lblFullName);
            panel.Controls.Add(lblStation);
            panel.Controls.Add(lblPosition);
            panel.Controls.Add(lblCrew);
            return panel;
        }

        private Panel CreateStationCard(string id, string name, string Inn, string Adress)
        {
            Panel panel = new Panel
            {
                Width = 800,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblName = new Label
            {
                Text = name,
                Location = new Point(5, 5),
                AutoSize = true
            };

            Label lblInn = new Label
            {
                Text = Inn,
                Location = new Point(5, 25),
                AutoSize = true
            };

            Label lblAdr = new Label
            {
                Text = Adress,
                Location = new Point(5, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblName);
            panel.Controls.Add(lblInn);
            panel.Controls.Add(lblAdr);
            return panel;
        }

        private Panel CreateRouteCard(
    string id,
    string ownerStationName,
    string trainName,
    string departureStationName,
    string arrivalStationName,
    string departureTime,
    string arrivalTime,
    string crewName)
        {
            Panel panel = new Panel
            {
                Width = 800,
                Height = 140,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Заголовок: поезд + время отправления/прибытия
            Label lblTitle = new Label
            {
                Text = $"🚆 {trainName} | {departureTime} → {arrivalTime}",
                Location = new Point(5, 5),
                AutoSize = true
            };

            // Станция отправления
            Label lblDeparture = new Label
            {
                Text = "Отправление: " + departureStationName,
                Location = new Point(5, 30),
                AutoSize = true
            };

            // Станция прибытия
            Label lblArrival = new Label
            {
                Text = "Прибытие: " + arrivalStationName,
                Location = new Point(5, 50),
                AutoSize = true
            };

            // Владелец маршрута
            Label lblOwner = new Label
            {
                Text = "Владелец: " + ownerStationName,
                Location = new Point(5, 70),
                AutoSize = true
            };

            // Бригада
            Label lblCrew = new Label
            {
                Text = "Бригада: " + crewName,
                Location = new Point(5, 90),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDeparture);
            panel.Controls.Add(lblArrival);
            panel.Controls.Add(lblOwner);
            panel.Controls.Add(lblCrew);

            return panel;
        }
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
            DatabaseService db = new DatabaseService();
            List<EmployeeModel> employees = db.GetEmployeeModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var emp in employees)
            {
                Panel card = CreateEmployeeCard(
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
            DatabaseService db = new DatabaseService();
            List<StationModel> stations = db.GetStationModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var station in stations)
            {
                Panel card = CreateStationCard(
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
            DatabaseService db = new DatabaseService();
            List<RouteModel> routes = db.GetRouteModels();
            flowLayoutPanel1.Controls.Clear();
            foreach (var route in routes)
            {
                Panel card = CreateRouteCard(
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
    }
}
