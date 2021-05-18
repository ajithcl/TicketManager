using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManager
{
    public partial class MainForm : Form
    {
        private readonly Tickets tickets;
        private Dictionary<string, int> statusCount = new Dictionary<string, int>();
        private string projectDirectory;

        // Standard constant record actions
        private enum RecordAction
        {
            insert,
            update
        }

        // Settings for status label display
        private enum StatusTypes
        {
            success,
            error,
            warning,
            general
        }
        private string recordAction;
        public MainForm()
        {
            InitializeComponent();

            LoadControls();
            EnableEditFields(false);
            tickets = new Tickets();
        }
        private void LoadControls()
        {
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.AddRange(Tickets.ticketStatusList);

            cmbEditStatus.Items.AddRange(Tickets.ticketStatusList);

            //TODO
            projectDirectory = ConfigurationManager.AppSettings.Get("ProjectDirectory");

            if (projectDirectory.Length == 0 )
                DisplayStatus("project directory not configured!", StatusTypes.error);
        }

        private void cmbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            string status = cmbStatusFilter.SelectedItem.ToString();
            dgvTickets.DataSource = tickets.GetDataBasedStatus(status);
            DisplayStatus("Status filter applied.", StatusTypes.general);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAllFields();
            EnableEditFields(false);
            tickets.CloseSqlConection();
        }

        private void btnDateFilter_Click(object sender, EventArgs e)
        {
            DisplayStatus("Completion date filter applied.", StatusTypes.general);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordAction = RecordAction.insert.ToString();
            EnableEditFields(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            Tickets.TicketData ticketData = new Tickets.TicketData
            {
                ticketNumber = txtTicketNo.Text,
                status = cmbEditStatus.Text,
                description = txtDescription.Text,
                comments = rtbComments.Text
            };
            if (recordAction == RecordAction.insert.ToString())
            {
                // INSERT
                result = tickets.Insert(ticketData);
            }
            else if (recordAction == RecordAction.update.ToString())
            {
                // UPDATE
                 result = tickets.Update(ticketData);
            }
            if (result)
            {
                //SUCCESS
                DisplayStatus(Tickets.LastError,StatusTypes.success);
                clearAllFields();
                EnableEditFields(false);

                DisplayStatus(Tickets.LastError, StatusTypes.success);

                // Refresh grid view
                string status = cmbStatusFilter.Text;
                dgvTickets.DataSource = tickets.GetDataBasedStatus(status);

                // Status count refresh
                RefreshStatusCounts();

                // Create ticket folder
                string ticketDirPath = projectDirectory + "\\" +ticketData.ticketNumber;
                try
                {
                    if (Directory.Exists(ticketDirPath))
                    {
                        DisplayStatus($"Directory : {ticketDirPath.Trim()} already exists!", StatusTypes.warning);
                    }
                    else
                    {
                        Directory.CreateDirectory(ticketDirPath);
                    }
                }
                catch(Exception ex)
                {
                    DisplayStatus($"Error while creating directory {ticketDirPath}. {ex.Message}", StatusTypes.error);
                }
            }
            else
                DisplayStatus(Tickets.LastError,StatusTypes.error);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordAction = RecordAction.update.ToString();
            EnableEditFields(true);
        }

        #region clearAllFields
        private void clearAllFields()
        {
            //TODO : Code for clearing fields.
            txtTicketNo.Text = "";
            txtDescription.Text = "";
            rtbComments.Text = "";
            cmbEditStatus.SelectedIndex = -1;
            lblStripStatus.Text = "";
        }
        #endregion

        #region EnableEditFields
        private void EnableEditFields(bool enable)
        {
            if (enable && recordAction == RecordAction.insert.ToString())
            {
                txtTicketNo.Enabled = enable;
            }
            else
                txtTicketNo.Enabled = false;
            txtDescription.Enabled = enable;
            cmbEditStatus.Enabled = enable;
            rtbComments.Enabled = enable;
            btnCancel.Enabled = enable;
            btnSave.Enabled = enable;
            btnDirectory.Enabled = enable;
            btnShowObjects.Enabled = enable;
            btnMail.Enabled = enable;
            btnTimeStamp.Enabled = enable;
        }
        #endregion

        #region DisplayStatus
        private void DisplayStatus( string message,StatusTypes type)
        {
            lblStripStatus.Text = message;

            if (type == StatusTypes.error)
            {
                lblStripStatus.BackColor = System.Drawing.Color.Red;
            }
            else if (type == StatusTypes.success)
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (type == StatusTypes.general)
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightGray;
            }
            else if (type == StatusTypes.warning)
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightYellow;
            } 
        }
        #endregion

        private void dgvTickets_SelectionChanged(object sender, EventArgs e)
        {
            if ((dgvTickets.SelectedRows.Count) == 0)
                    return;
            var row = dgvTickets.SelectedRows[0];
            if (row == null)
                return;
            DataRowView rowView = (DataRowView)row.DataBoundItem;
            if (rowView == null)
                return;

            Tickets.TicketData ticketData = new Tickets.TicketData
            {
                ticketNumber = rowView.Row["TicketNumber"].ToString(),
                description = rowView.Row["Description"].ToString(),
                status = rowView.Row["Status"].ToString(),
                comments = rowView.Row["Comments"].ToString()
            };

            ViewFieldData(ticketData);

        }

        #region ViewFieldData
        private void ViewFieldData(Tickets.TicketData data)
        {
            txtTicketNo.Text = data.ticketNumber;
            txtDescription.Text = data.description;
            cmbEditStatus.Text = data.status;
            rtbComments.Text = data.comments;

            btnDirectory.Enabled = true;
            btnMail.Enabled = true;
            btnShowObjects.Enabled = true;
        }
        #endregion

        private void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataRowView rowView = (DataRowView)dgvTickets.Rows[e.RowIndex].DataBoundItem;
            if (rowView == null)
                return;

            Tickets.TicketData ticketData = new Tickets.TicketData
            {
                ticketNumber = rowView.Row["TicketNumber"].ToString(),
                description = rowView.Row["Description"].ToString(),
                status = rowView.Row["Status"].ToString(),
                comments = rowView.Row["Comments"].ToString()
            };

            ViewFieldData(ticketData);

            recordAction = RecordAction.update.ToString();
            EnableEditFields(true);
            DisplayStatus("Ready for update", StatusTypes.general);

        }

        #region RefreshStatusCounts
        private void RefreshStatusCounts()
        {
            statusCount = tickets.GetStatusCount();
            if (statusCount != null)
            {
                lblAnalysis.Text = statusCount["Analysis"].ToString();
                lblAssigned.Text = statusCount["Assigned"].ToString();
                lblCompleted.Text = statusCount["Completed"].ToString();
                lblInProgress.Text = statusCount["In Progress"].ToString();
                lblNeedToStart.Text = statusCount["NeedToStart"].ToString();
                lblWaiting.Text = statusCount["Waiting"].ToString();
                lblTotal.Text = statusCount["Total"].ToString();
            }
            else
                DisplayStatus(Tickets.LastError, StatusTypes.error);
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshStatusCounts();
        }

        private void btnSearchKeyWord_Click(object sender, EventArgs e)
        {
            DisplayStatus("Keyword search filter applied.", StatusTypes.general);
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (projectDirectory.Length == 0)
                return;
            string ticketNumber = txtTicketNo.Text;
            string ticketDirectory = projectDirectory + "\\" + ticketNumber;
            if (Directory.Exists(ticketDirectory))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = ticketDirectory,
                    FileName = "explorer.exe"
                };
            Process.Start(startInfo);
            }
            else
            {
                DisplayStatus($"Directory : {ticketDirectory.Trim()} does not exist.", StatusTypes.error);
            }
        }
    }
}
