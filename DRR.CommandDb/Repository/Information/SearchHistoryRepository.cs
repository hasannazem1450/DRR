using DRR.Application.Contracts.Repository.Finance;
using DRR.Application.Contracts.Repository.Information;
using DRR.CommandDB;
using DRR.Domain.Finance;
using DRR.Domain.Information;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
        public async Task<string> ReadSuggestionByTerm(List<string> searchTerms)
        {
            var query = _Db.SearchHistorys.Where(x => x.SearchCount >= 1);
                           //.OrderByDescending(x => x.SearchCount);
            string baseresult = "";
            if (searchTerms.Count == 0 )
            {
               
                //var top10 = await query.OrderByDescending(x => x.SearchCount).Take(10).ToListAsync();
                var top10 = await query.ToListAsync();
                foreach (var item in top10)
                {
                    baseresult += item.SearchTerm + ",";
                }
                return baseresult;
            }
            else
            {
                foreach (var searchTerm in searchTerms.Where(w => w.IsNotNullOrEmpty()))
                    query = query.Where(w => w.SearchTerm.Contains(searchTerm)
                    );

                var result = await query.OrderByDescending(x => x.SearchCount).Take(10).ToListAsync();
                foreach (var item in result)
                {
                    baseresult = item.SearchTerm + ",";
                }
                return baseresult;
              
            }
        }
        public async Task CreateUpdate(string term)
        {
            var result = _Db.SearchHistorys.Where(c => c.SearchTerm == term).FirstOrDefault();

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
