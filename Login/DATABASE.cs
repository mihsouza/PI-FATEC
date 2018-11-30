using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login
{
    public static class DATABASE
    {
        public static SqlConnection abrir()
        {
            string strcon = "Data Source = LAPTOP-1Q9K28V3; Initial Catalog = PROJETOJCSE; User ID =teste; Password =123456";
            SqlConnection cn = new SqlConnection(strcon);
            cn.Open();
            return cn;

        }

    }
}
