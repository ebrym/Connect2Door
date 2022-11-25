using Api.ResponseWrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Api.Endpoints
{
    /// </summary>
    [ApiVersion("1.0")]
    public class UploadTemplateController : BaseApiController
    {



        /// <summary>
        /// Gets the upload template file by type  (Asset,Employee,Vendor).
        /// </summary>
        /// <param name="templateType">The template type</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{templateType}")]
        [ProducesDefaultResponseType()]
        public async Task<IActionResult> GetTemplate(string templateType)
        {
            //the file type
            string filepath;
            string fileName;

            switch (templateType.ToUpper())
            {
                case  "ASSET" :
                        filepath = @"wwwroot/Templates/AssetUploadTemplate.xlsx";
                        fileName = "AssetTemplate.xlsx";
                    break;
                case "EMPLOYEE":
                    filepath = @"wwwroot/Templates/EmployeeUploadTemplate.xlsx";
                    fileName = "EmployeeTemplate.xlsx";
                    break;
                case "VENDOR":
                    filepath = @"wwwroot/Templates/VendorUploadTemplate.xlsx";
                    fileName = "VendorTemplate.xlsx";
                    break;
                default:
                    return NotFound();
                    break;
            }

             filepath = Path.GetFullPath(filepath);
            
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filepath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            if (memory.Length > 0)
                return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

          

            return NotFound();
        }





    }
}