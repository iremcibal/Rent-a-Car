using Autofac;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            
            builder.RegisterType<UserBusinessRules>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions
               {
                   Selector = new AspectInterceptorSelector()
               })
               .SingleInstance();
        }


    }
}
