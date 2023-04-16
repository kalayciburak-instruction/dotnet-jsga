using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using var context = new TContext(); // Transient
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

    public void Delete(int id)
    {
        using var context = new TContext();
        var entity = context.Set<TEntity>().Find(id);
        context.Set<TEntity>().Remove(entity);
        context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        using var context = new TContext();
        context.Update(entity);
        context.SaveChanges();
    }
}