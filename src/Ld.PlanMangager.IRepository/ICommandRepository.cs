using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface
{
    /// <summary>
    /// 命令仓储接口
    /// </summary>
    public interface ICommandRepository<TEntity>
    {

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        bool Add(TEntity entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        bool Update(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">需要添加到数据库的实体（一条数据）</param>
        /// <returns>返回是否操作成功，true#成功，false#失败</returns>
        bool Delete(TEntity entity);

    }
}
