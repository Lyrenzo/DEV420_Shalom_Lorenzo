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
    public partial class PatientManagementForm : Form
    {
        private HospitalContext _context;

        public PatientManagementForm()
        {
            InitializeComponent();
            _context = new HospitalContext();
        }

        private void PatientManagementForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            MessageBox.Show("Patients loaded successfully.");
        }

        private void LoadPatients()
        {
            var loadPatients = from patient in _context.Patients
                               select new
                               {
                                   patient.PatientId,
                                   patient.FirstName,
                                   patient.LastName,
                                   patient.DateOfBirth,
                                   patient.MedicalHistory
                               };

            dataGridViewPatients.DataSource = loadPatients.ToList();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Patient newPatient = new Patient
            {
                FirstName = textBox_FirstName.Text,
                LastName = textBox_LastName.Text,
                DateOfBirth = dateTimePickerDOB.Value,
                MedicalHistory = textBox_MedicalHistory.Text
            };

            _context.Patients.Add(newPatient);
            int changes = _context.SaveChanges();
            LoadPatients();

            if (changes > 0)
            {
                MessageBox.Show("Patient added successfully.");
            }
            else
            {
                MessageBox.Show("Failed to add patient.");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                int patientId = (int)dataGridViewPatients.SelectedRows[0].Cells[0].Value;
                var patient = _context.Patients.Find(patientId);

                if (patient != null)
                {
                    patient.FirstName = textBox_FirstName.Text;
                    patient.LastName = textBox_LastName.Text;
                    patient.DateOfBirth = dateTimePickerDOB.Value;
                    patient.MedicalHistory = textBox_MedicalHistory.Text;

                    int changes = _context.SaveChanges();
                    LoadPatients();

                    if (changes > 0)
                    {
                        MessageBox.Show("Patient updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update patient.");
                    }
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                int patientId = (int)dataGridViewPatients.SelectedRows[0].Cells[0].Value;
                var patient = _context.Patients.Find(patientId);

                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    int changes = _context.SaveChanges();
                    LoadPatients();

                    if (changes > 0)
                    {
                        MessageBox.Show("Patient deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete patient.");
                    }
                }
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void dataGridViewPatients_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                int patientId = (int)dataGridViewPatients.SelectedRows[0].Cells[0].Value;
                var patient = _context.Patients.Find(patientId);

                if (patient != null)
                {
                    textBox_FirstName.Text = patient.FirstName;
                    textBox_LastName.Text = patient.LastName;
                    dateTimePickerDOB.Value = patient.DateOfBirth;
                    textBox_MedicalHistory.Text = patient.MedicalHistory;
                }
            }
        }
    }
}