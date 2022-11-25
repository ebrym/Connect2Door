namespace Application.Interfaces
{
    /// <summary>
    /// Generate QR Code
    /// </summary>
    public interface IQrCodeGeneratorService
    {
        /// <summary>
        /// Generates the qr code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string GenerateQrCode(string code);
    }
}