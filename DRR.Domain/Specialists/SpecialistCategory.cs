using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Specialists
{
    public class SpecialistCategory : Entity<int>
    {
        public SpecialistCategory(int specialistId, int categoryId)
        {
            SpecialistId = specialistId;
            CategoryId = categoryId;
          
        }

        public int SpecialistId { get; set; }
        public int CategoryId { get; set; }
       
        public ICollection<Specialist> Specialists { get; set; }
        public ICollection<Category> Categorys { get; set; }
    }
}
