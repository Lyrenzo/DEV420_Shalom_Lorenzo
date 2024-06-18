using Microsoft.AspNetCore.SignalR.Client;
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
    public partial class CommunicationsForm : Form
    {
        private HubConnection connection;

        public CommunicationsForm()
        {
            InitializeComponent();
            InitializeSignalR();
        }

        private async void InitializeSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5299/hospitalchathub")
                .Build();

            // Receive messages
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke((Action)(() =>
                {
                    string messageText = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {user}: {message}";
                    listBoxMessages.Items.Add(messageText);
                }));
            });

            try
            {
                await connection.StartAsync();
                MessageBox.Show("Connection to Hub was successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            // Sending messages
            string user = textBoxUser.Text;
            string message = textBoxMessage.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("User and message fields cannot be empty.");
                return;
            }

            try
            {
                await connection.InvokeAsync("SendMessage", user, message);
                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
