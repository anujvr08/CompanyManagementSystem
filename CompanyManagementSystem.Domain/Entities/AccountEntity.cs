namespace CompanyManagementSystem.Domain.Entities
{
    /// <summary>
    /// Entity class mapping to the 'accounts' database table.
    /// </summary>
    public class AccountEntity
    {
        public int pk_acc_id { get; set; }
        public string acc_name { get; set; }
        public string acc_group { get; set; }
        public decimal acc_balance { get; set; }
        public int fk_user_id { get; set; }
        public int fk_comp_id { get; set; }
    }
}
