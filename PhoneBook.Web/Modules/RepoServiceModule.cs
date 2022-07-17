using Autofac;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;
using PhoneBook.Repository;
using PhoneBook.Repository.Repositories;
using PhoneBook.Repository.UnitOfWorks;
using PhoneBook.Service.Mapping;
using PhoneBook.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace PhoneBook.Web.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>));

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();




            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //InstancePerLifetimeScope == Scope
            //InstanceDependency == transient

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).
                Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).
                Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
