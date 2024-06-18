namespace HospitalClient
{
    partial class Form1
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
            this.btn_ptManagement = new System.Windows.Forms.Button();
            this.btn_apptManangement = new System.Windows.Forms.Button();
            this.btn_invManagement = new System.Windows.Forms.Button();
            this.btn_communications = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ptManagement
            // 
            this.btn_ptManagement.Location = new System.Drawing.Point(24, 89);
            this.btn_ptManagement.Name = "btn_ptManagement";
            this.btn_ptManagement.Size = new System.Drawing.Size(113, 37);
            this.btn_ptManagement.TabIndex = 0;
            this.btn_ptManagement.Text = "Patient Management Portal";
            this.btn_ptManagement.UseVisualStyleBackColor = true;
            this.btn_ptManagement.Click += new System.EventHandler(this.btn_ptManagement_Click);
            // 
            // btn_apptManangement
            // 
            this.btn_apptManangement.Location = new System.Drawing.Point(170, 89);
            this.btn_apptManangement.Name = "btn_apptManangement";
            this.btn_apptManangement.Size = new System.Drawing.Size(113, 37);
            this.btn_apptManangement.TabIndex = 1;
            this.btn_apptManangement.Text = "Appointment Management Portal";
            this.btn_apptManangement.UseVisualStyleBackColor = true;
            // 
            // btn_invManagement
            // 
            this.btn_invManagement.Location = new System.Drawing.Point(24, 152);
            this.btn_invManagement.Name = "btn_invManagement";
            this.btn_invManagement.Size = new System.Drawing.Size(113, 37);
            this.btn_invManagement.TabIndex = 2;
            this.btn_invManagement.Text = "Inventory Management Portal";
            this.btn_invManagement.UseVisualStyleBackColor = true;
            this.btn_invManagement.Click += new System.EventHandler(this.btn_invManagement_Click);
            // 
            // btn_communications
            // 
            this.btn_communications.Location = new System.Drawing.Point(170, 152);
            this.btn_communications.Name = "btn_communications";
            this.btn_communications.Size = new System.Drawing.Size(113, 37);
            this.btn_communications.TabIndex = 3;
            this.btn_communications.Text = "Hospital Communications";
            this.btn_communications.UseVisualStyleBackColor = true;
            this.btn_communications.Click += new System.EventHandler(this.btn_communications_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Data Analytics Portal";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hospital Management System";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_communications);
            this.Controls.Add(this.btn_invManagement);
            this.Controls.Add(this.btn_apptManangement);
            this.Controls.Add(this.btn_ptManagement);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ptManagement;
        private System.Windows.Forms.Button btn_apptManangement;
        private System.Windows.Forms.Button btn_invManagement;
        private System.Windows.Forms.Button btn_communications;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

