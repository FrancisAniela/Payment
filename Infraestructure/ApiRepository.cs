using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{

    public class ApiRepository<TEntity> : BaseRepository<TEntity>, IApiRepository<TEntity>
    where TEntity : class
    {
        public DbContext dbContext { get; set; }
        public ApiRepository(DbPayContext _dbContext) :
            base(_dbContext)
        {
            dbContext = _dbContext;
        }
    }


}
