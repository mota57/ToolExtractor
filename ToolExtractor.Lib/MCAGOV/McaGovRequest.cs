using AngleSharp.Dom;
using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Bibliography;
using System.Diagnostics;
using System.Text.Json;
using DocumentFormat.OpenXml.Spreadsheet;
using ToolExtractor.Lib.Utils;
using System.IO;
using AngleSharp.Io;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace ToolExtractor.Lib.MCAGOV
{

    public class RequestByCIN
    {
        public RequestByCIN(string cin)
        {
            CIN = cin;
        }
        public string CIN { get; set; }
    }


    public class RequestPublicDocument
    {

        public RequestPublicDocument(string companyName, string cIN)
        {
            CompanyName = companyName;
            CIN = cIN;
        }

        public string CompanyName { get; }
        public string CIN { get; }

        public string ToRequestUrl(int year, string categoryName)
        {
            return $"cinFDetails={CIN}&companyName={string.Join("+", CompanyName.Split(" "))}&cartType=&categoryName={categoryName}&finacialYear={year}";
        }
    }

    public class ResponsePublicDocument
    {
        public ResponsePublicDocument(int year, string categoryName, RequestPublicDocument request, List<Dictionary<string, string>> tableResult)
        {
            this.CIN = request.CIN;
            this.CompanyName = request.CompanyName;
            this.Year = year;
            this.CategoryName = categoryName;
            this.CategoryTableResult = tableResult != null ? tableResult : new List<Dictionary<string, string>>();

        }
        public string CIN { get; set; }
        public string CompanyName { get; set; }
        public int Year { get; set; }
        public string CategoryName { get; }

        public List<Dictionary<string, string>> CategoryTableResult { get; set; }

        public override string ToString()
        {
            if (this == null)
            {
                return "";
            }
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    public static class SharedConstants
    {
        public static bool IsTest { get; set; } = false;
    }

    public static class McaGovRequest
    {
        public static int MaxYear = 2023;

        private static int[] Years = { 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 }; //2024, 2025, 2026, 2027, 2028, 2029, 2030 


        static Dictionary<string, string> DocumentCategory = new Dictionary<string, string>()
        {
                { "Certificates" , "CETF" },

                { "Change in Directors",  "CDRD" },

                { "Incorporation Documents" , "INCD" },

                { "Charge Documents" , "CRGD" },

                { "Annual Returns and Balance Sheet eForms" , "ARBE" },

                { "LLP Forms(Conversion of company to LLP)" , "LLPF" },

                { "Other eForm Documents" , "OTRE" },

                { "Other Attachments" , "OTRA" },
        };



        public static async Task<int> RequestByCinMethod(List<RequestByCIN> requests, string downloadDirectory, List<string> cookies, IProgress<int> progress = null)
        {
            CookieList = cookies.Select(c => new Cookie(c.Split("=")[0], c.Split("=")[1])).ToList();

            Console.WriteLine("requesting..");
            var publicDocuments = await GetPublicDocuments(requests, progress);
            var fileName = Path.Combine(downloadDirectory, "mcagov_" + DateTime.Now.ToString("yyyyMMddhhmmss"));

            var jsonData = JsonSerializer.Serialize(publicDocuments, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(Path.Combine(downloadDirectory, fileName + ".json"), jsonData);

            Console.WriteLine($"mapping total records {publicDocuments}");

            var count = ExportToExcel(publicDocuments, fileName);

            return count;
        }
        public static async Task<int> RequestByCINAndCompany(List<RequestPublicDocument> requests, string downloadDirectory, List<string> cookies,IProgress<int> progress = null)
        {
            CookieList = cookies.Select(c => new Cookie(c.Split("=")[0], c.Split("=")[1])).ToList();
            //CookieList.Add(new Cookie("", "HttpOnly"));

            Console.WriteLine("requesting..");
            var publicDocuments = await GetPublicDocuments(requests, progress);
            var fileName = Path.Combine(downloadDirectory, "mcagov_" + DateTime.Now.ToString("yyyyMMddhhmmss"));

            var jsonData = JsonSerializer.Serialize(publicDocuments, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(Path.Combine(downloadDirectory, fileName + ".json"), jsonData);

            Console.WriteLine($"mapping total records {publicDocuments}");

            var count = ExportToExcel(publicDocuments, fileName);

            return count;
        }


        public static async Task<List<ResponsePublicDocument>> GetPublicDocuments(List<RequestByCIN> requests,  IProgress<int> progress = null)
        {
            var cinData = await RequestByCinList(requests, progress);

            var docRequests = cinData.Select(cinData => new RequestPublicDocument(cinData["Company Name"], cinData["CIN/ FCRN"])).ToList();

            var responseDocList = await ExtractPublicDocuments(docRequests, progress);

            return responseDocList;
        }
        public static async Task<List<ResponsePublicDocument>> GetPublicDocuments(List<RequestPublicDocument> docRequests,  IProgress<int> progress = null)
        {

            var responseDocList = await ExtractPublicDocuments(docRequests, progress);

            return responseDocList;
        }


        public static async Task<List<ResponsePublicDocument>> ExtractPublicDocuments(List<RequestPublicDocument> requests,  IProgress<int> progress = null)
        {
            var client = await CreateMcaGovHttpRequestClient(referer: "https://www.mca.gov.in/mcafoportal/vpdCheckCompanyStatus.do");

            var returnData = new List<ResponsePublicDocument>();

            var yearList = Years.Where(y => y <= MaxYear).ToList();

            var totalRequests = requests.Count;

            for (int index = 0; index < totalRequests; index++)
            {
                var record = requests[index];

                foreach (var categoryKeyVal in DocumentCategory)
                {
                    var tasks = yearList.Select(async year =>
                    {

                        var body = new StringContent(record.ToRequestUrl(year, categoryKeyVal.Value), Encoding.UTF8, "application/x-www-form-urlencoded");

                        var document = await GetHtmlFromPostRequest(client, "https://www.mca.gov.in/mcafoportal/vpdDocumentCategoryDetails.do", body);
                        var html =  document.ToHtml();

                        var table = GetTableData(document);

                        var res = new ResponsePublicDocument(year, categoryKeyVal.Key, record, table);

                        returnData.Add(res);

                        Console.WriteLine(res);
                    });

                    Task.WaitAll(tasks.ToArray());
                }


                if (progress != null)
                {
                    var reportValue = (index + 1) / totalRequests;
                    progress.Report(reportValue == 0 ? index + 1 : reportValue);
                }
            }
            return returnData;
        }

        static async Task<IDocument> GetHtmlFromPostRequest(HttpClient client, string url, StringContent data)
        {
            var response = await client.PostAsync(url, data);
            var responseBody = await response.Content.ReadAsStringAsync();

            var bcontext = BrowsingContext.New(Configuration.Default);
            var document = await bcontext.OpenAsync(req => req.Content(responseBody));
            return document;
        }


        public static async Task<List<Dictionary<string, string>>> RequestByCinList(List<RequestByCIN> requestDataList,  IProgress<int> progress = null)
        {
            var client = await CreateMcaGovHttpRequestClient(referer: "https://www.mca.gov.in/mcafoportal/vpdDocumentCategoryDetails.do");

            var dataResult = new List<Dictionary<string, string>>();

            for (int index = 0; index < requestDataList.Count; index++)
            {
                var request = requestDataList[index];
                var jsonFormUrl = $"companyOrllp=C&cartType=&__checkbox_companyChk=true&cinChk=true&__checkbox_cinChk=true&cinFDetails={request.CIN}&__checkbox_llpChk=true&__checkbox_llpinChk=true&__checkbox_regStrationNumChk=true&countryOrigin=INDIA&__checkbox_stateChk=true&displayCaptcha=false&companyID=";
                var data = new StringContent(jsonFormUrl, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.PostAsync("https://www.mca.gov.in/mcafoportal/viewDocuments.do", data);
                var responseBody = await response.Content.ReadAsStringAsync();

                var bcontext = BrowsingContext.New(Configuration.Default);
                var document = await bcontext.OpenAsync(req => req.Content(responseBody));

                var tempData = GetTableData(document);
                if (tempData?.Any() ?? false)
                    dataResult.AddRange(tempData);

                if (progress != null)
                {
                    var reportValue = (index + 1) / requestDataList.Count;
                    progress.Report(reportValue == 0 ? index + 1 : reportValue);
                }
            }
            return dataResult;

        }


        private static List<Dictionary<string, string>> GetTableData(IDocument document)
        {
            var tableData = new List<Dictionary<string, string>>();
            var trList = document.QuerySelectorAll("table#results > tbody tr").ToList();
            if (trList.Count > 1)
            {
                var columns = trList[0].QuerySelectorAll("th")?.Select(td => td.TextContent).ToList() ?? new List<string>();

                for (int i = 1; i < trList.Count; i++)
                {
                    IElement? tr = trList[i];
                    var row = new Dictionary<string, string>();

                    var columnItr = columns.GetEnumerator();
                    foreach (var td in tr.QuerySelectorAll("td")?.Select(td => td.TextContent).ToList() ?? new List<string>())
                    {
                        if (columnItr.MoveNext())
                        {
                            row.Add(columnItr.Current.Trim(), td.Trim());
                        }
                    }
                    tableData.Add(row);
                }
            }
            return tableData;
        }


        public static int ExportToExcel(List<ResponsePublicDocument> publicDocuments, string filePath)
        {
            var rowList = BuildRowsForExcel(publicDocuments, filePath);
            var sheet = new SheetObjectMeta(
                   name: "mvc_gov",
                   rows: rowList
            );

            var sheetList = new List<SheetObjectMeta>() { sheet };


            ExtractorUtilService.ConvertDictToExcel(sheets: sheetList, filePath: filePath + ".xlsx");
            return rowList.Count;
        }

        private static List<Dictionary<string, string>> BuildRowsForExcel(List<ResponsePublicDocument> publicDocuments, string fileName)
        {
            var rowList = publicDocuments.SelectMany(rd =>
            {
                var dictionaries = new List<Dictionary<string, string>>();

                if (rd.CategoryTableResult?.Count > 0)
                {
                    foreach (var dict in rd.CategoryTableResult)
                    {
                        var dictionary = new Dictionary<string, string>();
                        dictionary.Add("CIN", rd.CIN);
                        dictionary.Add("CompanyName", rd.CompanyName);
                        dictionary.Add("Year", rd.Year.ToString());
                        dictionary.Add("CategoryName", rd.CategoryName);
                        foreach (var item in dict)
                        {
                            dictionary.Add(item.Key, item.Value);
                        }
                        dictionaries.Add(dictionary);
                    }
                }
                else
                {
                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add("CIN", rd.CIN);
                    dictionary.Add("CompanyName", rd.CompanyName);
                    dictionary.Add("Year", rd.Year.ToString());
                    dictionary.Add("CategoryName", rd.CategoryName);
                    dictionary.Add("Document Name", "");
                    dictionary.Add("Date Of Filing", "");
                    dictionaries.Add(dictionary);
                }
                return dictionaries;
            }).ToList();




            Console.WriteLine("completed");
            return rowList;
        }

        private static List<Cookie> CookieList { get; set; } = null;

        private static async Task<HttpClient> CreateMcaGovHttpRequestClient(string referer)
        {
            var cookieContainer = new CookieContainer();
            //_cookies = _cookies == null ? await GetChromeCookies(profileDir) : _cookies;

            foreach (var c in CookieList)
            {
                c.Domain = "www.mca.gov.in";

                cookieContainer.Add(c);
            }
            var client = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer });

            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            client.DefaultRequestHeaders.Add("Accept-language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("Cache-control", "max-age=0");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"111\", \"Not(A:Brand\";v=\"8\", \"Chromium\";v=\"111\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
            client.DefaultRequestHeaders.Add("sec-fetch-dest", "document");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "navigate");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
            client.DefaultRequestHeaders.Add("sec-fetch-user", "?1");
            client.DefaultRequestHeaders.Add("upgrade-insecure-requests", "same-origin");
            client.DefaultRequestHeaders.Add("Referrer-Policy", "1");
            client.DefaultRequestHeaders.Add("Referer", referer);
            return client;
        }


        public static async Task<List<Cookie>> GetChromeCookies(string profileDir)
        {

            var driverService = ChromeDriverService.CreateDefaultService(@"./driver/chromedriver.exe");

            // Set Chrome driver options
            var options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2); // Disable cookies
            if (SharedConstants.IsTest)
            {
                options.AddArgument(@$"user-data-dir=C:\Users\pc001\AppData\Local\Google\Chrome\User Data\Default"); // Set data directory
            }
            else
            {
                options.AddArgument(@$"user-data-dir={profileDir}"); // Set data directory

            }
            var driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.mca.gov.in/mcafoportal/viewPublicDocumentsFilter.do");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((cond) =>
                 cond.FindElement(OpenQA.Selenium.By.Id("tdSubmitBtn1"))
            );


            // Get the cookies from the current page
            var cookies = driver.Manage().Cookies.AllCookies;

            // Print the cookies
            var cookieList = new List<Cookie>();


            foreach (var cookie in cookies)
            {
                cookieList.Add(new Cookie(cookie.Name, cookie.Value));
            }

            if (cookies == null || cookies.Count <= 1 || cookies.Any(x => x.Name == "JSESSIONID") == false || cookies.Any(x => x.Name == "cookiesession1") == false)
            {
                throw new Exception("Not able to get all the cookies!!");
            }

            driver.Quit();
            return cookieList;
        }
    }
}
