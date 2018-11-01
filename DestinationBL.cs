using DataAccessLib;
using ModelLib.Bases;
using ModelLib.Common;
using ModelLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilLib;

namespace BusinessLib
{
    public class DestinationBL : BusinessBase
    {
        DestinationDA _destinationDA;
        public DestinationBL()
            : base(GlobalSettings.CustomerLogger)
        {
            
            _destinationDA = new DestinationDA();
           
        }

        public BusinessResponse<Destination> GetDestination(SearchModel<Destination> searchQ)
        {

            Func<BusinessResponse<Destination>, List<Destination>> injector = (ret) =>
            {
                SearchResult<Destination> hotels = _destinationDA.GetModel();
                List<Destination> hotelRes = new List<Destination>();
                hotelRes = hotels.SearchResultList;
                ret.MetaData.TotalRecords = hotels.TotalRecords;
                return hotelRes;
            };
            return ExecuteBusiness("DestinationBL.GetBusinessResponse", injector);
        }

    }
}
