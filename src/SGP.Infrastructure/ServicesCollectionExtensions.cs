namespace SGP.Infrastructure
{
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Scrutor;
    using Services;
    using Shared.AppSettings;
    using Shared.Interfaces;
    using System;
    using UoW;

    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddScoped<IDateTime, LocalDateTimeService>();
            services.AddScoped<IHashService, BCryptHashService>();
            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Automatically register services ASP.NET Core DI container
            // REF: https://github.com/khellang/Scrutor
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(implementations => implementations.AssignableTo<IRepository>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection ConfigureAppSettings(this IServiceCollection services)
        {
            Guard.Against.Null(services, nameof(services));

            services.AddOptions<AuthConfig>()
                .BindConfiguration(nameof(AuthConfig), BinderNonPublicPropertiesOptions());

            services.AddOptions<JwtConfig>()
                .BindConfiguration(nameof(JwtConfig), BinderNonPublicPropertiesOptions());

            services.AddOptions<ConnectionStrings>()
                .BindConfiguration(nameof(ConnectionStrings), BinderNonPublicPropertiesOptions());

            return services;
        }

        private static Action<BinderOptions> BinderNonPublicPropertiesOptions()
        {
            return options => options.BindNonPublicProperties = true;
        }
    }
}