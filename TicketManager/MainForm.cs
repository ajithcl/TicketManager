using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManager
{
    public partial class MainForm : Form
    {
        private readonly Tickets tickets;

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
        }

        private void cmbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            string status = cmbStatusFilter.SelectedItem.ToString();
            dgvTickets.DataSource = tickets.GetDataBasedStatus(status);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAllFields();
            EnableEditFields(false);
        }

        private void btnDateFilter_Click(object sender, EventArgs e)
        {
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
                DisplayStatus(StatusTypes.success.ToString());
                clearAllFields();
                EnableEditFields(false);
            }
            else
                DisplayStatus(StatusTypes.error.ToString());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordAction = RecordAction.update.ToString();
            EnableEditFields(true);
        }

        private void clearAllFields()
        {
            //TODO : Code for clearing fields.
            txtTicketNo.Text = "";
            txtDescription.Text = "";
            rtbComments.Text = "";
            cmbEditStatus.SelectedIndex = -1;
        }
        private void EnableEditFields(bool enable)
        {
            txtTicketNo.Enabled = enable;
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

        private void DisplayStatus( string type)
        {
            lblStripStatus.Text = Tickets.LastError;

            if (type == StatusTypes.error.ToString())
            {
                lblStripStatus.BackColor = System.Drawing.Color.Red;
            }
            else if (type == StatusTypes.success.ToString())
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else if (type == StatusTypes.general.ToString())
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightGray;
            }
            else if (type == StatusTypes.warning.ToString())
            {
                lblStripStatus.BackColor = System.Drawing.Color.LightYellow;
            } 
        }

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

        private void ViewFieldData(Tickets.TicketData data)
        {
            txtTicketNo.Text = data.ticketNumber;
            txtDescription.Text = data.description;
            cmbEditStatus.Text = data.status;
            rbComments.Text = data.comments;

        }
    }
}
