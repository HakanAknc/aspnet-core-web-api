namespace UserManagementApi.DTOs
{
    public class GetUserDTO
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BirthPlace { get; set; }
        public int BirthYear { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        
    }
}
