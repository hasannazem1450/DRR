using DRR.Domain.Reservations;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.VisitCosts
{
    public interface IVisitCostRepository : IRepository
    {

        Task<VisitCost> ReadVisitCostById(int id);
        Task<List<VisitCost>> ReadVisitCostByDoctorId(int id);
        Task<List<VisitCost>> ReadVisitCostByVisitTypeId(int id);
        

        Task Delete(int id);

        Task Update(Domain.Reservations.VisitCost visitCost);

        Task Create(Domain.Reservations.VisitCost visitCost);
    }

}
