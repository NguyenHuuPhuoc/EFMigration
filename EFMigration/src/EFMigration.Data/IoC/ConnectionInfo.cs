using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFMigration.Data.IoC
{
    public class ConnectionInfo
    {
        /// <summary>
        /// Notice:
        /// - MaxRetryCount default is 10
        /// - MaxRetryDelay default is 30 seconds
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="connectionLifetime"></param>
        public ConnectionInfo(string connectionString, ServiceLifetime connectionLifetime = ServiceLifetime.Transient)
        {
            ConnectionString = string.IsNullOrEmpty(connectionString) ? throw new ArgumentException(nameof(connectionString)) : connectionString;

            ConnectionLifetime = connectionLifetime;

            MaxRetryCount = 10;

            MaxRetryDelay = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="maxRetryCount"></param>
        /// <param name="maxRetryDelay"></param>
        /// <param name="connectionLifetime"></param>
        public ConnectionInfo(string connectionString, int maxRetryCount, int maxRetryDelay, ServiceLifetime connectionLifetime = ServiceLifetime.Transient)
        {
            ConnectionString = string.IsNullOrEmpty(connectionString) ? throw new ArgumentException(nameof(connectionString)) : connectionString;

            ConnectionLifetime = connectionLifetime;

            MaxRetryCount = maxRetryCount;

            MaxRetryDelay = TimeSpan.FromSeconds(maxRetryDelay);
        }

        public ServiceLifetime ConnectionLifetime { get; }

        public int MaxRetryCount { get; }

        public TimeSpan MaxRetryDelay { get; set; }

        public string ConnectionString { get; }
    }
}