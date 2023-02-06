using CrudDemoApp.Data;
using CrudDemoApp.Dto;
using CrudDemoApp.Models;
using CrudDemoApp.Utility;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CrudDemoApp.Repositories
{
    public interface IEmployee
    {
        Task<List<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployee(int id);
        Task<bool> UpdateEmployee(EditEmployeeDto editemployeeDto);
        Task AddEmployee(AddEmployeeDto AddemployeeDto);
        Task<bool> DeleteEmployee(int id);

        Task<EmployeeDto> GetEmployeeInfo();
    }
    public class EmployeeRepos : IEmployee
    {
        private readonly EmployeeContext _context;
        private readonly  ClaimServices _claimServices;

        public EmployeeRepos(EmployeeContext context, ClaimServices claimServices)
        {
            _context = context;
            _claimServices = claimServices;
        }

        public async Task AddEmployee(AddEmployeeDto addemployeeDto)
        {
            try
            {
                var employee = new Employee()
                {
                    Name = addemployeeDto.Name,
                    Email = addemployeeDto.Email,
                    Password = addemployeeDto.Password,
                    FatherName = addemployeeDto.FatherName,
                    Age = addemployeeDto.Age,
                    Address = addemployeeDto.Address,
                    IsActive = true,
                    IsDelete = false,
                    FkRoleId = 1
                };
                await _context.employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee != null)
                {
                    employee.IsActive = false;
                    employee.IsDelete = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.employees.Where(x => x.Id == id && x.IsActive && !x.IsDelete).Select(x => new EmployeeDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    FatherName = x.FatherName,
                    Age = x.Age,
                    Address = x.Address
                }).FirstOrDefaultAsync();
                if (employee != null)
                {

                    return employee;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDto> GetEmployeeInfo()
        {
            try
            {
                 int id = _claimServices.GetCurrentUserId();
                var employee = await _context.employees.Where(x => x.Id == id && x.IsActive && !x.IsDelete).Select(x => new EmployeeDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    FatherName = x.FatherName,
                    Age = x.Age,
                    Address = x.Address
                }).FirstOrDefaultAsync();
                if (employee != null)
                {

                    return employee;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            try
            {

                var employees = await _context.employees.Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    FatherName = x.FatherName,
                    Age = x.Age,
                    Address = x.Address
                }).AsNoTracking().ToListAsync();
                return employees;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateEmployee(EditEmployeeDto editemployeeDto)
        {
            var responce = new Responce();
            try
            {
                var employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == editemployeeDto.Id);



                employee.Name = editemployeeDto.Name;
                employee.Email = editemployeeDto.Email;
                employee.Password = editemployeeDto.Password;
                employee.FatherName = editemployeeDto.FatherName;
                employee.Age = editemployeeDto.Age;
                employee.Address = editemployeeDto.Address;
                employee.IsDelete = false;
                employee.IsActive = true;


                await _context.SaveChangesAsync();

                return responce.IsSuccess;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
