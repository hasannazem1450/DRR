using DRR.Application.Contracts.Commands.Specialist;
using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Specialists
{
    public interface ISpecialistRepository : IRepository
    {

        Task<Domain.Specialists.Specialist> ReadSpecialistById(int id);


        Task Delete(int id);

        Task Update(Domain.Specialists.Specialist specialist);

        Task Create(Domain.Specialists.Specialist specialist);
    }

}
