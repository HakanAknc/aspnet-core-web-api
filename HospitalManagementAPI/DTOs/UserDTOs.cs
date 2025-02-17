namespace HospitalManagementAPI.DTOs
{
    public class UserDTOs
    {
        public class GetUserDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Job { get; set; }
        }

        public class CreateUserDTO
        {
            public string Tc { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int BirthYear { get; set; }
            public string BirthPlace { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Job { get; set; }
            public decimal Wage { get; set; }
        }

        public class UpdateUserDTO
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Job { get; set; }
            public decimal Wage { get; set; }
        }
    }
}
