using HospitalManagementAPI.Models;
using HospitalManagementAPI.Repositories;

namespace HospitalManagementAPI.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id);
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.CreateDoctorAsync(doctor);
        }

        public async Task UpdateDoctorAsync(string id, Doctor doctor)
        {
            await _doctorRepository.UpdateDoctorAsync(id, doctor);
        }

        public async Task DeleteDoctorAsync(string id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
        }

        /*
         Tüm doktorları getirir
         ID’ye göre doktoru getirir
         Yeni doktor oluşturur
         Mevcut doktoru günceller
         Doktoru siler 
         */
    }
}
