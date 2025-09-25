using Hospital.Services.Abstract;
using Hospital.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hospital.Services
{
    public static class ModuleServiceDependencie
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IpatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IMedicalRecordService, MedicalRecordService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();
            services.AddAutoMapper((Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}

