using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace LearningSystem.WEB.HealthChecks
{
    public class TimeConnectionToDBHealthCheck : IHealthCheck
    {
        private IUsersRepository _usersRepository;
        public TimeConnectionToDBHealthCheck(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                var user = await _usersRepository.GetValueByСonditionAsync(u => u.UserName, "test");
                sw.Stop();
                if (sw.ElapsedMilliseconds > 2000)
                {
                    return HealthCheckResult.Degraded("Database is working slow.");
                }
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Error: {ex.Message}");
            }
        }
    }
}
