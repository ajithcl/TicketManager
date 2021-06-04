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
        #region Field declarations 
        public static string LastMessage
        {
            get; set;
        }

        public struct ObjectData
        {
            public string ticketNumber, objectName, comments, activity;
        }

        public static string[] activityList = new string[]
                                                    {"New", "Delete", "Update", "Reference"};

        
        // Database connection fields
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;
        private readonly SqlDataAdapter sqlDA;
        private readonly DataTable dt;

        private string ticketNumber;

        #endregion

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


        #region GetDataBasedOnTicketNumber
        public DataTable GetDataBasedOnTicketNumber(string ticketNumber)
        {
            sqlCommand.Parameters.Clear();

            //Clear Datatable
            dt.Clear();

            sqlCommand.CommandText = "SELECT TicketNumber,ObjectName,Activity,CreatedOn,Comments FROM Objects WHERE TicketNumber = @ticketnumber";
            sqlCommand.Parameters.AddWithValue("@ticketnumber", ticketNumber);

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }
        #endregion

        #region CloseSQLConnection
        public void CloseSQLConnection()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }
        #endregion

        #region Finalizer
        ~Objects()
        {
            CloseSQLConnection();
        }
        #endregion

    }
}
