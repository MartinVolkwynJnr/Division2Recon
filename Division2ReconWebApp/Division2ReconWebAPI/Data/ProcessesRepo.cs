using Division2ReconWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Division2ReconWebAPI.Data
{
    public class ProcessesRepo : IProcessesRepo
    {
        //private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\DataReceived.csv");
        private readonly string filePath = @"C:\Users\Marti\OneDrive\Desktop\Wassenburg\Division2 Recon\Division2Recon\Division2ReconWebApp\Division2ReconWebAPI\Data\DataReceived.csv";

        private IEnumerable<Processes> readTextFile()
        {
            var processes = new List<Processes>();
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
            return processes;
        }

        public IEnumerable<Processes> GetProcesses()
        {
            return readTextFile();
        }

        public IEnumerable<Processes> SearchByCustomerName(string searchString)
        {
            var processes = readTextFile();
            return processes.Where(pro => pro.CustomerName.Equals(searchString));
        }

        public Processes GetProcess(string process)
        {
            var processes = readTextFile();
            return processes.FirstOrDefault(pro => pro.Process.Equals(process));
        }

        public IEnumerable<Processes> SearchBySensorData(string sensorData)
        {
            var processes = readTextFile();
            return processes.Where(pro => pro.SensorData.Equals(sensorData));
        }
    }
}
