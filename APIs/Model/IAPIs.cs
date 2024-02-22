namespace webAPI.Model
{
    public interface IAPIs<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(string email="",string password="");
        Task<IEnumerable<T>> Get(string email );

        Task<T> Post(T person);
        Task Put(T person);
        Task Delete(int id);

    }
}
