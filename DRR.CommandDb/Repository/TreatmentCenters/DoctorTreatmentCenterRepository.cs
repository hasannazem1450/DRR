﻿using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Specialists;
using DRR.Utilities.Extensions;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using System.Diagnostics.Eventing.Reader;
using DRR.Application.Contracts.Commands.Information;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    public class DoctorTreatmentCenterRepository : BaseRepository, IDoctorTreatmentCenterRepository
    {
        public DoctorTreatmentCenterRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<DoctorTreatmentCenter>> Search(SearchDoctorTreatmentCentersQuery query)
        {
            var q = _Db.DoctorTreatmentCenters
               .Include(d => d.Doctor).ThenInclude(sp => sp.Specialist)
               .Include(d => d.Doctor).ThenInclude(di => di.DoctorInsurances).ThenInclude(i => i.Insurance)
               .Include(o => o.Office).ThenInclude(oc => oc.City)
               .Include(c => c.Clinic).ThenInclude(cc => cc.City)
               .Include(r => r.Reservations).ThenInclude(v => v.VisitCost).ThenInclude(vt => vt.VisitType)
               .Include(r => r.Reservations).ThenInclude(v => v.Turns)
               .AsQueryable();
            if (query.DoctorTreatmentCenterName != null && query.DoctorTreatmentCenterName != "")
            {
                q = q.Where(x => x.Clinic.Name.Contains(query.DoctorTreatmentCenterName) || x.Office.Name.Contains(query.DoctorTreatmentCenterName));
            }

            if (query.ProvinceId != null && query.ProvinceId != 0)
                q = q.Where(x => x.Office.City.ProvinceId == query.ProvinceId);

            if (query.CityId != null && query.CityId != 0)
                q = q.Where(x => x.Office.CityId == query.CityId);

            if (query.specialistIds != null && query.specialistIds != "")
            {
                List<int> csis = query.specialistIds.Split(',').Select(int.Parse).ToList();
                q = q.Where(x => csis.Contains(x.Doctor.SpecialistId));
            }

            if (query.BimeAsli != null && query.BimeAsli != "")
            {
                List<Domain.Insurances.Insurance> li = await _Db.Insurances.ToListAsync();
                Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(query.BimeAsli);
                int levenshteinDistance = 20;
                foreach (var item in li)
                {
                    if (levenshteinDistance > lev.DistanceFrom(item.Name))
                    {
                        levenshteinDistance = lev.DistanceFrom(item.Name);
                        query.BimeAsli = item.Name;
                    }
                }
                q = q.Where(x => x.Doctor.DoctorInsurances.Any(x => x.Insurance.Name == query.BimeAsli));

            }

            if (query.BimehTakmili != null && query.BimehTakmili != "")
            {
                List<Domain.Insurances.Insurance> li = await _Db.Insurances.ToListAsync();
                Fastenshtein.Levenshtein lev = new Fastenshtein.Levenshtein(query.BimehTakmili);
                int levenshteinDistance = 20;
                int dis = 0;
                foreach (var item in li)
                {
                    dis = lev.DistanceFrom(item.Name);
                    if (levenshteinDistance > lev.DistanceFrom(item.Name))
                    {
                        levenshteinDistance = lev.DistanceFrom(item.Name);
                        query.BimehTakmili = item.Name;
                    }
                }
                q = q.Where(x => x.Doctor.DoctorInsurances.Any(x => x.Insurance.Name == query.BimehTakmili));

            }

            if (query.JustOnline != null && query.JustOnline == true)
            {
                string JustOnlineCodes = "2,3,4";
                List<int> joc = JustOnlineCodes.Split(',').Select(int.Parse).ToList();
                q = q.Where(x => joc.Contains(x.Office.OfficeTypeId));
            }

            if (query.HasTurn != null && query.HasTurn == true)
            {
                int actdate = DatetimeExtension.DateToNumber(DateTime.Now.ToPersianString());
                q = q.Where(x => x.Reservations.Any(x => x.ReservationDate >= actdate));

            }

            if (query.AcceptInsurance != null && query.AcceptInsurance == true)
                q = q.Where(x => x.Doctor.DoctorInsurances.Any(x => x.InsuranceId >= 1));


            if (query.Gender != null)
                q = q.Where(x => x.Doctor.Gender == query.Gender);


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

                q = q.Where(x => x.Doctor.DoctorTreatmentCenters.Any(y => y.Reservations.Any(z => z.ReservationDate >= isdate && z.ReservationDate <= iedate)));

            }

            if (query.OnlineTypeId != null && query.OnlineTypeId != 0)
                q = q.Where(x => x.Doctor.DoctorTreatmentCenters.Any(x => x.Office.OfficeTypeId == query.OnlineTypeId));

            if (query.OfficeOrClinicHozoori != null)
            {
                if ((bool)query.OfficeOrClinicHozoori)
                    q = q.Where(x => x.Doctor.DoctorTreatmentCenters.Any(x => x.OfficeId == null));
                else
                    q = q.Where(x => x.Doctor.DoctorTreatmentCenters.Any(x => x.ClinicId == null));
            }

            if (query.DoctorName.IsNotNullOrEmpty())
                q = q.Where(w => w.Doctor.DoctorName.Contains(query.DoctorName) || w.Doctor.DoctorFamily.Contains(query.DoctorName));

            if (query.doctorFamily.IsNotNullOrEmpty())
                q = q.Where(w => w.Doctor.DoctorName.Contains(query.doctorFamily) || w.Doctor.DoctorFamily.Contains(query.doctorFamily));

            query.TotalRecords = q.Count();
            if (query.TotalRecords == 0)
            {
                if (query.DoctorTreatmentCenterName != null && query.DoctorTreatmentCenterName != "")
                {
                    List<DoctorTreatmentCenter> ldt = await _Db.DoctorTreatmentCenters
                         .Include(o => o.Office)
                         .Include(c => c.Clinic)
                        .ToListAsync();
                    Fastenshtein.Levenshtein levdt = new Fastenshtein.Levenshtein(query.DoctorTreatmentCenterName);

                    int levenshteinDistancedt = 20;
                    int disdto = 0;
                    int disdtc = 0;
                    foreach (var item in ldt)
                    {
                        if (item.Office != null)
                        {
                            disdto = levdt.DistanceFrom(item.Office.Name);
                            if (levenshteinDistancedt > levdt.DistanceFrom(item.Office.Name))
                            {
                                levenshteinDistancedt = levdt.DistanceFrom(item.Office.Name);
                                query.DoctorTreatmentCenterName = item.Office.Name;
                            }
                        }
                        if (item.Clinic != null)
                        {
                            disdtc = levdt.DistanceFrom(item.Clinic.Name);
                            if (levenshteinDistancedt > levdt.DistanceFrom(item.Clinic.Name))
                            {
                                levenshteinDistancedt = levdt.DistanceFrom(item.Clinic.Name);
                                query.DoctorTreatmentCenterName = item.Clinic.Name;
                            }
                        }
                    }
                    q = q.Where(x => x.Clinic.Name.Contains(query.DoctorTreatmentCenterName) || x.Office.Name.Contains(query.DoctorTreatmentCenterName));
                }

            }
            var result = await q.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToListAsync();

            return result;
        }

        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterCountOfDoctorsAndSpecialistsByGuId(Guid guid)
        {
            var query = _Db.DoctorTreatmentCenters
               .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
               .AsQueryable();


            var result = await query.Where(c => c.ClinicId == guid || c.OfficeId == guid).ToListAsync();

            return result;

        }
        public async Task<List<DoctorTreatmentCenter>> ReadAllDoctorTreatmentCenters()
        {
            var query = _Db.DoctorTreatmentCenters
                .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
                .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
                .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Office).ThenInclude(c => c.OfficeType)
                .Include(x => x.Reservations).ThenInclude(t => t.Turns)
                .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
                .AsQueryable();

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<DoctorTreatmentCenter> ReadDoctorTreatmentCenterById(int id)
        {
            var query = _Db.DoctorTreatmentCenters
                .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
                .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
                .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Office).ThenInclude(c => c.OfficeType)
                .Include(x => x.Reservations).ThenInclude(t => t.Turns)
                .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
                .AsQueryable();


            var result = await query.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByNameSSR(string nameSSR)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Doctor).ThenInclude(s => s.DoctorInsurances).ThenInclude(i => i.Insurance)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .AsQueryable();

            var result = await query.Where(c => c.Clinic.Name == nameSSR || c.Office.Name == nameSSR).ToListAsync();
            return result;
        }

        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorId(int id)
        {
            var query = _Db.DoctorTreatmentCenters
               .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
               .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
               .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
               .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
               .Include(x => x.Office).ThenInclude(c => c.OfficeType)
               .Include(x => x.Reservations).ThenInclude(t => t.Turns)
               .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
               .AsQueryable();
            var result = await query.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByOfficeId(Guid? id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.OfficeId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByClinicId(Guid? id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.ClinicId == id).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdHozoori(int id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.Doctor.Id == id && (c.Clinic != null || c.Office.OfficeType.Id == 1)).ToListAsync();

            return result;
        }
        public async Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdOnline(int id)
        {
            var query = _Db.DoctorTreatmentCenters
              .Include(x => x.Doctor).ThenInclude(s => s.Specialist)
              .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Clinic).ThenInclude(c => c.ClinicType)
              .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
              .Include(x => x.Office).ThenInclude(c => c.OfficeType)
              .Include(x => x.Reservations).ThenInclude(t => t.Turns)
              .Include(x => x.Reservations).ThenInclude(v => v.VisitCost)
              .AsQueryable();

            var result = await query.Where(c => c.Doctor.Id == id && (c.Clinic == null && c.Office.OfficeType.Id != 1)).ToListAsync();

            return result;
        }
        public async Task Create(DoctorTreatmentCenter DoctorTreatmentCenter)
        {
            await _Db.DoctorTreatmentCenters.AddAsync(DoctorTreatmentCenter);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.DoctorTreatmentCenter DoctorTreatmentCenter)
        {
            var result = await this.ReadDoctorTreatmentCenterById(DoctorTreatmentCenter.Id);

            result.DoctorId = DoctorTreatmentCenter.DoctorId;
            result.ClinicId = DoctorTreatmentCenter.ClinicId;
            result.OfficeId = DoctorTreatmentCenter.OfficeId;
            result.Desc = DoctorTreatmentCenter.Desc;


            _Db.DoctorTreatmentCenters.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.DoctorTreatmentCenters.FirstOrDefaultAsync(n => n.Id == id);

            _Db.DoctorTreatmentCenters.Remove(result);

            await _Db.SaveChangesAsync();
        }

        public async Task<List<TreatmentCenterSearchDto>> MainSearch(List<string> searchTerms)
        {
            var query = _Db.DoctorTreatmentCenters
                .Include(x => x.Clinic).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Include(x => x.Office).ThenInclude(c => c.City).ThenInclude(p => p.Province)
                .Where(w => !w.IsDeleted);

            foreach (var searchTerm in searchTerms.Where(w => w.IsNotNullOrEmpty()))
                query = query.Where(w =>
                    w.Clinic.Name.Contains(searchTerm) || w.Clinic.City.Name.Contains(searchTerm) || w.Clinic.City.Province.Name.Contains(searchTerm) ||
                    w.Clinic.Name.Contains(searchTerm) || w.Office.City.Name.Contains(searchTerm) || w.Office.City.Province.Name.Contains(searchTerm)
                );


            if (query.Count() == 0)
            {
                string fullterm = "";
                foreach (var searchTerm in searchTerms.Where(w => w.IsNotNullOrEmpty()))
                {
                    fullterm = searchTerm + " ";
                }

                Fastenshtein.Levenshtein levdt = new Fastenshtein.Levenshtein(fullterm);

                int levenshteinDistancedt = 20;
                int disdto = 0;
                int disdtc = 0;
                List<DoctorTreatmentCenter> ldt = await _Db.DoctorTreatmentCenters
                         .Include(o => o.Office)
                         .Include(c => c.Clinic)
                        .ToListAsync();
                foreach (var item in ldt)
                {
                    if (item.Office != null)
                    {
                        disdto = levdt.DistanceFrom(item.Office.Name);
                        if (levenshteinDistancedt > levdt.DistanceFrom(item.Office.Name))
                        {
                            levenshteinDistancedt = levdt.DistanceFrom(item.Office.Name);
                            fullterm = item.Office.Name;
                        }
                    }
                    if (item.Clinic != null)
                    {
                        disdtc = levdt.DistanceFrom(item.Clinic.Name);
                        if (levenshteinDistancedt > levdt.DistanceFrom(item.Clinic.Name))
                        {
                            levenshteinDistancedt = levdt.DistanceFrom(item.Clinic.Name);
                            fullterm = item.Clinic.Name;
                        }
                    }
                }
                query = query.Where(x => x.Clinic.Name.Contains(fullterm) || x.Office.Name.Contains(fullterm));

            }
            var result1 = await query.Select(x => new TreatmentCenterSearchDto { Result= x.Clinic.Name,Link = x.Clinic.Name  }).Distinct().ToListAsync();
            //var result = await query.ToListAsync();

            return result1;
        }
    }

}
