using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using New_Application.Infrastructure;
using New_Application.Models;

namespace New_Application.Repository {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly NewApplicationDbContext _context;
        private readonly ILogger _Logger;

        public EmployeeRepository (NewApplicationDbContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _Logger = loggerFactory.CreateLogger ("EmployeeRepository");
        }
        public Task<bool> DeleteEmployeeAsync (Guid id) {
            throw new NotImplementedException ();
        }

        public Task<Employee> GetEmployeeAsync (Guid id) {
            throw new NotImplementedException ();
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync () {
            return await _context.Employees.ToListAsync ();
        }
        public async Task<Employee> InsertEmployeeAsync (Employee entity) {
            await _context.Employees.AddAsync (entity);
            try {
                await _context.SaveChangesAsync ();
            } catch (System.Exception exp) {
                _Logger.LogError ($"Error in {nameof(InsertEmployeeAsync)}: " + exp.Message);
            }

            return entity;
        }

        public Task<bool> SaveAsync () {
            throw new NotImplementedException ();
        }

        public Task<bool> UpdateEmployeeAsync (Employee entity) {
            throw new NotImplementedException ();
        }
    }
}