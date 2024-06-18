using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalClient
{
    public partial class AnalyticsForm : Form
    {
        private readonly DataAnalyticsDataContext _dataContext = new DataAnalyticsDataContext();

        public AnalyticsForm()
        {
            InitializeComponent();
            // Populate ComboBox with the options
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            comboBox1.Items.AddRange(new object[] { "Patient Visits", "Common Ailments", "Medication Usage" });
        }


        private void btnGenerateAnalytics_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected option from the ComboBox
                var selectedOption = comboBox1.SelectedItem?.ToString();

                // Execute the selected option
                switch (selectedOption)
                {
                    case "Patient Visits":
                        DisplayPatientVisits();
                        break;
                    case "Common Ailments":
                        DisplayCommonAilments();
                        break;
                    case "Medication Usage":
                        DisplayMedicationUsage();
                        break;
                    default:
                        // Shows message if no valid option is selected
                        MessageBox.Show("Please select a valid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Shows error message if exception occurs
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // Method to show the patient visits data
        private void DisplayPatientVisits()
        {
            var query = from appointment in _dataContext.AppointTableNews
                        join patient in _dataContext.PatientTableNews on appointment.PatientID equals patient.PatientID
                        select new
                        {
                            appointment.AppID,
                            appointment.PatientID,
                            patient.Patient_FName,
                            patient.Patient_LName,
                            appointment.AppDay,
                            appointment.AppTime
                        };

            // Bind query result to DataGridView
            dataGridViewAnalytics.DataSource = query.ToList();
        }

        // Method to show common ailments data
        private void DisplayCommonAilments()
        {
            var query = from ailment in _dataContext.Ailments
                        join patient in _dataContext.PatientTableNews on ailment.PatientID equals patient.PatientID
                        group new { ailment, patient } by new
                        {
                            ailment.AilmentID,
                            ailment.PatientID,
                            patient.Patient_FName,
                            patient.Patient_LName,
                            ailment.AilmentDescription
                        } into groupedAilments
                        orderby groupedAilments.Count() descending
                        select new
                        {
                            groupedAilments.Key.AilmentID,
                            groupedAilments.Key.PatientID,
                            groupedAilments.Key.Patient_FName,
                            groupedAilments.Key.Patient_LName,
                            groupedAilments.Key.AilmentDescription,
                            OccurrenceCount = groupedAilments.Count()
                        };

            // Bind query result to DataGridView
            dataGridViewAnalytics.DataSource = query.ToList();
        }

        // Method to show medication usage data
        private void DisplayMedicationUsage()
        {
            var query = from usage in _dataContext.MedicationsUsages
                        join medication in _dataContext.MedicationsAndSupplies on usage.MedicationID equals medication.ID
                        join patient in _dataContext.PatientTableNews on usage.PatientID equals patient.PatientID
                        select new
                        {
                            usage.UsageID,
                            usage.PatientID,
                            usage.MedicationID,
                            patient.Patient_FName,
                            patient.Patient_LName,
                            medication.Name,
                            medication.Description
                        };

            // Bind query result to DataGridView
            dataGridViewAnalytics.DataSource = query.ToList();
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAnalytics = new System.Windows.Forms.Button();
            this.Reports = new System.Windows.Forms.Label();
            this.dataGridViewAnalytics = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalytics)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(77, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(624, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // buttonAnalytics
            // 
            this.buttonAnalytics.Location = new System.Drawing.Point(124, 69);
            this.buttonAnalytics.Name = "buttonAnalytics";
            this.buttonAnalytics.Size = new System.Drawing.Size(577, 23);
            this.buttonAnalytics.TabIndex = 1;
            this.buttonAnalytics.Text = "Analytics";
            this.buttonAnalytics.UseVisualStyleBackColor = true;
            // 
            // Reports
            // 
            this.Reports.AutoSize = true;
            this.Reports.Location = new System.Drawing.Point(74, 74);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(44, 13);
            this.Reports.TabIndex = 2;
            this.Reports.Text = "Reports";
            // 
            // dataGridViewAnalytics
            // 
            this.dataGridViewAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnalytics.Location = new System.Drawing.Point(77, 146);
            this.dataGridViewAnalytics.Name = "dataGridViewAnalytics";
            this.dataGridViewAnalytics.Size = new System.Drawing.Size(624, 187);
            this.dataGridViewAnalytics.TabIndex = 3;
            // 
            // AnalyticsForm
            // 
            this.ClientSize = new System.Drawing.Size(775, 397);
            this.Controls.Add(this.dataGridViewAnalytics);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.buttonAnalytics);
            this.Controls.Add(this.comboBox1);
            this.Name = "AnalyticsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnalytics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
