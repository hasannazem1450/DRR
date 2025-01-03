using DRR.Application.Contracts.Repository.Customer;
using DRR.CommandDB;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Customer
{
    public class PatientFavoriteRepository : BaseRepository, IPatientFavoriteRepository
    {
        public PatientFavoriteRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<PatientFavorite> ReadPatientFavoriteById(int id)
        {
            var result = await _Db.PatientFavorites.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<PatientFavorite>> ReadPatientFavoriteByPatientId(int id)
        {
            var result = await _Db.PatientFavorites.Where(c => c.PatientId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientFavorite>> ReadPatientFavoriteByDoctorId(int id)
        {
            var result = await _Db.PatientFavorites.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientFavorite>> ReadPatientFavoriteByArticleId(int id)
        {
            var result = await _Db.PatientFavorites.Where(c => c.ArticleId == id).ToListAsync();

            return result;
        }
        public async Task Create(PatientFavorite PatientFavorite)
        {
            await _Db.PatientFavorites.AddAsync(PatientFavorite);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Customer.PatientFavorite PatientFavorite)
        {
            var result = await this.ReadPatientFavoriteById(PatientFavorite.Id);

            result.PatientId = PatientFavorite.PatientId;
            result.DoctorId = PatientFavorite.DoctorId;
            result.ArticleId = PatientFavorite.ArticleId;


            _Db.PatientFavorites.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.PatientFavorites.FirstOrDefaultAsync(n => n.Id == id);

            _Db.PatientFavorites.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
