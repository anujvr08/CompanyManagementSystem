using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Application.Mappers
{
    /// <summary>
    /// Converts between UserDTO and UserEntity.
    /// </summary>
    public class UserMapper
    {
        /// <summary>
        /// Convert UserDTO → UserEntity (for saving to DB).
        /// </summary>
        public UserEntity ToEntity(UserDTO dto)
        {
            return new UserEntity
            {
                pk_user_id = dto.UserId,
                user_name = dto.UserName,
                user_password = dto.Password,
                fk_comp_id = dto.CompanyId
            };
        }

        /// <summary>
        /// Convert UserEntity → UserDTO (for displaying in UI).
        /// </summary>
        public UserDTO ToDTO(UserEntity entity)
        {
            return new UserDTO
            {
                UserId = entity.pk_user_id,
                UserName = entity.user_name,
                Password = entity.user_password,
                CompanyId = entity.fk_comp_id
            };
        }
    }
}
