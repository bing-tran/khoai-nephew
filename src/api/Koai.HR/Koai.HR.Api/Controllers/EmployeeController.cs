using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Koai.HR.Api.Models;

namespace Koai.HR.Api.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class EmployeeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Employee
            {
                FirstName = Summaries[rng.Next(Summaries.Length)],
                LastName = Summaries[rng.Next(Summaries.Length)],
                Age = rng.Next(1, 151),
            })
            .ToArray();
        }
    }
}
