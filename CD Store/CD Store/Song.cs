using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_Store
{
    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public Artist Artist { get; set; }

        public string MusicType { get; set; }

    }
}
