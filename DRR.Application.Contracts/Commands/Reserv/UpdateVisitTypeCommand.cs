using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Reserv
{
    public class UpdateVisitTypeCommand : Command
    {
        public int Id { get; set; }
        public string VisitTypeName { get; set; }
      

    }

    public class UpdateVisitTypeCommandResponse : CommandResponse
    {
    }
}