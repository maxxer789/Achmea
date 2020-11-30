using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.SQL
{
    public class EvidenceDAL : AchmeaContext, IEvidence
    {
        public FileOfProof UploadFileOfProof(FileOfProof file, int SecurityRequirementProjectID)
        {
            if (SecurityRequirementProject.Find(SecurityRequirementProjectID).FileOfProofId != null)
            {
                try
                {
                    FileOfProof currentFile = FileOfProof.Find(SecurityRequirementProject.Find(SecurityRequirementProjectID).FileOfProofId);
                    currentFile.FileLocation = file.FileLocation;
                    currentFile.DocumentTitle = file.DocumentTitle;
                    FileOfProof.Update(currentFile);
                    SaveChanges();
                    SecurityRequirementProject SecPro = SecurityRequirementProject.Find(SecurityRequirementProjectID);
                    SecPro.Status = Logic._Status.Under_review;
                    SecurityRequirementProject.Update(SecPro);
                    SaveChanges();
                    return file;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                try
                {
                    FileOfProof.Add(file);
                    SaveChanges();
                    SecurityRequirementProject SecPro = SecurityRequirementProject.Find(SecurityRequirementProjectID);
                    SecPro.FileOfProofId = file.FileOfProofId;
                    SecPro.Status = Logic._Status.Under_review;
                    SecurityRequirementProject.Update(SecPro);
                    SaveChanges();
                    return file;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
