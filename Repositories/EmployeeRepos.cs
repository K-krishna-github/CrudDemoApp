using CrudDemoApp.Data;
using CrudDemoApp.Dto;
using CrudDemoApp.Models;
using CrudDemoApp.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CrudDemoApp.Repositories
{
    public interface IEmployee
    {
        Task<PaginationDto<EmployeeDto>> GetEmployees(string? searchtext, int skip, int maxresults);
        Task<EmployeeDto> GetEmployee(int id);
        Task<Responce> UpdateEmployee(EditEmployeeDto editemployeeDto);
        Task<Responce> AddEmployee(AddEmployeeDto AddemployeeDto);
        Task<Responce> DeleteEmployee(int id);

        Task<EmployeeDto> GetEmployeeInfo();
    }
    public class EmployeeRepos : IEmployee
    {
        private readonly EmployeeContext _context;
        private readonly ClaimServices _claimServices;

        public EmployeeRepos(EmployeeContext context, ClaimServices claimServices)
        {
            _context = context;
            _claimServices = claimServices;
        }

        public async Task<Responce> AddEmployee(AddEmployeeDto addemployeeDto)
        {
            var responce = new Responce();
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

                return responce;
            }
            catch (Exception ex)
            {
                responce.ErrorMessage = ex.Message;
                return responce;
            }
        }

        public async Task<Responce> DeleteEmployee(int id)
        {
            var responce = new Responce();
            try
            {
                var employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee != null)
                {
                    employee.IsActive = false;
                    employee.IsDelete = true;
                    await _context.SaveChangesAsync();
                    return responce;
                }
                else
                {
                    responce.ErrorMessage = "Data Not Found";
                    return responce;
                }
            }
            catch (Exception ex)
            {
                responce.ErrorMessage = ex.Message;
                return responce;
            }
        }

        public async Task<EmployeeDto> GetEmployee(int id)
        {
            try
            {
                var employee = await _context.employees.Where(x => x.Id == id && x.IsActive && !x.IsDelete).Select(x => new EmployeeDto()
                {
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
                    throw new ApplicationException("Data Not Found");
                }


            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
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
                    throw new ApplicationException("Data Not Found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<PaginationDto<EmployeeDto>> GetEmployees(string? searchtext, int skip, int maxresults)
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

                if (!string.IsNullOrEmpty(searchtext.ToLower()) && string.IsNullOrWhiteSpace(searchtext.ToLower()))
                {
                    var res = employees.Where(x => x.Name.ToLower().Contains(searchtext.ToLower()) || x.Email.ToLower().Contains(searchtext.ToLower())).ToList();

                    var data = new PaginationDto<EmployeeDto>();
                    data.Count = res.Count();
                    data.Entities = res.OrderByDescending(x => x.Id).Skip(skip).Take(maxresults).ToList();

                    return data;
                }
                else
                {
                    var data = new PaginationDto<EmployeeDto>();
                    data.Count = employees.Count();
                    data.Entities = employees.OrderByDescending(x => x.Id).Skip(skip).Take(maxresults).ToList();
                    return data;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Responce> UpdateEmployee(EditEmployeeDto editemployeeDto)
        {
            var responce = new Responce();
            try
            {
                var employee = await _context.employees.FirstOrDefaultAsync(x => x.Id == editemployeeDto.Id);

                if (employee != null)
                {

                    employee.Name = editemployeeDto.Name;
                    employee.Email = editemployeeDto.Email;
                    employee.Password = editemployeeDto.Password;
                    employee.FatherName = editemployeeDto.FatherName;
                    employee.Age = editemployeeDto.Age;
                    employee.Address = editemployeeDto.Address;
                    employee.IsDelete = false;
                    employee.IsActive = true;
                    await _context.SaveChangesAsync();
                    return responce;
                }
                else
                {
                    responce.ErrorMessage = "Data Not Found";
                    return responce;
                }
            }
            catch (Exception ex)
            {

                responce.ErrorMessage = ex.Message;
                return responce;
            }
        }
    }
}
