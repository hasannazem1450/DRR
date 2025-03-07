using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    public class OfficeRepository : BaseRepository, IOfficeRepository
    {
        public OfficeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Office>> ReadOffices()
        {
            var query = _Db.Offices
                .Include(x=> x.City).ThenInclude(x=> x.Province)
                .Include(x=> x.OfficeType)
                .AsQueryable();
           
            return await query.ToListAsync();
        }
        public async Task<Office> ReadOfficeById(Guid id)
        {
            var result = await _Db.Offices
                .Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.OfficeType)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<int> ReadOfficeDoctorsCountById(Guid id)
        {
            var result = _Db.DoctorTreatmentCenters
                .Where(x => x.OfficeId == id).Count();

            return result;
        }

        public async Task<List<Office>> ReadOfficeByCityId(int id)
        {
            var result = await _Db.Offices.Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.OfficeType).Where(c => c.CityId == id).ToListAsync();

            return result;
        }
        public async Task<List<Office>> ReadOfficeByOfficeTypeId(int id)
        {
            var result = await _Db.Offices.Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.OfficeType).Where(c => c.OfficeTypeId == id).ToListAsync();

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
            result.Geolat = Office.Geolat;
            result.Geolon = Office.Geolon;
            result.Phone = Office.Phone;
            result.CityId = Office.CityId;
            result.PostalCode = Office.PostalCode;
            result.OfficeTypeId = Office.OfficeTypeId;
            result.City = Office.City;
            result.OfficeType = Office.OfficeType;

            _Db.Offices.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var result = await _Db.Offices.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Offices.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
