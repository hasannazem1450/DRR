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
    public class SpecialistCategorysRepository : BaseRepository, ISpecialistCategorysRepository
    {
        public SpecialistCategorysRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Specialist>> ReadSpecialistsByCategoryId(int id)
        {
            var sc = await _Db.SpecialistCategorys.Where(x => x.CategoryId == id).Include(x => x.Specialists).ToListAsync();
            var s = new Specialist();
            var ls = new List<Specialist>();
            if (sc == null)
            {
                throw new Exception("تخصصی دراین دسته بندی نیست");
            }
            foreach (var item in sc)
            {
                s = await _Db.Specialists.Where(x => x.Id == item.SpecialistId).FirstOrDefaultAsync();
                ls.Add(s);
            }
            return ls;

        }
        public async Task Create(SpecialistCategory specialistCategory)
        {
            await _Db.SpecialistCategorys.AddAsync(specialistCategory);
            await _Db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _Db.SpecialistCategorys.FirstOrDefaultAsync(n => n.Id == id);

            _Db.SpecialistCategorys.Remove(result);

            await _Db.SaveChangesAsync();
        }
    }
}
