using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LearningSystem.WEB.HealthChecks
{
    public class DBHealthCheck : IHealthCheck
    {
        private IUsersRepository _usersRepository;
        public DBHealthCheck(IUsersRepository usersRepository)
        { 
            _usersRepository = usersRepository;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await _usersRepository.GetAllAsync();
                if (user == null)
                {
                    return HealthCheckResult.Unhealthy("Database is unavailable.");
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
