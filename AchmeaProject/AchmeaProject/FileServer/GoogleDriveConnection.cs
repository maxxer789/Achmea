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
using Google.Apis.Requests;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using File = Google.Apis.Drive.v3.Data.File;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Achmea.Core.Logic
{
    public static class GoogleDriveConnection
    {

        public static DriveService GetDriveService(string webRootPath, string contentRootPath, string serviceAccountEmail)
        {

            string path = Path.Combine(webRootPath, "achmea-294609-fd9d6b48f0d3.p12");

            DriveService service = AuthenticateServiceAccount(serviceAccountEmail, path);
            return service;
        }

        private static DriveService AuthenticateServiceAccount(string serviveAccountEmail, string keyFilePath)
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
            var newFile = new File
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

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

        public static FileList GetAllFiles(DriveService service)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.Q = "name = 'Achmea'";
                string folderId = listRequest.Execute().Files[0].Id;

                // Building the initial request.
                var request = service.Files.List();
                request.Q = $"'{folderId}' in parents";

                FileList allfiles = request.Execute();
                foreach (var file in allfiles.Files)
                {
                    service.Files.Delete(file.Id);
                }
                return allfiles;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        public static File GetFileById(DriveService service, string id)
        {
            try
            {
                var request = service.Files.Get(id);
                request.Fields = "name, id, webContentLink, webViewLink";
                var File = request.Execute();
                return File;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string UploadFile(DriveService service, IFormFile uploadFile)
        {
            //Get Id of parent folder Achmea for visibility purposes
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "name = 'Achmea'";
            string folderId = listRequest.Execute().Files[0].Id;

            //Set File name and filetype + define parent folder
            File Body = new File
            {
                Name = Path.GetFileName(uploadFile.FileName),
                MimeType = GetMimeType(uploadFile.FileName),
                Parents = new List<string> { folderId }
            };

            MemoryStream stream = new MemoryStream();
            uploadFile.CopyTo(stream);

            try
            {
                FilesResource.CreateMediaUpload request = service.Files.Create(Body, stream, GetMimeType(uploadFile.FileName));
                request.Upload();
                return request.ResponseBody.Id;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}
