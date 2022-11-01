using Autofac;
using AutoMapper;
using connect2door.Data;
using connect2door.Data.Entity;
using connect2door.Repository.Dto;
using connect2door.Repository.Interface;
namespace connect2door.Repository.AutofacModule
{
    public class AutofacRepoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>().InstancePerLifetimeScope();

            // register dependency convention
            builder.RegisterAssemblyTypes(typeof(IDependencyRegister).Assembly)
                .AssignableTo<IDependencyRegister>()
                .As<IDependencyRegister>()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

           


            base.Load(builder);
           
        }
    }    
}
