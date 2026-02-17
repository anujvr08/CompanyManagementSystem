namespace CompanyManagementSystem.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object for Account data between layers.
    /// </summary>
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Group { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
