using KutuphaneYonetimSistemi.Models;
using MongoDB.Driver;

namespace KutuphaneYonetimSistemi.Services
{
    public class KitapService
    {
        private readonly IMongoCollection<Kitap> _kitaplar;

        public KitapService(DatabaseSettings settings, IMongoClient client)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _kitaplar = database.GetCollection<Kitap>("Kitaplar");
        }

        public async Task<List<Kitap>> GetirAsync() =>
            await _kitaplar.Find(_ => true).ToListAsync();

        public async Task<Kitap?> GetirIdAsync(string id) =>
            await _kitaplar.Find(k => k.Id == id).FirstOrDefaultAsync();

        public async Task EkleAsync(Kitap kitap) =>
            await _kitaplar.InsertOneAsync(kitap);

        public async Task GuncelleAsync(string id, Kitap kitap) =>
            await _kitaplar.ReplaceOneAsync(k => k.Id == id, kitap);

        public async Task SilAsync(string id) =>
            await _kitaplar.DeleteOneAsync(k => k.Id == id);
    }
}
