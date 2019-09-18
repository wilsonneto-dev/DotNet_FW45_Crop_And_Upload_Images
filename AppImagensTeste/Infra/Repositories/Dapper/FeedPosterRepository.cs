using AppImagensTeste.Domain.Entity;
using AppImagensTeste.Domain.Interface;
using AppImagensTeste.Infra.Repositories.Dapper.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace AppImagensTeste.Infra.Repositories.Dapper
{
    public class FeedPosterRepository : DapperDAO, IFeedPosterRepository
    {
        public List<FeedPoster> GetAllUnlocked()
        {
            return (List<FeedPoster>) this.Connection.Query<FeedPoster>(
                @"SELECT 
                    Id, Url, MediaId, Width, Height, AspecRatio
                FROM FeedPosters
                WHERE
                    Id NOT IN(SELECT DISTINCT IdFeedPoster FROM FeedPosterLocks)"
            );
        }

        public FeedPoster GetByMediaId(int mediaId)
        {
            return this.Connection.QueryFirstOrDefault<FeedPoster>(
                @"SELECT 
                    Id, Url, MediaId, Width, Height, AspecRatio
                FROM 
                    FeedPosters
                WHERE
                    MediaId = @MediaId;",
                new { MediaId = mediaId }
            );
        }

        public FeedPoster GetByMediaId(int mediaId, int width, int height)
        {
            return this.Connection.QueryFirstOrDefault<FeedPoster>(
                @"SELECT 
                    Id, Url, MediaId, Width, Height, AspecRatio
                FROM 
                    FeedPosters
                WHERE
                    MediaId = @MediaId
                    AND Width = @Width AND Height = @Height",
                new { MediaId = mediaId, Width = width, Height = height }
            );
        }

        public FeedPoster GetByMediaIdAspec(int mediaId, string aspec)
        {

            return this.Connection.QueryFirstOrDefault<FeedPoster>(
                @"SELECT 
                    Id, Url, MediaId, Width, Height, AspecRatio
                FROM 
                    FeedPosters
                WHERE
                    MediaId = @MediaId
                    AND AspecRation = @AspecRatio",
                new { MediaId = mediaId, AspecRatio = aspec }
            );
        }

        public bool Remove(FeedPoster feedPoster)
        {
            return this.Connection.Delete<FeedPoster>(feedPoster);
        }

        public FeedPoster Save(FeedPoster feedPoster)
        {
            long id = this.Connection.Insert<FeedPoster>(feedPoster);
            feedPoster.Id = (int) id;
            return feedPoster;
        }
    }
}
