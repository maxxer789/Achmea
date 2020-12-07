using Achmea.Core.Interface;
using AchmeaProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchmeaTestss.MockServices
{
    public class MockEvidenceDAL : IEvidence
    {
        private List<SecurityRequirementProject> securityRequirementProjects;
        private List<FileOfProof> fileOfProofs;

        public MockEvidenceDAL()
        {
            securityRequirementProjects = new List<SecurityRequirementProject>();
            fileOfProofs = new List<FileOfProof>();
            Populate();
        }

        public FileOfProof UploadFileOfProof(FileOfProof file, int SecurityRequirementProjectID)
        {
            if (file.DocumentTitle != null && file.FileLocation != null)
            {
                fileOfProofs.Add(file);
                SecurityRequirementProject securityRequirementProject = securityRequirementProjects.Find(e => e.SecurityRequirementProjectId == SecurityRequirementProjectID);
                securityRequirementProject.FileOfProofId = file.FileOfProofId;
            }

            return file;
        }
        public FileOfProof GetBySecurityRequirementProjectID(int id)
        {
            FileOfProof fileOfProof = null;

            SecurityRequirementProject securityRequirementProject = securityRequirementProjects.Find(e => e.SecurityRequirementProjectId == id);
            if (securityRequirementProject != null)
            {
                fileOfProof = fileOfProofs.Find(e => e.FileOfProofId == securityRequirementProject.FileOfProofId);
            }

            return fileOfProof;
        }

        private void Populate()
        {
            for (int i = 0; i < 3; i++)
            {
                securityRequirementProjects.Add(
                     new SecurityRequirementProject()
                     {
                         FileOfProofId = i,
                         ProjectId = 1,
                         SecurityRequirementId = i,
                         SecurityRequirementProjectId = i
                     }
                    );
            }

            securityRequirementProjects.Add(
                new SecurityRequirementProject()
                {
                    FileOfProofId = null,
                    ProjectId = 1,
                    SecurityRequirementId = 4,
                    SecurityRequirementProjectId = 4
                }
                );

            securityRequirementProjects.Add(
                new SecurityRequirementProject()
                {
                    FileOfProofId = null,
                    ProjectId = 1,
                    SecurityRequirementProjectId = 5,
                    SecurityRequirementId = 5
                }
                );

            for (int i = 0; i < 3; i++)
            {
                fileOfProofs.Add(
                    new FileOfProof()
                    {
                        FileOfProofId = i,
                        FileLocation = $"location{i}",
                        DocumentTitle = $"testdoc{i}.pdf"
                    }
                    );
            }
        }


    }
}
