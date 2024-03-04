using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{

		private readonly IAPIs<User> _User;
		private readonly IDepartment<Department> _department;
		private readonly IWebHostEnvironment hosting;

		public DepartmentController(IAPIs<User> User, IDepartment<Department> department, IWebHostEnvironment hosting)
		{
			_department = department;
			_User = User;
			this.hosting = hosting;
		}
		[HttpGet]
		public async Task<IEnumerable<Department>> Get()
		{
			return await _department.Get();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Department>> GetDepartment(int id)
		{
			return await _department.GetDepartment(id);
		}

		[HttpPost("InsertDep")]

		public async Task<ActionResult<Department>> InsertDep([FromBody] Department department)
		{
			_department.InsertDep(department);


			return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
		}

		[HttpPut]
		public async Task<ActionResult<User>> InsertEmp(int departmentId, int userId)
		{
			 await _department.InsertEmp(departmentId, userId);
			User user = await _User.Get(userId);
			await _User.Put(user);

			return NoContent();
			// Return the inserted user
		}
		[HttpDelete]
		public async Task<ActionResult> Delect(int departmentId,int Userid)
		{
			var UserDelete = await _department.GetDepartment(departmentId);
			if (UserDelete == null)
			{
				return NotFound();
			}else if (_department.GetEmpDep(departmentId,Userid)==null )
			{
				return NotFound();

			}
			else
			{
				await _department.RemoveEmp(departmentId, Userid);
			}
			return NoContent();
		}

	}
}
