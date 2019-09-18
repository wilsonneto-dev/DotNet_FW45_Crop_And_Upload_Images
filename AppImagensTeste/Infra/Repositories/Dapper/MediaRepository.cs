using AppImagensTeste.Domain.Entity;
using AppImagensTeste.Domain.Interface;
using AppImagensTeste.Infra.Repositories.Dapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace AppImagensTeste.Infra.Repositories.Dapper
{
    public class MediaRepository : DapperDAO, IMediaRepository
    {
        public Media Get(int id)
        {
            return this.Connection.Get<Media>(id);
        }
    }
}
