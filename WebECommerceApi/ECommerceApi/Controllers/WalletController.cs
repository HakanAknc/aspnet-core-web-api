using ECommerceApi.Models;
using ECommerceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        // Kullanıcının cüzdan bakiyesini getir
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWalletByUserId(string userId)
        {
            var wallet = await _walletService.GetWalletByUserIdAsync(userId);
            if (wallet == null) return NotFound("Cüzdan bulunamadı.");
            return Ok(wallet);
        }

        // Cüzdan bakiyesini artır
        [HttpPut("add/{userId}")]
        public async Task<IActionResult> AddBalance(string userId, decimal amount)
        {
            if (amount <= 0) return BadRequest("Geçersiz bakiye miktarı.");
            await _walletService.UpdateWalletBalanceAsync(userId, amount);
            return NoContent();
        }

        // Cüzdan bakiyesini düşür
        [HttpPut("deduct/{userId}")]
        public async Task<IActionResult> DeductBalance(string userId, decimal amount)
        {
            if (amount <= 0) return BadRequest("Geçersiz bakiye miktarı.");

            var wallet = await _walletService.GetWalletByUserIdAsync(userId);
            if (wallet == null || wallet.Balance < amount) return BadRequest("Yetersiz bakiye.");

            await _walletService.UpdateWalletBalanceAsync(userId, -amount);
            return NoContent();
        }
    }
}
