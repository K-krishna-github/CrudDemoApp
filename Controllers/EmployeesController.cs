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
        public async Task<ActionResult<Responce>> AddEmployee(AddEmployeeDto employee) => await emprepos.AddEmployee(employee);
       

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("updateemployee")]
        public async Task<ActionResult<Responce>> UpdateEmployee(EditEmployeeDto editEmployeeDto) =>await emprepos.UpdateEmployee(editEmployeeDto);
        

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("getemployees")]
        public async Task<ActionResult<PaginationDto<EmployeeDto>>> GetEmployees(string? searchtext, int skip=0, int maxresults=10) => await emprepos.GetEmployees(searchtext,skip,maxresults);


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)=> await emprepos.GetEmployee(id);


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<ActionResult<Responce>> DeleteEmployee(int id) => await emprepos.DeleteEmployee(id);
        

        [Authorize(Roles ="Employee")]
        [HttpGet]
        [Route("GetEmployeeInfo")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeInfo()=> await emprepos.GetEmployeeInfo();
       
    }
}
