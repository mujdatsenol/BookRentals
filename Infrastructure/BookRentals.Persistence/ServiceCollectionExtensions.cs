﻿#pragma warning disable CS8604 // Possible null reference argument.

using BookRentals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRentals.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this DbContextOptionsBuilder builder, string connectionString, string migrationAssembly)
        {
            builder.UseSqlServer(
                       connectionString,
                       b => b.MigrationsAssembly(migrationAssembly));
        }

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddData<MainDbContext>(
                (options) =>
                {
                    options.ConfigureDatabase(
                        connectionString: configuration["ConnectionString:DefaultConnection"],
                        migrationAssembly: configuration["ConnectionString:MigrationsAssembly"]);
                });
        }
    }
}
