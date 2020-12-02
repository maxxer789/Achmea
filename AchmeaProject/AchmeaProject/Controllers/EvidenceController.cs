using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using File = Google.Apis.Drive.v3.Data.File;

namespace AchmeaProject.Controllers
{
    public class EvidenceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DriveService service;
        private readonly EvidenceLogic _evidenceLogic;

        public EvidenceController(IWebHostEnvironment webHost, IConfiguration configuration, IEvidence iEvidence)
        {
            _webHostEnvironment = webHost;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string serviceAccountEmail = configuration.GetSection("ServiceAccountGoogleDrive:ServiceAccountEmail").Value;
            service = GoogleDriveConnection.GetDriveService(webRootPath, contentRootPath, serviceAccountEmail);
            _evidenceLogic = new EvidenceLogic(iEvidence);
        }

        [HttpPost]
        public IActionResult Upload(EvidenceUploadViewModel vm, int projectId)
        {
            if (vm.File != null)
            {
                if (GoogleDriveConnection.ValidateFileType(vm.File))
                {
                    string UploadedFileId;
                    string databaseFileId;
                    try
                    {
                        databaseFileId = _evidenceLogic.GetBySecurityRequirementProjectID(vm.SecurityRequirementProjectID).FileLocation;
                        UploadedFileId = GoogleDriveConnection.UploadFile(service, vm.File);
                    }
                    catch (Exception)
                    {
                        TempData["Message"] = "Error encountered while uploading file";
                        return RedirectToAction("Details", "Overview", new { projectId = projectId });
                    }

                    FileOfProof fileOfProof = new FileOfProof
                    {
                        DocumentTitle = Path.GetFileName(vm.File.FileName),
                        FileLocation = UploadedFileId
                    };

                    _evidenceLogic.UploadFileOfProof(fileOfProof, vm.SecurityRequirementProjectID);

                    if (databaseFileId != null)
                    {
                        GoogleDriveConnection.DeleteFileById(service, databaseFileId);
                    }

                    TempData["Message"] = "File uploaded succesfully";
                }
                else
                {
                    TempData["Message"] = "File must be of type doc, docx, pdf or png";
                }
            }
            else
            {
                TempData["Message"] = "Please select a file for uploading";
            }

            return RedirectToAction("Details", "Overview", new { projectId = projectId });
        }
    }


}