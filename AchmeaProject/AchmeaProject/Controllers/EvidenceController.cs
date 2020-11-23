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

        public IActionResult Index()
        {
            EvidenceFileViewModel files = new EvidenceFileViewModel();
            return View(files);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            if (file != null)
            {
                string id = GoogleDriveConnection.UploadFile(service, file);

                return RedirectToAction("SelectById", "Evidence", new { id });
            }
            else
            {
                EvidenceFileViewModel files = new EvidenceFileViewModel();

                return View(files);
            }
        }

        public IActionResult SelectById(string id)
        {
            EvidenceFileViewModel files = new EvidenceFileViewModel
            {
                File = GoogleDriveConnection.GetFileById(service, id)
            };

            return View(files);
        }

        [HttpPost]
        public JsonResult Upload(EvidenceUploadViewModel vm)
        {
            if (vm.File != null)
            {
                if (GoogleDriveConnection.ValidateFileType(vm.File))
                {
                    string FileId = GoogleDriveConnection.UploadFile(service, vm.File);
                    FileOfProof fileOfProof = new FileOfProof
                    {
                        DocumentTitle = Path.GetFileName(vm.File.FileName),
                        FileLocation = FileId
                    };

                    _evidenceLogic.UploadFileOfProof(fileOfProof, vm.SecurityRequirementProjectID);

                    return Json("succes");
                }

                return Json("File can only be doc, docx, pdf or png");

            }
            else
            {
                return Json("No file selected");
            }
        }
    }


}