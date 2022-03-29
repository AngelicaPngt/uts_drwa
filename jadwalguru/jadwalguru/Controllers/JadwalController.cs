using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jadwalguru.Models;

namespace jadwalguru.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        private JadwalContext _context;

        public JadwalController(JadwalContext context)
        {
            this._context = context;
        }

        // 8. menampilkan data guru
        // GET: api/jadwal
        [HttpGet]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetAllJadwal();
        }

        //10. menampilkan data jadwal guru berdasarkan id_mapel
        //Get : api/jadwal/{id_mapel}
        /*[HttpGet("{id_mapel}", Name = "Get")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItem(String id_mapel)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwalId(id_mapel);
        }*/

        //9. menampilkan data jadwal guru berdasarkan nip
        //Get : api/jadwal/{nip}
        [HttpGet("{nip}", Name = "Get")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwal(String nip)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwalNip(nip);
        }

        //7. Melalkukan insert jadwal guru
        //Post :  api/mapel
        [HttpPost]
        public ActionResult<JadwalItem> AddJadwal([FromForm] string tahun_akademik, [FromForm] string semester, [FromForm] int id_guru, [FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai)
        {
            JadwalItem ji = new JadwalItem();
            ji.tahun_akademik = tahun_akademik;
            ji.semester = semester;
            ji.id_guru = id_guru;
            ji.hari = hari;
            ji.id_kelas = id_kelas; 
            ji.id_mapel = id_mapel;
            ji.jam_mulai = jam_mulai;
            ji.jam_selesai = jam_selesai;

            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.AddJadwal(ji);

        }

    }
}
