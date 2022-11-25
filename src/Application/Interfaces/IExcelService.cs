using System.Data;

namespace Application.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IExcelService
    {
        /// <summary>
        /// Gets the data table from excel.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="hasHeader">if set to <c>true</c> [has header].</param>
        /// <returns></returns>
        DataTable GetDataTableFromExcel(string path, bool hasHeader = true);
    }
}