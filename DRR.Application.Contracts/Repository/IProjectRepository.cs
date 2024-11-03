using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Project;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository
{
    public interface IProjectRepository :IRepository
    {
        Task<bool> Create(Project project);
    }
}
