namespace CompanyManagementSystem.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object for User data between layers.
    /// </summary>
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
    }
}
