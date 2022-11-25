using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IUploadService
    {
        /// <summary>
        /// Uploads to server.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="folder">The folder.</param>
        /// <returns></returns>
        Task<string> UploadToServer(IFormFile fileName, string folder);

        /// <summary>
        /// Uploads as base64 string.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>

        /// <returns></returns>
        Task<string> UploadAsBase64String(IFormFile fileName);
    }
}