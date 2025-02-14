namespace UserManagementApi.DTOs
{
    public class CreateUserDTO
    {
        public string Tc { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int BirthYear { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
