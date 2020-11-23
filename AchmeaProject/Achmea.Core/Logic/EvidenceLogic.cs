using Achmea.Core.Interface;
using AchmeaProject.Models;

namespace Achmea.Core.Logic
{
    public class EvidenceLogic
    {
        private readonly IEvidence _IEvidence;
        public EvidenceLogic(IEvidence Ievidence)
        {
            _IEvidence = Ievidence;
        }

        public void UploadFileOfProof(FileOfProof file, int SecurityRequirementProjectID)
        {
            _IEvidence.UploadFileOfProof(file, SecurityRequirementProjectID);
        }
    }
}
