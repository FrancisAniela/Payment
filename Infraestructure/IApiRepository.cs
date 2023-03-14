namespace Infraestructure
{
    public interface IApiRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
    }

}
