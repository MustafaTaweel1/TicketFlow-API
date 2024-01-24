namespace webAPI.Model
{
    public interface Iperson<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Get(string currency);

        Task<T> Post(T person);
        Task Put(T person);
        Task Delete(int id);
    }
}
