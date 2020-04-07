using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface.Interface
{
    /**
     * 参考资料：
     *      https://www.cnblogs.com/xishuai/p/3750154.html
     */

    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollbackTransaction();

        void Commit();


    }
}
