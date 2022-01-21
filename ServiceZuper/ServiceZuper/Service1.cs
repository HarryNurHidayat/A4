using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceZuper
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=DESKTOP-MO2Q66U;Initial Catalog=ZUPER;Integrated Security=True";
        SqlConnection connection;
        SqlCommand com; // To connect database

        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_login,Username,Password from dbo.Login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return list;
        }

        public string Register(string username, string password, string kategori)
        {
            try
            {
                string sql = "insert into Login values('" + username + "' , '" + password + "','" + kategori + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public string UpdateRegister(string username, string password, string kategori, int id)
        {
            try
            {
                string sql2 = "update dbo.Login set Username = '" + username + "', Password = '" + password + "', Kategori = '" + kategori + "' where ID_login =" + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string DeleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select ID_login from dbo.Login where Username = '" + username + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();
                string sql2 = "delete from dbo.Login where ID_login = " + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Login(string Username, string Password)
        {
            string kategori = "";
            string sql = "select kategori from Login where Username= '" + Username + "' and Password='" + Password + "'";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }
            return kategori;
        }
        public string deleteTransaksi(string IDTransaksi)
        {
            string a = "gagal";
            try
            {
                string sql = "delete dbo.Transaksi where IDTransaksi = '" + IDTransaksi + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string editProduct(int IDProduct, string NamaProduct)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.Product set Nama_Product = '" + NamaProduct + "', where ID_Product = '" + IDProduct + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string Product(int IDProduct, string NamaProduct, string JenisProduct, int StokProduct, int Harga, DateTime Expired)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Product values ('" + IDProduct + "', '" + NamaProduct + "', '" + JenisProduct + "', '" + StokProduct + "', '" + Harga + "', '" + Expired +"')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";

                string sql2 = "update dbo.Product set Stok_Product = Stok - " + StokProduct + "where ID_ '" + StokProduct + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<Transaksi> Orders()
        {
            List<Transaksi> transaksis = new List<Transaksi>();
            try
            {
                string sql = "select ID_reservasi, Nama_Customer, No_telpon, " +
                    "Jumlah_pemesanan, Nama_Lokasi from dbo.Pemesanan p join dbo.Lokasi l on p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Transaksi data = new Transaksi();
                    data.IDTransaksi = reader.GetString(0);
                    data.IDProduct = reader.GetInt32(1);
                    data.IDPegawai = reader.GetString(2);
                    data.Tanggal = reader.GetDateTime(3);
                    transaksis.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return transaksis;
        }
        public List<Pegawai> DetailPegawai()
        {
            throw new NotImplementedException();
        }
        public List<Product> DetailProduct()
        {
            List<Product> products = new List<Product>();
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Product data = new Product();
                    data.IDProduct = reader.GetInt32(0);
                    data.NamaProduct = reader.GetString(1);
                    data.JenisProduct = reader.GetString(2);
                    data.StokProduct = reader.GetInt32(3);
                    data.Harga = reader.GetInt32(4);
                    data.Expired = reader.GetDateTime(5);
                    products.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return products;
        }
    }
}

