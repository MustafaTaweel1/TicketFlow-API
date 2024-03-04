using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using webAPI.Model;

namespace APIs.Model.Repository
{
    public class DepartmentRepository : IDepartment<Department>
    {
        db _db;
        public DepartmentRepository(db db)
        {
            _db = db;
        }

		public async Task<IEnumerable<Department>> Get()
		{
			return await _db.departments.Include(t => t.User).ToListAsync();
		}

		public async Task<Department> GetDepartment(int id)
		{

			return await _db.departments.Include(t=>t.User).FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task<User> GetEmpDep(int DepartmentId, int UserId)
		{
			var Department= await _db.departments.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == DepartmentId);
			var User = await _db.users.FirstOrDefaultAsync(u => u.id==UserId);
			var check = Department.User.FirstOrDefault(User);
			if (check == null) {
				return null;
			}
			return User;
		}

		public async Task<Department> InsertDep(Department entity)
		{
			entity.User = new List<User>();
			_db.departments.AddAsync(entity);
			_db.SaveChangesAsync();

			return entity;
		}
		public async Task  InsertEmp(int departmentId, int UserId)
		{
			// Retrieve the department including its Users collection
			Department department = await _db.departments
											  .Include(d => d.User)
											  .FirstOrDefaultAsync(d => d.Id == departmentId);

			if (department == null)
			{
				return;
			}

			// Check if the user already exists by id
			User existingUser = await _db.users.FirstOrDefaultAsync(u => u.id ==UserId);
			if (existingUser != null)
			{
				return;

			}
			Department RemoveUserDep = await _db.departments.FindAsync(existingUser.id);
			RemoveUserDep.User.Remove(existingUser);
			department.User.Add(existingUser);
		
			existingUser.DepartmentId = departmentId;
			
			_db.Entry(existingUser).State = EntityState.Modified;
			_db.Entry(RemoveUserDep).State = EntityState.Modified;
			_db.Entry(department).State = EntityState.Modified;
			// Save changes to the database
			await _db.SaveChangesAsync();

			// Return the inserted user
		}

		public async Task RemoveEmp(int DepartmentId, int UserId)
		{
			var department = await _db.departments.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == DepartmentId);
			department.User.Remove(_db.users.FirstOrDefault(u => u.id == UserId));

			User emp = _db.users.FirstOrDefault(u => u.id == UserId);
			emp.DepartmentId = 1;
			_db.Entry(emp).State = EntityState.Modified;
			_db.Entry(department).State = EntityState.Modified;
			await _db.SaveChangesAsync();
		}

		public async Task UpdateEmp(int id, User entity)
		{
			Department department = _db.departments.Find(id);
			department.User.Add(entity);
			_db.Entry(department).State = EntityState.Modified;
			await _db.SaveChangesAsync();
		}



	}
}
