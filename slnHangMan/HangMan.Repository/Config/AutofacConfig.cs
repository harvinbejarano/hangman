using Autofac;
using Autofac.Core;
using HangMan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository.Config
{
   public  class AutofacConfig
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<hangmanEntities>().As<hangmanEntities>()
           .Named("hangmanEntities", typeof(hangmanEntities)).InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameters(new[] {
            new ResolvedParameter((p,c) => p.Name == "context",(p,c) => c.ResolveNamed<hangmanEntities>("hangmanEntities"))
            });


            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
