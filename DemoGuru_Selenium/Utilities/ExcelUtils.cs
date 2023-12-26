using DemoGuru_Selenium.Helper;
using ExcelDataReader;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGuru_Selenium.Utilities
{
    internal class ExcelUtils
    {

        public static List<InputDatas> ReadSearchDataExcelData(string excelFilePath, string sheetName)
        {
            List<InputDatas> excelDataList = new List<InputDatas>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            InputDatas excelData = new InputDatas
                            {
                                Firstname = GetValueOrDefault(row, "firstname"),
                                Lastname = GetValueOrDefault(row, "lastname"),
                                PhoneNumber = GetValueOrDefault(row, "phonenumber"),
                                Email = GetValueOrDefault(row, "email"),
                                Address = GetValueOrDefault(row, "address"),
                                City = GetValueOrDefault(row, "city"),
                                State = GetValueOrDefault(row, "state"),
                                Pincode = GetValueOrDefault(row,"pincode"),
                                Country = GetValueOrDefault(row,"Country"),

                                Username = GetValueOrDefault(row, "username"),
                                Password = GetValueOrDefault(row, "password"),
                                ConfirmPassword = GetValueOrDefault(row, "confirmpassword")

                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
