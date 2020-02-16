using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauWeb.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Net.Http.Headers;
using System.IO;

namespace TableauWeb.Services
{
    public class BlobService : IFichierService
    {
        private readonly NamesService _namesService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private CloudStorageAccount _cloudStorageAccount;

        public BlobService(NamesService namesService,
            IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _namesService = namesService;

            _cloudStorageAccount = new CloudStorageAccount(new StorageCredentials("tableauxblob", "qCcS5Quo0BjS744udqpXQBFAcHgdUcJTfx+gAlIbdIYi/jGNp2BTjSJopg/6aHEJ3mC+BAE6EKoglUcrpMNpLw=="), true);

            if (!Directory.Exists(namesService.DossierImagesTableaux))
                Directory.CreateDirectory(namesService.DossierImagesTableaux);
        }

        public async Task<string> CreateFile(IFormFile formFile)
        {
            var blobClient = _cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("tableauxcontainer");
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var newFileName = string.Empty;

            if (formFile.Length > 0)
            {
                if (!Directory.Exists(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierImagesTableaux)))
                    Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierImagesTableaux));

                var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                var FileExtension = Path.GetExtension(fileName);
                newFileName = myUniqueFileName + FileExtension;

                fileName = Path.Combine(_webHostEnvironment.WebRootPath, _namesService.DossierImagesTableaux + $@"\{newFileName}");

                using (FileStream fs = File.Create(fileName))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }

                using (var fileStream = File.OpenRead(fileName))
                {
                    var blockBlob = container.GetBlockBlobReference(newFileName);

                    await blockBlob.UploadFromStreamAsync(fileStream);
                }

                File.Delete(fileName);
            }

            return newFileName;
        }

        public async Task<string> GetUrlImage(int id)
        {
            var nomImage = string.Empty;

            if (string.IsNullOrEmpty(nomImage))
                return string.Empty;

            var blobClient = _cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("tableauxcontainer");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomImage);
            if (!await blockBlob.ExistsAsync())
            {
                return string.Empty;
            }

            using (var fileStream = File.OpenWrite(Path.Combine(_namesService.DossierImagesTableaux, nomImage)))
            {
                await blockBlob.DownloadToStreamAsync(fileStream);
            }

            return blockBlob.Uri.ToString();
        }
    }
}
