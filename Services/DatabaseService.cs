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
    }
}
