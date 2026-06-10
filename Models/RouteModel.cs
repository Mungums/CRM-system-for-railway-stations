using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    internal class RouteModel
    {
        public string Id { get; set; }
        public string OwnerStationName { get; set; }
        public string TrainName { get; set; }   
        public string DepartureStationName { get; set; }
        public string ArrivalStationName { get; set; }
        public string DepartureTime { get; set; } 
        public string ArrivalTime { get; set; }
        public string CrewName { get; set; }

    }
}
