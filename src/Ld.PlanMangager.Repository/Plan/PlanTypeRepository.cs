using Ld.PlanMangager.Domain.Plan;
using Ld.PlanMangager.Repository.Interface;
using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Plan
{
    /// <summary>
    /// PlanType 仓储
    /// </summary>
    /// <remarks>
    /// 说明：
    ///     如需要查询方法，可以让IPlanTypeRepository继承接口，然后在该类中实现
    /// </remarks>
    public sealed class PlanTypeRepository : BaseRepository, IPlanTypeRepository<Domain.Plan.PlanType>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(PlanType entity)
        {
            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.INSERT);
            int result = ExcuteSql(sql, entity);

            return result > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(PlanType entity)
        {
            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.DELETE);
            int result = ExcuteSql(sql, entity);
            return result > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(PlanType entity)
        {
            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.UPDATE);
            int result = ExcuteSql(sql, entity);
            return result > 0;
        }


    }
}
