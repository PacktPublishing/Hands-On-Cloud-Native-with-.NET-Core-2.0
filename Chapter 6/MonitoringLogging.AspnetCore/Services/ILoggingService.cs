using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoringLogging.AspnetCore.Services
{
    public interface ILoggingService
    {
        void TrackRequest(IDictionary<string, string> properties);
        void TrackDependency(string dependencyTypeName, string target, string dependencyName, string data, DateTimeOffset startTime, TimeSpan duration, string resultCode, bool success, IDictionary<string, string> properties = null);
    }
}
