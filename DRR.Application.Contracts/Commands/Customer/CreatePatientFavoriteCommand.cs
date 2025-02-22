using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class CreatePatientFavoriteCommand : Command
    {
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ArticleId { get; set; }
       

    }
    public class CreatePatientFavoriteCommandResponse : CommandResponse
    {
    }
}
