using Refugee.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Refugee.Pattern
{
    public class Services<T> : IServices<T> where T : class
    {
        #region Private Fields
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor
        public Services(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }
        #endregion Constructor

        public void Add(T entity)
        {
            utwk.getRepository<T>().Add(entity);
        }

        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Expression<Func<T, bool>> condition)
        {
            utwk.getRepository<T>().Delete(condition);
        }

        public void Delete(T entity)
        {
            utwk.getRepository<T>().Delete(entity);
        }

        public void Dispose()
        {
            utwk.Dispose();
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            return utwk.getRepository<T>().Get(condition);
        }

        public IEnumerable<T> GetAll()
        {
            return utwk.getRepository<T>().GetAll();
        }

        public T GetById(long id)
        {
            return utwk.getRepository<T>().GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null)
        {
            return utwk.getRepository<T>().GetMany(condition, orderBy);
        }

        public void Update(T entity)
        {
            utwk.getRepository<T>().Update(entity);
        }
    }
}
