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
        public VisitCost( int doctorId, decimal price ,int visitTypeId)
        {
            DoctorId = doctorId;
            Price = price;
            VisitTypeId = visitTypeId;

        }

        public void Update(int doctorId, decimal price, int visitTypeId)
        {
            DoctorId = doctorId;
            Price = price;
            VisitTypeId = visitTypeId;

        }

        public int DoctorId { get; set; }
        public decimal Price { get; set; }
        public int VisitTypeId { get; set; }
        public VisitType VisitType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }




    }

}
