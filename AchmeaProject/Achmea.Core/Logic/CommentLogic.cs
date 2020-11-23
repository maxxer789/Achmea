using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class CommentLogic
    {

        readonly IComment _iComment;

        public CommentLogic(IComment iComment)
        {
            _iComment = iComment;
        }

        public int CreateMessage(int userID, string Message, int projectID)
        {
            try
            {
                return _iComment.InsertMessage(userID, Message, projectID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<Comment> GetAllComments()
        {
            try
            {
                return _iComment.GetAllComments();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
