using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PETSHOPMANAGEMENT
{
    internal class DbConnect
    {
        SqlConnection cn=new SqlConnection();
        SqlCommand com =new SqlCommand();
        private string con;
        public string connection()
        { 
            con= @"Data Source=LAPTOP-QT1417EM\SQLEXPRESS;Initial Catalog=databasepetstore2;Integrated Security=True";
            return con;
        }
    }
}
