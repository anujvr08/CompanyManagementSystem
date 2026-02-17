using System;
using System.Collections.Generic;
using System.Linq;
using CompanyManagementSystem.Application.Mappers;
using CompanyManagementSystem.Domain.DTOs;
using CompanyManagementSystem.Domain.Entities;
using CompanyManagementSystem.Infrastructure.Repositories;

namespace CompanyManagementSystem.Application.Services
{
    /// <summary>
    /// Service for company business logic and orchestration.
    /// </summary>
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepo;
        private readonly CompanyMapper _mapper;

        public CompanyService(CompanyRepository companyRepo, CompanyMapper mapper)
        {
            _companyRepo = companyRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Save a new company. Checks for duplicate names.
        /// </summary>
        public void SaveCompany(CompanyDTO dto)
        {
            // Business rule: company name must be unique
            if (_companyRepo.CheckNameExists(dto.CompanyName))
            {
                throw new Exception("Company name already exists");
            }

            // Convert DTO → Entity and save
            CompanyEntity entity = _mapper.ToEntity(dto);
            _companyRepo.Save(entity);
        }

        /// <summary>
        /// Get all companies as DTOs.
        /// </summary>
        public List<CompanyDTO> ListCompanies()
        {
            var entities = _companyRepo.GetAll();
            return entities.Select(e => _mapper.ToDTO(e)).ToList();
        }

        /// <summary>
        /// Get a single company by ID.
        /// </summary>
        public CompanyDTO GetCompanyById(int companyId)
        {
            var entity = _companyRepo.GetById(companyId);
            return _mapper.ToDTO(entity);
        }

        /// <summary>
        /// Check if a company has any users registered.
        /// </summary>
        public bool HasUsers(int companyId)
        {
            return _companyRepo.CheckUsersExist(companyId);
        }
    }
}
