using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WB.WAPP.SEG.Business.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IGenericRepository<TEntity> Delete(TEntity entityToDelete);
        IGenericRepository<TEntity> Delete(object id);
        IGenericRepository<TEntity> Insert(TEntity entity);
        IGenericRepository<TEntity> Update(TEntity entityToUpdate);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters);
        IGenericRepository<TEntity> Save();
    }
}
