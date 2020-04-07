using Dapper;
using Ld.PlanMangager.Infrastructure.DataMapping;
using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ld.PlanMangager.Repository
{
    public abstract class CommandRepository<TEntity> : BaseRepository, ICommandRepository<TEntity> where TEntity : class, IAggregate
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        public bool Add(TEntity entity)
        {
            String sql = GenerateSql<TEntity>(entity, Infrastructure.SqlOperationType.INSERT);
            Int32 affectedRows = ExcuteSql(sql, entity);
            return affectedRows > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        public bool Update(TEntity entity)
        {
            String sql = GenerateSql<TEntity>(entity, Infrastructure.SqlOperationType.UPDATE);
            Int32 affectedRows = ExcuteSql(sql, entity);
            return affectedRows > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        public bool Delete(TEntity entity)
        {
            String sql = GenerateSql<TEntity>(entity, Infrastructure.SqlOperationType.DELETE);
            Int32 affectedRows = ExcuteSql(sql, entity);
            return affectedRows > 0;
        }

    }
}
