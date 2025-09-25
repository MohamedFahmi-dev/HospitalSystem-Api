using AutoMapper;

namespace Hospital.core.Mapping
{
    public partial class PatientProfile : Profile
    {
        public PatientProfile()
        {
            GetPatientListMapping();
            GetPatientByidMapping();
            AddPatientCommandMapping();
            EditPatientsCommandMapping();
        }
    }
}
