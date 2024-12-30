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
        public VisitCost( int doctorId, decimal price)
        {
            DoctorId = doctorId;
            Price = price;

        }

        public void Update(int doctorId, decimal price)
        {
            DoctorId = doctorId;
            Price = price;

        }

        public int DoctorId { get; set; }
        public decimal Price { get; set; }
      
        public ICollection<Reservation> Reservations { get; set; }




    }

}
