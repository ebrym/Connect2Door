using Application.Interfaces;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Linq;

namespace Persistence.Uploads;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Application.Interfaces.IExcelService" />
    public class ExcelService : IExcelService
    {
        /// <summary>
        /// Gets the data table from excel.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="hasHeader">if set to <c>true</c> [has header].</param>
        /// <returns></returns>
        public DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage pck = new ExcelPackage();
            using (FileStream stream = File.OpenRead(path))
            {
                pck.Load(stream);
            }
            ExcelWorksheet workSheet = pck.Workbook.Worksheets.FirstOrDefault();
            DataTable dataTable = new DataTable();
            if (workSheet != null)
            {
                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                {
                    dataTable.Columns.Add(hasHeader
                        ? firstRowCell.Text
                        : $"Column {firstRowCell.Start.Column}");
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= workSheet.Dimension.End.Row; rowNum++)
                {
                    var wsRow = workSheet.Cells[rowNum, 1, rowNum, workSheet.Dimension.End.Column];
                    DataRow row = dataTable.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
            }
            return dataTable;
        }
    }
