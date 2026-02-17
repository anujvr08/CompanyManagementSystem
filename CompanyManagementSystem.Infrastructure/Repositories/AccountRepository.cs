using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagementSystem.Domain.Entities;
using CompanyManagementSystem.Infrastructure.Context;

namespace CompanyManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for Account CRUD operations with user-level filtering.
    /// </summary>
    public class AccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save a new account to the database.
        /// </summary>
        public void Save(AccountEntity entity)
        {
            try
            {
                _context.Accounts.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error while saving account", ex);
            }
        }

        /// <summary>
        /// Get accounts created by a specific user.
        /// Used when a user is logged in (CurrentUserId > 0).
        /// </summary>
        public List<AccountEntity> GetAccountsByUser(int userId)
        {
            return _context.Accounts
                .Where(a => a.fk_user_id == userId)
                .ToList();
        }

        /// <summary>
        /// Get accounts that have no assigned user (fk_user_id IS NULL)
        /// for a specific company. Used when no user is logged in.
        /// </summary>
        public List<AccountEntity> GetAccountsWithoutUser(int companyId)
        {
            return _context.Accounts
                .Where(a => a.fk_comp_id == companyId && a.fk_user_id == 0)
                .ToList();
        }

        /// <summary>
        /// Get all accounts for a company (no user filtering).
        /// </summary>
        public List<AccountEntity> GetAllByCompany(int companyId)
        {
            return _context.Accounts
                .Where(a => a.fk_comp_id == companyId)
                .ToList();
        }
    }
}
