using Hospital.core.Base;
using Hospital.core.Features.Patient.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.core.Features.Patient.Queries.Models
{
  public  class GetPatientByIdQuery:IRequest<Response<GetSinglePatientResponse>>
    {
        public int Id { get; set; }
        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
