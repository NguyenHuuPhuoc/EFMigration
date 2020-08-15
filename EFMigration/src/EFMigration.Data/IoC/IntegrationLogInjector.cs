using EFMigration.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFMigration.Data.IoC
{
    public static class IntegrationLogInjector
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionInfo"><see cref="ConnectionInfo"/> database connection options</param>
        /// <param name="autoMigrate">auto execute database migration</param>
        /// <returns></returns>
        public static IServiceCollection AddIntegrationLog(this IServiceCollection services, ConnectionInfo connectionInfo,
            bool autoMigrate = true)
        {
            services.AddDb(connectionInfo);

            if (autoMigrate)
                services.AutoMigration();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, ConnectionInfo connectionInfo)
        {
            if (connectionInfo == null || string.IsNullOrEmpty(connectionInfo.ConnectionString))
                throw new ArgumentNullException(nameof(connectionInfo));

            // register DbContext
            var migrationAssembly = typeof(IntegrationLogInjector).Assembly.GetName().Name;

            services.AddDbContextPool<IntegrationLogContext>(optionsAction: options =>
               options.UseSqlServer(connectionInfo.ConnectionString, opts =>
                  opts.EnableRetryOnFailure(maxRetryCount: connectionInfo.MaxRetryCount,
                     maxRetryDelay: connectionInfo.MaxRetryDelay,
                     errorNumbersToAdd: null)
                     .MigrationsAssembly(migrationAssembly)));

            return services;
        }

        private static void AutoMigration(this IServiceCollection services)
        {
            // auto migration
            var serviceProviderFactory = new DefaultServiceProviderFactory();
            var serviceProvider = serviceProviderFactory.CreateServiceProvider(services);

            using (var serviceScope = serviceProvider
                                       .GetRequiredService<IServiceScopeFactory>()
                                       .CreateScope())
            {
                using (var context = serviceProvider.GetRequiredService<IntegrationLogContext>())
                {
                    if (context.Database.IsSqlServer())
                    {
                        context.Database.EnsureCreated();
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}