using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Entity
{
    public class FeedPosterLock
    {
        public int Id { get; set; }
        public int IdFeedPosterPartner { get; set; }
        public int IdFeedPoster { get; set; }
    }
}
