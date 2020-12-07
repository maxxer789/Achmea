using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using DeepEqual.Syntax;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace AchmeaTestss.TestClasses
{
    [TestClass]
    public class EvidenceTest
    {
        IEvidence Interface;
        EvidenceLogic _Logic;

        public EvidenceTest()
        {
            Interface = new MockEvidenceDAL();
            _Logic = new EvidenceLogic(Interface);
        }

        [TestMethod]
        public void SuccesfullyGetFileofProofBySecReqProjectID()
        {
            int SecReqProjectID = 1;

            FileOfProof expected = new FileOfProof()
            {
                FileOfProofId = 1,
                FileLocation = "location1",
                DocumentTitle = "testdoc1.pdf"
            };

            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(SecReqProjectID);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsDeepEqual(expected));
        }

        [TestMethod]
        public void NoFileOfProofLinkedToSecReqProject()
        {
            int SecReqProjectID = 4;

            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(SecReqProjectID);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SecurityReqProjectIdDoesNotExist()
        {
            int SecReqProjectID = 10;

            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(SecReqProjectID);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SuccesfullyAddFile()
        {
            FileOfProof uploadFile = new FileOfProof()
            {
                FileOfProofId = 10,
                FileLocation = "UploadString",
                DocumentTitle = "UploadFile.docx"
            };

            SecurityRequirementProject securityRequirementProject = new SecurityRequirementProject()
            {
                FileOfProofId = null,
                ProjectId = 1,
                SecurityRequirementProjectId = 4,
                SecurityRequirementId = 4
            };

            Assert.IsNull(_Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId));

            _Logic.UploadFileOfProof(uploadFile, securityRequirementProject.SecurityRequirementProjectId);
            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId);

            Assert.IsNotNull(result);
            Assert.IsTrue(uploadFile.IsDeepEqual(result));
        }

        [TestMethod]
        public void UnsuccesfullyAddFileNoDocumentTitle()
        {
            FileOfProof uploadFile = new FileOfProof()
            {
                FileOfProofId = 10,
                FileLocation = "UploadString",
                DocumentTitle = null
            };

            SecurityRequirementProject securityRequirementProject = new SecurityRequirementProject()
            {
                FileOfProofId = null,
                ProjectId = 1,
                SecurityRequirementProjectId = 5,
                SecurityRequirementId = 5
            };

            
            Assert.IsNull(_Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId));

            _Logic.UploadFileOfProof(uploadFile, securityRequirementProject.SecurityRequirementProjectId);
            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void UnsuccesfullyAddFileNoFileLocation()
        {
            FileOfProof uploadFile = new FileOfProof()
            {
                FileOfProofId = 10,
                FileLocation = null,
                DocumentTitle = "UploadFile.Docx"
            };

            SecurityRequirementProject securityRequirementProject = new SecurityRequirementProject()
            {
                FileOfProofId = null,
                ProjectId = 1,
                SecurityRequirementProjectId = 5,
                SecurityRequirementId = 5
            };


            Assert.IsNull(_Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId));

            _Logic.UploadFileOfProof(uploadFile, securityRequirementProject.SecurityRequirementProjectId);
            FileOfProof result = _Logic.GetBySecurityRequirementProjectID(securityRequirementProject.SecurityRequirementProjectId);

            Assert.IsNull(result);
        }
    }
}