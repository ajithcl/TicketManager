using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    class Objects
    {
        public static string LastMessage
        {
            get; set;
        }

        // Database connection fields
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;
        private readonly SqlDataAdapter sqlDA;
        private readonly DataTable dt;

        #region Constructor
        public Objects()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbTicketManagerConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlDA = new SqlDataAdapter();
            dt = new DataTable();
        }
        #endregion
    }
}
