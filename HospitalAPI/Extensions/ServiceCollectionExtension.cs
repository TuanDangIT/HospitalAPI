using HospitalAPI.Behaviors;
using System.Reflection;
using System.Runtime.CompilerServices;
using FluentValidation;
using HospitalAPI.DAL.Repositories;
using HospitalAPI.Factories;

namespace HospitalAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(currentAssembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddValidatorsFromAssembly(currentAssembly);
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            return services;
        }
    }
}
