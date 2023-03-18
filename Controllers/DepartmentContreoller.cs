using Core_EFApi.Models;
using Core_EFApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_EFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentContreoller : ControllerBase
    {
        
        private readonly IService<Department, int> deptServ;

        public DepartmentContreoller(IService<Department, int> serv)
        {
            deptServ = serv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await deptServ.GetAsync();
            return Ok(response);
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await deptServ.GetAsync(id);
            return Ok(response);
        }
         [HttpPost]
        public async Task<IActionResult> Post(Department department)
        {
           var response = await deptServ.CreateAsync(department);
           return Ok(response);
     
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department department)
        {
            var response = await deptServ.UpdateAsync(id, department);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await deptServ.DeleteAsync(id);
            return Ok("Record is Deleted");
        }
    }
}
