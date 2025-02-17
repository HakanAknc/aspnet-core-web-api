using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(string id);
        Task CreateDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(string id, Doctor doctor);
        Task DeleteDoctorAsync(string id);

        /*
         Tüm doktorları getir
         Belirli bir doktoru ID ile getir
         Yeni bir doktor oluştur
         Var olan bir doktoru güncelle
         Bir doktoru sil
        */
    }
}
