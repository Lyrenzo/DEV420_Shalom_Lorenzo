using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient
{
    public partial class LoginForm : Form
    {
        IMongoCollection<User> userCollection;
        public LoginForm()
        {
            InitializeComponent();

            // Connect to the database using the connection string in app.config and call the "users" collection
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            userCollection = database.GetCollection<User>("users");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Get username and password from textboxes
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Find if the user exists
            var filter = Builders<User>.Filter.Eq("Username", username) &
                         Builders<User>.Filter.Eq("Password", password);

            var user = userCollection.Find(filter).FirstOrDefault();

            if (user != null)
            {
                // Check user role and navigate to the appropriate form
                if (user.Role == "Staff")
                {
                    // Navigate to Staff's main form
                    Form1 staffForm = new Form1();
                    staffForm.Show();
                }
                else if (user.Role == "Patient")
                {
                    // Navigate to Patient's main form
                    PatientForm patientForm = new PatientForm();
                    patientForm.Show();
                }

                this.Hide();
            }
            else
            {
                // Error, Login failed
                MessageBox.Show("Invalid username or password");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            // Get info from the user
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string role = comboBoxRole.SelectedItem.ToString(); // Get the selected role from the combo box

            // Check if the user already exists
            var filter = Builders<User>.Filter.Eq("Username", username);
            var existingUser = userCollection.Find(filter).FirstOrDefault();

            if (existingUser == null)
            {
                // Create new user
                var user = new User
                {
                    Username = username,
                    Password = password,
                    Role = role
                };

                // Add it to the database
                userCollection.InsertOne(user);

                MessageBox.Show("Registered Successfully");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                comboBoxRole.SelectedIndex = -1; // Clear the selected role
            }
            else
            {
                // User already exists
                MessageBox.Show("Username already exists");
            }
        }
    }
}