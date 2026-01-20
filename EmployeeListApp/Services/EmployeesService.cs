using EmployeeListApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListApp.Services
{
    public class EmployeesService
    {
        private readonly AppDbContext _context;

        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> InsertEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(string id, Employee e)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return null;

            emp.FullName = e.FullName;
            emp.Department = e.Department;
            emp.Salary = e.Salary;

            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> DeleteEmployeeAsync(string id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return null;

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
    }
}