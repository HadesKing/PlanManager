using Autofac;
using Ld.PlanMangager.Domain.Plan;
using Ld.PlanMangager.Repository.Interface.Plan;
using Ld.PlanMangager.Repository.Plan;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Contrib.Autofac.DependencyInjection;

namespace Ld.PlanMangager.Manager
{
    public class AutofacModule : Module
    {

        private IConfiguration _config;

        /// <summary>
        /// 配置信息
        /// </summary>
        public IConfiguration Configuration
        {
            get => _config;
            set => _config = value;
        }

        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            //builder.Register(c => new LogService())
            //    .As<ILogService>()
            //    .InstancePerLifetimeScope();

            /*
             * 
             * InstancePerLifetimeScope 对应于 DI 中的 AddScoped
             * InstancePerDependency 对应于 DI 中的 AddTransient，也是默认的
             */

            //builder.RegisterType(typeof(UserManage)).InstancePerRequest();

            builder.RegisterType<PlanTypeRepository>().As<IPlanTypeRepository<PlanType>>().InstancePerDependency();


            builder.AddAutoMapper(typeof(PlanType).Assembly);

        }

    }
}
