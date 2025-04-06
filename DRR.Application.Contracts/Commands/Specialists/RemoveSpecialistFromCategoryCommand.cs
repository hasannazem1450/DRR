using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Specialists
{
    public class RemoveSpecialistFromCategoryCommand : Command
    {
        public int SpecialistId { get; set; }
        public int CategoryId { get; set; }
    }
    public class RemoveSpecialistFromCategoryCommandResponse : CommandResponse
    {
    }
}
