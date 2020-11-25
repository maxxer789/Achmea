using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IComment
    {
        int InsertMessage(int userID, string Message, int projectID);
        IEnumerable<Comment> GetAllComments();
    }
}
