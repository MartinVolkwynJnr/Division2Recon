using Division2ReconWebAPI.Data;
using Division2ReconWebAPI.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ProcessesTests
{
    [TestFixture]
    public class ProcessesTests
    {

        private List<Processes> getDummyData()
        {
            var processes = new List<Processes>();

            var mockProcess1 = new Processes();
            var mockProcess2 = new Processes();
            var mockProcess3 = new Processes();

            mockProcess1.CustomerId = 3123;
            mockProcess1.CustomerName = "UMC Utrecht";
            mockProcess1.MachineNr = "UMC-342";
            mockProcess1.MachineId = 21;
            mockProcess1.MachineTypeSerial = "EWD220;33819830413901";
            mockProcess1.Process = "WashDisWash";
            mockProcess1.ProcessTime = "Start =2019-13-02 21 =13 =11.328;End =2019-13-02 22 =03 =00.327";
            mockProcess1.SensorData = "WaterTemp =celcius =23;Pump10 =off;Pump5 =on;Dra inSensor =off;WaterLevel =ml-432;";
            mockProcess1.OnlineFrom = "27-07-2014 10 =02 =37";

            mockProcess2.CustomerId = 2954;
            mockProcess2.CustomerName = "UMC Utrecht";
            mockProcess2.MachineNr = "UMC-536J";
            mockProcess2.MachineId = 22;
            mockProcess2.MachineTypeSerial = "EWD440;4813850810101";
            mockProcess2.Process = "WashDis";
            mockProcess2.ProcessTime = "Start =2019-20-04 20 =10 =04.129;End =2019-20-04 21 =29 =20.734";
            mockProcess2.SensorData = "WaterTemp =celcius =25;Pump10 =on;Pump5 =off;Dra inSensor =off;WaterLevel =ml-382;";
            mockProcess2.OnlineFrom = "08-09-2017 18 =12 =43";

            mockProcess3.CustomerId = 1224;
            mockProcess3.CustomerName = "AMC";
            mockProcess3.MachineNr = "AMC1-32";
            mockProcess3.MachineId = 21;
            mockProcess3.MachineTypeSerial = "EWD440- PT;36849839827301";
            mockProcess3.Process = "Dis";
            mockProcess3.ProcessTime = "Start =2019-12-09 23 =54 =12.349;End =2019-12-09 23 =59 =14.343";
            mockProcess3.SensorData = "WaterTemp =celcius =22;Pump10 =off;Pump5 =on;Dra inSensor =on;WaterLevel =ml-30;";
            mockProcess3.OnlineFrom = "29-06-2016 16 =55 =02";

            processes.Add(mockProcess1);
            processes.Add(mockProcess2);
            processes.Add(mockProcess3);

            return processes;
        }

        [Test]
        public void GetProcess()
        {
            var processes = new List<Processes>();
            var process = new Processes();

            processes = getDummyData();

            //Testing method call
            var sut = new ProcessesRepo();
            process = sut.GetProcess(processes, processes[0].Process, SearchType.Process);

            //assertions
            Assert.That(process.Process, Is.EqualTo(processes[0].Process));
        }

        [Test]
        public void SearchByCustomerName()
        {
            //initializations
            var processes = new List<Processes>();

            processes = getDummyData();

            //Testing method call
            var sut = new ProcessesRepo();
            processes = sut.Search(processes, processes[0].CustomerName, SearchType.CustomerName).ToList();

            //assertions
            Assert.That(processes.Count > 0, Is.True);
        }

        [Test]
        public void SearchBySensorData()
        {
            //initializations
            var processes = new List<Processes>();

            processes = getDummyData();

            //Testing method call
            var sut = new ProcessesRepo();
            processes = sut.Search(processes, processes[0].SensorData, SearchType.SensorData).ToList();

            //assertions
            Assert.That(processes.Count > 0, Is.True);
        }
    }
}
