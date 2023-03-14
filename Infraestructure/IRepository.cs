using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;

namespace Infraestructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void CreateOrUpdate(TEntity entity);
        IEnumerable<TEntity> GetAllXId(List<long> ids);
        IEnumerable<TEntity> GetAll<TProperty>(Expression<Func<TEntity, TProperty>> include);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        TEntity Get<TProperty>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TProperty>> include);
        TEntity Get<TProperty>(Expression<Func<TEntity, bool>> where, List<Expression<Func<TEntity, TProperty>>> includes);
        TEntity Get(Expression<Func<TEntity, bool>> where, string includeNavigationPropertyPath);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetMany<TProperty>(List<Expression<Func<TEntity, TProperty>>> includes = null, bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetMany<TProperty>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TProperty>> include, bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetMany<TProperty>(Expression<Func<TEntity, bool>> where, List<Expression<Func<TEntity, TProperty>>> includes = null, bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetMany<TProperty>(List<Expression<Func<TEntity, bool>>> where, List<Expression<Func<TEntity, TProperty>>> includes = null, bool isListTrackingEnabled = false);
        IEnumerable<TProperty> GetManyWithSelect<TProperty>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TProperty>> select, bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetManyOrderedBy<TKey, TProperty>(Expression<Func<TEntity, bool>> where
            , Expression<Func<TEntity, TKey>> keySelector = null
            , bool descending = false
            , List<Expression<Func<TEntity, TProperty>>> includes = null
            , bool isListTrackingEnabled = false);
        IEnumerable<TEntity> GetManyOrderedBy<TKey, TProperty>(List<Expression<Func<TEntity, bool>>> where
            , Expression<Func<TEntity, TKey>> keySelector = null
            , bool descending = false
            , List<Expression<Func<TEntity, TProperty>>> includes = null
            , bool isListTrackingEnabled = false);


        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);

        //int SqlQuery(string query, params dynamic[] param);
        List<TEntity> FromSql(string query);
        TEntity FromSqlEntity(string query);
        void EnableTracking();
        void DisableTracking();
        void Commit();
        void Dispose();

        Task CommitAsycn();
    }

}
