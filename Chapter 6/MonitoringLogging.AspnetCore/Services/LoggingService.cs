using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringLogging.AspnetCore.Services
{
    public class LoggingService : ILoggingService
    {
        public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success, IDictionary<string, string> properties = null)
        {
            var dependencyTelemetry = new DependencyTelemetry(dependencyTypeName, target, dependencyName, data, startTime, duration, resultCode, success);

            if(properties != null)
            {
                foreach (var property in properties)
                {
                    dependencyTelemetry.Properties.Add(property.Key, property.Value);
                }
            }
            new TelemetryClient().TrackDependency(dependencyTelemetry);
        }

        public void TrackRequest(IDictionary<string, string> properties = null)
        {
            var requestTelemetry = new RequestTelemetry();
            if(properties != null)
            {
                foreach (var property in properties)
                {
                    requestTelemetry.Properties.Add(property.Key, property.Value);
                }
            }
            new TelemetryClient().TrackRequest(requestTelemetry);
        }
    }
}
