using Hospital.Data.Models;
using Hospital.core.Features.Patient.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.core.Mapping
{
    public partial class  PatientProfile
    {
        public void AddPatientCommandMapping()
        {
            CreateMap<CreatePatientsCommand, Patients>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now)));
        }
    }
}
