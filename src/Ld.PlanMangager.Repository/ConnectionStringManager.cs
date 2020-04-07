using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository
{
    /// <summary>
    /// 连接字符串管理者
    /// </summary>
    public sealed class ConnectionStringManager
    {

        private static string m_connectionString = null;

        private static string m_readOnlyConnectionString = null;

        /// <summary>
        /// 连接字符串为空的提示信息
        /// </summary>
        private static string m_connectionStringIsEmpty = "The connection string is null or empty!";
        /// <summary>
        /// 只读连接字符串为空的提示信息
        /// </summary>
        private static string m_readOnlyConnectionStringIsEmpty = "The readonly connection string is null or empty!";

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            if (String.IsNullOrWhiteSpace(m_connectionString))
            {
                throw new Exception(m_connectionStringIsEmpty);
            }
            return m_connectionString;
        }

        /// <summary>
        /// 获取只读连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetReadOnlyConnectionString()
        {
            if (String.IsNullOrWhiteSpace(m_readOnlyConnectionString))
            {
                throw new Exception(m_readOnlyConnectionStringIsEmpty);
            }
            return m_readOnlyConnectionString;
        }

        /// <summary>
        /// 设置连接字符串的值
        /// </summary>
        /// <param name="connectionString">连接字符串，不能为空</param>
        public static void SetConnectionString(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception(m_connectionStringIsEmpty);
            }
            else
            {
                m_connectionString = connectionString;
            }
        }

        /// <summary>
        /// 设置只读连接字符串的值
        /// </summary>
        /// <param name="readOnlyConnectionString">连接字符串，不能为空</param>
        public static void SetReadOnlyConnectionString(string readOnlyConnectionString)
        {
            if (String.IsNullOrWhiteSpace(readOnlyConnectionString))
            {
                throw new Exception(m_readOnlyConnectionStringIsEmpty);
            }
            else
            {
                m_readOnlyConnectionString = readOnlyConnectionString;
            }
        }


    }
}
