using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Infrastructure.Configurations
{
    /// <summary>
    /// EF6 Fluent API configuration for CompanyEntity → companies table.
    /// </summary>
    public class CompanyConfiguration : EntityTypeConfiguration<CompanyEntity>
    {
        public CompanyConfiguration()
        {
            // Table name
            ToTable("companies");

            // Primary key
            HasKey(c => c.pk_comp_id);

            // Properties
            Property(c => c.pk_comp_id)
                .HasColumnName("pk_comp_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.comp_name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("comp_name");

            Property(c => c.comp_gstin)
                .IsOptional()
                .HasMaxLength(15)
                .HasColumnName("comp_gstin");

            Property(c => c.comp_country)
                .IsOptional()
                .HasMaxLength(100)
                .HasColumnName("comp_country");

            Property(c => c.comp_state)
                .IsOptional()
                .HasMaxLength(100)
                .HasColumnName("comp_state");
        }
    }
}
