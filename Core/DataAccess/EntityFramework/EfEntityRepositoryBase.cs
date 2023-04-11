using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();

            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();

            return context.Set<TEntity>().FirstOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            context.Remove(filter);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
