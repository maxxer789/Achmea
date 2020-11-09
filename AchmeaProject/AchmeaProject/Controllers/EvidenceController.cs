using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
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
using File = Google.Apis.Drive.v3.Data.File;

namespace AchmeaProject.Controllers
{
    public class EvidenceController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DriveService service;

        public EvidenceController(IWebHostEnvironment webHost)
        {
            _webHostEnvironment = webHost;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            service = GoogleDriveConnection.GetDriveService(webRootPath, contentRootPath);
        }

        public IActionResult Index()
        {
            EvidenceFileViewModel files = new EvidenceFileViewModel
            {
                File = GoogleDriveConnection.GetFileById(service, "1NTg-K35pRhzkI2rudMRnBAL18GgsSiVL")
            };

            return View(files);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            GoogleDriveConnection.UploadFile(service, file);

            return RedirectToAction("Index");
        }
    }
}