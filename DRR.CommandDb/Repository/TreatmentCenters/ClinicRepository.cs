using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;


namespace DRR.CommandDb.Repository.TreatmentCenters
{
    class ClinicRepository : BaseRepository, IClinicRepository
    {
        public ClinicRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Clinic>> ReadClinicByDto(ClinicDto ClinicDto)
        {
            var query = _Db.Clinics.AsQueryable();
            if (ClinicDto.ClinicCode != null)
                query = query.Where(q => q.SiamCode == ClinicDto.ClinicCode);

            if (!ClinicDto.ClinicName.IsNotNullOrEmpty())
                query = query.Where(q => q.Name == ClinicDto.ClinicName);

            return await query.ToListAsync();

        }

        public async Task<Clinic> ReadClinicById(int id)
        {
            var result = await _Db.Clinics.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Clinic>> ReadClinicByCityId(int id)
        {
            var result = await _Db.Clinics.Where(c => c.CityId == id).ToListAsync();

            return result;
        }
        public async Task<List<Clinic>> ReadClinicByClinicTypeId(int id)
        {
            var result = await _Db.Clinics.Where(c => c.ClinicTypeId == id).ToListAsync();

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
            result.Geoloc = Clinic.Geoloc;
            result.Phone = Clinic.Phone;
            result.CityId = Clinic.CityId;
            result.SiamCode = Clinic.SiamCode;
            result.Desc = Clinic.Desc;
            result.ClinicTypeId = Clinic.ClinicTypeId;


            _Db.Clinics.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Clinics.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Clinics.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }
}
