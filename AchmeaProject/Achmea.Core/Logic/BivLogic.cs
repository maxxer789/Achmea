using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class BivLogic
    {
        readonly IBiv _IBiv;

        public BivLogic(IBiv IBiv)
        {
            _IBiv = IBiv;
        }

        public List<BivModel> GetBiv()
        {
            return _IBiv.GetBiv();
        }
    }
}

