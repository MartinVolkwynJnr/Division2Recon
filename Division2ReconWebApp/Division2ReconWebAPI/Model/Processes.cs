using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Division2ReconWebAPI.Model
{
    public class Processes
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MachineNr { get; set; }
        public int MachineId { get; set; }
        public string MachineTypeSerial { get; set; }
        public string Process { get; set; }
        public string ProcessTime { get; set; }
        public string SensorData { get; set; }
        public string OnlineFrom { get; set; }
    }
}
