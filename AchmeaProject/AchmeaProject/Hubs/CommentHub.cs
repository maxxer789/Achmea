using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AchmeaProject.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendMessage(IHubContext<CommentHub> _commentHub, string user, string message, int id, int messageID)
        {
            await _commentHub.Clients.All.SendAsync("ReceiveMessage", user, message, id, messageID);
        }

        public async Task projectNotification(IHubContext<CommentHub> _commentHub, string project, int[] Members)
        {
            await _commentHub.Clients.All.SendAsync("ReceiveProjectNotification", project, Members);
        }
    }
}