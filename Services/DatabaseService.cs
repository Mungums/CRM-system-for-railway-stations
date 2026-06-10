using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    internal class DatabaseService
    {
        private string connectionString = "server=localhost;user=root;password=;database=CRMSystemForRailway;";

        public List<EmployeeModel> GetEmployeeModels()
        {
            var employees = new List<EmployeeModel>();
            string query = @"
                SELECT 
                    Personnel.Id,
                    Stations.Name AS StationName,
                    Personnel.FullName,
                    Positions.Name AS PositionName,
                    Crews.Name AS CrewName
                FROM Personnel
                LEFT JOIN Stations ON Personnel.StationId = Stations.Id
                LEFT JOIN Positions ON Personnel.PositionId = Positions.Id
                LEFT JOIN Crews ON Personnel.CrewId = Crews.Id;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new EmployeeModel
                    {
                        Id = reader["Id"]?.ToString(),
                        StationName = reader["StationName"]?.ToString(),
                        FullName = reader["FullName"]?.ToString(),
                        PositionName = reader["PositionName"]?.ToString(),
                        CrewName = reader["CrewName"]?.ToString()
                    });
                }
            }
            return employees;
        }

        public List<StationModel> GetStationModels()
        {
            var stations = new List<StationModel>();
            string query = @"
                SELECT
                    Id,
                    Name AS StationName,
                    Inn AS StationInn,
                    Address AS StationAdress
                FROM Stations;
            ";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    stations.Add(new StationModel
                    {
                        Id = reader["Id"]?.ToString(),
                        Name = reader["StationName"]?.ToString(),
                        Inn = reader["StationInn"]?.ToString(),
                        Adress = reader["StationAdress"]?.ToString()
                    });
                }
                return stations;
            }
        }

        public List<RouteModel> GetRouteModels()
        {
            var routes = new List<RouteModel>();
            string query = @"
        SELECT
            r.Id,
            own.Name AS OwnerStationName,
            t.Name AS TrainName,
            dep.Name AS DepartureStationName,
            arr.Name AS ArrivalStationName,
            r.DepartureTime,
            r.ArrivalTime,
            c.Name AS CrewName
        FROM Routes r
        LEFT JOIN Stations own ON r.OwnerStationId = own.Id
        LEFT JOIN Trains t ON r.TrainId = t.Id
        LEFT JOIN Stations dep ON r.DepartureStationId = dep.Id
        LEFT JOIN Stations arr ON r.ArrivalStationId = arr.Id
        LEFT JOIN Crews c ON r.CrewId = c.Id;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    routes.Add(new RouteModel
                    {
                        Id = reader["Id"]?.ToString(),
                        OwnerStationName = reader["OwnerStationName"]?.ToString(),
                        TrainName = reader["TrainName"]?.ToString(),
                        DepartureStationName = reader["DepartureStationName"]?.ToString(),
                        ArrivalStationName = reader["ArrivalStationName"]?.ToString(),
                        DepartureTime = reader["DepartureTime"]?.ToString(),
                        ArrivalTime = reader["ArrivalTime"]?.ToString(),
                        CrewName = reader["CrewName"]?.ToString()
                    });
                }
            }
            return routes;
        }
    }
}
