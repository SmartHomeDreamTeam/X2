using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SimpleInjector.Extensions;
using X2.NHibernate;
using X2.Services.Runtime.Implementation.Repository;
using X2.Services.Runtime.Repository;
using Container = SimpleInjector.Container;

namespace X2.Bootstrapper
{
    public class WebBootStrapper : BootStrapperbase
    {
        public override Container Boot()
        {
            var container = base.Initial();

            container.Register<INHibernateService>(() => new NHibernateService(new List<string> { typeof(NHibernateService).Namespace }));
                                                                                                  
            container.Register<IRepositoryService, RepositoryService>();

            return container;
        }
    }
}
