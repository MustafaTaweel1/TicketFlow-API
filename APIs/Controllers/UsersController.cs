using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAPIs<User> _User;
        private readonly IDepartment<Department> _department;
		private readonly IWebHostEnvironment hosting;

		public UsersController(IAPIs<User> User, IDepartment<Department> department,IWebHostEnvironment hosting)
        {
           _User = User;
            _department = department;
            this.hosting = hosting;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _User.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _User.Get(id);
        }
        [HttpGet("users")]
        public async Task<IEnumerable<User>> GetUser(string email, string password)
        {
            return await _User.Get(email, password);
        }
		[HttpGet("Email")]
		public async Task<IEnumerable<User>> GetUser(string email)
		{
			return await _User.Get(email);
		}





		[HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User User)
        {
            var Users = await _User.Post(User);
            int user_id = User.id;
            await _department.InsertEmp(User.DepartmentId,user_id);
            return CreatedAtAction(nameof(GetUser), new { id = Users.id }, Users);
        }
		//      [HttpPut]
		//      public async Task<ActionResult> Put(int id, [FromBody] User User)
		//      {
		//          if (id != User.id)
		//          {
		//              return BadRequest();
		//          }
		//          var olddata=await _User.Get(User.id);
		//	await _User.Put(User);

		//	if (User.DepartmentId != olddata.DepartmentId) {
		//              _department.InsertEmp(User.DepartmentId, User);
		//              _department.RemoveEmp(olddata.DepartmentId, User.id);
		//          }
		//	return NoContent();

		//}
		[HttpPut]
		public async Task<ActionResult> Put(int id, [FromBody] User User)
		{
			if (id != User.id)
			{
				return BadRequest();
			}
			await _User.Put(User);
			return NoContent();
		}
		[HttpDelete("{id}")]
        public async Task<ActionResult> Delect(int id)
        {
            var Currencydelet = await _User.Get(id);
            if (Currencydelet == null)
            {
                return NotFound();
            }
            await  _User.Delete(Currencydelet.id);
            return NoContent();
        }
    }
}
