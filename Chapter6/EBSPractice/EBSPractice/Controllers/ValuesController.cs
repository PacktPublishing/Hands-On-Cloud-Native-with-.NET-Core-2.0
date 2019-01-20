using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.AWS.Logger;
using NLog.Config;

namespace EBSPractice.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static void ConfigureNLog()
        {
            var loggingConfiguration = new LoggingConfiguration();

            var awsTarget = new AWSTarget()
            {
                LogGroup = "NLog.HandsOnLogging",
                Region = "us-west-2"
            };

            loggingConfiguration.AddTarget("aws", awsTarget);

            loggingConfiguration.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, awsTarget));

            LogManager.Configuration = loggingConfiguration;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ConfigureNLog();

            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info("Get API endpoint is called.");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
