﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface
{
    /// <summary>
    /// 值对象
    /// </summary>
    /// <typeparam name="TId">id类型</typeparam>
    public interface IValueObject<TId> : IAggregate<TId>
    {
        

    }
}
