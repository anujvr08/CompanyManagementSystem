using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.GlobalVars;
using CompanyManagementSystem.Infrastructure.Repositories;

namespace CompanyManagementSystem.Application.Services
{
    /// <summary>
    /// Service for account business logic with user-level filtering.
    /// </summary>
    public class AccountService
    {
        private readonly AccountRepository _accountRepo;
        private readonly AccountMapper _mapper;

        public AccountService(AccountRepository accountRepo, AccountMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Save a new account. Automatically assigns the current company and user.
        /// </summary>
        public void SaveAccount(AccountDTO dto)
        {
            // Set company from global state
            dto.CompanyId = GlobalConstants.CurrentCompanyId;

            // Set user: stores the current user ID (0 if not logged in)
            dto.UserId = GlobalConstants.CurrentUserId;

            var entity = _mapper.ToEntity(dto);
            _accountRepo.Save(entity);
        }

        /// <summary>
        /// Get accounts based on current user context.
        /// Rule: If no user logged in → show accounts with NULL user.
        ///       If user logged in → show only that user's accounts.
        /// </summary>
        public List<AccountDTO> GetAccountsForCurrentUser()
        {
            List<AccountDTO> result;

            if (GlobalConstants.CurrentUserId == 0)
            {
                // No user logged in - show accounts without assigned user
                var entities = _accountRepo.GetAccountsWithoutUser(
                    GlobalConstants.CurrentCompanyId);
                result = entities.Select(e => _mapper.ToDTO(e)).ToList();
            }
            else
            {
                // Show only current user's accounts
                var entities = _accountRepo.GetAccountsByUser(
                    GlobalConstants.CurrentUserId);
                result = entities.Select(e => _mapper.ToDTO(e)).ToList();
            }

            return result;
        }
    }
}
