﻿using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDB;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.TreatmentCentres
{
    class OfficeTypeRepository : BaseRepository, IOfficeTypeRepository
    {
        public OfficeTypeRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<OfficeType> ReadOfficeTypeById(int id)
        {
            var result = await _Db.OfficeTypes.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task Create(OfficeType OfficeType)
        {
            await _Db.OfficeTypes.AddAsync(OfficeType);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.TreatmentCenters.OfficeType OfficeType)
        {
            var result = await this.ReadOfficeTypeById(OfficeType.Id);

            result.Type = OfficeType.Type;


            _Db.OfficeTypes.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.OfficeTypes.FirstOrDefaultAsync(n => n.Id == id);

            _Db.OfficeTypes.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}