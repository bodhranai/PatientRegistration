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

    public interface IRepository : IDisposable
    {
        T GetItem<T>(int? id) where T : class;
        T Get<T>(string id) where T : class;
        T Get<T>(params object[] id) where T : class;


        int RawSQL(string sql, params object[] parameters);
        IList<T> ListAll<T>() where T : class;
        IQueryable<T> QueryAll<T>() where T : class;
        void Add<T>(T newItem) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Edit<T>(T entity, Expression<Func<T, bool>> id) where T : class;
        void Save();
        IQueryable<TEntity> RunQuery<TEntity>(Expression<Func<TEntity, bool>> predicate, bool tracking = false) where TEntity : class;
        IQueryable<TEntity> RunQuery<TEntity>(bool tracking = false) where TEntity : class;

        DbContextTransaction BeginTransaction(IsolationLevel isolationLvl);
        void CommitTransaction();
        void RollbackTransaction();










    }
}
