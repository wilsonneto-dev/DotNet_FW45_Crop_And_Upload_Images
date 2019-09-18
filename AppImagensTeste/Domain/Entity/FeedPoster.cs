using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Domain.Entity
{
    public class FeedPoster
    {
        public int Id { get; set; }        
        public String Url { get; set; }
        public int MediaId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
