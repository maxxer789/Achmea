using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Achmea.Core.Model
{
    public class RequirementModel
    {
        private int RequirementId { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private string Details { get; set; }
        private string Family { get; set; }
        private string RequirementNumber { get; set; }
        private string MainGroup { get; set; }

        public RequirementModel()
        {

        }

        public RequirementModel(int requirementId, string name, string description, string details, string family, string requirementNumber, string mainGroup)
        {
            RequirementId = requirementId;
            Name = name;
            Description = description;
            Details = details;
            Family = family;
            RequirementNumber = requirementNumber;
            MainGroup = mainGroup;
        }

        public int GetId()
        {
            return RequirementId;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
