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
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void btn_apptManangement_Click(object sender, EventArgs e)
        {
            // Logic for Appointment Management
            MessageBox.Show("Navigating to Appointment Management Portal");
        }

        private void btn_communications_Click(object sender, EventArgs e)
        {
            CommunicationsForm communicationsForm = new CommunicationsForm();
            communicationsForm.Show();
            this.Hide();
        }
    }
}