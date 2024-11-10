using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    class OfficeRepository : BaseRepository, IOfficeRepository
    {
        public OfficeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Office>> ReadOfficeByDto(OfficeDto OfficeDto)
        {
            var query = _Db.Offices.AsQueryable();
            if (OfficeDto.CityName != null)
                query = query.Where(q => q.City.Name == OfficeDto.CityName);


            return await query.ToListAsync();
        }
        public async Task<Office> ReadOfficeById(int id)
        {
            var result = await _Db.Offices.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Office>> ReadOfficeByCityId(int id)
        {
            var result = await _Db.Offices.Where(c => c.CityId == id).ToListAsync();

            return result;
        }
        public async Task<List<Office>> ReadOfficeByOfficeTypeId(int id)
        {
            var result = await _Db.Offices.Where(c => c.OfficeTypeId == id).ToListAsync();

            return result;
        }
        public async Task Create(Office Office)
        {
            await _Db.Offices.AddAsync(Office);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.Office Office)
        {
            var result = await this.ReadOfficeById(Office.Id);

            result.Name = Office.Name;
            result.Address = Office.Address;
            result.GlId = Office.GlId;
            result.Phone = Office.Phone;
            result.CityId = Office.CityId;
            result.PostalCode = Office.PostalCode;
            result.OfficeTypeId = Office.OfficeTypeId;


            _Db.Offices.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Offices.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Offices.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
