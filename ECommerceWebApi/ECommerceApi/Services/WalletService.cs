using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class WalletService
    {
        private readonly WalletRepository _walletRepository;

        public WalletService(WalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public Task<Wallet> GetWalletByUserIdAsync(string userId) => _walletRepository.GetWalletByUserIdAsync(userId);

        public Task UpdateWalletBalanceAsync(string userId, decimal amount) => _walletRepository.UpdateWalletBalanceAsync(userId, amount);
    }
}
