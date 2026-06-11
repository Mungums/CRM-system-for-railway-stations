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
        public string LastError { get; private set;}
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
        // Методы для поиска по ID и удаления

        public EmployeeModel GetEmployeeById(int id)
        {
            string query = "SELECT Id, FullName FROM Personnel WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new EmployeeModel
                        {
                            Id = reader["Id"].ToString(),
                            FullName = reader["FullName"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool DeleteEmployee(int id)
        {
            string query = "DELETE FROM Personnel WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public StationModel GetStationById(int id)
        {
            string query = "SELECT Id, Name FROM Stations WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new StationModel
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool DeleteStation(int id)
        {
            string query = "DELETE FROM Stations WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                try
                { 
                    return cmd.ExecuteNonQuery() > 0;
                } catch (MySqlException ex)
                {
                    LastError = "Невозможно удалить станцию: на нее ссылаются записи из других таблиц";
                    return false;
                }
            }
        }

        public RouteModel GetRouteById(int id)
        {
            string query = @"
        SELECT
            r.Id,
            t.Name AS TrainName,
            dep.Name AS DepartureStationName,
            arr.Name AS ArrivalStationName
        FROM Routes r
        LEFT JOIN Trains t ON r.TrainId = t.Id
        LEFT JOIN Stations dep ON r.DepartureStationId = dep.Id
        LEFT JOIN Stations arr ON r.ArrivalStationId = arr.Id
        WHERE r.Id = @id;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new RouteModel
                        {
                            Id = reader["Id"].ToString(),
                            TrainName = reader["TrainName"]?.ToString(),
                            DepartureStationName = reader["DepartureStationName"]?.ToString(),
                            ArrivalStationName = reader["ArrivalStationName"]?.ToString()
                        };
                    }
                }
            }
            return null;
        }

        public bool DeleteRoute(int id)
        {
            string query = "DELETE FROM Routes WHERE Id = @id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                try
                { 
                    return cmd.ExecuteNonQuery() > 0; 
                } catch (MySqlException ex)
                {
                    LastError = "Невозможно удалить маршрут: на нее ссылаются записи из других таблиц";
                    return false;
                }
            }
        }

        // Добавление станции
        public bool InsertStation(string name, string inn, string address)
        {
            LastError = null;
            string query = "INSERT INTO Stations (Name, Inn, Address) VALUES (@name, @inn, @address)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@inn", inn);
                cmd.Parameters.AddWithValue("@address", address);
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    LastError = "Ошибка при добавлении станции: " + ex.Message;
                    return false;
                }
            }
        }

        // Добавление сотрудника
        public bool InsertEmployee(int stationId, string fullName, int positionId, int crewId)
        {
            LastError = null;
            string query = @"INSERT INTO Personnel (StationId, FullName, PositionId, CrewId) 
                     VALUES (@stationId, @fullName, @positionId, @crewId)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@stationId", stationId);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@positionId", positionId);
                cmd.Parameters.AddWithValue("@crewId", crewId);
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    LastError = "Ошибка при добавлении сотрудника: " + ex.Message;
                    return false;
                }
            }
        }

        // Добавление маршрута
        public bool InsertRoute(int ownerStationId, int trainId, int departureStationId,
                                int arrivalStationId, TimeSpan departureTime, TimeSpan arrivalTime, int crewId)
        {
            LastError = null;
            string query = @"INSERT INTO Routes (OwnerStationId, TrainId, DepartureStationId, ArrivalStationId, 
                        DepartureTime, ArrivalTime, CrewId)
                     VALUES (@ownerStationId, @trainId, @departureStationId, @arrivalStationId,
                             @departureTime, @arrivalTime, @crewId)";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ownerStationId", ownerStationId);
                cmd.Parameters.AddWithValue("@trainId", trainId);
                cmd.Parameters.AddWithValue("@departureStationId", departureStationId);
                cmd.Parameters.AddWithValue("@arrivalStationId", arrivalStationId);
                cmd.Parameters.AddWithValue("@departureTime", departureTime);
                cmd.Parameters.AddWithValue("@arrivalTime", arrivalTime);
                cmd.Parameters.AddWithValue("@crewId", crewId);
                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    LastError = "Ошибка при добавлении маршрута: " + ex.Message;
                    return false;
                }
            }
        }

        public List<KeyValuePair<int, string>> GetStationsList()
        {
            var list = new List<KeyValuePair<int, string>>();
            string query = "SELECT Id, Name FROM Stations";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader["Id"]), reader["Name"].ToString()));
                }
            }
            return list;
        }

        public List<KeyValuePair<int, string>> GetPositionsList()
        {
            var list = new List<KeyValuePair<int, string>>();
            string query = "SELECT Id, Name FROM Positions";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader["Id"]), reader["Name"].ToString()));
                }
            }
            return list;
        }

        public List<KeyValuePair<int, string>> GetCrewsList()
        {
            var list = new List<KeyValuePair<int, string>>();
            string query = "SELECT Id, Name FROM Crews";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader["Id"]), reader["Name"].ToString()));
                }
            }
            return list;
        }


        public List<KeyValuePair<int, string>> GetTrainsList()
        {
            var list = new List<KeyValuePair<int, string>>();
            string query = "SELECT Id, Name FROM Trains";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new KeyValuePair<int, string>(Convert.ToInt32(reader["Id"]), reader["Name"].ToString()));
                }
            }
            return list;
        }

    }
}
