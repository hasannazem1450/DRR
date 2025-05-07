using DRR.Application.Contracts.Commands.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Queries.Customer
{

    public class ReadPatientFavoritesQuery : Query
    {
        public int PatientId { get; set; }
    }
    public class ReadPatientFavoritesQueryResponse : QueryResponse
    {
        public ReadPatientFavoritesQueryResponse()
        {
            List = new List<PatientFavoriteDto>();
        }
        public List<PatientFavoriteDto> List { get; set; }
    }
}
