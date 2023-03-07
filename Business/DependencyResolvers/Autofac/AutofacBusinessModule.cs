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
using Core.Utilities.Security.Jwt;
using Core.Utilities.Helpers.FileHelper;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfFindeksDal>().As<IFindeksDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<FindeksManager>().As<IFindeksService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();

            builder.RegisterType<UserBusinessRules>().SingleInstance();
            builder.RegisterType<CustomerBusinessRules>().SingleInstance();
            builder.RegisterType<RentalBusinessRules>().SingleInstance();
            builder.RegisterType<CarImageBusinessRules>().SingleInstance();
            builder.RegisterType<BrandBusinessRules>().SingleInstance();
            builder.RegisterType<ColorBusinessRules>().SingleInstance();
            builder.RegisterType<FindeksBusinessRules>().SingleInstance();
            builder.RegisterType<CarBusinessRules>().SingleInstance();
            builder.RegisterType<AuthBusinessRules>().SingleInstance();

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
