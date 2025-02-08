using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class UpdateVisitCostCommand : Command
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public decimal Price { get; set; }
        public int VisitTypeId { get; set; }

    }

    public class UpdateVisitCostCommandResponse : CommandResponse
    {
    }
}