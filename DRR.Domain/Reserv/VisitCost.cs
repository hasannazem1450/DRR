using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Reserv
{
    public class VisitCost : Entity<int>
    {
        public VisitCost( int doctorId, int visitTypeId, decimal price)
        {
            DoctorId = doctorId;
            VisitTypeId = visitTypeId;
            Price = price;

        }

        public void Update(int doctorId, int visitTypeId, decimal price)
        {
            DoctorId = doctorId;
            VisitTypeId = visitTypeId;
            Price = price;

        }

        public int DoctorId { get; set; }
        public int VisitTypeId { get; set; }
        public decimal Price { get; set; }
      
        


             
        public ICollection<Reservation> Reservations { get; set; }




    }

}
