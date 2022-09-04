namespace EmployeeService.Services
{
    public interface IRepository<T, TId>
    {
        Task<IList<T>> GetAll();

        Task <T> GetById(TId id);

        Task<Guid> Create(T data);

        Task<bool> Update(T data);

        Task<bool> Delete(TId id);
    }
}
