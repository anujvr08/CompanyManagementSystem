namespace CompanyManagementSystem.Domain.DTOs
{
    /// <summary>
    /// Data Transfer Object for Company data between layers.
    /// </summary>
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string GSTIN { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
