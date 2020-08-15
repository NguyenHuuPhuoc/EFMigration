using EFMigration.Data.Repository;
using EFMigration.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFMigration.Data.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterIntegrationLog(this IServiceCollection services, IConfiguration Configuration, bool isAutoMigrate = true)
        {
            var connectionString = Configuration.GetValue<string>("IntegrationLogDb:ConnectionString");
            var maxRetryCount = Configuration.GetValue<int>("IntegrationLogDb:MaxRetryCount");
            var maxRetryDelay = Configuration.GetValue<int>("IntegrationLogDb:MaxRetryDelay");

            services.AddIntegrationLog(new ConnectionInfo(connectionString, maxRetryCount, maxRetryDelay), isAutoMigrate);
            services.AddScoped(typeof(IRepositoryIntegrationLog<>), typeof(EfRepositoryIntegrationLog<>));
            services.AddScoped<IUnitOfWorkIntegrationLog, UnitOfWorkIntegrationLog>();
        }
    }
}
