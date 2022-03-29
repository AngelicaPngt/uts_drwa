using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jadwalguru.Models
{
    public class JadwalContext:DbContext
    {
        public JadwalContext(DbContextOptions<JadwalContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public JadwalContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sia; Uid = root; Pwd =");
        }

        public List<JadwalItem> GetAllJadwal()
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select j.id_jadwal_guru, j.tahun_akademik, j.semester, j.id_guru, g.nip, g.nama_guru, " +
                    "j.hari, j.id_kelas, j.id_mapel, j.jam_mulai, j.jam_selesai FROM jadwal_guru j INNER JOIN guru g ON j.id_guru = g.id_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")

                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwalId(string id_mapel)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select j.id_jadwal_guru, j.tahun_akademik, j.semester, j.id_guru, g.nip, g.nama_guru, " +
                    "j.hari, j.id_kelas, j.id_mapel, j.jam_mulai, j.jam_selesai FROM jadwal_guru j INNER JOIN guru g ON j.id_guru = g.id_guru" +
                    " WHERE id_mapel = @id_mapel", conn);
                cmd.Parameters.AddWithValue("@id_mapel", id_mapel);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")

                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwalNip(string nip)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select j.id_jadwal_guru, j.tahun_akademik, j.semester, j.id_guru, g.nip, g.nama_guru, " +
                    "j.hari, j.id_kelas, j.id_mapel, j.jam_mulai, j.jam_selesai FROM jadwal_guru j INNER JOIN guru g ON j.id_guru = g.id_guru" +
                    " WHERE nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id_jadwal_guru = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")

                        });
                    }
                }
            }
            return list;
        }

        public JadwalItem AddJadwal(JadwalItem ji)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into jadwal_guru (tahun_akademik, semester, id_guru, hari, id_kelas, id_mapel," +
                    "jam_mulai, jam_selesai) values (@tahun_akademik, @semester, @id_guru, @hari, @id_kelas, @id_mapel, @jam_mulai, @jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", ji.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", ji.semester);
                cmd.Parameters.AddWithValue("@id_guru", ji.id_guru);
                cmd.Parameters.AddWithValue("@hari", ji.hari);
                cmd.Parameters.AddWithValue("@id_kelas", ji.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", ji.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", ji.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", ji.jam_selesai);

                cmd.ExecuteReader();
            }
            return ji;
        }

    }
}
