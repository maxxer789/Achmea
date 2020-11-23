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
            try
            {
                FileOfProof.Add(file);
                SaveChanges();
                SecurityRequirementProject SecPro = SecurityRequirementProject.Find(SecurityRequirementProjectID);
                SecPro.FileOfProofId = file.FileOfProofId;
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
