using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Infrastructure.Configurations
{
    /// <summary>
    /// EF6 Fluent API configuration for AccountEntity → accounts table.
    /// </summary>
    public class AccountConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        public AccountConfiguration()
        {
            // Table name
            ToTable("accounts");

            // Primary key
            HasKey(a => a.pk_acc_id);

            // Properties
            Property(a => a.pk_acc_id)
                .HasColumnName("pk_acc_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.acc_name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("acc_name");

            Property(a => a.acc_group)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("acc_group");

            Property(a => a.acc_balance)
                .HasColumnName("acc_balance")
                .HasPrecision(18, 2);

            Property(a => a.fk_user_id)
                .IsOptional()
                .HasColumnName("fk_user_id");

            Property(a => a.fk_comp_id)
                .IsRequired()
                .HasColumnName("fk_comp_id");
        }
    }
}
