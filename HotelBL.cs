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
    public class HotelBL : BusinessBase
    {
        HotelDA _hotelDA;
        public HotelBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _hotelDA = new HotelDA();
        
        }
        public BusinessResponse<Hotel> GetHotelDetails()
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                SearchResult<Hotel> hotelDetails = _hotelDA.GetHotelDetails();
                List<Hotel> det = new List<Hotel>();
                det = hotelDetails.SearchResultList;
                return det;
            };

            return ExecuteBusiness<Hotel>("HotelBL.GetHotelDetails", injector);

        }

        public BusinessResponse<Hotel> GetByID(Hotel curr)
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                List<Hotel> det = new List<Hotel>();
                det.Add(_hotelDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<Hotel>("HotelBL.GetByID", injector);
        }

        public BusinessResponse<Hotel> Delete(Hotel hotel)
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                List<Hotel> det = new List<Hotel>();
                det.Add(_hotelDA.Delete(hotel));
                return det;
            };

            return ExecuteBusiness<Hotel>("HotelBL.Delete", injector);
        }


        public BusinessResponse<Hotel> SaveHotelInfo(Hotel model)
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                List<Hotel> details = new List<Hotel>();
                details.Add(_hotelDA.Save(model));
                return details;
            };
            return ExecuteBusiness("HotelBL.SaveHotelInfo", injector);
        }

        public BusinessResponse<Hotel> SearchByName(string searchQ)
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                SearchResult<Hotel> Details = _hotelDA.Find(searchQ);
                List<Hotel> DetailsRes = new List<Hotel>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("HotelBL.SearchByName", injector);
        }
    }
}
