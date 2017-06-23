using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services.Config
{
    public class AutofacConfig
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            HangMan.Repository.Config.AutofacConfig.RegisterTypes(builder);


            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
