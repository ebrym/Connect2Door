using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Persistence.Uploads
{
    /// <summary>
    ///
    /// </summary>
    public class UploadService : IUploadService
    {
        private readonly IHostingEnvironment env;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadService"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public UploadService(IHostingEnvironment env)
        {
            this.env = env;
        }

        /// <summary>
        /// Uploads as base64 string.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public async Task<string> UploadAsBase64String(IFormFile fileName)
        {
            using var memoryStream = new MemoryStream();
            await fileName.CopyToAsync(memoryStream);
            byte[] imageByte = memoryStream.ToArray();
            string image = Convert.ToBase64String(imageByte);
            return image;
        }

        /// <summary>
        /// Uploads to server.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        public async Task<string> UploadToServer(IFormFile fileName, string folder)
        {
            if (fileName == null) return string.Empty;
            string dir = $"{env.ContentRootPath}";
            string documentPath = folder;
            string dirPath = $"{dir}\\{documentPath}";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            string path = Path.Combine(dirPath, $"{DateTime.Now.Ticks.ToString()}{Path.GetExtension(fileName.FileName)}");
            await using var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            await fileName.CopyToAsync(stream);

            stream.Close();

            return path;
        }
    }
}