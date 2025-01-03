using DRR.Application.Contracts.Repository.Finance;
using DRR.CommandDB;
using DRR.Domain.Finance;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Finance
{
    public class PatientTransactionRepository : BaseRepository, IPatientTransactionRepository
    {
        public PatientTransactionRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<PatientTransaction> ReadPatientTransactionById(int id)
        {
            var result = await _Db.PatientTransactions.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<PatientTransaction>> ReadPatientTransactionByPatientId(int id)
        {
            var result = await _Db.PatientTransactions.Where(c => c.PatientId == id).ToListAsync();

            return result;
        }
        public async Task<List<PatientTransaction>> ReadPatientTransactionByPatientReservationId(int id)
        {
            var result = await _Db.PatientTransactions.Where(c => c.PatientReservationId == id).ToListAsync();

            return result;
        }
        public async Task Create(PatientTransaction PatientTransaction)
        {
            await _Db.PatientTransactions.AddAsync(PatientTransaction);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Finance.PatientTransaction PatientTransaction)
        {
            var result = await this.ReadPatientTransactionById(PatientTransaction.Id);

            result.PatientId = PatientTransaction.PatientId;
            result.TransactionDate = PatientTransaction.TransactionDate;
            result.PaymentNumber = PatientTransaction.PaymentNumber;
            result.PatientReservationId = PatientTransaction.PatientReservationId;


            _Db.PatientTransactions.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.PatientTransactions.FirstOrDefaultAsync(n => n.Id == id);

            _Db.PatientTransactions.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
