using HtmlAgilityPack;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using System.Windows.Controls;

namespace ToolExtractor.Lib.Utils
{
    public class ExtractorUtilService
    {

        public static void ConvertListToExcel<T>(List<T> objects, string filePath)
        {
            var properties = typeof(T).GetProperties();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(typeof(T).Name);

                // Write the header row
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                // Write the data rows
                int row = 2;
                foreach (var obj in objects)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cell(row, i + 1).Value = properties[i].GetValue(obj)?.ToString();
                    }
                    row++;
                }

                // Auto-fit the columns
                worksheet.Columns().AdjustToContents();


                // Save the Excel file
                workbook.SaveAs(filePath);
            }
        }

        public static void ConvertDictToExcel(List<SheetObjectMeta> sheets, string filePath)
        {

            using (var workbook = new XLWorkbook())
            {
                foreach (var sheet in sheets)
                {
                    var sheetName = sheet.Name;
                    var records = sheet.Rows;
                    var keys = sheet.Keys;

                    var worksheet = workbook.Worksheets.Add(sheetName);

                    // Write the header row
                    for (int i = 0; i < keys.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = keys[i];
                    }

                    // Write the data rows
                    int row = 2;
                    foreach (var dictRecord in records)
                    {
                        for (int i = 0; i < keys.Count; i++)
                        {
                            if (dictRecord.ContainsKey(keys[i]))
                            {
                                worksheet.Cell(row, i + 1).Value = dictRecord[keys[i]]?.ToString();
                            }
                            else
                            {
                                worksheet.Cell(row, i + 1).Value = "na";
                            }
                        }
                        row++;
                    }

                    // Auto-fit the columns
                    worksheet.Columns().AdjustToContents();

                }

                // Save the Excel file
                workbook.SaveAs(filePath);
            }
        }



        public static int IterateFilesWithProgress(List<string> files, IProgress<int> progress, Action<HtmlNode, string> actionExtractor)
        {


            var totalFiles = files.Count;

            for (int i = 0; i < totalFiles; i++)
            {
                try
                {
                    var path = files[i];

                    var document = LoadDocument(path);

                    actionExtractor(document, Path.GetFileNameWithoutExtension(path));

                    progress.Report(i + 1 / totalFiles);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }


            return 1;
        }

        public static HtmlNode LoadDocument(string path)
        {
            var html = new HtmlDocument();
            html.Load(path);
            var document = html.DocumentNode;
            return document;
        }

        public static void IterateByColumns(IEnumerable<string> nodes, int columns, Action<List<string>> action)
        {
            var skip = 0;
            var rows = nodes.Count() / columns;
            while (skip < rows)
            {
                var values = nodes.Skip(skip * columns).Take(columns).ToList();

                action(values);
                skip += 1;
            }
        }
    }
}