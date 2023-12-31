using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using CorePackagesGeneral.Utilities.Helpers.FileHelper.Abstract;
using CorePackagesGeneral.Utilities.Helpers.FileHelper.Concrete;
using CorePackagesGeneral.Utilities.Interceptors;
using CorePackagesGeneral.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
        builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

        builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
        builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

        builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
        builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

        builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
        builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

        builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
        builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

        builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
        builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

        builder.RegisterType<AuthManager>().As<IAuthService>();


        builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();


        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}

