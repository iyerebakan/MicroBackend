using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Mongo.Interfaces
{
    public interface IMongoRepository<T> where T : IMongoEntity
    {

        IMongoCollection<T> collection { get; }
        T GetById(ObjectId id);
        T GetById(string id);
        T GetById(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(ObjectId id);
        Task<T> GetByIdAsync(string id);
        T Add(T entity);
        Task<T> AddAsync(T entities);
        void Add(IEnumerable<T> entities);
        Task AddAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        void Update(IEnumerable<T> entities);
        Task DeleteAsync(string id);
        void Delete(ObjectId id);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        long Count();
        bool Exists(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> condition);
        Task<List<T>> GetItemsByConditionAsync(Expression<Func<T, bool>> expression, int skip = 0, int limit = 10);
        Task<long> GetCountByConditionAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetItemsByConditionAndSortExpAsync(Expression<Func<T, bool>> where, int skip, int take, Expression<Func<T, object>> sort, bool isAscending);
    }
}
