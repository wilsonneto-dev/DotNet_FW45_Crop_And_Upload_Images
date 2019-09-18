using AppImagensTeste.Domain.Util;
using AppImagensTeste.Domain.Util.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.App.DI
{
    class DIContainer : NinjectModule
    {
        public override void Load()
        {
            // utils
            Bind<IHttpFilesHelper>().To<WebClientHttpFilesHelper>();
            Bind<IImageManipulator>().To<GenericImageManipulator>();
            Bind<ICloudHelper>().To<CloudHelper>();

        }
    }
}
