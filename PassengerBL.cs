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
    public class PassengerBL : BusinessBase
    {
         PassengerDA _passengerDA;

         public PassengerBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _passengerDA = new PassengerDA();
        }

        public BusinessResponse<Passenger> SavePassenger(Passenger passenger)
        {

            Func<BusinessResponse<Passenger>, List<Passenger>> injector = (ret) =>
            {
                List<Passenger> pax = new List<Passenger>();
                pax.Add(_passengerDA.Save(passenger));
                return pax;
            };
            return ExecuteBusiness("PassengerBL.SavePassenger", injector);
        }

        public BusinessResponse<Passenger> GetPassengerByID(Passenger passenger)   
        {
             Func<BusinessResponse<Passenger>, List<Passenger>> injector = (ret) =>
            {
                List<Passenger> passengersList = new List<Passenger>();
                passengersList.Add(_passengerDA.GetByID(passenger));
                return passengersList;
            };
             return ExecuteBusiness("PassengerBL.GetPassengerByID", injector);
        }

        public BusinessResponse<Passenger> FindPassenger(SearchModel<Passenger> searchQ)
        {
             Func<BusinessResponse<Passenger>, List<Passenger>> injector = (ret) =>
            {
                SearchResult<Passenger> passengersDetails = _passengerDA.Find(searchQ);
                List<Passenger> passengersDetailsRes = new List<Passenger>();
                passengersDetailsRes = passengersDetails.SearchResultList;
                ret.MetaData.TotalRecords = passengersDetails.TotalRecords;
                return passengersDetailsRes;
            };
             return ExecuteBusiness("PassengerBL.FindPassenger", injector);
        }

        public BusinessResponse<Passenger> DeletePassenger(Passenger passenger)
        {
             Func<BusinessResponse<Passenger>, List<Passenger>> injector = (ret) =>
            {
                List<Passenger> passengerDetails = new List<Passenger>();
                passengerDetails.Add(_passengerDA.Delete(passenger));
                return passengerDetails;
            };
             return ExecuteBusiness("PassengerBL.DeletePassenger", injector);
        }

        public BusinessResponse<PassengerDetails> FindPassengerDetails(SearchModel<PassengerDetails> searchQ) 
        {
            Func<BusinessResponse<PassengerDetails>, List<PassengerDetails>> injector = (ret) =>
            {
                SearchResult<PassengerDetails> passengersDetails = _passengerDA.Find(searchQ);
                List<PassengerDetails> passengersDetailsRes = new List<PassengerDetails>();
                passengersDetailsRes = passengersDetails.SearchResultList;
                ret.MetaData.TotalRecords = passengersDetails.TotalRecords;
                return passengersDetailsRes;
            };
            return ExecuteBusiness("PassengerBL.FindPassenger", injector);
        }
        
    }
}



 