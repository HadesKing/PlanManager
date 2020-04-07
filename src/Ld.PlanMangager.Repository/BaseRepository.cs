using Dapper;
using Ld.PlanMangager.Infrastructure.TSqlRules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ld.PlanMangager.Repository
{
    /// <summary>
    /// Repository 基类
    /// </summary>
    public abstract class BaseRepository
    {
        protected virtual string TableName { get; set; }

        protected IList<ITSqlRule> m_sqlRules = null;

        public BaseRepository()
        {
            m_sqlRules = new List<ITSqlRule>() {
                new NullOrEmptyRule()
                , new SpecialCharacterRule()
                , new WhereSqlRule()
            };
        }

        /// <summary>
        /// 连接超时时间
        /// </summary>
        protected Int32 ConnectionCommandTimeout
        {
            get
            {
                return 300;
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected virtual string ConnectionString
        {
            get
            {
                return ConnectionStringManager.GetConnectionString();
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected virtual string ReadOnlyConnectionString
        {
            get
            {
                return ConnectionStringManager.GetReadOnlyConnectionString();
            }
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="isOpenConnection">是否打开连接，默认为打开</param>
        /// <returns></returns>
        protected IDbConnection GetDbConnection(bool isOpenConnection = true)
        {
            IDbConnection dbConnection = null;

            try
            {
                dbConnection = new MySqlConnection(ConnectionString);
                if (isOpenConnection) dbConnection.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != dbConnection && dbConnection.State != ConnectionState.Closed)
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }

            return dbConnection;
        }

        /// <summary>
        /// 执行SQL语句，返回受影响的函数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        protected Int32 ExcuteSql(String sql, object param = null, CommandType commandType = CommandType.Text)
        {
            ValidateSql(sql);
            Int32 affectedRows;
            using (IDbConnection dbConnection = GetDbConnection())
            {
                affectedRows = dbConnection.Execute(sql, param, null, ConnectionCommandTimeout, commandType);
            }

            return affectedRows;
        }

        /// <summary>
        /// 校验 sql 语句
        /// </summary>
        /// <param name="sql">语句</param>
        protected void ValidateSql(String sql)
        {
            bool result;

            foreach(ITSqlRule rule in m_sqlRules)
            {
                result = rule.IsMatch(sql);
                if(result)
                {
                    throw new Exception(rule.ErrorMsg);
                }
            }
        }

    }
}
