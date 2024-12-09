using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;



namespace KSMArtMauiApp.Services
{
    class AzureFileService
    {
        BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;

        string _AzureConnectionString = "DefaultEndpointsProtocol=https;AccountName=ksmart123;AccountKey=DEiSpAMHjSWiWva5zJDjeGkLdiPww3M5tGdo4ChyRRIQlCe/88wZhRZMw+ndHAHeB0b6hR4O9QiE+AStTARFGA==;EndpointSuffix=core.windows.net";

        public AzureFileService()
        { 
            _blobServiceClient = new BlobServiceClient(_AzureConnectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient("ksmfiles123");        
        }

        internal async Task<List<BlobContentInfo>> UploadFiles(List<IFormFile> files)
        {
            var azureResonpses = new List<BlobContentInfo>();
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    var client = await _blobContainerClient.UploadBlobAsync(file.FileName, memoryStream, default);
                    azureResonpses.Add(client);
                }
            }
            return azureResonpses;
        }

        internal async Task<List<BlobItem>> DownloadFiles()
        {
            var items = new List<BlobItem>();
            var UploadedFiles = _blobContainerClient.GetBlobsAsync();
            await foreach (var uploadedFile in UploadedFiles)
            {
                items.Add(uploadedFile);
            }

            return items;
        }

        internal async Task<List<Image>> DownloadImageFiles()
        {
            var items = new List<Image>();
            var UploadedFiles = _blobContainerClient.GetBlobsAsync();

            await foreach (var uploadedFile in UploadedFiles)
            {
                var blobClient = _blobContainerClient.GetBlobClient(uploadedFile.Name);
                Azure.Response<BlobDownloadStreamingResult> me = await blobClient.DownloadStreamingAsync();
                var metoo = me.Value;
                System.IO.Stream methree = metoo.Content;

                var image = Image.FromStream(methree);

                items.Add(image);


                //var fsr = new FileStreamResult(methree, "image/jpeg");
            }

            return items;
        }
    }
}
