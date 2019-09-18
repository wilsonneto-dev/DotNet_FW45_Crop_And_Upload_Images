using AppImagensTeste.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Interface
{
    public interface IFeedPosterRepository
    {
        FeedPoster GetByMediaId(int mediaId);
        FeedPoster GetByMediaId(int mediaId, int width, int height);
        FeedPoster GetByMediaIdAspec(int mediaId, String Aspec);
        FeedPoster Save(FeedPoster feedPoster);
        Boolean Remove(FeedPoster feedPoster);
        List<FeedPoster> GetAllUnlocked();
    }
}
