using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reserv
{
    public interface IVisitTypeRepository : IRepository
    {
        Task<List<VisitType>> ReadVisitTypes();
        Task<VisitType> ReadVisitTypeById(int id);


        Task Delete(int id);

        Task Update(VisitType visitType);

        Task Create(VisitType visitType);
    }

}
