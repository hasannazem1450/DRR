using DRR.Domain.Information;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Information
{
    public interface ISearchHistoryRepository : IRepository
    {
        Task<string> ReadSuggestionByTerm(string term);
        Task CreateUpdate(string term);
    }
}
