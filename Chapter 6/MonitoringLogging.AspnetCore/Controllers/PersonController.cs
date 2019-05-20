using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoringLogging.AspnetCore.Services;
using Newtonsoft.Json;

namespace MonitoringLogging.AspnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase 
    {
        //private TelemetryClient telemetryClient;
        private ILoggingService loggingService;
        private List<Person> People;

        // Default controller
        public PersonController(ILoggingService loggingService) 
        {
            //this.telemetryClient = client;
            this.loggingService = loggingService;

            // Create a data source for the people.
            this.People = new List<Person>
            {
                new Person { Id = 1, Name = "Afzaal Ahmad Zeeshan", Title = "Software Engineer" },
                new Person { Id = 1, Name = "Afzaal Ahmad Zeeshan", Title = "Mobile Developer" },
                new Person { Id = 1, Name = "Afzaal Ahmad Zeeshan", Title = "Technical Writer" },
                new Person { Id = 1, Name = "Afzaal Ahmad Zeeshan", Title = "Gamer" }
            };
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<string> GetAll() 
        {
            var startTime = DateTime.Now;
            var properties = new Dictionary<string, string>
            {
                ["Time"] = DateTime.Now.ToString()
            };

            // Sample authentication delay
            await Task.Delay(50);
            loggingService.TrackDependency("Authentication", "Database", "API Authentication", "API took 50ms", startTime, DateTime.Now - startTime, "200", true);

            // Sample cachin delay
            startTime = DateTime.Now;
            await Task.Delay(20);
            loggingService.TrackDependency("Caching", "in-memory", "Cache hit or miss", "Cache took 20ms", startTime, DateTime.Now - startTime, "200", true);

            // Sample database delay
            startTime = DateTime.Now;
            await Task.Delay(100);
            loggingService.TrackDependency("Database", "NoSQL", "Finding data from database", "API took 100ms", startTime, DateTime.Now - startTime, "200", true);

            // Track the request, finally.
            loggingService.TrackRequest(properties);

            // Sample other delays
            startTime = DateTime.Now;
            await Task.Delay(10);
            loggingService.TrackDependency("Monitoring", "HTTP request -> response", "Finalizing the request", "Overall process took 10ms", startTime, DateTime.Now - startTime, "200", true);

            // Send the response.
            return JsonConvert.SerializeObject(this.People);
        }
    }

    // Helper class, created in the same file as the Web API Controller. 
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
