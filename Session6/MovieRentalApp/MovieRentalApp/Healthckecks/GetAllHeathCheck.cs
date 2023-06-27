using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MovieRentalApp.Context;

namespace MovieRentalApp.Healthckecks
{
    public class GetAllHeathCheck : IHealthCheck
    {
        private readonly AppDbContext _appContext;

        public GetAllHeathCheck(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var list =await _appContext.Movies.ToListAsync();
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
