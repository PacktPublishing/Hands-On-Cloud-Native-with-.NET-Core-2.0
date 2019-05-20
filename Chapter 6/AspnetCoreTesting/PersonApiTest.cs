using Microsoft.ApplicationInsights;
using MonitoringLogging.AspnetCore.Controllers;
using System;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetCoreTesting
{
    public class PersonApiTest
    {
        [Fact]
        public void Test_Get_All () 
        {
            // Arrange
            var telemetryClient = new TelemetryClient();
            var loggingService = new TestLoggingService();

            // Act
            PersonController personController = new PersonController(loggingService);
            var response = personController.GetAll().Result;

            // Assert
            Assert.IsType<string>(response);
            Assert.IsType<List<Person>>(JsonConvert.DeserializeObject<List<Person>>(response));
        }
    }
}
