using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TLMP_Paris.classes
{
    public class DBUtils
    {
        public static SqlConnection()    
        {
            GetDBConnection(string datasource, string database, string username, string password);
        }
}
