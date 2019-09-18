using AppImagensTeste.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Interface
{
    public interface IFeedPosterLockRepository
    {
        FeedPosterLock Save(FeedPosterLock feedPosterLock);
        Boolean RemoveAll(int idFeedPosterPartner);
    }
}
