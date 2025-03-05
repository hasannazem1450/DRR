using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{
    public class ReadAllPatientFavoritesQuery : Query
    {

    }
   
    public class ReadAllPatientFavoritesQueryResponse : QueryResponse
    {
        public ReadAllPatientFavoritesQueryResponse()
        {
            List = new List<PatientFavoriteDto>();
        }
        public List<PatientFavoriteDto> List { get; set; }
    }
}
