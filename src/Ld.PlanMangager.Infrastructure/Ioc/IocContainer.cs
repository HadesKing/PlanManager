using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.Ioc
{
    /// <summary>
    /// IOC 容器
    /// </summary>
    public class IocContainer
    {
        private IocContainer()
        {
        }

        private static readonly IocContainer _instance = new IocContainer();

        /// <summary>
        /// 容器
        /// </summary>
        private ILifetimeScope Container { get; set; }

        /// <summary>
        /// 实例
        /// </summary>
        public static IocContainer Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="container"></param>
        public void Init(ILifetimeScope container)
        {
            Container = container;
        }

        /// <summary>
        /// 获取容器中已注入的类型实例
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public TInterface Resolve<TInterface>()
        {
            try
            {
                return Container.Resolve<TInterface>();
            }
            catch
            {
                throw;
            }

        }

        public TInterface Resolve<TInterface>(string name, object value)
        {
            try
            {
                List<Autofac.Core.Parameter> parameters = new List<Autofac.Core.Parameter>();
                parameters.Add(new NamedParameter(name, value));
                return Container.Resolve<TInterface>(parameters);
            }
            catch
            {
                throw;
            }

        }

        public TInterface Resolve<TInterface>(Type type, object value)
        {
            try
            {
                List<Autofac.Core.Parameter> parameters = new List<Autofac.Core.Parameter>();
                parameters.Add(new TypedParameter(type, value));
                return Container.Resolve<TInterface>(parameters);
            }
            catch
            {
                throw;
            }

        }

    }
}
