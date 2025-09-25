using AutoMapper;
using Hospital.Data.Models;
using Hospital.core.Features.Patient.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.core.Mapping
{
    public partial class PatientProfile 
    {
        public void  GetPatientListMapping()
        {
            CreateMap<Patients, PatientListResponse>()
                .ForMember(dest => dest.AppointmentDate, opt => opt.
                MapFrom(src => src.Appointments != null && src.Appointments.Any() 
                    ? src.Appointments.FirstOrDefault().AppointmentDate.ToString("yyyy-MM-dd") 
                    : "No appointment"));
        }
    }
}
