using Hospital.Infrastructure.Abstract;
using Hospital.Infrastructure.InfrastructureBase;
using Hospital.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure
{
    public static class ModuleInfrastructureDependencie
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IPatient, PatientRepository>();
            services.AddTransient<IDcotor, DoctorRepository>();
            services.AddTransient<IAppointment, AppointmentRepository>();
            services.AddTransient<IMedicalRecord, MedicalRecordRepository>();
            services.AddTransient<IAuth, AuthRepository>();
            services.AddTransient(typeof(IGenericRepos<>), typeof(GenericRepos<>));
            return services;
        }
    }

}
