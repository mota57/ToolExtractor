using HtmlAgilityPack;
using System.Collections.Generic;
using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using Fizzler.Systems.HtmlAgilityPack;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using System.Text.RegularExpressions;
using ToolExtractor.Lib.Utils;

namespace ToolExtractor.Lib.HtmlExtractorJob1
{

    public static class CustomExtractor
    {
        public static List<TableMasterData> ExtractMasterData(List<string> files, IProgress<int> progress)
        {

            var masterDataList = new List<TableMasterData>();

            ExtractorUtilService.IterateFilesWithProgress(files, progress, (document, fileName) =>
            {
                HtmlNode tableMasterData = null;

                tableMasterData = document.SelectSingleNode("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/section[1]/div[3]/section[1]/div[2]/div[1]/div[1]/div[1]/table[1]");

                var masterData = new TableMasterData();
                masterDataList.Add(masterData);


                if (tableMasterData == null)
                {
                    masterData.CIN = fileName;
                    return;
                }

                masterData.CIN = GetCIN(document);

                tableMasterData?.ChildNodes.FirstOrDefault(n => n.Name == "tbody")?
                .ChildNodes
                .Where(n => n.Name == "tr")
                .ToList().ForEach((tr) =>
                {
                    var tdTexts = tr.Descendants("td")?.Select(td => td.InnerText?.Trim()).ToList() ?? null;
                    if (tdTexts?.Count() >= 2)
                    {
                        switch (tdTexts[0])
                        {
                            case "Company Name":
                                masterData.COMPANY_NAME = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Company Status":
                                masterData.COMPANY_STATUS = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "RoC":
                                masterData.ROC = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Registration Number":
                                masterData.REG_NO = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Company Category":
                                masterData.COMPANY_CATEGORY = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Company Sub Category":
                                masterData.COMPANY_SUB_CATEGORY = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Class of Company":
                                masterData.COMPANY_CLASS = tdTexts[1]?.Trim() ?? "";
                                break;


                            case "Date of Incorporation":
                                masterData.DATE_OF_INCORPORATION = tdTexts[1]?.Trim() ?? "";
                                break;

                            case "Age of Company":
                                break;

                            case "Activity":
                                break;

                            case "Number of Members":
                                masterData.NO_OF_MEMBERS = tdTexts[1]?.Trim() ?? "";
                                break;
                        }
                    }

                });



                //masterData.COMPANY_NAME = tableMasterData?.ChildNodes[3]?.ChildNodes[1]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.COMPANY_STATUS = tableMasterData?.ChildNodes[3]?.ChildNodes[3]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.ROC = tableMasterData?.ChildNodes[3]?.ChildNodes[5]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.REG_NO = tableMasterData?.ChildNodes[3]?.ChildNodes[7]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.COMPANY_CATEGORY = tableMasterData?.ChildNodes[3]?.ChildNodes[9]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.COMPANY_SUB_CATEGORY = tableMasterData?.ChildNodes[3]?.ChildNodes[11]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.COMPANY_CLASS = tableMasterData?.ChildNodes[3]?.ChildNodes[13]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.DATE_OF_INCORPORATION = tableMasterData?.ChildNodes[3]?.ChildNodes[15]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                //masterData.NO_OF_MEMBERS = tableMasterData?.ChildNodes[3]?.ChildNodes[21]?.ChildNodes[3]?.InnerText?.Trim() ?? "";


                var trListOfCapitalTable = document.SelectSingleNode("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/section[1]/div[3]/section[1]/div[2]/div[1]/div[1]/div[4]/table[1]");

                masterData.AUTHORIZE_CAPITAL = trListOfCapitalTable?.ChildNodes[1]?.ChildNodes[3]?.InnerText?.Trim() ?? "";
                if (masterData.AUTHORIZE_CAPITAL?.Length > 0)
                {
                    masterData.AUTHORIZE_CAPITAL = HtmlEntity.DeEntitize(masterData.AUTHORIZE_CAPITAL);
                }

                masterData.PAID_UP_CAPITAL = trListOfCapitalTable?.ChildNodes[3]?.ChildNodes[3]?.InnerText?.Trim() ?? "";

                if (masterData.PAID_UP_CAPITAL?.Length > 0)
                {
                    masterData.PAID_UP_CAPITAL = HtmlEntity.DeEntitize(masterData.PAID_UP_CAPITAL);
                }

                var tableCompliance = document.SelectSingleNode("/html[1]/body[1]/div[5]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/section[1]/div[3]/section[1]/div[2]/div[1]/div[1]/div[5]/table[1]");
                if (tableCompliance != null)
                {

                    var tdNodes = tableCompliance.Descendants("tr");
                    foreach (var item in tdNodes)
                    {
                        var bodyTexts = item.Descendants("td")?.Select(td => td.InnerText?.Trim()).ToList() ?? new List<string?>();
                        if (bodyTexts?.Count() >= 2)
                        {
                            switch (bodyTexts[0])
                            {
                                case "Listing status":
                                    masterData.LISTING_STATUS = bodyTexts[1] ?? "";
                                    break;

                                case "Date of Last Annual General Meeting":
                                    masterData.DATE_OF_LAST_AGM = bodyTexts[1] ?? "";
                                    break;
                                case "Date of Latest Balance Sheet":
                                    masterData.DATE_LATEST_BALANCE_SHEET = bodyTexts[1] ?? "";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }



                    var divContact = document.QuerySelector("#block-system-main > div.contaier > div.container.information > div:nth-child(16) > div > div:nth-child(1)");
                    masterData.Email = divContact?.ChildNodes[1]?.LastChild?.InnerText?.Trim() ?? "";
                    masterData.Address = divContact?.ChildNodes[6].InnerText?.Trim() ?? "";
                }


            });

            return masterDataList;
        }


        public static List<TableCompanyDirector> ExtractDirectors(List<string> files, IProgress<int> progress)
        {
            var directors = new List<TableCompanyDirector>();

            ExtractorUtilService.IterateFilesWithProgress(files, progress, (document, fileName) =>
            {
                string cin = GetCIN(document);

                var table = document.SelectNodes("//h4")?
                    .FirstOrDefault(x => x.InnerText.Trim() == "Director Details")?
                    .NodesAfterSelf()?
                    .FirstOrDefault(n => n.Name == "table");

                if (table == null)
                {
                    return;
                }

                var columns = table
                .ChildNodes?
                .FirstOrDefault(n => n.Name == "thead")?
                .ChildNodes?
                .FirstOrDefault(n => n.Name == "tr")?
                .ChildNodes?
                .Where(n => n.Name == "td")?
                .Count() ?? 0;

                var trList = table
                    .ChildNodes?
                    .FirstOrDefault(n => n.Name == "tbody")?
                    .ChildNodes
                    .Where(n => n.Name == "tr")
                    .ToList() ?? new List<HtmlNode>();


                for (int trIndex = 0; trIndex < trList.Count; trIndex++)
                {
                    var tr = trList[trIndex];
                    var tds = tr.ChildNodes.Where(n => n.Name == "td").ToList();
                    if (tds.Count > 1)
                    {
                        var values = tds.Select(n => n.InnerText.Trim()).ToList();
                        var director = new TableCompanyDirector();
                        directors.Add(director);

                        director.CIN = cin;//todo
                        director.DIN = values[0];
                        director.DirectorName = values[1];
                        director.Designation = values[2];
                        director.DateOfAppointment = values[3];
                    }

                }

            });

            return directors;
        }




        public static List<TableChargeOrBorrowingDetails> ExtractCharges(List<string> files, IProgress<int> progress)
        {
            var charges = new List<TableChargeOrBorrowingDetails>();


            ExtractorUtilService.IterateFilesWithProgress(files, progress, (document, fileName) =>
            {
                string cin = GetCIN(document);

                var nodes = document.SelectNodes("//table[@id='charges']/tbody/tr//td").Select(x => x.InnerText.Trim()).ToList();
                if (nodes == null || !nodes.Any()) return;

                ExtractorUtilService.IterateByColumns(nodes, 7, (values) =>
                {
                    var ch = new TableChargeOrBorrowingDetails();
                    ch.CIN = cin;
                    ch.ChargeID = values[0];
                    ch.CreationDate = values[1];
                    ch.ModificationDate = values[2];
                    ch.ClosureDate = values[3];
                    ch.AssetsUnderCharge = values[4];
                    ch.Amount = values[5];
                    ch.ChargeHolder = values[6];

                    charges.Add(ch);
                });
            });

            return charges;
        }


        public static List<TableDocument> ExtractDocuments(List<string> files, IProgress<int> progress)
        {
            var docList = new List<TableDocument>();



            ExtractorUtilService.IterateFilesWithProgress(files, progress, (document, fileName) =>
            {

                var tables = document.SelectNodes($"//table");

                var categories = document.SelectNodes("//h3").Where(x => x.Attributes.Any(a => a.Name == "class" && a.Value == "pull-left")).Select(x => x.InnerText).ToList() ?? new List<string>();

                if (tables == null || !tables.Any())
                {
                    return;
                }

                var cin = GetCIN(document);

                for (int i = 0; i < tables.Count; i++)
                {
                    try
                    {
                        var columns = tables[i].Descendants("th").Count();
                        var tdList = tables[i]
                            .Descendants("td")
                            .Select(x => x.InnerText?.Trim()).ToList();

                        if (tdList == null || !tdList.Any())
                        {
                            continue;
                        }

                        var tdCount = tdList.Count();
                        for (int y = 0; y < tdCount; y += columns)
                        {
                            var ch = new TableDocument();

                            ch.CIN = cin; //path
                            ch.Date = tdList[y] ?? "";
                            ch.Title = tdList[y + 1] ?? "";
                            ch.Category = categories[i] ?? "";

                            docList.Add(ch);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("");
                    }
                }


            });

            return docList;
        }

        public static string GetCIN(HtmlNode document)
        {
            return document.SelectSingleNode("//body[1]").Attributes.FirstOrDefault(x => x.Name == "class").Value.Split("-").LastOrDefault().ToUpper();
        }

    }
}