using ECommerceApi.Models;
using MongoDB.Driver;

namespace ECommerceApi.Repositories
{
    public class WalletRepository
    {
        private readonly IMongoCollection<Wallet> _walletCollection;

        public WalletRepository(IMongoDatabase database)
        {
            _walletCollection = database.GetCollection<Wallet>("Wallets");
        }

        public async Task<Wallet> GetWalletByUserIdAsync(string userId)
        {
            return await _walletCollection.Find(w => w.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task UpdateWalletBalanceAsync(string userId, decimal amount)
        {
            var update = Builders<Wallet>.Update.Inc(w => w.Balance, amount);
            await _walletCollection.UpdateOneAsync(w => w.UserId == userId, update, new UpdateOptions { IsUpsert = true });
        }
    }
}
