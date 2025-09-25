using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.core.Features.Patient.Queries.Response
{
    public class GetSinglePatientResponse
    {

        public int id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string? PhoneNumber { get; set; }
        public required string Email { get; set; }
       
    }
}

