using DRR.Application.Contracts.Repository.Finance;
using DRR.Application.Contracts.Repository.Information;
using DRR.CommandDB;
using DRR.Domain.Finance;
using DRR.Domain.Information;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Information
{
    public class SearchHistoryRepository : BaseRepository, ISearchHistoryRepository
    {
        public SearchHistoryRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<string> ReadSuggestionByTerm(string term)
        {
            var result = await _Db.SearchHistorys.Where(c => c.SearchTerm.Contains(term)).OrderByDescending(X => X.SearchCount).FirstOrDefaultAsync();
            if (result != null)
                return result.SearchTerm;
            else
                return "";
        }
        public async Task CreateUpdate(string term)
        {
            var result = await _Db.SearchHistorys.Where(c => c.SearchTerm == term).FirstOrDefaultAsync();

            if (result == null)
            {
                var search = new SearchHistory();
                search.SearchTerm = term;
                search.SearchCount = 1;
                await _Db.SearchHistorys.AddAsync(search);
                await _Db.SaveChangesAsync();

            }
            else
            {
                result.SearchCount += 1;
                _Db.SearchHistorys.Update(result);
                await _Db.SaveChangesAsync();
            }
        }
    }
}
