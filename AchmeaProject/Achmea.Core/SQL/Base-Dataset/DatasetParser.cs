using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core
{
    public class DatasetParser
    //Data uit Database wordt omgezet in een klasse..
    {
        public static UserModel DatasetToUser(DataSet D, int RowIndex)
        {
            return new UserModel()
            {
                UserID = Convert.ToInt32(D.Tables[0].Rows[RowIndex][0]),
                Email = D.Tables[0].Rows[RowIndex][1].ToString(),
                Password = D.Tables[0].Rows[RowIndex][2].ToString(),
                Firstname = D.Tables[0].Rows[RowIndex][3].ToString(),
                Lastname = D.Tables[0].Rows[RowIndex][4].ToString(),
                PhoneNumber = Convert.ToInt32(D.Tables[0].Rows[RowIndex][5]),
                RoleID = Convert.ToInt32(D.Tables[0].Rows[RowIndex][6]),
            };
        }

        public static ProjectModel DataSetToProject(DataSet D, int RowIndex)
        {
            int projectId = Convert.ToInt32(D.Tables[0].Rows[RowIndex][0]);
            int userId = Convert.ToInt32(D.Tables[0].Rows[RowIndex][1]);
            string title = D.Tables[0].Rows[RowIndex][2].ToString();
            string description = D.Tables[0].Rows[RowIndex][3].ToString();
            string status = D.Tables[0].Rows[RowIndex][4].ToString();
            if (D.Tables[0].Rows[RowIndex][5] != System.DBNull.Value)
            {
                DateTime creationDate = Convert.ToDateTime(D.Tables[0].Rows[RowIndex][5]);
                return new ProjectModel(projectId, userId, title, description, status, creationDate);
            }
            return new ProjectModel(projectId, userId, title, description, status);
        }

        public static RequirementModel DataSetToRequirement(DataSet D, int RowIndex)
        {
            int requirementId = Convert.ToInt32(D.Tables[0].Rows[RowIndex][0]);
            string name = D.Tables[0].Rows[RowIndex][1].ToString();
            string description = D.Tables[0].Rows[RowIndex][2].ToString();
            string details = D.Tables[0].Rows[RowIndex][3].ToString();
            string family = D.Tables[0].Rows[RowIndex][4].ToString();
            string requirementNumber = D.Tables[0].Rows[RowIndex][5].ToString();
            string mainGroup = D.Tables[0].Rows[RowIndex][6].ToString();

            return new RequirementModel(requirementId, name, description, details, family, requirementNumber, mainGroup);
        }
        public static RequirementProject DataSetToRequirementProject(DataSet D, int RowIndex)
        {
            int projectId = Convert.ToInt32(D.Tables[0].Rows[RowIndex][1]);
            int requirementId = Convert.ToInt32(D.Tables[0].Rows[RowIndex][2]);
            bool excluded = Convert.ToBoolean(D.Tables[0].Rows[RowIndex][3]);
            string reason = D.Tables[0].Rows[RowIndex][4].ToString();
            string status = D.Tables[0].Rows[RowIndex][5].ToString();

            return new RequirementProject(projectId, requirementId, excluded, reason, status);
        }

        public static AspectAreaModel DatasetToAspectArea (DataSet D, int RowIndex)
        {
            return new AspectAreaModel(
                    Convert.ToInt32(D.Tables[0].Rows[RowIndex][0]), 
                    D.Tables[0].Rows[RowIndex][1].ToString(), 
                    D.Tables[0].Rows[RowIndex][2].ToString()
                );
        }
    }
}
