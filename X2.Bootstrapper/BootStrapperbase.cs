using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using SimpleInjector;
using SimpleInjector.Extensions;
using X2.NHibernate;
using X2.Services.Runtime.Implementation;
using X2.Services.Runtime.Implementation.Repository;
using X2.Services.Runtime.Repository;

namespace X2.Bootstrapper
{
    public abstract class BootStrapperbase
    {
        public Container Initial()
        {
            var container = new Container();

            var repositoryAssembly = typeof(IRepositoryService).Assembly;

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Name.EndsWith("Service")
                where !type.Name.Equals("NHibernateService")
                where !type.Name.Equals("RepositoryService")
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            return container;
        }

        public abstract Container Boot();
    }
}
