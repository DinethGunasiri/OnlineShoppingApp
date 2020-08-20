using Microsoft.EntityFrameworkCore;
using OnlineShopping.data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OnlineShopping.data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly ShoppingContext context;

        public Repository(ShoppingContext shoppingContext)
        {
            this.context = shoppingContext;
            this._dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity GetDetails(object id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            // context.Entry<TEntity>(entity).State = EntityState.Modified;
           return _dbSet.Add(entity).Entity;

          //  return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException($"{entities}");
            }

            foreach (var entity in entities)
                 context.Entry<TEntity>(entity).State = EntityState.Added;

                    
        }

        public TEntity Remove(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return entity;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException($"{entities}");
            }

            foreach (var entity in entities)
                context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void Remove(object Id)
        {
            TEntity entity = _dbSet.Find(Id);
            this.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            // return entity;

            return context.Entry(entity).Entity;
        }
    }
}
