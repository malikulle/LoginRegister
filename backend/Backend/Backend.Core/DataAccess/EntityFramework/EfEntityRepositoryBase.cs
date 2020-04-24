using Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Backend.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using(var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.Remove(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity GetById(int id)
        {
            using(var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null
                        ? context.Set<TEntity>().ToList()
                        : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using(var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
            }
        }
    }
}
