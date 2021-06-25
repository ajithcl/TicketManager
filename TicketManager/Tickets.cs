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
                                            { "Assigned", "NeedToStart","Analysis", "In Progress", "Completed","Done","Waiting"};
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

        #region Constructor
        public Tickets()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbTicketManagerConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlDA = new SqlDataAdapter();
            dt = new DataTable();
        }
        #endregion

        #region GetDataBasedStatus
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
        #endregion

        #region Get Data based on completed date
        public DataTable GetDataBasedOnCompletedDates(DateTime startDate, DateTime endDate)
        {
            sqlCommand.Parameters.Clear();

            dt.Clear();

            sqlCommand.CommandText = "SELECT * FROM Tickets WHERE CompletedOn >= @startdate AND CompletedOn <= @enddate";
            sqlCommand.Parameters.AddWithValue("@startdate", startDate);
            sqlCommand.Parameters.AddWithValue("@enddate", endDate);

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }
        #endregion

        #region Get Data based on similar ticket number 
        public DataTable GetDataBasedSimilarTicketNumber(string ticketNumber)
        {
            sqlCommand.Parameters.Clear();

            dt.Clear();

            sqlCommand.CommandText = "SELECT * FROM Tickets WHERE TicketNumber LIKE @ticketnumber ";
            sqlCommand.Parameters.AddWithValue("@ticketnumber", '%' + ticketNumber + '%');

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }

        #endregion

        #region Get Data with similar comments
        public DataTable GetDatawithComments(string keyComment)
        {
            sqlCommand.Parameters.Clear();

            dt.Clear();

            sqlCommand.CommandText = "SELECT * FROM Tickets WHERE Comments LIKE @keyComment ";
            sqlCommand.Parameters.AddWithValue("@keyComment", '%' + keyComment + '%');

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }
        #endregion

        #region  Insert
        public bool Insert(TicketData ticket)
        {
            ticket.updatedOn = DateTime.Now.Date;
            ticket.createdOn = DateTime.Now.Date;
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

                LastError = "Ticket Record created.";
                return true;
            }
            catch (Exception ex)
            {
                LastError = $"Error while creating record.{ex.Message}";
                return false;
            }
        }
        #endregion

        #region update
        public bool Update(TicketData ticket)
        {
            ticket.updatedOn = DateTime.Now.Date;

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "UPDATE Tickets SET Description = @description, " +
                                                            "Status = @status, " +
                                                            "Comments = @comments, " +
                                                            "UpdatedOn = @updatedon, " + 
                                                            "CompletedOn = @completedon " + 
                                                            "WHERE TicketNumber = @ticketnumber";

                sqlCommand.Parameters.AddWithValue("@ticketnumber", ticket.ticketNumber);
                sqlCommand.Parameters.AddWithValue("@description", ticket.description);
                sqlCommand.Parameters.AddWithValue("@status", ticket.status);
                sqlCommand.Parameters.AddWithValue("@comments", ticket.comments);
                sqlCommand.Parameters.AddWithValue("@updatedon", ticket.updatedOn);

                if (ticket.status.Trim() == "Completed")
                    sqlCommand.Parameters.AddWithValue("@completedon", DateTime.Now.Date);
                else
                    sqlCommand.Parameters.AddWithValue("@completedon", DBNull.Value);

                sqlCommand.CommandType = CommandType.Text;

                sqlDA.UpdateCommand = sqlCommand;

                sqlConnection.Open();
                sqlDA.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                LastError = "Ticket updated.";
                return true;
            }
            catch (Exception ex)
            {
                LastError = $"Update Error. {ex.Message}";
                return false;
            }
            
        }
        #endregion

        #region Delete
        public bool Delete(string ticketNumber)
        {
            if (ticketNumber.Length == 0)
            {
                LastError = "Invalid ticketnumber";
                return false;
            }

            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "DELETE FROM Tickets WHERE TicketNumber=@ticketnumber";
                sqlCommand.Parameters.AddWithValue("@ticketnumber", ticketNumber);
                sqlCommand.CommandType = CommandType.Text;
                sqlDA.DeleteCommand = sqlCommand;

                int rowsAffected;

                sqlConnection.Open();
                rowsAffected = sqlDA.DeleteCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0)
                {
                    LastError = "Records deleted";
                    return true;
                }
                else
                {
                    LastError = "No records deleted.";
                    return false;
                }

            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }
        #endregion

        #region CloseSqlConection
        public void CloseSqlConection()
        {
            // Explicitly closing connection
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        #endregion

        #region GetStatusCount
        public Dictionary<string, int> GetStatusCount()
        {
            Dictionary<string, int> statusCount = new Dictionary<string, int>();

            // SQL Command : select count(case Status when 'Completed' then 1 else null end) from Tickets;

            try
            {
                foreach (string status in ticketStatusList)
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandText = "select count(case Status when @status then 1 else null end) from Tickets";
                    sqlCommand.Parameters.AddWithValue("@status", status);

                    sqlCommand.CommandType = CommandType.Text;
                    sqlDA.SelectCommand = sqlCommand;

                    sqlConnection.Open();
                    statusCount.Add(status, (int)sqlDA.SelectCommand.ExecuteScalar());
                    sqlConnection.Close();

                    
                }
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "select count (*) from Tickets";
                sqlCommand.CommandType = CommandType.Text;
                sqlDA.SelectCommand = sqlCommand;

                sqlConnection.Open();
                statusCount.Add("Total", (int)sqlDA.SelectCommand.ExecuteScalar());
                sqlConnection.Close();
                
            }
            catch (Exception ex)
            {
                LastError = $"Unable to retrieve status counts. {ex.Message}";
                return null;
            }

            return statusCount;
        }
        #endregion
    }
}
