using Hospital.core.Features.Patient.Command.Models;
using Hospital.Data.Models;

namespace Hospital.core.Mapping
{
    public partial class PatientProfile
    {
        public void EditPatientsCommandMapping()
        {
            CreateMap<EditPatientsCommand, Patients>();
        }
    }
}
