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
    public partial class InventoryManagementForm : Form
    {
        private HubConnection _connection;

        public InventoryManagementForm()
        {
            InitializeComponent();
            InitializeSignalR(); 
            SetupDataGridView(); 
        }

        // Method to initialize the SignalR connection
        private async void InitializeSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5299/hospitalinventoryhub") // Set the URL of the SignalR hub
                .Build();

            // Set up a handler for receiving inventory stock updates from the server
            _connection.On<List<InventoryItem>>("ReceiveInventoryStock", items =>
            {
                Invoke(new Action(() =>
                {
                    dataGridView_Inventory.Rows.Clear(); // Clear the existing rows in the DataGridView
                    foreach (var item in items)
                    {
                        int rowIndex = dataGridView_Inventory.Rows.Add(item.Name, item.Quantity, item.Threshold);
                        if (item.Quantity < item.Threshold)
                        {
                            dataGridView_Inventory.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red; // Highlight low stock items
                        }
                    }
                }));
            });

            try
            {
                await _connection.StartAsync(); // Start the SignalR connection
                await _connection.InvokeAsync("StartInventoryUpdates"); // Invoke the method to start receiving updates
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Show an error message if the connection fails
            }
        }

        //set up the datagrid view with the needed columns and column sizes
        private void SetupDataGridView()
        {            
            dataGridView_Inventory.Columns.Add("ItemName", "Item Name");
            dataGridView_Inventory.Columns.Add("Quantity", "Quantity");
            dataGridView_Inventory.Columns.Add("Threshold", "Threshold");
            dataGridView_Inventory.Columns["ItemName"].Width = 150;
            dataGridView_Inventory.Columns["Quantity"].Width = 100;
            dataGridView_Inventory.Columns["Threshold"].Width = 100;


            this.Controls.Add(dataGridView_Inventory);
        }

        //class for inventoryItem,
        public class InventoryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Threshold { get; set; }
        }
    }
}

