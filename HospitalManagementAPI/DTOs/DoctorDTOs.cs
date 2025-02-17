namespace HospitalManagementAPI.DTOs
{
    public class DoctorDTOs
    {
        // GET , Read
        public class GetDoctorDTO
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string AreaOf​​Expertise { get; set; }
            public string Email { get; set; }
        }

        // POST , Create
        public class CreateDoctorDTO
        {
            public string Tc { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string AreaOf​​Expertise { get; set; }
            public int BirthYear { get; set; }
            public string BirthPlace { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public decimal Wage { get; set; }
        }

        // PUT , 
        public class UpdateDoctorDTO
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string AreaOf​​Expertise { get; set; }
            public string Email { get; set; }
            public decimal Wage { get; set; }
        }
    }
}
