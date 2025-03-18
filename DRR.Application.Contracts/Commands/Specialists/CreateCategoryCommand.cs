using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Specialists
{
    public class CreateCategoryCommand : Command
    {
        public string CategoryName { get; set; }
        public string CategoryLogoFile { get; set; }
    }
    public class CreateCategoryCommandResponse : CommandResponse
    {
    }
}
