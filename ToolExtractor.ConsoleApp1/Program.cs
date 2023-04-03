using ToolExtractor.Lib;
using ToolExtractor.Lib.MCAGOV;

namespace ToolExtractor.ConsoleApp1 {

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            //await McaGovRequest.RequestByCinList(new List<FormGov>
            //{
            //    new FormGov()
            //    {
            //        cinFDetails = "L51900GJ1981PLC079859"

            //    }
            //});

            SharedConstants.IsTest = true;
            var cookies = await McaGovRequest.GetChromeCookies(null);
            foreach (var item in cookies)
            {
                Console.WriteLine($"{item.Name} = {item.Value}");
            }
            Console.ReadLine();
        }


        public static async Task TestExportDocumentsRequest()
        {

            //await ExportDocuments(new List<RequestByCIN>
            //{
            //    new RequestByCIN("L51900GJ1981PLC079859")
            //},
            //@"C:\Users\pc001\source\repos\ToolExtractor\ToolExtractor.WinFormMCAGov\Resources");

        }
    }

}
