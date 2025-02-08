﻿using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reserv
{
    public interface ITurnRepository : IRepository
    {
        
        Task<List<Turn>> GetTurnsByReservationId(int reservationId);
        Task<Turn> ReadTurnById(int id);
        Task Create(Turn trun);
        Task Delete(int id);
        Task UpdateGet(Turn trun);
        Task UpdateCancel(Turn trun);



    }
}
