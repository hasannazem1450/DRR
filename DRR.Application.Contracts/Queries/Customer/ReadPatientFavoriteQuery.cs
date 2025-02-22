using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadAllPatientFavoriteQuery : Query
    {

    }
    public class ReadPatientFavoriteQuery : Query
    {
        public int PatientId { get; set; }
    }
    public class ReadPatientFavoriteQueryResponse : QueryResponse
    {
        public ReadPatientFavoriteQueryResponse()
        {
            List = new List<PatientFavoriteDto>();
        }
        public List<PatientFavoriteDto> List { get; set; }
    }
}
