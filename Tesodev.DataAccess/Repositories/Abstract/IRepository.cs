using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T : CoreEntity
    {

        bool Add(T item);

        bool Add(List<T> items);

        bool Update(T item);

        bool Remove(T item);

        bool Remove(Guid id);

        bool RemoveAll(Expression<Func<T, bool>> exp);

        T GetByID(Guid id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        List<T> GetActive();

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        List<T> GetAll();

        bool Any(Expression<Func<T, bool>> exp);

        int Save();
    }
}
