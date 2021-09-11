using Division2ReconWebAPI.Data;
using Division2ReconWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Division2ReconWebAPI.Controllers
{
    [Route("api/processes")]
    [ApiController]
    public class ProcessesController : ControllerBase
    {
        private readonly IProcessesRepo _repository;

        public ProcessesController(IProcessesRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Processes>> GetAllProcesses()
        {
            var processes = _repository.GetProcesses();
            return Ok(processes);
        }

        [HttpGet("SearchByCustomerName/{customerName}")]
        public ActionResult<IEnumerable<Processes>> SearchByCustomerName(string customerName)
        {
            var processes = _repository.SearchByCustomerName(customerName);
            return Ok(processes);
        }

        [HttpGet("SearchBySensorData/{sensorData}")]
        public ActionResult<IEnumerable<Processes>> SearchBySensorData(string sensorData)
        {
            var processes = _repository.SearchBySensorData(sensorData);
            return Ok(processes);
        }

        [HttpGet("GetProcess/{process}")]
        public ActionResult<Processes> GetProcess(string process)
        {
            var processes = _repository.GetProcess(process);
            return Ok(processes);
        }
    }
}
