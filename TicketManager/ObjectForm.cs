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
        private int currentRecordId;
        private string ticketNumber;

        public ObjectForm()
        {
            InitializeComponent();

            objects = new Objects();

            cmbActivity.Items.AddRange(Objects.activityList);
        }
        public ObjectForm(string ticketnr): this()
        {
            ticketNumber = ticketnr;
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
            currentRecordId          = data.id;

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
                id           = Convert.ToInt32(rowView.Row["ID"]),
                ticketNumber = rowView.Row["TicketNumber"].ToString(),
                objectName   = rowView.Row["ObjectName"].ToString(),
                activity     = rowView.Row["Activity"].ToString(),
                comments     = rowView.Row["Comments"].ToString()
            };

            newRecord = false;

            ShowUpdateTab(data);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result;
            Objects.ObjectData data = new Objects.ObjectData()
            {
                ticketNumber = txtTicket.Text,
                activity     = cmbActivity.Text,
                objectName   = txtObject.Text,
                comments     = rtbComments.Text
            };
            if (newRecord)
            {
                // Insert
                data.id = 0;
                result = objects.Insert(data);

            }
            else
            {
                // Update
                data.id = currentRecordId;
                result  = objects.Update(data);
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
                    // Blankout input fields
                    txtTicket.Text            = ticketNumber;
                    txtObject.Text            = "";
                    rtbComments.Text          = "";
                    cmbActivity.SelectedIndex = -1;

                    toolStripStatusLabel1.Text = "Objects related to ticket number";
                    break;
                case 1:
                     toolStripStatusLabel1.Text = "Updates object record";
                     break;
                default:
                    toolStripStatusLabel1.Text = "Search for objects";
                    break;
            }
        }

        private void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender.GetType().ToString() == "System.Windows.Forms.TabControl" && tabs.SelectedTab.Name == "tabUpdate")
            {
                newRecord = true;
                txtTicket.Text = ticketNumber;
                toolStripStatusLabel1.Text = "Creates new record";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objects.Delete(currentRecordId);
            toolStripStatusLabel1.Text = Objects.LastMessage;
        }
    }
}
