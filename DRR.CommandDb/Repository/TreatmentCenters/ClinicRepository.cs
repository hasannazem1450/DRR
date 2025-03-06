using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;


namespace DRR.CommandDb.Repository.TreatmentCenters
{
    public class ClinicRepository : BaseRepository, IClinicRepository
    {
        public ClinicRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Clinic>> ReadClinics()
        {
            var result = await _Db.Clinics
                .Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.ClinicType)
                .ToListAsync();
            
            return result;
        }
        public async Task<List<Clinic>> ReadClinicByDto(ClinicDto ClinicDto)
        {
            var query = _Db.Clinics.AsQueryable();
            if (!ClinicDto.ClinicName.IsNotNullOrEmpty())
                query = query.Where(q => q.Name == ClinicDto.ClinicName);

            return await query.ToListAsync();

        }

        public async Task<Clinic> ReadClinicById(Guid id)
        {
            var result = await _Db.Clinics
                .Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.ClinicType)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }
        public async Task<int> ReadClinicDoctorsCountById(Guid id)
        {
            var result = _Db.DoctorTreatmentCenters
                .Where(x => x.ClinicId == id).Count();

            return result;
        }

        public async Task<List<Clinic>> ReadClinicByCityId(int id)
        {
            var result = await _Db.Clinics.Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.ClinicType).Where(c => c.CityId == id).ToListAsync();

            return result;
        }
        public async Task<List<Clinic>> ReadClinicByClinicTypeId(int id)
        {
            var result = await _Db.Clinics.Include(x => x.City).ThenInclude(x => x.Province)
                .Include(x => x.ClinicType).Where(c => c.ClinicTypeId == id).ToListAsync();

            return result;
        }
        public async Task Create(Clinic Clinic)
        {
            await _Db.Clinics.AddAsync(Clinic);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.Clinic Clinic)
        {
            var result = await this.ReadClinicById(Clinic.Id);

            result.Name = Clinic.Name;
            result.Address = Clinic.Address;
            result.Geolat = Clinic.Geolat;
            result.Geolon = Clinic.Geolon;
            result.Phone = Clinic.Phone;
            result.CityId = Clinic.CityId;
            result.SiamCode = Clinic.SiamCode;
            result.Desc = Clinic.Desc;
            result.ClinicTypeId = Clinic.ClinicTypeId;


            _Db.Clinics.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var result = await _Db.Clinics.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Clinics.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }
}
