using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Application.Mappers
{
    /// <summary>
    /// Converts between AccountDTO and AccountEntity.
    /// </summary>
    public class AccountMapper
    {
        /// <summary>
        /// Convert AccountDTO → AccountEntity (for saving to DB).
        /// </summary>
        public AccountEntity ToEntity(AccountDTO dto)
        {
            return new AccountEntity
            {
                pk_acc_id = dto.AccountId,
                acc_name = dto.AccountName,
                acc_group = dto.Group,
                acc_balance = dto.Balance,
                fk_user_id = dto.UserId,
                fk_comp_id = dto.CompanyId
            };
        }

        /// <summary>
        /// Convert AccountEntity → AccountDTO (for displaying in UI).
        /// </summary>
        public AccountDTO ToDTO(AccountEntity entity)
        {
            return new AccountDTO
            {
                AccountId = entity.pk_acc_id,
                AccountName = entity.acc_name,
                Group = entity.acc_group,
                Balance = entity.acc_balance,
                UserId = entity.fk_user_id,
                CompanyId = entity.fk_comp_id
            };
        }
    }
}
