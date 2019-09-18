using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppImagensTeste.Infra.Repositories.Dapper.Base
{
    public class DapperDAO
    {
        public SqlConnection Connection { get; set; }
        public DapperDAO()
        {
            this.Connection = new SqlConnection(
                "Server=localhost\\LOCALDB;" +
                "Database=sandbox;" +
                "User Id=sa;" +
                "Password = wilsonneto;"
            );
        }
    }
}
