namespace APIs.Model.IRepository
{
    public interface ITickets<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetStatus(int status);
        Task<IEnumerable<T>> GetUser_Create(int id_create);
        Task<IEnumerable<T>> GetUser_Take(int id_user);
		Task<IEnumerable<T>> GetDepartment(int dep_id);

		Task<T> Post(T ticket);
        Task Put(T ticket);
        Task Delete(int ticket);
    }
}
