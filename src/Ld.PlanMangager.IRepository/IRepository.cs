using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface.Interface
{
    public interface IRepository<TEntity> where TEntity : class, IAggregate
    {

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

    }
}
