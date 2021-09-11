using Division2ReconWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Division2ReconWebAPI.Data
{
    public interface IProcessesRepo
    {
        IEnumerable<Processes> GetProcesses();
        IEnumerable<Processes> SearchByCustomerName(string searchString);

        IEnumerable<Processes> SearchBySensorData(string sensorData);

        Processes GetProcess(string process);


    }
}
