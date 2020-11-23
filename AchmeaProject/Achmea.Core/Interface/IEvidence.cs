using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IEvidence
    {
        FileOfProof UploadFileOfProof(FileOfProof file, int SecurityRequirementProjectID);
    }
}
