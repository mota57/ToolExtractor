using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.Json;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ToolExtractor.Lib.HUDUSER
{
    /*
     {
        state: "AL",
        counties: [
            "Autauga-County_AL",
            "Clarke-County_AL"
        ]
     }
     
     */
    internal class StateMeta
    {
        public StateMeta(string name, string iso2)
        {
            StateName = name;
            ISO2 = iso2;
            Counties = new List<string>();
        }
        public string StateName { get; set; }
        public string ISO2 { get; set; }
        public List<string> Counties { get; set; }
    }

    public class StateHudUserInfo
    {
        public StateHudUserInfo()
        {

        }
        public string StateName { get; set; }
        public List<Dictionary<string, string>> Rows { get; set; } = new List<Dictionary<string, string>>();
    }

    public class ExtractExcelMetaData
    {
        public static void ExtractCountyState()
        {
            var data = new Dictionary<string, StateMeta>();

            using (var workbook = new XLWorkbook("C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.ConsoleApp1\\Resources\\county_state_metadata.xlsx"))
            {
                // Code to read data from the workbook
                var worksheet = workbook.Worksheet("State");

                var column = 1;
                for (int row = 2; row <= 57; row++)
                {
                    var state = worksheet.Cell(row, column).Value.ToString();
                    var iso2 = worksheet.Cell(row, column + 1).Value.ToString();
                    data.Add(iso2, new StateMeta(state, iso2));
                }

                var worksheetCounty = workbook.Worksheet("County");


                for (int row = 2; row <= 3229; row++)
                {
                    var county = worksheetCounty.Cell(row, column).Value.ToString();

                    var iso2 = worksheetCounty.Cell(row, column + 1).Value.ToString();

                    data[iso2].Counties.Add(county);
                }
            }

            var stateMetaList = data.Values.ToList();
            var content = JsonSerializer.Serialize(stateMetaList, new JsonSerializerOptions { WriteIndented = true });
            var path = "C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.ConsoleApp1\\Resources\\state_country.json";
            System.IO.File.WriteAllText(path, content);
            Console.WriteLine("complete!!");
            //manual process clean the unformated counties using the regular exprssion [^\w\-_,\s"\}\]\{\:\[] using visual studio. Errors at puerto rico mostly.
        }
        public static void ExtractHudUserExcel()
        {
            var records = new SortedDictionary<string, StateHudUserInfo>();

            using (var workbook = new XLWorkbook("C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.ConsoleApp1\\Resources\\data_scrape_from_huduser.xlsx"))
            {
                var worksheet = workbook.Worksheet("sheet1");

                var columnNames = "year_number,stateName,stateid,county,countyRealtorCode,countyId,ZIP_Code,Year,Efficiency,One_Bedroom,Two_Bedroom,Three-Bedroom,Four_Bedroom".Split(",").ToList();

                for (int rowIndex = 2; rowIndex <= 45156; rowIndex++)
                {
                    Console.WriteLine($"processing row :: {rowIndex}");

                    var row = new Dictionary<string, string>();
                    for (int colIndex = 0; colIndex < columnNames.Count; colIndex++)
                    {
                        var value = worksheet.Cell(rowIndex, colIndex + 1).Value.ToString();
                        row.Add(columnNames[colIndex], value);
                    }
                    if (records.ContainsKey(row["stateName"]))
                    {
                        records[row["stateName"]].Rows.Add(row);
                    }
                    else
                    {
                        var hudUserInfo = new StateHudUserInfo
                        {
                            StateName = row["stateName"],
                        };
                        hudUserInfo.Rows.Add(row);
                        records.Add(row["stateName"], hudUserInfo);
                    }
                }
            }

            var path = "C:\\Users\\pc001\\source\\repos\\ToolExtractor\\ToolExtractor.ConsoleApp1\\Resources\\HUDUserData.json";
            Console.WriteLine($"saving serialize & saving to file {path}");
            var content = JsonSerializer.Serialize(records.Values.ToList(), new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(path, content);
            Console.WriteLine("complete!!");
            //manual process clean the unformated counties using the regular exprssion [^\w\-_,\s"\}\]\{\:\[] using visual studio. Errors at puerto rico mostly.
        }

    }
}
