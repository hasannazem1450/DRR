using DRR.Domain.Reservations;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reservations
{
    public interface IVisitTypeRepository : IRepository
    {

        Task<VisitType> ReadVisitTypeById(int id);


        Task Delete(int id);

        Task Update(Domain.Reservations.VisitType visitType);

        Task Create(Domain.Reservations.VisitType visitType);
    }

}
