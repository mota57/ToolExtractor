using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolExtractor.Lib.HtmlExtractorJob1
{

    public class TableMasterData
    {
        public string CIN { get; set; }
        public string COMPANY_NAME { get; set; }
        public string COMPANY_STATUS { get; set; }
        public string ROC { get; set; }
        public string REG_NO { get; set; }
        public string COMPANY_CATEGORY { get; set; }
        public string COMPANY_SUB_CATEGORY { get; set; }
        public string COMPANY_CLASS { get; set; }
        public string DATE_OF_INCORPORATION { get; set; }
        public string NO_OF_MEMBERS { get; set; }
        public string AUTHORIZE_CAPITAL { get; set; }
        public string PAID_UP_CAPITAL { get; set; }
        public string LISTING_STATUS { get; set; }
        public string DATE_OF_LAST_AGM { get; set; }
        public string DATE_LATEST_BALANCE_SHEET { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class TableCompanyDirector
    {
        public string CIN { get; set; }
        public string DIN { get; set; }
        public string DirectorName { get; set; }

        public string Designation { get; set; }
        public string DateOfAppointment { get; set; }
    }

    public class TableChargeOrBorrowingDetails
    {
        public string CIN { get; set; }
        public string ChargeID { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }
        public string ClosureDate { get; set; }
        public string AssetsUnderCharge { get; set; }
        public string Amount { get; set; }
        public string ChargeHolder { get; set; }
    }

    public class TableDocument
    {
        public string CIN { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
    }
}
