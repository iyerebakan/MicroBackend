using MicroBackend.Domain.Core.Mongo.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Mongo.Models
{
    public abstract class MongoRepositoryBase<TMongoEntity> : IMongoRepository<TMongoEntity>
        where TMongoEntity : class, IMongoEntity, new()
    {
        protected readonly MongoHelper _mongoHelper;
        protected MongoRepositoryBase(MongoHelper mongoHelper)
        {
            _mongoHelper = mongoHelper;
        }
        public IMongoCollection<TMongoEntity> collection
        {
            get
            {
                return _mongoHelper.Connection.GetCollection<TMongoEntity>(typeof(TMongoEntity).Name);
            }
        }

        public void Add(IEnumerable<TMongoEntity> entities)
        {
            collection.InsertMany(entities);
        }

        public async Task AddAsync(IEnumerable<TMongoEntity> entities)
        {
            await collection.InsertManyAsync(entities, null, System.Threading.CancellationToken.None);
        }

        public TMongoEntity Add(TMongoEntity entity)
        {
            collection.InsertOne(entity);
            return entity;
        }
        public async Task<TMongoEntity> AddAsync(TMongoEntity entities)
        {

            await collection.InsertOneAsync(entities, null, System.Threading.CancellationToken.None);
            return entities;

        }
        public async Task<TMongoEntity> GetByIdAsync(string id)
        {
            return await GetByIdAsync(new ObjectId(id)).ConfigureAwait(false);
        }
        public async Task<TMongoEntity> GetByIdAsync(ObjectId id)
        {
            return await collection.Find(new BsonDocument("_id", id)).FirstOrDefaultAsync();
        }
        public async Task<TMongoEntity> GetFirstByConditionAsync(Expression<Func<TMongoEntity, bool>> expression)
        {
            var result = await collection.FindAsync<TMongoEntity>(expression);
            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<TMongoEntity>> GetItemsByConditionAsync(Expression<Func<TMongoEntity, bool>> expression, int skip, int limit)
        {

            var result = await collection.Find<TMongoEntity>(expression).Skip(skip).Limit(limit).ToListAsync();
            return result;


        }
        public async Task<long> GetCountByConditionAsync(Expression<Func<TMongoEntity, bool>> expression)
        {

            var result = await collection.CountAsync(expression);
            return result;

        }
        public TMongoEntity GetById(string id)
        {
            return GetById(new ObjectId(id));
        }
        public TMongoEntity GetById(ObjectId id)
        {

            return collection.Find(new BsonDocument("_id", id)).FirstOrDefault();
        }
        public long Count()
        {
            return collection.Count(null);
        }
        public void Delete(Expression<Func<TMongoEntity, bool>> predicate)
        {
            foreach (TMongoEntity entity in this.collection.AsQueryable<TMongoEntity>().Where(predicate))
            {
                this.Delete(entity);
            }
        }
        public void Delete(string id)
        {
            if (typeof(TMongoEntity).IsSubclassOf(typeof(IMongoEntity<TMongoEntity>)))
            {
                collection.DeleteOne(new BsonDocument("_id", new ObjectId(id)));
            }
            else
            {
                collection.DeleteOne(new BsonDocument("_id", BsonValue.Create(id)));
            }
        }
        public async Task DeleteAsync(string id)
        {
            if (typeof(TMongoEntity).IsSubclassOf(typeof(MongoEntity<TMongoEntity>)))
            {
                await collection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
            }
            else
            {
                await collection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
            }
        }
        public void Delete(TMongoEntity entity)
        {
            collection.DeleteOne(new BsonDocument("_id", new ObjectId(entity.GetType().GetProperty("_id").GetValue(entity).ToString())));
        }
        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }
        public bool Exists(Expression<Func<TMongoEntity, bool>> predicate)
        {
            return this.collection.AsQueryable<TMongoEntity>().Any(predicate);
        }
        public IEnumerator<TMongoEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Update(IEnumerable<TMongoEntity> entities)
        {
            foreach (var entity in entities)
            {
                collection.ReplaceOne(new BsonDocument("_id", new ObjectId(entity.GetType().GetProperty("_id").GetValue(entity).ToString())), entity);
            }

        }


        public async Task<TMongoEntity> UpdateAsync(TMongoEntity entity)
        {
            await collection.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.GetType().GetProperty("_id").GetValue(entity).ToString())), entity);
            return entity;
        }


        public Type ElementType
        {
            get { return this.collection.AsQueryable<TMongoEntity>().ElementType; }
        }
        public Expression Expression
        {
            get { return this.collection.AsQueryable<TMongoEntity>().Expression; }
        }
        public IQueryProvider Provider
        {
            get { return this.collection.AsQueryable<TMongoEntity>().Provider; }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.collection.AsQueryable<TMongoEntity>().GetEnumerator();
        }

        public List<TMongoEntity> GetList(Expression<Func<TMongoEntity, bool>> condition)
        {
            return collection.FindAsync<TMongoEntity>(condition).Result.ToList() ?? new List<TMongoEntity>();
        }

        public async Task<TMongoEntity> GetOneAsync(Expression<Func<TMongoEntity, bool>> expression)
        {
            var response = await collection.FindAsync<TMongoEntity>(expression);
            var result = await response.FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                return default(TMongoEntity);
            }
        }

        public async Task<bool> DeleteOneAsyncV2(string id)
        {

            var result = await collection.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
            return result.DeletedCount > 0 ? true : false;


        }

        public async Task<bool> Upsert(TMongoEntity entity)
        {
            var result = await collection.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(entity.GetType().GetProperty("_id").GetValue(entity).ToString())), entity, new UpdateOptions { IsUpsert = true });
            return result.ModifiedCount > 0 ? true : false;

        }
        public async Task<List<TMongoEntity>> GetItemsByConditionAndSortExpAsync(Expression<Func<TMongoEntity, bool>> where, int skip, int take, Expression<Func<TMongoEntity, object>> sort, bool isAscending)
        {
            if (isAscending)
            {
                try
                {
                    var result = await collection.Find<TMongoEntity>(where).Sort(Builders<TMongoEntity>.Sort.Ascending(sort)).Skip(skip).Limit(take).ToListAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                    throw;
                }

            }
            else
            {
                var result = await collection.Find<TMongoEntity>(where).Sort(Builders<TMongoEntity>.Sort.Descending(sort)).Skip(skip).Limit(take).ToListAsync();
                return result;
            }

        }
    }
}
