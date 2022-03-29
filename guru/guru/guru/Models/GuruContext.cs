using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace guru.Model
{
    public class GuruContext : DbContext
    {
        public GuruContext(DbContextOptions<GuruContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }

        //public KelasContext(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sia; Uid = root; Pwd =");
        }

        public List<GuruItem> GetAllGuru()
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }

        public List<GuruItem> GetGuru(string nip)
        {
            List<GuruItem> list = new List<GuruItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM guru WHERE nip = @nip", conn);
                cmd.Parameters.AddWithValue("@nip", nip);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GuruItem()
                        {
                            id_guru = reader.GetInt32("id_guru"),
                            rfid = reader.GetString("rfid"),
                            nip = reader.GetString("nip"),
                            nama_guru = reader.GetString("nama_guru"),
                            alamat = reader.GetString("alamat"),
                            status_guru = reader.GetInt32("status_guru")
                        });
                    }
                }
            }
            return list;
        }
        public GuruItem AddGuru(GuruItem ki)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into guru (rfid, nip, nama_guru, alamat, status_guru) values (@rfid, @nip, @nama_guru, @alamat, @status_guru)", conn);
                cmd.Parameters.AddWithValue("@rfid", ki.rfid);
                cmd.Parameters.AddWithValue("@nip", ki.nip);
                cmd.Parameters.AddWithValue("@nama_guru", ki.nama_guru);
                cmd.Parameters.AddWithValue("@alamat", ki.alamat);
                cmd.Parameters.AddWithValue("@status_guru", ki.status_guru);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //list.Add(new KelasItem()
                        //{
                        //  id = reader.GetInt32("id_kelas"),
                        //  kelas = reader.GetString("kelas"),
                        //  sub = reader.GetInt32("sub"),
                        //  jurusan = reader.GetString("jurusan")
                        // });
                        // }
                        // }
                    }
                    return ki;
                }
            }
        }
    }
}
