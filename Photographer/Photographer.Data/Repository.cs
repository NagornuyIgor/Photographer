using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographerPerformance.Data
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity entity);

        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entity);

        TEntity Update(TEntity entity);

        TEntity Delete(object id);

        TEntity Delete(TEntity entity);

        void Save();
    }

    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
        where TEntity : class
    {
        public Repository(DbContext context)
            : base(context)
        {
        }

        public virtual TEntity Create(TEntity entity)
        {
            return Table.Add(entity);
        }

        public virtual IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entity)
        {
            return Table.AddRange(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual TEntity Delete(object id)
        {
            var entity = Table.Find(id);

            return Delete(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var dbSet = Table;
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            return dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }
    }
}
