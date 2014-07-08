using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure.Domain
{
    public interface IRepository<in T> where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }
}
