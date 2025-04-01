using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Specialists
{
    public class UpdateCategoryCommand : Command
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryLogoFile { get; set; }
    }
    public class UpdateCategoryCommandResponse : CommandResponse
    {
        public Category Data { get; set; }
    }
}
