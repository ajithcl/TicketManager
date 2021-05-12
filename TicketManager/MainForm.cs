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
        private string recordAction;
        public MainForm()
        {
            InitializeComponent();
            LoadControls();
            tickets = new Tickets();

        }
        private void LoadControls()
        {
            cmbStatusFilter.Items.AddRange(Tickets.ticketStatusList);
        }

        private void cmbStatusFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            string status = cmbStatusFilter.SelectedItem.ToString();
            dgvTickets.DataSource = tickets.GetDataBasedStatus(status);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnDateFilter_Click(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordAction = RecordAction.insert.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (recordAction == RecordAction.insert.ToString())
            {
                Tickets.TicketData ticketData = new Tickets.TicketData
                {
                    ticketNumber = txtTicketNo.Text,
                    description = txtDescription.Text,
                    comments = rtbComments.Text,
                    createdOn = DateTime.Now.Date,
                    updatedOn = DateTime.Now.Date
                };

                tickets.Insert(ticketData);
            }
            else if (recordAction == RecordAction.update.ToString())
            {
                Tickets.TicketData ticketData = new Tickets.TicketData
                {
                    ticketNumber = txtTicketNo.Text,
                    description = txtDescription.Text,
                    comments = rtbComments.Text,
                    createdOn = DateTime.Now.Date,
                    updatedOn = DateTime.Now.Date
                };

                //TODO : Call update method
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordAction = RecordAction.update.ToString();
        }
    }
}
