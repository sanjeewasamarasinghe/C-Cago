using DataAccessLib;
using ModelLib.Bases;
using ModelLib.Common;
using ModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib
{
    public class HVR_ReportBL : BusinessBase
    {
        HVR_ReportDA _hvr_reportDA;

        public HVR_ReportBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _hvr_reportDA = new HVR_ReportDA();
        }

        public BusinessResponse<HVR_ReportViweModels> FindHVR_ReportDetails(SearchModel<HVR_ReportViweModels> searchQ) 
        {
            Func<BusinessResponse<HVR_ReportViweModels>, List<HVR_ReportViweModels>> injector = (ret) =>
            {
                SearchResult<HVR_ReportViweModels> HVR_ReportDetails = _hvr_reportDA.Find(searchQ);
                List<HVR_ReportViweModels> HVR_ReportDetailsRes = new List<HVR_ReportViweModels>();
                HVR_ReportDetailsRes = HVR_ReportDetails.SearchResultList;
                ret.MetaData.TotalRecords = HVR_ReportDetails.TotalRecords;
                return HVR_ReportDetailsRes;
            };
            return ExecuteBusiness("HVR_ReportBL.FindHVR_ReportDetails", injector);
        }

        public BusinessResponse<HVR_ReportViweModels> FindHVR_Genaral_ReportDetails(SearchModel<HVR_ReportViweModels> searchQ)
        {
            Func<BusinessResponse<HVR_ReportViweModels>, List<HVR_ReportViweModels>> injector = (ret) =>
            {
                SearchResult<HVR_ReportViweModels> HVR_Genaral_ReportDetails = _hvr_reportDA.FindHVR_Genaral_Report(searchQ);
                List<HVR_ReportViweModels> HVR_Genaral_ReportDetailsRes = new List<HVR_ReportViweModels>();
                HVR_Genaral_ReportDetailsRes = HVR_Genaral_ReportDetails.SearchResultList;
                ret.MetaData.TotalRecords = HVR_Genaral_ReportDetails.TotalRecords;
                return HVR_Genaral_ReportDetailsRes;
            };
            return ExecuteBusiness("HVR_ReportBL.FindHVR_Genaral_ReportDetails", injector);
        }
    }
}
