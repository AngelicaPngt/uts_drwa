using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mapel.Models
{
    public class MapelItem
    {
        private MapelContext _context;
        public int id_mapel { get; set; }
        public string nama_mapel { get; set; }
        public string deskripsi { get; set; }
    }
}
