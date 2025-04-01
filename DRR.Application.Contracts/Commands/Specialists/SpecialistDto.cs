using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Specialists
{
    public class SpecialistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maxa { get; set; }
        public string MaxaName { get; set; }
        public string LogoFile { get; set; }
        public List<Category> categories { get; set; }
    }
}
