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

        public struct TicketData
        {
            public string ticketNumber, description, status, comments;
            public DateTime createdOn, updatedOn, completedOn;
        }

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

        // Insert data
        public bool Insert(TicketData ticket)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "INSERT INTO Tickets (TicketNumber,Description,Status,Comments,CreatedOn,UpdatedOn)" +
                                         "VALUES (@ticketnumber, @description, @status, @comments, @createdon,@updatedon)";
                sqlCommand.Parameters.AddWithValue("@ticketnumber", ticket.ticketNumber);
                sqlCommand.Parameters.AddWithValue("@description", ticket.description);
                sqlCommand.Parameters.AddWithValue("@status", ticket.status);
                sqlCommand.Parameters.AddWithValue("@comments", ticket.comments);
                sqlCommand.Parameters.AddWithValue("@createdon", ticket.createdOn);
                sqlCommand.Parameters.AddWithValue("@updatedon", ticket.updatedOn);

                sqlCommand.CommandType = CommandType.Text;

                sqlDA.InsertCommand = sqlCommand;

                sqlConnection.Open();
                sqlDA.InsertCommand.ExecuteNonQuery();
                sqlConnection.Close();

                LastError = "Record Inserted";
                return true;
            }
            catch (Exception ex)
            {
                LastError = $"Error while creating record.{ex.Message}";
                return false;
            }
        }

    }
}
