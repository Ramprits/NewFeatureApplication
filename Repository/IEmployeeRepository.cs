using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using New_Application.Models;

namespace New_Application.Repository {
    public interface IEmployeeRepository {
        Task<IEnumerable<Employee>> GetEmployeesAsync ();
        Task<Employee> GetEmployeeAsync (Guid id);
        Task<Employee> InsertEmployeeAsync (Employee entity);
        Task<bool> UpdateEmployeeAsync (Employee entity);
        Task<bool> DeleteEmployeeAsync (Guid id);
        Task<bool> SaveAsync ();
    }
}