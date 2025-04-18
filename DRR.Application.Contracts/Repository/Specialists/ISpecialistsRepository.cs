using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Specialists
{
    public interface ISpecialistRepository : IRepository
    {

        Task<Specialist> ReadSpecialistById(int id);

        Task<List<Specialist>> ReadSpecialists();
        Task Delete(int id);

        Task Update(Specialist specialist);

        Task Create(Specialist specialist);
        Task<List<Specialist>> Search(List<string> searchTerms);
    }

}
