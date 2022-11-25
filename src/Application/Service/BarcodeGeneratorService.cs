using Application.Interfaces;
using NetBarcode;
using Type = NetBarcode.Type;

namespace Application.Service
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Application.Interfaces.IBarcodeGeneratorService" />
    public class BarcodeGeneratorService : IBarcodeGeneratorService
    {
        /// <summary>
        /// Generates the bar code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public string GenerateBarCode(string code)
        {
            var barcode = new Barcode(code, Type.Code128, true);

            return barcode.GetBase64Image();
        }
    }
}