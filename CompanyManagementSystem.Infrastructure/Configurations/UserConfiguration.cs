using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Infrastructure.Configurations
{
    /// <summary>
    /// EF6 Fluent API configuration for UserEntity → users table.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            // Table name
            ToTable("users");

            // Primary key
            HasKey(u => u.pk_user_id);

            // Properties
            Property(u => u.pk_user_id)
                .HasColumnName("pk_user_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.user_name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("user_name");

            Property(u => u.user_password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("user_password");

            Property(u => u.fk_comp_id)
                .IsRequired()
                .HasColumnName("fk_comp_id");
        }
    }
}
