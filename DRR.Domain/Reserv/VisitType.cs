using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Reserv
{
    public class VisitType : Entity<int>
    {
        public VisitType(string visitTypeName)
        {
            VisitTypeName = visitTypeName;
            
        }

        public void Update(string visitTypeName)
        {
            VisitTypeName = visitTypeName;

        }

        public int Id { get; set; }
       
        public string VisitTypeName { get; set; }




        public ICollection<VisitCost> visitCosts { get; set; }
        
    }

}
