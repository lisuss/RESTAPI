using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebApi.Contracts.HealthCheck
{
    public class HealthCheckResponse
    {
        public string Status {get; set;}

        public IEnumerable<HealthCheck> Checks { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
