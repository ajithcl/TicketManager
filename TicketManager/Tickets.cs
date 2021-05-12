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
    class Tickets
    {
        public static string[] ticketStatusList = new string[]
                                            { "All", "Assigned", "NeedToStart","Analysis", "In Progress", "Completed","Done","Waiting"};
        public static string LastError
        {
            get;set;
        }

        // Database connection fields
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private readonly SqlCommand sqlCommand;
        private readonly SqlDataAdapter sqlDA;
        private readonly DataTable dt;

        // Constructor
        public Tickets()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbTicketManagerConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlDA = new SqlDataAdapter();
            dt = new DataTable();
        }

        // Access records based on Ticket Status
        public DataTable GetDataBasedStatus(string status)
        {
            sqlCommand.Parameters.Clear();
            // Clear the datatable
            dt.Clear();

            if (status == "All")
            {
                sqlCommand.CommandText = "SELECT * FROM Tickets";
            }
            else
            {
                sqlCommand.CommandText = "SELECT * FROM Tickets WHERE Status = @status";
                sqlCommand.Parameters.AddWithValue("@status", status);
            }

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }

    }
}
