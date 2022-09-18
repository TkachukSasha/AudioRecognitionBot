using AudioRecognition.Core.Dal.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace AudioRecognition.Core.Dal.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.ConfigureOptions<DatabaseOptionsSetup>();

            services.AddDbContext<AudioRecognitionContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseSqlServer(databaseOptions.DefaultConnection, sqlServerAction =>
                {
                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);

                });

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);

                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });

            return services;
        }
    }
}
