using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.News
{
    public class DeleteNewsCommand : Command
    {
        public int Id { get; set; }
    }

    public class DeleteNewsCommandResponse : CommandResponse
    {
    }
}
