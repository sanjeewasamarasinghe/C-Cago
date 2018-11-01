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
    public class CurrencyBL : BusinessBase
    {
        CurrencyDA _currencyDA;

        public CurrencyBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _currencyDA = new CurrencyDA();
        }

        public BusinessResponse<CurrencyRate> GetCurrencyDetails() 
        {
            Func<BusinessResponse<CurrencyRate>, List<CurrencyRate>> injector = (ret) =>
            {
                SearchResult<CurrencyRate> currencyDetails = _currencyDA.GetCurrencyDetails();
                List<CurrencyRate> det = new List<CurrencyRate>();
                det = currencyDetails.SearchResultList;
                return det;
            };

            return ExecuteBusiness<CurrencyRate>("CurrencyBL.GetCurrencyDetails", injector);

        }

        public BusinessResponse<CurrencyRate> Delete(CurrencyRate curr)
        {
            Func<BusinessResponse<CurrencyRate>, List<CurrencyRate>> injector = (ret) =>
            {
                List<CurrencyRate> det = new List<CurrencyRate>();
                det.Add(_currencyDA.Delete(curr));
                return det;
            };

            return ExecuteBusiness<CurrencyRate>("CurrencyBL.Delete", injector);
        }

        public BusinessResponse<CurrencyRate> GetByID(CurrencyRate curr)
        {
            Func<BusinessResponse<CurrencyRate>, List<CurrencyRate>> injector = (ret) =>
            {
                List<CurrencyRate> det = new List<CurrencyRate>();
                det.Add(_currencyDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<CurrencyRate>("CurrencyBL.GetByID", injector);
        }

        public BusinessResponse<CurrencyRate> SaveCurrencyRate(CurrencyRate model)
        {
            Func<BusinessResponse<CurrencyRate>, List<CurrencyRate>> injector = (ret) =>
            {
                List<CurrencyRate> details = new List<CurrencyRate>();
                details.Add(_currencyDA.Save(model));
                return details;
            };
            return ExecuteBusiness("CurrencyBL.SaveCurrencyRate", injector);
        }

        public BusinessResponse<CurrencyRate> SearchByName(string month, string year)
        {
            Func<BusinessResponse<CurrencyRate>, List<CurrencyRate>> injector = (ret) =>
            {
                SearchResult<CurrencyRate> Details = _currencyDA.Find(month, year);
                List<CurrencyRate> DetailsRes = new List<CurrencyRate>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("CurrencyBL.SearchByName", injector);
        }
    }

}
