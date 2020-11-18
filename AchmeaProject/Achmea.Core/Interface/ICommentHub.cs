using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achmea.core.Interfaces
{
    public interface ICommentHub
    {
        Task RecieveMessage(string comment);
    }
}
