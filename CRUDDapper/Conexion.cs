using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDDapper
{
    public class Conexion
    {
        public static string GetConnection()
        {
            return "Data Source=.;Initial Catalog=ZJuanResidenciasDapper;Persist Security Info=True;User ID=sa;Password=pass@word1";
            
        }
    }
}
