using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class RequirementModel
    {
        public int RequiermentID { get; }
        public string name { get; }
        public string description { get; }
        public string details { get; }
        public string family { get; }
        public string requiermentNumber { get; }
        public string mainGroup { get; }
#nullable enable
        public string? status { get; }
#nullable disable

        public RequirementModel()
        {

        }

        public RequirementModel(int id)
        {
            RequiermentID = id;
        }
    }
}
