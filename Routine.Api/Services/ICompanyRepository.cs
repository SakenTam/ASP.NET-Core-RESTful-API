using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Routine.Api.Entities;
using Routine.Api.Models;
using Routine.Api.ResourceParameters;

namespace Routine.Api.Services
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId,string genderDisplay,string q);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);

        void AddEmployee(Guid companyId, Employee employee);

        void UpdateEmployeeAsync(Employee employee);

        void DeleteEmployeeAsync(Employee employee);

        Task<IEnumerable<Company>> GetCompaniesAsync(CompanyDtoParameters parameters);

        Task<Company> GetCompanyAsync(Guid companyId);

        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds);

        void AddCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(Company company);

        Task<bool> CompanyExistsAsync(Guid companyId);

        Task<bool> SaveAsync();

    }
}