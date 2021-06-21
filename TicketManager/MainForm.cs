using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TicketManager
{
    public partial class MainForm : Form
    {
        private readonly Tickets tickets;
        private readonly Objects objects;
        private Dictionary<string, int> statusCount = new Dictionary<string, int>();
        private string projectDirectory, templateDocDiretory;

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
            objects = new Objects();

            cmbStatusFilter.SelectedItem = GetInitialStatusFilter();
        }

        private string GetInitialStatusFilter()
        {
            statusCount = tickets.GetStatusCount();
            if (statusCount != null)
            {
                if (statusCount["In Progress"] > 0)
                    return "In Progress";
                else if (statusCount["Assigned"] > 0)
                    return "Assigned";
                else if (statusCount["NeedToStart"] > 0)
                    return "NeedToStart";
                else if (statusCount["Waiting"] > 0)
                    return "Waiting";
                else
                    return "Completed";
            }
            else
                return "Completed";
        }
        private void LoadControls()
        {
            cmbStatusFilter.Items.Add("All");
            cmbStatusFilter.Items.AddRange(Tickets.ticketStatusList);

            cmbEditStatus.Items.AddRange(Tickets.ticketStatusList);

            projectDirectory    = ConfigurationManager.AppSettings.Get("ProjectDirectory");
            templateDocDiretory = ConfigurationManager.AppSettings.Get("TemplateDocumentsDirectory");

            if (projectDirectory.Length == 0 )
                DisplayStatus("project directory not configured!", StatusTypes.error);
            if (templateDocDiretory.Length == 0)
                DisplayStatus("Template documents path not set!", StatusTypes.error);
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
            DateTime startDate, endDate;
            startDate = dtpCompltdFrom.Value;
            endDate   = dtpCompltdTo.Value;

            dgvTickets.DataSource = tickets.GetDataBasedOnCompletedDates(startDate, endDate);

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

                if (recordAction == RecordAction.insert.ToString())
                {                
                    // Create ticket folder while creating ticket
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

                            // Copy contents from template directory to ticket directory
                            if (Directory.Exists(ticketDirPath)&& Directory.Exists(templateDocDiretory))
                            {
                                string[] filePathList = Directory.GetFiles(templateDocDiretory);
                                
                                foreach (var filepath in filePathList)
                                {
                                    string fileName = Path.GetFileName(filepath);
                                    File.Copy(filepath, ticketDirPath + "\\" + fileName);                                
                                }
                            }

                        }
                    }
                    catch(Exception ex)
                    {
                        DisplayStatus($"Error while setup directory {ticketDirPath}. {ex.Message}", StatusTypes.error);
                    }
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
            
            cmbEditStatus.Enabled = enable;            
            btnCancel.Enabled = enable;
            btnSave.Enabled = enable;
            btnDirectory.Enabled = enable;
            btnShowObjects.Enabled = enable;
            btnMail.Enabled = enable;
            btnTimeStamp.Enabled = enable;
            if (enable)
            {
                txtDescription.ReadOnly = false;
                rtbComments.ReadOnly = false;
                rtbComments.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtDescription.ReadOnly = true;
                rtbComments.ReadOnly = true;
                rtbComments.BackColor = SystemColors.Control;
            }
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
            DateTime lastDate;
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
                comments = rowView.Row["Comments"].ToString(),
                createdOn = (DateTime)rowView.Row["CreatedOn"]
                // completedOn = (DateTime)rowView.Row["CompletedOn"]
            };
            try
            {
                lastDate = (rowView.Row["CompletedOn"] != DBNull.Value)? (DateTime)rowView.Row["CompletedOn"]:DateTime.Now;
                ticketData.completedOn = lastDate;
            }
            catch
            {
                lastDate = DateTime.Now;
            }

            ViewFieldData(ticketData);

        }

        #region ViewFieldData
        private void ViewFieldData(Tickets.TicketData data)
        {
            

            txtTicketNo.Text    = data.ticketNumber;
            txtDescription.Text = data.description;
            cmbEditStatus.Text  = data.status;
            rtbComments.Text    = data.comments;

            btnDirectory.Enabled = true;
            btnMail.Enabled = true;
            btnShowObjects.Enabled = true;

            if (data.ticketNumber.Length > 0)
            {
                lblObjectCount.Text = objects.GetObjectCountForTicket(data.ticketNumber).ToString();
                try
                {
                    TimeSpan duration = data.completedOn - data.createdOn;
                    lblDuration.Text = ((int)duration.TotalDays).ToString() + " days";
                }catch
                {
                    lblDuration.Text = "-";
                }
            }
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
            if (txtKeyWord.TextLength == 0)
                return;

            if (rbTicketNo.Checked == true)
            {
                dgvTickets.DataSource = tickets.GetDataBasedSimilarTicketNumber(txtKeyWord.Text);
            }
            else if (rbComments.Checked == true)
            {
                dgvTickets.DataSource = tickets.GetDatawithComments(txtKeyWord.Text);
            }
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

        private void btnShowObjects_Click(object sender, EventArgs e)
        {
            string ticketNumber = txtTicketNo.Text;
            var frmObject = new ObjectForm(ticketNumber);
            frmObject.ShowDialog();
        }

        private void btnTimeStamp_Click(object sender, EventArgs e)
        {
            rtbComments.Text += "\n"+ DateTime.Now.ToString() + ":";

        }

        private void toExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                excelApp.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "export";

                // Storing header
                for (int i = 1; i < dgvTickets.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvTickets.Columns[i - 1].HeaderText;
                }

                // Storing cell values
                for (int i = 0; i < dgvTickets.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvTickets.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgvTickets.Rows[i].Cells[j].Value.ToString();
                    }
                }
                string desktoppath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (desktoppath.Substring(desktoppath.Length - 1) != @"\")
                {
                    desktoppath += @"\";
                }
                desktoppath += "Tickets.xlsx";

                workbook.SaveAs(desktoppath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //exit application    
                excelApp.Quit();
                DisplayStatus(desktoppath + " saved.", StatusTypes.success);
            }
            catch(Exception ex)
            {
                DisplayStatus(ex.Message, StatusTypes.error);
            }

        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {
            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem mailItem = outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            mailItem.Subject = txtTicketNo.Text;
            mailItem.Display(true);
            }
            catch(Exception ex)
            {
                DisplayStatus("Unable to launch mail", StatusTypes.error);
            }
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string displayText = $"Project directory : {projectDirectory}" +
                                 $"\nTemplate document directory : {templateDocDiretory}";
            MessageBox.Show(displayText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
