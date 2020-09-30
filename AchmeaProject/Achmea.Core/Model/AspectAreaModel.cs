using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class AspectAreaModel
    {
        private int AspectAreaId { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }

        public AspectAreaModel(int aspectAreaId, string title, string description)
        {
            AspectAreaId = aspectAreaId;
            Title = title;
            Description = description;
        }

        public string GetTitle()
        {
            return Title;
        }

        public int GetAspectArea()
        {
            return AspectAreaId;
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
