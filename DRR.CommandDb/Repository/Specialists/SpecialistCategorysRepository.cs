using DRR.Application.Contracts.Repository.Specialists;
using DRR.CommandDB;
using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository.Specialists
{
    public class SpecialistCategorysRepository : BaseRepository, ISpecialistCategorysRepository
    {
        public SpecialistCategorysRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Specialist>> ReadSpecialistsByCategoryId(int id)
        {
            var query = _Db.SpecialistCategorys.Where(x => x.CategoryId == id).Include(x => x.Specialists)
           .AsQueryable();
            var sc = await query.ToListAsync();
            var s = new Specialist();
            var ls = new List<Specialist>();
            if (sc == null)
            {
                //throw new Exception("تخصصی دراین دسته بندی نیست");
                return null;
            }
            foreach (var item in sc)
            {
                s = await _Db.Specialists.Where(x => x.Id == item.SpecialistId).FirstOrDefaultAsync();
                ls.Add(s);
            }
            return ls;

        }

        public async Task<List<Category>> ReadCategoriesBySpecialistId(int id)
        {
            var query = _Db.SpecialistCategorys.Where(x => x.SpecialistId == id).Include(x => x.Categorys)
          .AsQueryable();
            var cs = await query.ToListAsync();
            var c = new Category();
            var lc = new List<Category>();
            if (cs == null)
            {
                //throw new Exception("این تخصص درهیچ دسته بندی نیست");
                return null;
            }
            foreach (var item in cs)
            {
                c = await _Db.Categorys.Where(x => x.Id == item.CategoryId).FirstOrDefaultAsync();
                lc.Add(c);
            }
            return lc;
        }
        public async Task Create(SpecialistCategory specialistCategory)
        {
            await _Db.SpecialistCategorys.AddAsync(specialistCategory);
            await _Db.SaveChangesAsync();
        }

        public async Task Delete(int specialistid, int categoryid)
        {
            var result = await _Db.SpecialistCategorys.FirstOrDefaultAsync(n => n.SpecialistId == specialistid && n.CategoryId == categoryid);

            _Db.SpecialistCategorys.Remove(result);

            await _Db.SaveChangesAsync();
        }
    }
}
