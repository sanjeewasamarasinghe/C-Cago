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
  public class SHGOBL : BusinessBase
    {
        SHGODA _shgoDA;
        public SHGOBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _shgoDA = new SHGODA();
        
        }
        public BusinessResponse<SHGO_DMC> GetSHGODetails()
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                SearchResult<SHGO_DMC> hotelDetails = _shgoDA.GetSHGODetails();
                List<SHGO_DMC> det = new List<SHGO_DMC>();
                det = hotelDetails.SearchResultList;
                return det;
            };

            return ExecuteBusiness<SHGO_DMC>("SHGOBL.GetSHGODetails", injector);

        }

        public BusinessResponse<SHGO_DMC> GetByID(SHGO_DMC curr)
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                List<SHGO_DMC> det = new List<SHGO_DMC>();
                det.Add(_shgoDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<SHGO_DMC>("SHGOBL.GetByID", injector);
        }

        public BusinessResponse<SHGO_DMC> Delete(SHGO_DMC hotel)
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                List<SHGO_DMC> det = new List<SHGO_DMC>();
                det.Add(_shgoDA.Delete(hotel));
                return det;
            };

            return ExecuteBusiness<SHGO_DMC>("SHGOBL.Delete", injector);
        }


        public BusinessResponse<SHGO_DMC> SaveSHGOInfo(SHGO_DMC model)
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                List<SHGO_DMC> details = new List<SHGO_DMC>();
                details.Add(_shgoDA.Save(model));
                return details;
            };
            return ExecuteBusiness("SHGOBL.SaveSHGOInfo", injector);
        }

        public BusinessResponse<SHGO_DMC> SearchByName(string searchQ)
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                SearchResult<SHGO_DMC> Details = _shgoDA.Find(searchQ);
                List<SHGO_DMC> DetailsRes = new List<SHGO_DMC>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("SHGOBL.SearchByName", injector);
        }
    }
}
