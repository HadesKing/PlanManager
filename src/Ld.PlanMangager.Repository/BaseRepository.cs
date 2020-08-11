using Dapper;
using Ld.PlanMangager.Infrastructure;
using Ld.PlanMangager.Infrastructure.DataMapping;
using Ld.PlanMangager.Infrastructure.TSqlRules;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Ld.PlanMangager.Repository
{
    /// <summary>
    /// Repository 基类
    /// </summary>
    public abstract class BaseRepository
    {
        protected virtual string TableName { get; set; }

        protected IList<ITSqlRule> m_sqlRules = null;

        protected BaseRepository()
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
        protected Int32 ConnectionCommandTimeout => 300;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected virtual string ConnectionString => ConnectionStringManager.GetConnectionString();

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
        /// <param name="argConnectionString">数据库连接字符串</param>
        /// <returns></returns>
        protected IDbConnection GetDbConnection(bool isOpenConnection = true, String argConnectionString = null)
        {
            IDbConnection dbConnection = null;

            try
            {
                dbConnection = new MySqlConnection(argConnectionString ?? ConnectionString);
                if (isOpenConnection) dbConnection.Open();
            }
            catch
            {
                throw;
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
            using IDbConnection dbConnection = GetDbConnection();
            Int32 affectedRows = ExecuteSql((conn) => conn.Execute(sql, param, null, ConnectionCommandTimeout, commandType));
            //affectedRows = dbConnection.Execute(sql, param, null, ConnectionCommandTimeout, commandType);

            return affectedRows;
        }

        /// <summary>
        /// 校验 sql 语句
        /// </summary>
        /// <param name="sql">语句</param>
        protected void ValidateSql(String sql)
        {
            bool result;

            foreach (ITSqlRule rule in m_sqlRules)
            {
                result = rule.IsMatch(sql);
                if (result)
                {
                    throw new Exception(rule.ErrorMsg);
                }
            }
        }

        /// <summary>
        /// 生成SQL语句
        /// 说明：
        ///     SELECT 子句的 WHERE 子句不进行处理（需要自行拼接）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="sqlOperationType"></param>
        /// <returns></returns>
        protected String GenerateSql<TEntity>(TEntity entity, SqlOperationType sqlOperationType) where TEntity : class
        {
            char spaceCharacter = '?';      //这里是mysql所以直接使用?
            StringBuilder sbSql = new StringBuilder();
            String tableName = DbTableMapping.GetTableName(entity);
            Dictionary<String, String> columnMappingDict = DbTableColumnMapping.GetColumnMapping(entity.GetType());
            Dictionary<String, String> primaryKey = null;
            if (null != columnMappingDict && columnMappingDict.Count > 0)
            {
                switch (sqlOperationType)
                {
                    case SqlOperationType.INSERT:
                        sbSql.Append($"INSERT INTO {tableName} ");
                        StringBuilder sbColumns = new StringBuilder();
                        StringBuilder sbValues = new StringBuilder();
                        foreach (KeyValuePair<String, String> keyValuePair in columnMappingDict)
                        {
                            sbColumns.Append($"`{keyValuePair.Value}`,");
                            sbValues.Append($"{spaceCharacter}{keyValuePair.Key},");
                        }
                        sbSql.Append($"({sbColumns.ToString().Trim(',')})");
                        sbSql.Append(" VALUES ");
                        sbSql.Append($"( {sbValues.ToString().Trim(',')} );");
                        break;
                    case SqlOperationType.DELETE:
                        primaryKey = DbTablePrimaryKeyMapping.GetPrimaryKey(entity.GetType());
                        if (null != primaryKey)
                        {
                            foreach (KeyValuePair<String, String> keyValuePair in primaryKey)
                            {
                                sbSql.Append($"DELETE FROM {tableName} WHERE `{keyValuePair.Value}` = {spaceCharacter}{keyValuePair.Key};");
                                break;
                            }
                        }
                        break;
                    case SqlOperationType.UPDATE:
                        primaryKey = DbTablePrimaryKeyMapping.GetPrimaryKey(entity.GetType());
                        if (null != primaryKey)
                        {
                            foreach (KeyValuePair<String, String> keyValuePair in primaryKey)
                            {
                                StringBuilder sbSet = new StringBuilder();
                                foreach (KeyValuePair<String, String> columnMap in columnMappingDict)
                                {
                                    if (keyValuePair.Key.ToLower() != columnMap.Key.ToLower())
                                        sbSet.Append($" `{columnMap.Value}` = {spaceCharacter}{columnMap.Key},");
                                }
                                sbSql.Append($"UPDATE {tableName} " +
                                    $"SET {sbSet.ToString().Trim(',')} " +
                                    $"WHERE {keyValuePair.Value} = {spaceCharacter}{keyValuePair.Key};");
                                break;
                            }
                        }
                        break;
                    default:        //select
                        StringBuilder columns = new StringBuilder();
                        sbSql.Append("SELECT ");
                        foreach (KeyValuePair<String, String> keyValuePair in columnMappingDict)
                        {
                            columns.Append($" `{keyValuePair.Value}` AS '{keyValuePair.Key}', ");
                        }
                        sbSql.Append($" FROM {tableName} ");
                        break;
                }
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="func">执行函数</param>
        /// <returns></returns>
        /// <example>
        /// public List<UserModel> GetList()
        /// {
        ///     return Execute((conn) =>
        ///     {
        ///         var list = conn.Query<UserModel>("select * from users").ToList();
        ///         return list;
        ///     });
        /// }
        /// 
        /// public bool Insert()
        /// {
        ///     return Execute((conn) =>
        ///     {
        ///         var execnum = conn.Execute("insert into xxx ");
        ///         return execnum > 0;
        ///     });
        /// }
        /// 
        /// public bool Update()
        /// {
        ///     return Execute((conn) =>
        ///     {
        ///         var execnum = conn.Execute("update xxx ....");
        ///         return execnum > 0;
        ///     });
        /// }
        ///
        /// </example>
        protected T ExecuteSql<T>(Func<IDbConnection, T> func)
        {
            using IDbConnection connection = GetDbConnection();
            return func(connection);
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="argConnectionString">数据库连接字符串</param>
        /// <param name="func">执行函数</param>
        /// <returns></returns>
        public T ExecuteSql<T>(String argConnectionString, Func<IDbConnection, T> func)
        {
            using IDbConnection connection = GetDbConnection(true, argConnectionString:argConnectionString);
            return func(connection);
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="func">执行函数</param>
        /// <returns></returns>
        /// <example>
        /// public bool Insert()
        /// {
        /// 	return Execute((conn, trans) =>
        /// 	{
        ///         try
        ///         {
        /// 		var execnum = conn.Execute("insert into xxx ", transaction: trans);
        /// 		if (execnum == 0) return false;
        ///  
        /// 		var execnum2 = conn.Execute("update xxx set xxx", transaction: trans);
        /// 		if (execnum2 > 0) trans.Commit();
        /// 
        /// 		return execnum > 0;
        ///         }
        ///         catch
        ///         {
        ///             transaction.Rollback();
        ///             throw;
        ///         }
        /// 	});
        /// }
        /// </example>
        public T ExecuteTransaction<T>(Func<IDbConnection, IDbTransaction, T> func)
        {
            using IDbConnection connection = GetDbConnection(true);
            using var transaction = connection.BeginTransaction();
            return func(connection, transaction);
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="argConnectionString">数据库连接字符串</param>
        /// <param name="func">执行函数</param>
        /// <returns></returns>
        public T ExecuteTransaction<T>(String argConnectionString, Func<IDbConnection, IDbTransaction, T> func)
        {
            using IDbConnection connection = GetDbConnection(true, argConnectionString);
            using var transaction = connection.BeginTransaction();
            return func(connection, transaction);
        }

        #region 【Async】

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <example>
        /// 
        /// public bool Insert()
        /// {
        ///     return Execute((conn) =>
        ///     {
        ///         var execnum = conn.ExecuteAsync("insert into xxx ");
        ///         return execnum > 0;
        ///     });
        /// }
        ///
        /// </example>
        protected async Task<T> ExecuteSqlAsync<T>(Func<IDbConnection, T> func)
        {
            using IDbConnection connection = GetDbConnection();
            return  func(connection);
        }

        #endregion


    }
}
