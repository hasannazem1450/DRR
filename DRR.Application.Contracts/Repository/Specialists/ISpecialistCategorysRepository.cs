﻿using DRR.Domain.Specialists;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Specialists
{
    public interface ISpecialistCategorysRepository : IRepository
    {
        Task<List<Specialist>> ReadSpecialistsByCategoryId(int id);
        Task<List<Category>> ReadCategoriesBySpecialistId(int id);
        Task Delete(int specialistid, int categoryid);

        Task Create(SpecialistCategory specialistCategory);
    }
}
