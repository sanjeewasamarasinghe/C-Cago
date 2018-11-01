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
    public class ExcursionBL: BusinessBase
    {
       ExcursionDA _excursionDA;
       public ExcursionBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _excursionDA = new ExcursionDA();
        
        }
    
        public BusinessResponse<Excursions> GetExcursionDetails()
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                SearchResult<Excursions> Details = _excursionDA.GetExcursionDetails();
                List<Excursions> det = new List<Excursions>();
                det = Details.SearchResultList;
                return det;
            };

            return ExecuteBusiness<Excursions>("ExcursionBL.GetExcursionDetails", injector);

        }

        public BusinessResponse<Excursions> GetByID(Excursions curr)
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                List<Excursions> det = new List<Excursions>();
                det.Add(_excursionDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<Excursions>("ExcursionBL.GetByID", injector);
        }

        public BusinessResponse<Excursions> Delete(Excursions hotel)
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                List<Excursions> det = new List<Excursions>();
                det.Add(_excursionDA.Delete(hotel));
                return det;
            };

            return ExecuteBusiness<Excursions>("ExcursionBL.Delete", injector);
        }


        public BusinessResponse<Excursions> SaveExcursionInfo(Excursions model)
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                List<Excursions> details = new List<Excursions>();
                details.Add(_excursionDA.Save(model));
                return details;
            };
            return ExecuteBusiness("ExcursionBL.SaveExcursionInfo", injector);
        }

        public BusinessResponse<Excursions> SearchByName(string searchQ)
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                SearchResult<Excursions> Details = _excursionDA.Find(searchQ);
                List<Excursions> DetailsRes = new List<Excursions>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("ExcursionBL.SearchByName", injector);
        }
   }
}
