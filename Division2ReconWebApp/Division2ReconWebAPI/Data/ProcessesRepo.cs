using Division2ReconWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Division2ReconWebAPI.Data
{
    public class ProcessesRepo : IProcessesRepo
    {
        private IEnumerable<Processes> readTextFile()
        {
            string filePath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Values")["filePath"];
            var processes = new List<Processes>();
            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    string[] processEntries = line.Split("|");

                    Processes entryProcess = new Processes
                    {
                        CustomerId = Int32.Parse(processEntries[0]),
                        CustomerName = processEntries[1],
                        MachineNr = processEntries[2],
                        MachineId = Int32.Parse(processEntries[3]),
                        MachineTypeSerial = processEntries[4],
                        Process = processEntries[5],
                        ProcessTime = processEntries[6],
                        SensorData = processEntries[7],
                        OnlineFrom = processEntries[8]
                    };
                    processes.Add(entryProcess);
                }
            }
            
            return processes;
        }
        public IEnumerable<Processes> Search(IEnumerable<Processes> processes, string searchString, SearchType searchType)
        {
            switch (searchType)
            {
                case SearchType.CustomerName:
                    return processes.Where(pro => pro.CustomerName.Contains(searchString));
                case SearchType.SensorData:
                    return processes.Where(pro => pro.SensorData.Contains(searchString));
                case SearchType.Process:
                    return processes.Where(pro => pro.Process.Contains(searchString));
                default: return processes;
            };
        }

        public Processes GetProcess(IEnumerable<Processes> processes, string searchString, SearchType searchType)
        {
            switch (searchType)
            {
                case SearchType.CustomerName:
                    return processes.FirstOrDefault(pro => pro.CustomerName.Contains(searchString));
                case SearchType.SensorData:
                    return processes.FirstOrDefault(pro => pro.SensorData.Contains(searchString));
                case SearchType.Process:
                    return processes.FirstOrDefault(pro => pro.Process.Contains(searchString));
                default: return null;
            };
        }

        public IEnumerable<Processes> GetProcesses()
        {
            return readTextFile();
        }

        public IEnumerable<Processes> SearchByCustomerName(string customerName)
        {
            var processes = readTextFile();
            return Search(processes, customerName, SearchType.CustomerName);
        }

        public IEnumerable<Processes> SearchBySensorData(string sensorData)
        {
            var processes = readTextFile();
            return Search(processes, sensorData, SearchType.SensorData);
        }

        public Processes GetProcess(string process)
        {
            var processes = readTextFile();
            return GetProcess(processes, process, SearchType.Process);
        }


    }
}
