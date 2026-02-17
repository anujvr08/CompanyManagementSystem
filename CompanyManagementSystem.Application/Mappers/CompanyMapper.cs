using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Application.Mappers
{
    /// <summary>
    /// Converts between CompanyDTO and CompanyEntity.
    /// </summary>
    public class CompanyMapper
    {
        /// <summary>
        /// Convert CompanyDTO → CompanyEntity (for saving to DB).
        /// </summary>
        public CompanyEntity ToEntity(CompanyDTO dto)
        {
            return new CompanyEntity
            {
                pk_comp_id = dto.CompanyId,
                comp_name = dto.CompanyName,
                comp_gstin = dto.GSTIN,
                comp_country = dto.Country,
                comp_state = dto.State
            };
        }

        /// <summary>
        /// Convert CompanyEntity → CompanyDTO (for displaying in UI).
        /// </summary>
        public CompanyDTO ToDTO(CompanyEntity entity)
        {
            return new CompanyDTO
            {
                CompanyId = entity.pk_comp_id,
                CompanyName = entity.comp_name,
                GSTIN = entity.comp_gstin,
                Country = entity.comp_country,
                State = entity.comp_state
            };
        }
    }
}
