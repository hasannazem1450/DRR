using DRR.Application.Contracts.Repository.Specialists;
using DRR.CommandDB;
using DRR.Domain.Specialists;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Categorys
{
    class CategorysRepository : BaseRepository, ICategorysRepository
    {
        public CategorysRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Category> ReadCategoryById(int id)
        {
            var query = _Db.Categorys
            .AsQueryable();
            if (id != 0)
                query = query.Where(c => c.Id == id);
            return await query.FirstOrDefaultAsync();

        }

        public async Task<List<Category>> ReadCategorys()
        {
            var query = _Db.Categorys
            .AsQueryable();
           
            return await query.ToListAsync();
        }

        public async Task Create(Category Category)
        {
            await _Db.Categorys.AddAsync(Category);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Specialists.Category Category)
        {
            var result = await this.ReadCategoryById(Category.Id);


            result.CategoryName = Category.CategoryName;
            result.CategoryLogoFile = Category.CategoryLogoFile;


            _Db.Categorys.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Categorys.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Categorys.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
