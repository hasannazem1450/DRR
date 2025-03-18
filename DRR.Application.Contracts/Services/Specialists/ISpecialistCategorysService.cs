using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Specialists
{
    public interface ISpecialistCategorysService : IService
    {
        Task<int> GetFileSizeKb(string base64);
    }
}
