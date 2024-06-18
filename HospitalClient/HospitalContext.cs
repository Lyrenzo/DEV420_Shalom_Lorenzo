using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace HospitalClient
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("name=HospitalDBConnectionString")
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}