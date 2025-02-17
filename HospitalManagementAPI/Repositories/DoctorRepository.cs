using HospitalManagementAPI.Models;
using MongoDB.Driver;

namespace HospitalManagementAPI.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IMongoCollection<Doctor> _doctors;

        public DoctorRepository(IMongoDatabase database)
        {
            _doctors = database.GetCollection<Doctor>("doctors");
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctors.Find(doctor => true).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _doctors.Find(doctor => doctor.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _doctors.InsertOneAsync(doctor);
        }
        public async Task UpdateDoctorAsync(string id, Doctor doctor)
        {
            await _doctors.ReplaceOneAsync(d => d.Id == id, doctor);
        }

        public async Task DeleteDoctorAsync(string id)
        {
            await _doctors.DeleteOneAsync(doctor => doctor.Id == id);
        }

        /*
        Bu sınıf, IDoctorRepository’yi uygular ve MongoDB ile bağlantıyı kurar.
        MongoDB’den doktorları getirir
        Doktor ekler, günceller ve siler
        */
    }
}
