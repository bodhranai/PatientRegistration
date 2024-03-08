using PatientRegistration.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistration.Infrastructure.Repsoitory
{
    public class Repository : IRepository, IDisposable
    {
        private PatientRegistrationContext context;

        public Repository()
        {
            context = new PatientRegistrationContext();
            
        }
        public void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }

        public DbContextTransaction BeginTransaction(IsolationLevel isolationLvl)
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Edit<T>(T entity, Expression<Func<T, bool>> id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string id) where T : class
        {
            throw new NotImplementedException();
        }

        public T Get<T>(params object[] id) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetItem<T>(int? id) where T : class
        {
            throw new NotImplementedException();
        }

        public IList<T> ListAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public int RawSQL(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> RunQuery<TEntity>(Expression<Func<TEntity, bool>> predicate, bool tracking = false) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> RunQuery<TEntity>(bool tracking = false) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
