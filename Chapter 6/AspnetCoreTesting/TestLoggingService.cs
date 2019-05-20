using MonitoringLogging.AspnetCore.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreTesting
{
    public class TestLoggingService : ILoggingService
    {

        public void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success, IDictionary<string, string> properties = null)
        {
            Debug.Write($"Tracking '{dependencyName}' Dependency");
        }

        public void TrackRequest(IDictionary<string, string> properties)
        {
            Debug.Write("Tracking Request");
        }
    }
}
