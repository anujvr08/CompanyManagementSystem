using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagementSystem.Domain.Entities;
using CompanyManagementSystem.Infrastructure.Context;

namespace CompanyManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for User CRUD and authentication operations.
    /// </summary>
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save a new user to the database.
        /// </summary>
        public void Save(UserEntity entity)
        {
            try
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error while saving user", ex);
            }
        }

        /// <summary>
        /// Get all users belonging to a specific company.
        /// </summary>
        public List<UserEntity> GetByCompanyId(int companyId)
        {
            return _context.Users
                .Where(u => u.fk_comp_id == companyId)
                .ToList();
        }

        /// <summary>
        /// Authenticate a user by checking username and password for a given company.
        /// Returns the UserEntity if credentials are valid, null otherwise.
        /// </summary>
        public UserEntity CheckCredentials(int companyId, string username, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                u.fk_comp_id == companyId &&
                u.user_name == username &&
                u.user_password == password);
        }

        /// <summary>
        /// Check if a username already exists within a company.
        /// </summary>
        public bool CheckUsernameExists(int companyId, string username)
        {
            return _context.Users.Any(u =>
                u.fk_comp_id == companyId &&
                u.user_name.ToLower() == username.ToLower());
        }
    }
}
