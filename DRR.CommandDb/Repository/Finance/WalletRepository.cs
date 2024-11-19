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
    class WalletRepository : BaseRepository, IWalletRepository
    {
        public WalletRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<Wallet> ReadWalletById(int id)
        {
            var result = await _Db.Wallets.FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Wallet>> ReadWalletByUserId(int id)
        {
            var result = await _Db.Wallets.Where(c => c.SmeProfileId == id).ToListAsync();

            return result;
        }
        public async Task Create(Wallet Wallet)
        {
            await _Db.Wallets.AddAsync(Wallet);
            await _Db.SaveChangesAsync();
        }
        public async Task Update(Domain.Finance.Wallet Wallet)
        {
            var result = await this.ReadWalletById(Wallet.Id);

            result.SmeProfileId = Wallet.SmeProfileId;
            result.Amount = Wallet.Amount;


            _Db.Wallets.Update(result);

            await _Db.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var result = await _Db.Wallets.FirstOrDefaultAsync(n => n.Id == id);

            _Db.Wallets.Remove(result);

            await _Db.SaveChangesAsync();
        }

    }

}
