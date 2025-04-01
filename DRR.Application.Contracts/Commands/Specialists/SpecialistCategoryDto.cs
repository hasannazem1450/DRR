using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Specialists
{
    public class SpecialistCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryLogoFile { get; set; }
        public List<Specialist> Specialists { get; set; }
    }
}
