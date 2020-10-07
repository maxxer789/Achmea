using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class AspectAreaModel
    {
        public int AspectAreaId { get; }
        public string Title { get; }
        public string Description { get;}

        public AspectAreaModel()
        {

        }
        public AspectAreaModel(int aspectAreaId, string title, string description)
        {
            AspectAreaId = aspectAreaId;
            Title = title;
            Description = description;
        }
    }
}
