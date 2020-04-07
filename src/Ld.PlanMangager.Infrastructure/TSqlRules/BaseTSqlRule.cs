using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.TSqlRules
{
    public abstract class BaseTSqlRule : ITSqlRule
    {
        public string ErrorMsg { get; protected set; }

        public abstract bool IsMatch(string sql);

    }
}
