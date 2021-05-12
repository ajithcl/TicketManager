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
    }
}
