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
        Objects objects;
        public ObjectForm()
        {
            InitializeComponent();
            objects = new Objects();
        }
        public ObjectForm(string ticketnr): this()
        {
            // Display object details based on ticket number
            dgvObjects.DataSource = objects.GetDataBasedOnTicketNumber(ticketnr);
        }

        public void ShowUpdateTab()
        {
            this.tabs.SelectTab(1);
        }

        private void dgvObjects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowUpdateTab();
        }
    }
}
