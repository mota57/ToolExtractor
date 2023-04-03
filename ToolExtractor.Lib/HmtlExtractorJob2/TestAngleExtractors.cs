using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.InkML;
using System.Diagnostics;
using static ToolExtractor.Lib.Utils.ExtractorUtilService;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net;
using ToolExtractor.Lib.Utils;

namespace ToolExtractor.Lib.HmtlExtractorJob2
{
    public class TestAngleExtractors
    {
        public static async Task TestExtractGstin()
        {

            //Source to be parsed
            var source = Directory.GetFiles("C:/Users/pc001/source/repos/ToolExtractor/ToolExtractor.WinFormApp/ToolExtractor.WinFormApp/Resources/gstin1/", "*.html");
            var filePath = "C:/Users/pc001/source/repos/ToolExtractor/ToolExtractor.WinFormApp/ToolExtractor.WinFormApp/Resources/GsTinDownload/";
            await ExtractGstin(source.ToList(), filePath);
        }



        public static async Task<IDocument> LoadDocument(string sourceFile)
        {

            var content = await File.ReadAllTextAsync(sourceFile);

            var config = Configuration.Default;

            var bcontext = BrowsingContext.New(config);
            return await bcontext.OpenAsync(req => req.Content(content));
        }


        public static async Task ExtractGstin(List<string> sourceFiles, string targetFolder)
        {

            var rows = new List<Dictionary<string, string>>() { };

            foreach (var sourceFile in sourceFiles)
            {
                //Create a virtual request to specify the document to load (here from our fixed string)
                IDocument document = await LoadDocument(sourceFile);

                //Do something with document like the following
                var divs = document.QuerySelector("section")?
                    .QuerySelectorAll("div")?
                    .Skip(1)?
                    .FirstOrDefault()?
                    .QuerySelectorAll("div")?
                    .ToList() ?? new List<IElement>();

                var row = new Dictionary<string, string>();

                foreach (var div in divs)
                {
                    var texts = div.QuerySelectorAll("p")?.Select(p => p.Text().Trim()).ToList() ?? new List<string>();
                    if (texts.Count == 2)
                    {
                        row.Add(texts[0], texts[1]);
                    }
                }
                rows.Add(row);
            }

            var sheet = new SheetObjectMeta(
                name: "gstin",
                rows: rows,
                keys: "Trade Name,Legal Name,Registration Status,Registration Date,Entity Type,Place of Business (Address),Aggregate Turnover"
            );

            var sheetList = new List<SheetObjectMeta>() { sheet };

            var filePathTarget = Path.Combine(targetFolder, "extract2_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx");
            ConvertDictToExcel(sheets: sheetList, filePath: filePathTarget);
        }



    }
}
