using OfficeOpenXml;
using System;
using System.Linq;

namespace API.Extensions
{
    public static class EpPlusExtensionMethods
    {
        public static int? GetColumnByName(this ExcelWorksheet worksheet, string columnName)
        {
            if (worksheet == null) throw new ArgumentNullException(nameof(worksheet));
            var column = worksheet.Cells["1:1"].FirstOrDefault(c => c.Value.ToString() == columnName);
            if (column != null)
                return column.Start.Column;
            else
                return null;
        }
        public static string ConvertToString(this ExcelWorksheet worksheet, int row, int column)
        {
            if (worksheet == null) throw new ArgumentNullException(nameof(worksheet));
            return worksheet.Cells[row, column].Value != null ? worksheet.Cells[row, column].Value.ToString().Trim() : "";
        }
        public static string ConvertPossibleTime(this ExcelWorksheet worksheet, int row, int column)
        {
            if (worksheet == null) throw new ArgumentNullException(nameof(worksheet));
            DateTime dateValue;
            string stringValue = worksheet.Cells[row, column].Value != null ? worksheet.Cells[row, column].Value.ToString() : "";
            bool canConvert = DateTime.TryParse(stringValue, out dateValue);
            if (canConvert == true)
                return dateValue.ToString();
            else
                return stringValue;
        }
    }
}
