using KutuphaneYonetimSistemi.Models;
using KutuphaneYonetimSistemi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneYonetimSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private readonly KitapService _kitapService;

        public KitapController(KitapService kitapService)
        {
            _kitapService = kitapService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kitap>>> Getir() =>
            await _kitapService.GetirAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Kitap>> GetirId(string id)
        {
            var kitap = await _kitapService.GetirIdAsync(id);

            if (kitap == null)
                return NotFound();

            return kitap;
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Kitap kitap)
        {
            await _kitapService.EkleAsync(kitap);
            return CreatedAtAction(nameof(GetirId), new { id = kitap.Id }, kitap);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Guncelle(string id, Kitap kitap)
        {
            var mevcutKitap = await _kitapService.GetirIdAsync(id);

            if (mevcutKitap == null)
                return NotFound();

            kitap.Id = mevcutKitap.Id;
            await _kitapService.GuncelleAsync(id, kitap);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Sil(string id)
        {
            var kitap = await _kitapService.GetirIdAsync(id);

            if (kitap == null)
                return NotFound();

            await _kitapService.SilAsync(id);

            return NoContent();
        }
    }
}
