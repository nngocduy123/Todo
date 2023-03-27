using System;
using System.Reflection;
using Autofac;
using Todo.Business.Constracts.Base;
using Todo.Data;
using Todo.Data.Constract;
using Todo.Data.Repositories;

namespace Todo.Business
{
    public class BusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AssignableTo<IPerRequest>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ToDoDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));

            base.Load(builder);
        }
    }
}

