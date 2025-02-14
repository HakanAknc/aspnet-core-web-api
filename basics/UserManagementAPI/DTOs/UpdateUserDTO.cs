namespace UserManagementApi.DTOs
{
    public class UpdateUserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
