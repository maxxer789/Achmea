using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Achmea.Core.SQL
{
    public class CommentDAL : AchmeaContext, IComment
    {
        public IEnumerable<Comment> GetAllComments()
        {
            return Comment.ToList();
        }

        public int InsertMessage(int userID, string Message, int ProjectID)
        {
            Comment comment = new Comment();
            comment.UserId = userID;
            comment.Content = Message;
            comment.PostDateTime = DateTime.Now;
            comment.SecurityRequirementProjectId = ProjectID;

            Comment.Add(comment);
            SaveChanges();

            return comment.CommentId;
        }
    }
}
