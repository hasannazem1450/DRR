using DRR.Application.Contracts.Repository.Customer;
using DRR.CommandDB;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Domain.BaseInfo;
using DRR.Utilities.Extensions;
using System.Reflection;

namespace DRR.CommandDb.Repository.Customer
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(BaseProjectCommandDb db) : base(db)
        {
        }
        public async Task<List<Doctor>> ReadAllDoctors()
        {
            var query = _Db.Doctors
               .Include(s => s.SmeProfile)
               .Include(sp => sp.Specialist)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(o => o.Office.City)
               .Include(dtc2 => dtc2.DoctorTreatmentCenters).ThenInclude(c => c.Clinic.City)
               .Include(di => di.DoctorInsurances).ThenInclude(i => i.Insurance)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.Turns)
               .AsQueryable();

            var result = await query.ToListAsync();

            return result;
        }
        public async Task<List<Doctor>> Search(SearchDoctorsQuery query)
        {
            var q = _Db.Doctors
               .Include(s => s.SmeProfile)
               .Include(sp => sp.Specialist)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(o => o.Office.City)
               .Include(dtc2 => dtc2.DoctorTreatmentCenters).ThenInclude(c => c.Clinic.City)
               .Include(di => di.DoctorInsurances).ThenInclude(i => i.Insurance)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.Turns)
               .AsQueryable();
            if (query.ProvinceId != null && query.ProvinceId != 0)
                q = q.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office.City.ProvinceId == query.ProvinceId));

            if (query.CityId != null && query.CityId != 0)
                q = q.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office.CityId == query.CityId));

            if (query.specialistIds != null && query.specialistIds != "")
            {
                List<int> csis = query.specialistIds.Split(',').Select(int.Parse).ToList();
                q = q.Where(x => csis.Contains(x.SpecialistId));
            }

            if (query.BimeAsli != null && query.BimeAsli != "")
            {
                List<Domain.Insurances.Insurance> li = await _Db.Insurances.ToListAsync();
                Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(query.BimeAsli);
                int levenshteinDistance = 1000;
                foreach (var item in li)
                {
                    if (levenshteinDistance > lev.DistanceFrom(item.Name))
                    {
                        levenshteinDistance = lev.DistanceFrom(item.Name);
                        query.BimeAsli = item.Name;
                    }
                }
                q = q.Where(x => x.DoctorInsurances.Any(x => x.Insurance.Name == query.BimeAsli));

            }

            if (query.BimehTakmili != null && query.BimehTakmili != "")
            {
                List<Domain.Insurances.Insurance> li = await _Db.Insurances.ToListAsync();
                Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(query.BimehTakmili);
                int levenshteinDistance = 1000;
                foreach (var item in li)
                {
                    if (levenshteinDistance > lev.DistanceFrom(item.Name))
                    {
                        levenshteinDistance = lev.DistanceFrom(item.Name);
                        query.BimehTakmili = item.Name;
                    }
                }
                q = q.Where(x => x.DoctorInsurances.Any(x => x.Insurance.Name == query.BimehTakmili));

            }

            if (query.JustOnline != null && query.JustOnline == true)
            {
                string JustOnlineCodes = "2,3,4";
                List<int> joc = JustOnlineCodes.Split(',').Select(int.Parse).ToList();
                q = q.Where(x => x.DoctorTreatmentCenters.Any(x => joc.Contains(x.Office.OfficeTypeId)));
            }

            if (query.HasTurn != null && query.HasTurn == true)
            {
                int actdate = DatetimeExtension.DateToNumber(DateTime.Now.ToPersianString());
                q = q.Where(x => x.Reservations.Any(x => x.ReservationDate >= actdate));

            }

            if (query.AcceptInsurance != null && query.AcceptInsurance == true)
                q = q.Where(x => x.DoctorInsurances.Any(x => x.InsuranceId >= 1));


            if (query.Gender != null)
                q = q.Where(x => x.Gender == query.Gender);


            if ((query.Sdate != null && query.Sdate != "") || (query.Edate != null && query.Edate != ""))
            {
                if (query.Sdate == null || query.Sdate == "")
                {
                    query.Sdate = DateTime.Now.ToPersianString();
                }
                if (query.Edate == null || query.Edate == "")
                {
                    query.Edate = "1500/01/01";
                }

                int isdate = DatetimeExtension.DateToNumber(query.Sdate);
                int iedate = DatetimeExtension.DateToNumber(query.Edate);

                q = q.Where(x => x.DoctorTreatmentCenters.Any(y => y.Reservations.Any(z => z.ReservationDate >= isdate && z.ReservationDate <= iedate)));

            }

            if (query.OnlineTypeId != null && query.OnlineTypeId != 0)
                q = q.Where(x => x.DoctorTreatmentCenters.Any(x => x.Office.OfficeTypeId == query.OnlineTypeId));

            if (query.OfficeOrClinicHozoori != null)
            {
                if ((bool)query.OfficeOrClinicHozoori)
                    q = q.Where(x => x.DoctorTreatmentCenters.Any(x => x.OfficeId == null));
                else
                    q = q.Where(x => x.DoctorTreatmentCenters.Any(x => x.ClinicId == null));
            }

            if (query.DoctorName.IsNotNullOrEmpty())
                q = q.Where(w => w.DoctorName.Contains(query.DoctorName) || w.DoctorFamily.Contains(query.DoctorName));

            if (query.doctorFamily.IsNotNullOrEmpty())
                q = q.Where(w => w.DoctorName.Contains(query.doctorFamily) || w.DoctorFamily.Contains(query.doctorFamily));

            query.TotalRecords = q.Count();

            var result = await q.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToListAsync();

            return result;
        }
        public async Task<Doctor> ReadDoctorById(int id)
        {
            //var result = await _Db.Doctors.FirstOrDefaultAsync(c => c.Id == id);

            //return result;
            var query = _Db.Doctors
               .Include(s => s.SmeProfile)
               .Include(sp => sp.Specialist)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(o => o.Office.City)
               .Include(dtc2 => dtc2.DoctorTreatmentCenters).ThenInclude(c => c.Clinic.City)
               .Include(di => di.DoctorInsurances).ThenInclude(i => i.Insurance)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(dtc1 => dtc1.DoctorTreatmentCenters).ThenInclude(r => r.Reservations).ThenInclude(v => v.Turns)
               .AsQueryable();

            var result = await query.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }
        public async Task<List<Doctor>> ReadDoctorBySmeProfileId(int smeProfileId)
        {
            var result = await _Db.Doctors.Where(c => c.SmeProfileId == smeProfileId).ToListAsync();

            return result;
        }
        public async Task<List<Doctor>> ReadDoctorBySpecialistId(int id)
        {
            var result = await _Db.Doctors.Where(c => c.SpecialistId == id).ToListAsync();

            return result;
        }

        public async Task Create(Doctor Doctor)
        {
            await _Db.Doctors.AddAsync(Doctor);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Customer.Doctor Doctor)
        {
            var result = await this.ReadDoctorById(Doctor.Id);


            result.DoctorName = Doctor.DoctorName;
            result.DoctorFamily = Doctor.DoctorFamily;
            result.NationalId = Doctor.NationalId;
            result.SpecialistId = Doctor.SpecialistId;
            result.CodeNezam = Doctor.CodeNezam;
            result.DocExperiance = Doctor.DocExperiance;
            result.DocInstaLink = Doctor.DocInstaLink;
            result.Mobile = Doctor.Mobile;
            result.Desc = Doctor.Desc;


            _Db.Doctors.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Doctors.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Doctors.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
