using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AchmeaProject.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
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

        public EvidenceController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            string path = Path.Combine(webRootPath, "achmea-294609-fd9d6b48f0d3.p12");

            string serviceAccountEmail = "achmea@achmea-294609.iam.gserviceaccount.com";

            DriveService service = AuthenticateServiceAccount(serviceAccountEmail, path);

            CreateFolder(service, "Test folder");
            UploadFile(service);

            DriveViewModel files = new DriveViewModel();
            files.list = ListAll(service);

            return View(files);
        }

        public static DriveService AuthenticateServiceAccount(string serviveAccountEmail, string keyFilePath)
        {
            {
                string[] scopes = new string[] { DriveService.Scope.Drive };

                var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);

                try
                {
                    ServiceAccountCredential credential = new ServiceAccountCredential(
                        new ServiceAccountCredential.Initializer(serviveAccountEmail)
                        {
                            Scopes = scopes
                        }.FromCertificate(certificate));

                    DriveService service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Drive Api Sample"
                    });
                    return service;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static string CreateFolder(DriveService service, string folderName)
        {
            var newFile = new File { Name = folderName, MimeType = "application/vnd.google-apps.folder" };

            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "name = 'Achmea'";
            string folderId = listRequest.Execute().Files[0].Id;

            // List files.
            IList<File> files = listRequest.Execute().Files;

            //check if foldername already exists

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name == newFile.Name)
                    {
                        return file.Id;
                    }
                }
            }

            newFile.Parents = new List<string> { folderId };
            var result = service.Files.Create(newFile).Execute();

            return result.Id;
        }

        public static FileList ListAll(DriveService service)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                // Building the initial request.
                var request = service.Files.List();
                request.Q = "name = 'Achmea'";


                var pageStreamer = new Google.Apis.Requests.PageStreamer<File, FilesResource.ListRequest, FileList, string>(
                                                   (req, token) => request.PageToken = token,
                                                   response => response.NextPageToken,
                                                   response => response.Files);

                var allFiles = new FileList();
                allFiles.Files = new List<File>();

                foreach (var result in pageStreamer.Fetch(request))
                {
                    allFiles.Files.Add(result);
                }

                return allFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception("Request Files.List failed.", Ex);
            }
        }

        public static File UploadFile(DriveService service)
        {
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "name = 'Achmea'";
            string folderId = listRequest.Execute().Files[0].Id;

            string uploadFile = "C:\\Users\\nkrui\\Downloads\\DBO Achmea.jpg";
            File Body = new File();

            if (System.IO.File.Exists(uploadFile))
            {
                Body.Name = Path.GetFileName(uploadFile);
                Body.MimeType = GetMimeType(uploadFile);
                Body.Parents = new List<string> { folderId };
            }

            byte[] byteArray = System.IO.File.ReadAllBytes(uploadFile);
            MemoryStream stream = new MemoryStream(byteArray);

            try
            {
                FilesResource.CreateMediaUpload request = service.Files.Create(Body, stream, GetMimeType(uploadFile));
                request.Upload();
                return request.ResponseBody;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
