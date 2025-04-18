
using DRR.Application.Contracts.Repository.Specialists;
using DRR.CommandDB;
using DRR.Domain.Specialists;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DRR.Domain.Customer;
using System.Linq;
using DRR.Utilities.Extensions;


namespace DRR.CommandDb.Repository.Specialists
{
    public class SpecialistRepository : BaseRepository, ISpecialistRepository
    {
        public SpecialistRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Specialist> ReadSpecialistById(int id)
        {
            var result = await _Db.Specialists.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Specialist>> ReadSpecialists()
        {
            var query = await _Db.Specialists.ToListAsync();

            return query;
        }

        public async Task Create(Specialist Specialist)
        {
            await _Db.Specialists.AddAsync(Specialist);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Specialists.Specialist Specialist)
        {
            var result = await this.ReadSpecialistById(Specialist.Id);


            result.Name = Specialist.Name;
            result.Maxa = Specialist.Maxa;
            result.LogoFile = Specialist.LogoFile;
            

            _Db.Specialists.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Specialists.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Specialists.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task<List<Specialist>> Search(List<string> searchTerms)
        {
            var query = _Db.Specialists
                .Where(w => !w.IsDeleted);

            foreach (var searchTerm in searchTerms.Where(w => w.IsNotNullOrEmpty()))
                query = query.Where(w =>
                    w.Name.Contains(searchTerm) ||
                    w.MaxaName.Contains(searchTerm) 
                );

            var result = await query.ToListAsync();

            return result;
        }

    }

}
