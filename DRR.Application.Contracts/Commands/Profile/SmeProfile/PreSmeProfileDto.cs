using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.SmeProfile
{
    public class PreSmeProfileDto
    {
        public int Id { get; set; }
        public string SmeName { get; set; }
        public string ManagerName { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
    }
}
