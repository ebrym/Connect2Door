using System.IO;
using Api.ResponseWrapper;
using Application.Request.FileUpload;
using Application.Response.FileUpload;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Api.Endpoints
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Api.Endpoints.BaseApiController" />
    [ApiVersion("1.0")]
    public class FileUploadController : BaseApiController
    {
        /// <summary>
        /// Uploads the asynchronous.
        /// </summary>
        /// <param name="fileUploadRequest">The file upload request.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType(typeof(string))]
        public async Task<IActionResult> UploadAsync([FromForm] FileUploadRequest fileUploadRequest)
        {
            var (succeed, message) = await Mediator.Send(fileUploadRequest);
            if (succeed)
                return Ok(message.ToResponse());
            return BadRequest(message.ToResponse());
        }

        /// <summary>
        /// Gets the uploaded files asynchronous.
        /// </summary>
        /// <param name="getUploadedFileRequest">The get uploaded file request.</param>
        /// <returns></returns>
        [HttpPost("GetUploaded")]
        [ProducesDefaultResponseType(typeof(GetUploadedFileResponse[]))]
        public async Task<IActionResult> GetUploadedFilesAsync([FromBody] GetUploadedFileRequest getUploadedFileRequest)
        {
            var (succeed, message, file) = await Mediator.Send(getUploadedFileRequest);
            if (succeed) return Ok(file.ToResponse());
            return BadRequest(message.ToResponse());
        }

        /// <summary>
        /// Gets the uploaded file by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpGet("GetUploaded/{id}")]
        [ProducesDefaultResponseType()]
        public async Task<IActionResult> GetUploadedFileByIdAsync(string id)
        {
            var file = await Mediator.Send(new GetFileUploadedByIdRequest { Id = id });
            if (file == null || string.IsNullOrEmpty(file.File)) return NotFound();

            var memory = new MemoryStream();
            await using var stream = new FileStream(file.File, FileMode.Open);
            await stream.CopyToAsync(memory);
            memory.Position = 0;
            return File(memory, file.MimeType, $"{file.Name}.{file.Ext}");

        }
    }
}