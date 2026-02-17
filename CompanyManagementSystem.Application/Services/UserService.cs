using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Infrastructure.Repositories;

namespace CompanyManagementSystem.Application.Services
{
    /// <summary>
    /// Service for user business logic, authentication, and orchestration.
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _userRepo;
        private readonly UserMapper _mapper;

        public UserService(UserRepository userRepo, UserMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Save a new user. Checks for duplicate usernames within the company.
        /// </summary>
        public void SaveUser(UserDTO dto)
        {
            // Business rule: username must be unique within a company
            if (_userRepo.CheckUsernameExists(dto.CompanyId, dto.UserName))
            {
                throw new Exception("Username already exists in this company");
            }

            var entity = _mapper.ToEntity(dto);
            _userRepo.Save(entity);
        }

        /// <summary>
        /// Authenticate user credentials for a given company.
        /// Returns UserDTO if valid, null if invalid.
        /// </summary>
        public UserDTO Authenticate(int companyId, string username, string password)
        {
            var entity = _userRepo.CheckCredentials(companyId, username, password);

            if (entity == null)
            {
                return null;
            }

            return _mapper.ToDTO(entity);
        }

        /// <summary>
        /// Get all users for a specific company.
        /// </summary>
        public List<UserDTO> GetUsersByCompany(int companyId)
        {
            var entities = _userRepo.GetByCompanyId(companyId);
            return entities.Select(e => _mapper.ToDTO(e)).ToList();
        }
    }
}
