namespace CompanyManagementSystem.Domain.Entities
{
    /// <summary>
    /// Entity class mapping to the 'companies' database table.
    /// </summary>
    public class CompanyEntity
    {
        public int pk_comp_id { get; set; }
        public string comp_name { get; set; }
        public string comp_gstin { get; set; }
        public string comp_country { get; set; }
        public string comp_state { get; set; }
    }
}
