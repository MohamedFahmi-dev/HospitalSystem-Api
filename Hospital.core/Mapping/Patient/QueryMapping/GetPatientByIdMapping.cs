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
        public void GetPatientByidMapping()
        {
            CreateMap<Patients, GetSinglePatientResponse>();
        }
    }
}
