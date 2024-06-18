using Microsoft.AspNetCore.SignalR;


namespace HospitalServer
{
    public class HospitalChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

        }


    }
}
