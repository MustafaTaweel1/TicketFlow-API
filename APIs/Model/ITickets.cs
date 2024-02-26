namespace webAPI.Model
{
    public interface ITickets<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetStatus(int status);

        Task<IEnumerable<T>> Get(string creatorName = "", int status = 0);

        Task<T> Post(T person);
        Task Put(T person);
        Task Delete(int id);
    }
}
