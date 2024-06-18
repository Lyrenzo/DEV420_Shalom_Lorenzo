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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_invManagement_Click(object sender, EventArgs e)
        {
            InventoryManagementForm inventoryManagementForm = new InventoryManagementForm();
            inventoryManagementForm.Show();
            this.Hide();
        }

        private void btn_communications_Click(object sender, EventArgs e)
        {
            CommunicationsForm communicationsForm = new CommunicationsForm();
            communicationsForm.Show();
            this.Hide();
        }

        private void btn_ptManagement_Click(object sender, EventArgs e)
        {
            PatientManagementForm patientManagementForm = new PatientManagementForm();
            patientManagementForm.Show();
            this.Hide();
        }
    }
}
