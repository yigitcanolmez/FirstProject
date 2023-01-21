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
    public class EfEntityRepositoryBase<TEntity, Context> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where Context : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (Context cnt = new Context())
            {
                var addedEntity = cnt.Entry(entity);
                addedEntity.State = EntityState.Added;
                cnt.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Context cnt = new Context())
            {
                var deletedEntity = cnt.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                cnt.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Context cnt = new Context())
            {
                return cnt.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter =  null)
        {
            using (Context cnt = new Context())
            {
                return filter == null
                    ? cnt.Set<TEntity>().ToList()
                    : cnt.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (Context cnt = new Context())
            {
                var updatedEntity = cnt.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                cnt.SaveChanges();
            }
        }
    }
}
