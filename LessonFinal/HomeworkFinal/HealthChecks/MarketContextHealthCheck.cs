using ExchangeMarket.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyHealthChecks
{
    public class MarketContextHealthCheck : IHealthCheck
    {
        private readonly MarketContext _context;

        public MarketContextHealthCheck(MarketContext context)
        {
            _context = context;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Persons.CountAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}