using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalClient
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
    }
}