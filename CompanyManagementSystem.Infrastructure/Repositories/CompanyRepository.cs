using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CompanyManagementSystem.Domain.Entities;
using CompanyManagementSystem.Infrastructure.Context;

namespace CompanyManagementSystem.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for Company CRUD operations.
    /// </summary>
    public class CompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save a new company to the database.
        /// </summary>
        public void Save(CompanyEntity entity)
        {
            try
            {
                _context.Companies.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error while saving company", ex);
            }
        }

        /// <summary>
        /// Get all companies.
        /// </summary>
        public List<CompanyEntity> GetAll()
        {
            return _context.Companies.ToList();
        }

        /// <summary>
        /// Get a company by its primary key.
        /// </summary>
        public CompanyEntity GetById(int id)
        {
            return _context.Companies.Find(id);
        }

        /// <summary>
        /// Check if a company name already exists (case-insensitive).
        /// </summary>
        public bool CheckNameExists(string companyName)
        {
            return _context.Companies
                .Any(c => c.comp_name.ToLower() == companyName.ToLower());
        }

        /// <summary>
        /// Check if any users exist in the given company.
        /// </summary>
        public bool CheckUsersExist(int companyId)
        {
            return _context.Users.Any(u => u.fk_comp_id == companyId);
        }
    }
}
