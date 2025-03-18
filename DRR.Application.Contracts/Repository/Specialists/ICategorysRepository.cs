using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Specialists
{
    public interface ICategorysRepository : IRepository
    {

        Task<Category> ReadCategoryById(int id);

        Task<List<Category>> ReadCategorys();
        Task Delete(int id);

        Task Update(Category specialist);

        Task Create(Category specialist);
    }

}
