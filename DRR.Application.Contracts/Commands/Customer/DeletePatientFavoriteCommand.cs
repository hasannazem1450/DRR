using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Customer
{
    public class DeletePatientFavoriteCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeletePatientFavoriteCommandResponse : CommandResponse
    {
    }


}
