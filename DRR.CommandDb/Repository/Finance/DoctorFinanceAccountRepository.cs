using DRR.Application.Contracts.Repository.Finance;
using DRR.CommandDB;
using DRR.Domain.Finance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Finance
{
    class DoctorFinanceAccountRepository : BaseRepository, IDoctorFinanceAccountRepository
    {
        public DoctorFinanceAccountRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<DoctorFinanceAccount> ReadDoctorFinanceAccountById(int id)
        {
            var result = await _Db.DoctorFinanceAccounts.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<DoctorFinanceAccount>> ReadDoctorFinanceAccountByDoctorId(int id)
        {
            var result = await _Db.DoctorFinanceAccounts.Where(c => c.DoctorId == id).ToListAsync();

            return result;
        }
        public async Task Create(DoctorFinanceAccount DoctorFinanceAccount)
        {
            await _Db.DoctorFinanceAccounts.AddAsync(DoctorFinanceAccount);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Finance.DoctorFinanceAccount DoctorFinanceAccount)
        {
            var result = await this.ReadDoctorFinanceAccountById(DoctorFinanceAccount.Id);

            result.DoctorId = DoctorFinanceAccount.DoctorId;
            result.Shebanumber = DoctorFinanceAccount.Shebanumber;
            result.Accountnumber = DoctorFinanceAccount.Accountnumber;
            result.TerminalId = DoctorFinanceAccount.TerminalId;
            result.Ip = DoctorFinanceAccount.Ip;
            result.Pass = DoctorFinanceAccount.Pass;
            result.URL = DoctorFinanceAccount.URL;
            result.GateName = DoctorFinanceAccount.GateName;
            result.GateId = DoctorFinanceAccount.GateId;
            result.DoctorPortion = DoctorFinanceAccount.DoctorPortion;
            result.CenterPortion = DoctorFinanceAccount.CenterPortion;
            result.DirectToAccout = DoctorFinanceAccount.DirectToAccout;
            result.PrePayment = DoctorFinanceAccount.PrePayment;



            _Db.DoctorFinanceAccounts.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.DoctorFinanceAccounts.FirstOrDefaultAsync(n => n.Id == id);

            _Db.DoctorFinanceAccounts.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
