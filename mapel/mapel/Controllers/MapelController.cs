using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mapel.Models;

namespace mapel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private MapelContext _context;

        public MapelController(MapelContext context)
        {
            this._context = context;
        }

        //5. Menampilkan data mapel
        // GET: api/mapel
        [HttpGet]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetAllMapel();
        }

        //6. Menampilkan data mapel berdasarkan id_mapel
        //Get : api/mapel/{id_mapel}
        [HttpGet("{id_mapel}", Name = "Get")]
        public ActionResult<IEnumerable<MapelItem>> GetMapelItem(String id_mapel)
        {
            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.GetMapel(id_mapel);
        }

        //4. Melakukan insert data mapel
        //Post :  api/mapel
        [HttpPost]
        public ActionResult<MapelItem> AddMapel([FromForm] string nama_mapel, [FromForm] string deskripsi)
        {
            MapelItem mi = new MapelItem();
            mi.nama_mapel = nama_mapel;
            mi.deskripsi = deskripsi;

            _context = HttpContext.RequestServices.GetService(typeof(MapelContext)) as MapelContext;
            return _context.AddMapel(mi);

        }
    }
}
