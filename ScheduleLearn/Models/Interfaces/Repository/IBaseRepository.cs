namespace ScheduleLearnApi.Models.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(string id);

        Task InsertAsync(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
