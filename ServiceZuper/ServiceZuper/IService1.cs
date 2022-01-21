using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static ServiceZuper.Pegawai;

namespace ServiceZuper
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Product(int IDProduct, string NamaProduct, string JenisProduct, int StokProduct, int Harga, DateTime Expired);
        [OperationContract]
        string editProduct(int IDProduct, string NamaProduct);
        [OperationContract]
        string deleteTransaksi(string IDTransaksi);
        [OperationContract]
        List<Pegawai> DetailPegawai();
        [OperationContract]
        List<Product> DetailProduct();
        [OperationContract]
        List<Transaksi> Orders();
        [OperationContract]
        string Login(string Username, string Password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    [DataContract]
    public class Pegawai
    {
        [DataMember]
        public string IDPegawai { get; set; }
        [DataMember]
        public string Nama { get; set; }
        [DataMember]
        public string JenisKelamin { get; set; }
        [DataMember]
        public int Umur { get; set; }
    }

    [DataContract]
    public class Product
    {
            [DataMember]
            public int IDProduct { get; set; }
            [DataMember]
            public string NamaProduct { get; set; }
            [DataMember]
            public string JenisProduct { get; set; }
            [DataMember]
            public int StokProduct { get; set; }
            [DataMember]
            public int Harga { get; set; }
            [DataMember]
            public DateTime Expired { get; set; }
    }

    [DataContract]
     public class Transaksi
     {
            [DataMember]
            public string IDTransaksi { get; set; }
            [DataMember]
            public int IDProduct { get; set; }
            [DataMember]
            public string IDPegawai { get; set; }
            [DataMember]
            public DateTime Tanggal { get; set; }

     }
}

