using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class CardRender
    {
        public static Panel CreateEmployeeCard(string id, string station, string fullName, string position, string crew)
        {
            Panel panel = new Panel
            {
                Width = 700,
                Height = 140,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblId = new Label
            {
                Text = "Id: " + id,
                Location = new Point(5, 85),
                AutoSize = true
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
            panel.Controls.Add(lblId);
            return panel;
        }

        public static Panel CreateStationCard(string id, string name, string inn, string address)
        {
            Panel panel = new Panel
            {
                Width = 800,
                Height = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblId = new Label
            {
                Text = "Id: " + id,
                Location = new Point(5, 65),
                AutoSize = true
            };
            Label lblName = new Label
            {
                Text = name,
                Location = new Point(5, 5),
                AutoSize = true
            };
            Label lblInn = new Label
            {
                Text = "ИНН: " + inn,
                Location = new Point(5, 25),
                AutoSize = true
            };
            Label lblAdr = new Label
            {
                Text = "Адрес: " + address,
                Location = new Point(5, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblName);
            panel.Controls.Add(lblInn);
            panel.Controls.Add(lblAdr);
            panel.Controls.Add(lblId);
            return panel;
        }

        public static Panel CreateRouteCard(
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
                Height = 160,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            Label lblTitle = new Label
            {
                Text = $"🚆 {trainName} | {departureTime} → {arrivalTime}",
                Location = new Point(5, 5),
                AutoSize = true
            };
            Label lblDeparture = new Label
            {
                Text = "Отправление: " + departureStationName,
                Location = new Point(5, 30),
                AutoSize = true
            };
            Label lblArrival = new Label
            {
                Text = "Прибытие: " + arrivalStationName,
                Location = new Point(5, 50),
                AutoSize = true
            };
            Label lblOwner = new Label
            {
                Text = "Владелец: " + ownerStationName,
                Location = new Point(5, 70),
                AutoSize = true
            };
            Label lblCrew = new Label
            {
                Text = "Бригада: " + crewName,
                Location = new Point(5, 90),
                AutoSize = true
            };
            Label lblId = new Label
            {
                Text = "Id: " + id,
                Location = new Point(5, 120),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblDeparture);
            panel.Controls.Add(lblArrival);
            panel.Controls.Add(lblOwner);
            panel.Controls.Add(lblCrew);
            panel.Controls.Add(lblId);
            return panel;
        }
    }
}
