using CrudDemoApp.Dto;
using CrudDemoApp.Models;
using CrudDemoApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployee emprepos;

        public EmployeesController(IEmployee emprepos)
        {
            this.emprepos = emprepos;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addemployee")]
        public async Task<ActionResult<Responce>> AddEmployee(AddEmployeeDto employee)
        {
            var responce = new Responce();
            await emprepos.AddEmployee(employee);
            return responce;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateemployee")]
        public async Task<ActionResult<Responce>> UpdateEmployee(EditEmployeeDto editEmployeeDto)
        {
            var responce = new Responce();
            var employee = await emprepos.UpdateEmployee(editEmployeeDto);
            if (employee)
            {
                return responce;
            }
            else
            {
                return new Responce() { ErrorMessage = "Data Not Found" };
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("getemployees")]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees() => await emprepos.GetEmployees();



        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await emprepos.GetEmployee(id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<ActionResult<Responce>> DeleteEmployee(int id)
        {
            var responce = new Responce();
            var employee = await emprepos.DeleteEmployee(id);
            if (employee)
            {
                return responce;
            }
            else
            {
                return new Responce() { ErrorMessage = "Data Not Found" };
            }
        }


        [Authorize(Roles ="Employee")]
        [HttpGet]
        [Route("GetEmployeeInfo")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeInfo()
        {


            var employee = await emprepos.GetEmployeeInfo();
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return NotFound();
            }
        }


    }
}
