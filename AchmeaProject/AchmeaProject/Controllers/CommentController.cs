﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.ContextModels;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.Models;
using Achmea.Core.SQL;
using AchmeaProject.Hubs;
using AchmeaProject.Models;
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
        private readonly ProjectLogic _ProjectLogic;



        public CommentController([NotNull] IHubContext<CommentHub> commentHub, IProject iProject)
        {
            _ProjectLogic = new ProjectLogic(iProject);
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
            Project project =_ProjectLogic.GetReqProject(id);

            string reqName = _ProjectLogic.GetSecReqProjName(id);

            List<ProjectMember> members = _ProjectLogic.GetProjectMembers(project.ProjectId);

            List<int> membersIds = new List<int>();

            foreach(ProjectMember member in members)
            {
                membersIds.Add(member.UserId);
            }

            string user = HttpContext.Session.GetString("Firstname");



            var userID = HttpContext.Session.GetInt32("UserID");



            commentLogic.CreateMessage(userID.Value, message, id);



            await _commentHub.Clients.All.SendAsync("ReceiveMessage", user, message, id, messageID);

            await _commentHub.Clients.All.SendAsync("RecieveMessageNotification", user, reqName, project.Title, membersIds);

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