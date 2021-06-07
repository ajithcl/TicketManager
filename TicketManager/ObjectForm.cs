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
        private bool newRecord;

        public ObjectForm()
        {
            InitializeComponent();

            objects = new Objects();

            cmbActivity.Items.AddRange(Objects.activityList);
        }
        public ObjectForm(string ticketnr): this()
        {
            DataTable dt = objects.GetDataBasedOnTicketNumber(ticketnr);
            if (dt.Rows.Count > 0) {
                newRecord = false;
                // Display object details based on ticket number
                dgvObjects.DataSource = dt;
            }
            else
            {
                // New record. Show edit screen
                Objects.ObjectData data = new Objects.ObjectData()
                {
                    ticketNumber = ticketnr
                };
                newRecord = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result;
            Objects.ObjectData data = new Objects.ObjectData()
            {
                ticketNumber = txtTicket.Text,
                activity = cmbActivity.Text,
                objectName = txtObject.Text,
                comments = rtbComments.Text
            };
            if (newRecord)
            {
                // Insert
                result = objects.Insert(data);

            }
            else
            {
                // Update
                result = objects.Update(data);
            }
            if (Objects.LastMessage.Length > 75)
                toolStripStatusLabel1.Text = Objects.LastMessage.Substring(0, 75);
            else
                toolStripStatusLabel1.Text = Objects.LastMessage;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {               
            switch (tabs.SelectedIndex)
            {
                case 0:  
                        toolStripStatusLabel1.Text = "Objects related to ticket number";
                        break;
                case 1:
                        toolStripStatusLabel1.Text = "Update object record";
                        break;
                default:
                    toolStripStatusLabel1.Text = "Search of tickets";
                    break;
            }
        }
    }
}
