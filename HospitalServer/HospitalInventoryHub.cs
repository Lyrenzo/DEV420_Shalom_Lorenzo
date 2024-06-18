using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Collections.Generic; 
using System.Data.SqlClient; 
using System.Threading.Tasks;



namespace HospitalServer
{
    // Hub class to handle real-time communication with clients
    public class HospitalInventoryHub : Hub
    {
        private Timer _timer;
        private readonly string connectionString = @"Data Source=ruths-garden\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True;";

        // Method to start sending inventory updates to connected clients
        public void StartInventoryUpdates()
        {
            var context = Context.ConnectionAborted; // Check if the client has disconnected
            var clients = Clients;

            // Initialize a timer to periodically send inventory updates
            _timer = new Timer(async _ =>
            {
                if (context.IsCancellationRequested)
                {
                    _timer.Dispose(); // Dispose the timer if the client has disconnected
                    return;
                }

                var inventoryStock = GetInventoryStock(); // Get the current inventory stock from the database
                await clients.All.SendAsync("ReceiveInventoryStock", inventoryStock); // Send the inventory data to all connected clients
            }, null, 0, 10000); // Set the timer interval (e.g., every 10 seconds)
        }

        // Method to fetch inventory stock from the SQL Server database
        private List<InventoryItem> GetInventoryStock()
        {
            var inventoryItems = new List<InventoryItem>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Inventory", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Populate the inventory item list with data from the database
                            inventoryItems.Add(new InventoryItem
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Threshold = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return inventoryItems;
        }

        // Method called when a client disconnects
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _timer?.Dispose(); // Dispose the timer to stop updates
            await base.OnDisconnectedAsync(exception);
        }
    }

    // Class representing an inventory item
    public class InventoryItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public int Threshold { get; set; }
    }
}