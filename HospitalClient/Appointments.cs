using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient
{
    public partial class AppointmentsForm : Form
    {
        private Label lblPatientID;
        private Label lblAppID;
        private Label lblAppointmentDate;
        private TextBox txtPatientID;
        private TextBox txtAppointmentID;
        private DateTimePicker dtpAppointmentDateTime;
        private Button btnAddAppointment;
        private Button btnUpdateAppointment;
        private DataGridView dgvAppointments;
        private Button btnDeleteAppointment;
        private DataClasses1DataContext dbContext = new DataClasses1DataContext();

        public AppointmentsForm()
        {
            InitializeComponent();
            this.btnAddAppointment.Click += new System.EventHandler(this.OnAddAppointmentClick);
            // Handle add appointment button click
            this.btnDeleteAppointment.Click += new System.EventHandler(this.OnDeleteAppointmentClick);
            // Handle delete appointment button click
            this.Load += new System.EventHandler(this.OnFormLoad);
            // Handle form load event
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                var appointments = from app in dbContext.AppointmentTables
                                   select new
                                   {
                                       app.appid,
                                       app.patientid,
                                       app.appday,
                                       app.apptime
                                   };

                dgvAppointments.DataSource = appointments.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void OnAddAppointmentClick(object sender, EventArgs e)
        {
            // Adding an appointment
            try
            {
                if (int.TryParse(txtPatientID.Text, out int patientID))
                {
                    DateTime appointmentDateTime = dtpAppointmentDateTime.Value;
                    AppointmentTable newAppointment = new AppointmentTable
                    {
                        patientid = patientID,
                        appday = appointmentDateTime.Date,
                        apptime = appointmentDateTime.TimeOfDay
                    };

                    dbContext.AppointmentTables.InsertOnSubmit(newAppointment);
                    dbContext.SubmitChanges();

                    MessageBox.Show("Appointment successfully added!");
                    LoadAppointments();
                }
                else
                {
                    MessageBox.Show("Please enter a valid Patient ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}");
            }
        }

        private void OnDeleteAppointmentClick(object sender, EventArgs e)
        {
            // Deleting an appointment
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                    int appointmentID = Convert.ToInt32(selectedRow.Cells["appid"].Value);
                    var appointmentToDelete = dbContext.AppointmentTables.SingleOrDefault(a => a.appid == appointmentID);
                    if (appointmentToDelete != null)
                    {
                        dbContext.AppointmentTables.DeleteOnSubmit(appointmentToDelete);
                        dbContext.SubmitChanges();
                        MessageBox.Show("Appointment successfully cancelled.");
                        LoadAppointments();
                    }
                    else
                    {
                        MessageBox.Show("Appointment not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling appointment: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to cancel.");
            }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.Rows[e.RowIndex];
                txtAppointmentID.Text = selectedRow.Cells["appid"].Value.ToString();
                txtPatientID.Text = selectedRow.Cells["patientid"].Value.ToString();
                dtpAppointmentDateTime.Value = Convert.ToDateTime(selectedRow.Cells["appday"].Value).Add((TimeSpan)selectedRow.Cells["apptime"].Value);
            }
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            // Code for updating appointments can be added here
        }

        private void InitializeComponent()
        {
            this.lblPatientID = new System.Windows.Forms.Label();
            this.lblAppID = new System.Windows.Forms.Label();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtAppointmentID = new System.Windows.Forms.TextBox();
            this.dtpAppointmentDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnUpdateAppointment = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Location = new System.Drawing.Point(48, 26);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(54, 13);
            this.lblPatientID.TabIndex = 0;
            this.lblPatientID.Text = "Patient ID";
            // 
            // lblAppID
            // 
            this.lblAppID.AutoSize = true;
            this.lblAppID.Location = new System.Drawing.Point(48, 62);
            this.lblAppID.Name = "lblAppID";
            this.lblAppID.Size = new System.Drawing.Size(47, 13);
            this.lblAppID.TabIndex = 1;
            this.lblAppID.Text = "App ID";
            // 
            // lblAppointmentDate
            // 
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Location = new System.Drawing.Point(48, 98);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(84, 13);
            this.lblAppointmentDate.TabIndex = 2;
            this.lblAppointmentDate.Text = "Appointment Date";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(149, 23);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(411, 20);
            this.txtPatientID.TabIndex = 3;
            // 
            // txtAppointmentID
            // 
            this.txtAppointmentID.Location = new System.Drawing.Point(149, 55);
            this.txtAppointmentID.Name = "txtAppointmentID";
            this.txtAppointmentID.Size = new System.Drawing.Size(411, 20);
            this.txtAppointmentID.TabIndex = 4;
            // 
            // dtpAppointmentDateTime
            // 
            this.dtpAppointmentDateTime.Location = new System.Drawing.Point(149, 91);
            this.dtpAppointmentDateTime.Name = "dtpAppointmentDateTime";
            this.dtpAppointmentDateTime.Size = new System.Drawing.Size(411, 20);
            this.dtpAppointmentDateTime.TabIndex = 5;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(51, 126);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(260, 23);
            this.btnAddAppointment.TabIndex = 6;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAppointment
            // 
            this.btnUpdateAppointment.Location = new System.Drawing.Point(311, 126);
            this.btnUpdateAppointment.Name = "btnUpdateAppointment";
            this.btnUpdateAppointment.Size = new System.Drawing.Size(249, 23);
            this.btnUpdateAppointment.TabIndex = 7;
            this.btnUpdateAppointment.Text = "Update Appointment";
            this.btnUpdateAppointment.UseVisualStyleBackColor = true;
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(45, 189);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(515, 159);
            this.dgvAppointments.TabIndex = 8;
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.Location = new System.Drawing.Point(45, 354);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(515, 23);
            this.btnDeleteAppointment.TabIndex = 9;
            this.btnDeleteAppointment.Text = "Delete Appointment";
            this.btnDeleteAppointment.UseVisualStyleBackColor = true;
            // 
            // AppointmentsForm
            // 
            this.ClientSize = new System.Drawing.Size(595, 400);
            this.Controls.Add(this.btnDeleteAppointment);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.btnUpdateAppointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dtpAppointmentDateTime);
            this.Controls.Add(this.txtAppointmentID);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.lblAppointmentDate);
            this.Controls.Add(this.lblAppID);
            this.Controls.Add(this.lblPatientID);
            this.Name = "AppointmentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
