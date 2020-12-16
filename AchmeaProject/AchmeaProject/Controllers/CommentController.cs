using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.Models;
using Achmea.Core.SQL;
using AchmeaProject.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AchmeaProject.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IHubContext<CommentHub> _commentHub;
        CommentLogic commentLogic;
        CommentDAL commentDAL;



        public CommentController([NotNull] IHubContext<CommentHub> commentHub)
        {
            commentDAL = new CommentDAL();
            commentLogic = new CommentLogic(commentDAL);
            _commentHub = commentHub;
        }




        //[HttpGet("/test")]
        //public string dunno()
        //{
        //    return "hey";
        //}



        //[HttpPost("messages")]
        //public async Task<IActionResult> Create([FromBody] ChatMessage message)
        //{



        //    await _commentHub.Clients.All.SendAsync("ReceiveMessage", message);



        //    return Ok();
        //}



        [HttpPost]
        public async Task<IActionResult> SendMessage(string message, int id, int messageID)
        {
            string user = HttpContext.Session.GetString("Firstname");



            var userID = HttpContext.Session.GetInt32("UserID");



            commentLogic.CreateMessage(userID.Value, message, id);



            await _commentHub.Clients.All.SendAsync("ReceiveMessage", user, message, id, messageID);



            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> JoinGroup(string group, string message)
        //{
        //    _commentHub.Groups.AddToGroupAsync(group);

        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> SendMessageToGroup(string group, string message)
        {
            string user = HttpContext.Session.GetString("Firstname");



            var userID = HttpContext.Session.GetInt32("UserID");



            commentLogic.CreateMessage(userID.Value, message, 1);



            await _commentHub.Clients.Group(group).SendAsync("ReceiveMessage", user, message);



            return Ok();
        }
    }
}