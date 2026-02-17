namespace CompanyManagementSystem.Domain.Entities
{
    /// <summary>
    /// Entity class mapping to the 'users' database table.
    /// </summary>
    public class UserEntity
    {
        public int pk_user_id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public int fk_comp_id { get; set; }
    }
}
