using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Model
{
    public class RequirementModel
    {
        public enum Status
        {
            ToDo,
            Completed,
            Rejected,
            Excluded
        }

        public int RequiermentID { get; }
        public string Name { get; }
        public string Description { get; }
        public string Details { get; }
        public string Family { get; }
        public string RequiermentNumber { get; }
        public string MainGroup { get; }
        public Status RequirementStatus { get; }

        public RequirementModel()
        {

        }

        public RequirementModel(int requiermentID, string name, string description, string details, string family, string requiermentNumber, string mainGroup, Status status)
        {
            RequiermentID = requiermentID;
            Name = name;
            Description = description;
            Details = details;
            Family = family;
            RequiermentNumber = requiermentNumber;
            MainGroup = mainGroup;
            RequirementStatus = status;
        }
    }
}
