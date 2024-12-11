using DRR.Application.Contracts.Commands.Specialist;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.CommandDB;
using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Specialists
{
    class SpecialistRepository : BaseRepository, ISpecialistRepository
    {
        public SpecialistRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Domain.Specialists.Specialist> ReadSpecialistById(int id)
        {
            var result = await _Db.Specialists.FirstOrDefaultAsync(c => c.Id == id);

            return result;
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
            

            _Db.Specialists.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Specialists.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Specialists.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
