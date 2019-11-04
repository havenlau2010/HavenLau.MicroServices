using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCheckDemo.MyCheck
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection("Data Source=.;Persist Security Info=True;User ID=sa;Password=Lwz3.131492653");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
