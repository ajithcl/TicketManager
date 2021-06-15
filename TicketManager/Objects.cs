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
            public int id;
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

        // private string ticketNumber;

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

            sqlCommand.CommandText = "SELECT ID,TicketNumber,ObjectName,Activity,CreatedOn,Comments FROM Objects WHERE TicketNumber = @ticketnumber";
            sqlCommand.Parameters.AddWithValue("@ticketnumber", ticketNumber);

            sqlCommand.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlCommand;

            sqlConnection.Open();
            sqlDA.Fill(dt);
            sqlConnection.Close();

            return dt;
        }
        #endregion

        public int NextId
        {
            get
            {
                int rowCount = 0;
                try
                {
                    sqlCommand.CommandText = "SELECT MAX(ID) FROM Objects";
                    sqlConnection.Open();
                    rowCount = (int) sqlCommand.ExecuteScalar();
                    sqlConnection.Close();

                }
                catch (Exception ex)
                {
                    LastMessage = "Unable to retrieve NextId." + ex.Message;
                }
                return rowCount + 1;
            }
            
        }

        #region INSERT
        public bool Insert(ObjectData data)
        {
            try
            {
                sqlCommand.Parameters.Clear();

                sqlCommand.CommandText = "INSERT INTO Objects (TicketNumber, ObjectName, Activity, CreatedOn, Comments)" +
                                         "VALUES (@ticketnumber, @objectname, @activity, @createdon, @comments)";

                sqlCommand.Parameters.AddWithValue("@ticketnumber", data.ticketNumber);
                sqlCommand.Parameters.AddWithValue("@objectname",   data.objectName);
                sqlCommand.Parameters.AddWithValue("@activity",     data.activity);
                sqlCommand.Parameters.AddWithValue("@createdon",    DateTime.Now.Date);
                sqlCommand.Parameters.AddWithValue("@comments",     data.comments);

                sqlCommand.CommandType = CommandType.Text;

                sqlDA.InsertCommand = sqlCommand;


                sqlConnection.Open();
                int rowsAffected = sqlDA.InsertCommand.ExecuteNonQuery();
                sqlConnection.Close();

                LastMessage = "Object record created";

                return true;
            }
            catch(Exception ex)
            {
                LastMessage = "Error while creating Obejct record." + ex.Message;
                return false;
            }
        }
        #endregion

        #region UPDATE
        public bool Update(ObjectData data)
        {
            if (data.id == 0)
            {
                LastMessage = "Invalid record id.";
                return false;
            }
            try
            {
                sqlCommand.Parameters.Clear();

                sqlCommand.CommandText = "UPDATE Objects SET Activity = @activity, Comments = @comments, ObjectName = @objectname"
                                       + " WHERE ID = @id";
                sqlCommand.Parameters.AddWithValue("@id",         data.id);
                sqlCommand.Parameters.AddWithValue("@activity",   data.activity);
                sqlCommand.Parameters.AddWithValue("@comments",   data.comments);
                sqlCommand.Parameters.AddWithValue("@objectname", data.objectName);
                
                sqlCommand.CommandType = CommandType.Text;
                sqlDA.UpdateCommand = sqlCommand;

                sqlConnection.Open();
                int rowsAffected = sqlDA.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0) {
                    LastMessage = "Object record updated";
                    return true;
                }
                else
                {
                    LastMessage = "Record didn't updated";
                    return false;
                }
            }
            catch (Exception ex)
            {
                CloseSQLConnection();
                LastMessage = "Error while updating obejct record." + ex.Message;
                return false;
            }

        }
        #endregion

        #region Delete
        public bool Delete(int rowId)
        {
            if (rowId == 0)
            {
                LastMessage = "Invalid row id to delete.";
                return false;
            }
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "DELETE FROM Objects WHERE ID = @id";
                sqlCommand.Parameters.AddWithValue("@id",rowId);
                sqlCommand.CommandType = CommandType.Text;
                sqlDA.DeleteCommand = sqlCommand;

                int rowsAffected;

                sqlConnection.Open();
                rowsAffected = sqlDA.DeleteCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0)
                {
                    LastMessage = "Record deleted successfully.";
                    return true;
                }
                else
                {
                    LastMessage = "Check record again!";
                    return false;
                }

            }
            catch(Exception ex)
            {
                LastMessage = ex.Message;
                return false;
            }
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
