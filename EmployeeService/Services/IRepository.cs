namespace EmployeeService.Services
{
    public interface IRepository<T, TId>
    {
        IList<T> GetAll();

        Task <T> GetById(TId id);

        int Create(T data);

        Task Update(T data);

        Task Delete(TId id);
    }
}
