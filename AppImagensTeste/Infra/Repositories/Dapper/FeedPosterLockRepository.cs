using AppImagensTeste.Domain.Entity;
using AppImagensTeste.Domain.Interface;
using AppImagensTeste.Infra.Repositories.Dapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace AppImagensTeste.Infra.Repositories.Dapper
{
    public class FeedPosterLockRepository : DapperDAO, IFeedPosterLockRepository
    {
        public bool RemoveAll(int idFeedPosterPartner)
        {
            this.Connection.Execute("DELETE FROM FeedPosterLocks WHERE IdFeedPosterPartner = @IdFeedPosterPartner", new { IdFeedPosterPartner = idFeedPosterPartner });
            return true;
        }

        public FeedPosterLock Save(FeedPosterLock feedPosterLock)
        {
            long id = this.Connection.Insert<FeedPosterLock>(feedPosterLock);
            feedPosterLock.IdFeedPoster = (int)id;
            return feedPosterLock;
        }
    }
}
