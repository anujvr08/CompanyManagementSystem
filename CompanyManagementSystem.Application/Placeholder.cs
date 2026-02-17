using System;
using CompanyManagementSystem.Domain.Entities;

namespace CompanyManagementSystem.Application
{
    public class Placeholder
    {
        public void TestReference()
        {
            // Try to use a class from the Domain project to verify reference works
            CompanyEntity company = new CompanyEntity();
            company.comp_name = "Test Company";
        }
    }
}
