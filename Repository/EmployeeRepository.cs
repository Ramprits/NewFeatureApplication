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
        public async Task<bool> DeleteEmployeeAsync (Guid id) {
            var deleteEmployee = await _context.Employees.FirstOrDefaultAsync (x => x.EmployeeId == id);
            _context.Remove (deleteEmployee);
            try {
                return (await _context.SaveChangesAsync () > 0 ? true : false);
            } catch (System.Exception exp) {
                _Logger.LogError ($"Error in {nameof(DeleteEmployeeAsync)}: " + exp.Message);
            }
            return false;
        }
        public async Task<bool> EmployeeExist (Guid id) {
            return await _context.Employees.AnyAsync (x => x.EmployeeId == id);
        }
        public async Task<Employee> GetEmployeeAsync (Guid id) {
            return await _context.Employees.FirstOrDefaultAsync (x => x.EmployeeId == id);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync () {
            return await _context.Employees.Include (x => x.Department).ToListAsync ();
        }
        public async Task<Employee> InsertEmployeeAsync (Employee entity) {
            entity.EmployeeId = Guid.NewGuid ();
            var employeeAlreadyExists = _context.Employees.AnyAsync (x => x.EmployeeId == entity.EmployeeId);
            if (await employeeAlreadyExists) {
                throw new Exception ($"employee with {entity.EmployeeId} is already exists !");
            }
            if (entity.FirstName == entity.LastName) {
                throw new Exception ($"{entity.FirstName} and {entity.LastName} couldn't be same.");
            }
            await _context.Employees.AddAsync (entity);
            try {
                await _context.SaveChangesAsync ();
            } catch (System.Exception exp) {
                _Logger.LogError ($"Error in {nameof(InsertEmployeeAsync)}: " + exp.Message);
            }

            return entity;
        }

        public async Task<bool> SaveAsync () {
            return (await _context.SaveChangesAsync () >= 0);
        }

        public Task<bool> UpdateEmployeeAsync (Employee entity) {
            throw new NotImplementedException ();
        }
    }
}