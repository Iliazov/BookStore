namespace BookStoreCRM.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> CheckCustomerOrdersAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
