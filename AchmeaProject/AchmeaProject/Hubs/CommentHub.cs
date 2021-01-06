using Achmea.Core.ContextModels;
using Achmea.Core.Logic;
using AchmeaProject.Models;
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

        public async Task ReqStatusChange(IHubContext<CommentHub> _commentHub, string status, string project, List<int> projectMembers)
        {
            await _commentHub.Clients.All.SendAsync("RecieveReqNotification", status, project, projectMembers);
        }
    }
}