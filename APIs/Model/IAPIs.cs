namespace webAPI.Model
{
    public interface IAPIs<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(string currency="",string name="");
        Task<IEnumerable<T>> Get(string currency );

        Task<T> Post(T person);
        Task Put(T person);
        Task Delete(int id);

    }
}
