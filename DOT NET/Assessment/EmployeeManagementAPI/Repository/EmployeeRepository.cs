using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbcontext;

        public EmployeeRepository(EmployeeDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            //return Ok(t);
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _dbcontext.Employees.Where(n => n.EmployeeId == id).FirstOrDefaultAsync();

            _dbcontext.Employees.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbcontext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbcontext.Employees.Where(n => n.EmployeeId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _dbcontext.Employees.Where(n => n.EmployeeId == employee.EmployeeId).FirstOrDefaultAsync();
            existingEmployee.EmployeeId = employee.EmployeeId;
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Email = employee.Email;

            await _dbcontext.SaveChangesAsync();
        }
    }
}