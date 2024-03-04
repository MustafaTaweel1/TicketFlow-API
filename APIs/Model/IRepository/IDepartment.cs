using APIs.Model.models;

namespace APIs.Model.IRepository
{
	public interface IDepartment<T>
	{
		Task<User> GetEmpDep(int DepartmentId, int UserId);

		Task InsertEmp(int id,int userId);
		Task<T> InsertDep(T entity);
		Task UpdateEmp(int id, User entity);
		Task<T> GetDepartment(int id);
		Task<IEnumerable<T>> Get();
		Task RemoveEmp(int DepartmentId,int UserId);
	}



}
