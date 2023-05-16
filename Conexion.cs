using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CRUD
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-9TJGN1R\\SQLEXPRESS;" +
                "DATABASE=Registro_productos;" +
                "integrated security=true;");

            cn.Open();
            return cn;
        }
    }
}
