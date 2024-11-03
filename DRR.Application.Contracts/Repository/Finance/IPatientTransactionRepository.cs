using DRR.Domain.Finance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Finance
{
    public interface IPatientTransactionRepository : IRepository
    {
        Task<PatientTransaction> ReadPatientTransactionById(int id);
        Task<List<PatientTransaction>> ReadPatientTransactionByPatientId(int id);
        Task<List<PatientTransaction>> ReadPatientTransactionByPatientReservationId(int id);



        Task Delete(int id);

        Task Update(Domain.Finance.PatientTransaction patientTransaction);

        Task Create(Domain.Finance.PatientTransaction patientTransaction);
    }

}
