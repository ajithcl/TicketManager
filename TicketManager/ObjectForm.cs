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
    public partial class ObjectForm : Form
    {
        private readonly Objects objects;

        public ObjectForm()
        {
            InitializeComponent();

            objects = new Objects();

            cmbActivity.Items.AddRange(Objects.activityList);
        }
        public ObjectForm(string ticketnr): this()
        {
            // Display object details based on ticket number
            DataTable dt = objects.GetDataBasedOnTicketNumber(ticketnr);
            if (dt.Rows.Count > 0)
                dgvObjects.DataSource = dt;
            else
            {
                Objects.ObjectData data = new Objects.ObjectData()
                {
                    ticketNumber = ticketnr
                };
                ShowUpdateTab(data);
            }
        }

        public void ShowUpdateTab()
        {
            this.tabs.SelectTab(1);
        }
        private void ShowUpdateTab(Objects.ObjectData data)
        {
            txtTicket.Text           = data.ticketNumber;
            txtObject.Text           = data.objectName;
            rtbComments.Text         = data.comments;
            cmbActivity.SelectedItem = data.activity;

            ShowUpdateTab();
        }

        private void dgvObjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            DataRowView rowView = (DataRowView)dgvObjects.Rows[e.RowIndex].DataBoundItem;
            if (rowView == null)
                return;
            Objects.ObjectData data = new Objects.ObjectData
            {
                ticketNumber = rowView.Row["TicketNumber"].ToString(),
                objectName   = rowView.Row["ObjectName"].ToString(),
                activity     = rowView.Row["Activity"].ToString(),
                comments     = rowView.Row["Comments"].ToString()
            };


            ShowUpdateTab(data);
        }
    }
}
