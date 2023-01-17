using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Model;
namespace EmployeeController;
using Microsoft.AspNetCore.Cors;
using EmployeeManagementApi.DAL;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Employee> getAllEmployee()
    {

        List<Employee> employees = UsersDataAccess.getAllEmployee();
        return employees;

    }

    [HttpGet]
    [EnableCors]
    [Route("{id}")]
    public ActionResult<Employee> getEmpById(int id)
    {
        Employee emp = UsersDataAccess.getEmployeeById(id);
        return emp;
    }

    [HttpPost]
    [EnableCors]
    public IActionResult insertNewEmployee(Employee employee)
    {

        UsersDataAccess.insertNewEmp(employee);
        return Ok(new { message = "Employee created..." });

    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors]
    public IActionResult deleteEmployeeById(int id)
    {

        UsersDataAccess.deleteEmp(id);
        return Ok(new { message = "Employee deleted..." });
    }


    [Route("{id}")]
    [HttpPut]
    [EnableCors()]
    public IActionResult updateEmployee(int id, Employee employee)
    {

        UsersDataAccess.updateEmp(id, employee);
        return Ok(new { message = "Employee details Updated succefully..." });
    }

}
