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
    public class BookingReceivedBL : BusinessBase
    {
       BookingReceivedDA _receivedDA;
       public BookingReceivedBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _receivedDA = new BookingReceivedDA();
        
        }
        public BusinessResponse<BookingReceivedFrom> GetBookingReceivedDetails()
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                SearchResult<BookingReceivedFrom> hotelDetails = _receivedDA.GetBookingReceivedDetails();
                List<BookingReceivedFrom> det = new List<BookingReceivedFrom>();
                det = hotelDetails.SearchResultList;
                return det;
            };

            return ExecuteBusiness<BookingReceivedFrom>("ReceivedBL.GetBookingReceivedDetails", injector);

        }

        public BusinessResponse<BookingReceivedFrom> GetByID(BookingReceivedFrom curr)
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                List<BookingReceivedFrom> det = new List<BookingReceivedFrom>();
                det.Add(_receivedDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<BookingReceivedFrom>("ReceivedBL.GetByID", injector);
        }

        public BusinessResponse<BookingReceivedFrom> Delete(BookingReceivedFrom hotel)
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                List<BookingReceivedFrom> det = new List<BookingReceivedFrom>();
                det.Add(_receivedDA.Delete(hotel));
                return det;
            };

            return ExecuteBusiness<BookingReceivedFrom>("ReceivedBL.Delete", injector);
        }


        public BusinessResponse<BookingReceivedFrom> SaveBookingReceivedInfo(BookingReceivedFrom model)
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                List<BookingReceivedFrom> details = new List<BookingReceivedFrom>();
                details.Add(_receivedDA.Save(model));
                return details;
            };
            return ExecuteBusiness("ReceivedBL.SaveBookingReceivedInfo", injector);
        }

        public BusinessResponse<BookingReceivedFrom> SearchByName(string searchQ)
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                SearchResult<BookingReceivedFrom> Details = _receivedDA.Find(searchQ);
                List<BookingReceivedFrom> DetailsRes = new List<BookingReceivedFrom>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("ReceivedBL.SearchByName", injector);
        }
    }
}
