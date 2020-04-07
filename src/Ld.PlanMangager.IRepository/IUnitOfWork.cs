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

        void Commit();


    }
}
