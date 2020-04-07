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
        public bool Add(PlanType entity)
        {
            //StringBuilder sbSql = new StringBuilder();
            //sbSql.Append($"INSERT INTO {TableName} ");
            //sbSql.Append(" ( Id, Date, PlanTypeId, Description, PlanSpendTimes, Remark, CreateTime) ");
            //sbSql.Append(" VALUES  ");
            //sbSql.Append(" ( @Id, @Date, @PlanTypeId, @Description, @PlanSpendTimes, @Remark, @CreateTime )");
            //sbSql.Append("");

            //int result = ExcuteSql(sbSql.ToString(), entity) ;

            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.INSERT);
            int result = ExcuteSql(sql, entity);

            return result > 0;
        }

        public bool Delete(PlanType entity)
        {
            //StringBuilder sbSql = new StringBuilder();
            //sbSql.Append($"DELETE FROM {TableName} WHERE Id=@Id ");

            //int result = ExcuteSql(sbSql.ToString(), new { Id = entity.Id });

            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.DELETE);
            int result = ExcuteSql(sql, entity);
            return result > 0;
        }

        public bool Update(PlanType entity)
        {
            //StringBuilder sbSql = new StringBuilder();
            //sbSql.Append($"UPDATE {TableName} ");
            //sbSql.Append(" SET ");
            //sbSql.Append(" Date = @Date, PlanTypeId = @PlanTypeId, Description = @Description, PlanSpendTimes = @PlanSpendTimes, Remark = @Remark, LastUpdateTime = @LastUpdateTime ");
            //sbSql.Append(" ");
            //sbSql.Append(" WHERE Id=@Id ");
            //sbSql.Append(" ");

            //int result = ExcuteSql(sbSql.ToString(), entity);

            String sql = GenerateSql<PlanType>(entity, Infrastructure.SqlOperationType.UPDATE);
            int result = ExcuteSql(sql, entity);
            return result > 0;
        }


    }
}
