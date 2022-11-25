using Application.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.IO;

namespace Application.Service
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Application.Interfaces.IQrCodeGeneratorService" />
    public class QrCodeGeneratorService : IQrCodeGeneratorService
    {
        /// <summary>
        /// Generates the qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string GenerateQrCode(string code)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
}