using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reserv
{
    public interface IVisitCostRepository : IRepository
    {

        Task<VisitCost> ReadVisitCostById(int id);
        Task<List<VisitCost>> ReadVisitCostByDoctorId(int id);
        

        Task Delete(int id);

        Task Update(VisitCost visitCost);

        Task Create(VisitCost visitCost);
    }

}
