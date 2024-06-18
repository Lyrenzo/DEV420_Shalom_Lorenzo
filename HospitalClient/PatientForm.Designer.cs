namespace HospitalClient
{
    partial class PatientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_apptManangement = new System.Windows.Forms.Button();
            this.btn_communications = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_apptManangement
            // 
            this.btn_apptManangement.Location = new System.Drawing.Point(50, 80);
            this.btn_apptManangement.Name = "btn_apptManangement";
            this.btn_apptManangement.Size = new System.Drawing.Size(200, 40);
            this.btn_apptManangement.TabIndex = 1;
            this.btn_apptManangement.Text = "Appointment Management Portal";
            this.btn_apptManangement.UseVisualStyleBackColor = true;
            this.btn_apptManangement.Click += new System.EventHandler(this.btn_apptManangement_Click);
            // 
            // btn_communications
            // 
            this.btn_communications.Location = new System.Drawing.Point(50, 140);
            this.btn_communications.Name = "btn_communications";
            this.btn_communications.Size = new System.Drawing.Size(200, 40);
            this.btn_communications.TabIndex = 2;
            this.btn_communications.Text = "Hospital Communications";
            this.btn_communications.UseVisualStyleBackColor = true;
            this.btn_communications.Click += new System.EventHandler(this.btn_communications_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient Access Portal";
            // 
            // PatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_communications);
            this.Controls.Add(this.btn_apptManangement);
            this.Name = "PatientForm";
            this.Text = "PatientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_apptManangement;
        private System.Windows.Forms.Button btn_communications;
        private System.Windows.Forms.Label label1;
    }
}