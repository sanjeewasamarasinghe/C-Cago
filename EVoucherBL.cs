using DataAccessLib;
using ModelLib.Bases;
using ModelLib.Common;
using ModelLib.Models;
using ModelLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib
{
    public class EVoucherBL : BusinessBase
    {
        EVoucherDA _eVoucherDA;

        public EVoucherBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _eVoucherDA = new EVoucherDA();
        }

        public BusinessResponse<EVoucherDetails> GetVoucherByRefID(EVoucherDetails voucher)
        {
            Func<BusinessResponse<EVoucherDetails>, List<EVoucherDetails>> injector = (ret) =>
            {
                List<EVoucherDetails> eVoucher = new List<EVoucherDetails>();
                eVoucher.Add(_eVoucherDA.GetByID(voucher));
                return eVoucher;
            };
            return ExecuteBusiness("EVoucherBL.GetVoucherByRefID", injector);
        }

        public BusinessResponse<Package> GetPackages(SearchModel<Package> searchQ)
        {
            Func<BusinessResponse<Package>, List<Package>> injector = (ret) =>
            {
                SearchResult<Package> packages = _eVoucherDA.GetPackages();
                List<Package> pckgs = new List<Package>();
                pckgs = packages.SearchResultList;
                ret.MetaData.TotalRecords = packages.TotalRecords;
                return pckgs;
            };
            return ExecuteBusiness("EVoucherBL.GetBusinessResponse", injector);
        }

        public BusinessResponse<SHGO_DMC> GetSHGO(SearchModel<SHGO_DMC> SHGO_searchQ)
        {
            Func<BusinessResponse<SHGO_DMC>, List<SHGO_DMC>> injector = (ret) =>
            {
                SearchResult<SHGO_DMC> result = _eVoucherDA.GetSHGO();
                List<SHGO_DMC> shgo = new List<SHGO_DMC>();
                shgo = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return shgo;
            };
            return ExecuteBusiness("EVoucherBL.GetSHGO", injector);
        }

        public BusinessResponse<ProductCode> GetProductCodes(SearchModel<ProductCode> PC_searchQ)
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                SearchResult<ProductCode> result = _eVoucherDA.GetProductCode();
                List<ProductCode> pc = new List<ProductCode>();
                pc = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return pc;
            };
            return ExecuteBusiness("EVoucherBL.GetProductCode", injector);
        }

        public BusinessResponse<Excursions> GetExcursions(SearchModel<Excursions> excursions_searchQ)
        {
            Func<BusinessResponse<Excursions>, List<Excursions>> injector = (ret) =>
            {
                SearchResult<Excursions> result = _eVoucherDA.GetExcursions();
                List<Excursions> pc = new List<Excursions>();
                pc = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return pc;
            };
            return ExecuteBusiness("EVoucherBL.GetExcursions", injector);
        }

        public BusinessResponse<Staff> GetStaff(SearchModel<Staff> staff_searchQ)
        {
            Func<BusinessResponse<Staff>, List<Staff>> injector = (ret) =>
            {
                SearchResult<Staff> result = _eVoucherDA.GetAllStaff();
                List<Staff> pc = new List<Staff>();
                pc = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return pc;
            };
            return ExecuteBusiness("EVoucherBL.GetStaffHandledBy", injector);
        }

        public BusinessResponse<Hotel> GetHotelNames(SearchModel<Hotel> Hotel_searchQ)
        {
            Func<BusinessResponse<Hotel>, List<Hotel>> injector = (ret) =>
            {
                SearchResult<Hotel> result = _eVoucherDA.GetHotels();
                List<Hotel> hotel = new List<Hotel>();
                hotel = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return hotel;
            };
            return ExecuteBusiness("EVoucherBL.GetHotels", injector);
        }

        public BusinessResponse<EVoucherDetails> SaveEVoucherDetails(EVoucherDetails detailsModel)
        {
            Func<BusinessResponse<EVoucherDetails>, List<EVoucherDetails>> injector = (ret) =>
            {
                List<EVoucherDetails> details = new List<EVoucherDetails>();
                details.Add(_eVoucherDA.SaveEVoucherDetails(detailsModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.SaveVoucherDetails", injector);
        }

        public BusinessResponse<EVoucherDetails> UpdateEVoucherDetails(EVoucherDetails detailsModel)
        {
            Func<BusinessResponse<EVoucherDetails>, List<EVoucherDetails>> injector = (ret) =>
            {
                List<EVoucherDetails> details = new List<EVoucherDetails>();
                details.Add(_eVoucherDA.UpdateEVoucherDetails(detailsModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.UpdateVoucherDetails", injector);
        }

        public BusinessResponse<Location> GetLocations(SearchModel<Location> location_searchQ, string From)
        {
            Func<BusinessResponse<Location>, List<Location>> injector = (ret) =>
            {
                SearchResult<Location> result = _eVoucherDA.GetLocations(From);
                List<Location> locations = new List<Location>();
                locations = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return locations;
            };
            return ExecuteBusiness("EVoucherBL.GetLocations", injector);
        }

        public BusinessResponse<RBD> GetRBD(SearchModel<RBD> RBD_searchQ)
        {
            Func<BusinessResponse<RBD>, List<RBD>> injector = (ret) =>
            {
                SearchResult<RBD> result = _eVoucherDA.GetRBD();
                List<RBD> RBD = new List<RBD>();
                RBD = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return RBD;
            };
            return ExecuteBusiness("EVoucherBL.GetRBD", injector);
        }

        public BusinessResponse<RoomType> GetRoomTypes(SearchModel<RoomType> RBD_searchQ)
        {
            Func<BusinessResponse<RoomType>, List<RoomType>> injector = (ret) =>
            {
                SearchResult<RoomType> result = _eVoucherDA.GetRoomTypes();
                List<RoomType> roomtypes = new List<RoomType>();
                roomtypes = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return roomtypes;
            };
            return ExecuteBusiness("EVoucherBL.GetRoomTypes", injector);
        }

        public BusinessResponse<CurrencyType> GetCurrencyType(SearchModel<CurrencyType> cur_searchQ)
        {
            Func<BusinessResponse<CurrencyType>, List<CurrencyType>> injector = (ret) =>
            {
                SearchResult<CurrencyType> result = _eVoucherDA.GetCurrencyTypes();
                List<CurrencyType> curtypes = new List<CurrencyType>();
                curtypes = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return curtypes;
            };
            return ExecuteBusiness("EVoucherBL.GetCurrencyTypes", injector);
        }

        public BusinessResponse<BookingReceivedFrom> GetReceivedFrom(SearchModel<BookingReceivedFrom> from_searchQ)
        {
            Func<BusinessResponse<BookingReceivedFrom>, List<BookingReceivedFrom>> injector = (ret) =>
            {
                SearchResult<BookingReceivedFrom> result = _eVoucherDA.GetReceivedFrom();
                List<BookingReceivedFrom> from_list = new List<BookingReceivedFrom>();
                from_list = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return from_list;
            };
            return ExecuteBusiness("EVoucherBL.GetReceivedFrom", injector);
        }

        public BusinessResponse<ReturnAirportTransfers> GetTransfers(SearchModel<ReturnAirportTransfers> transfer_searchQ)
        {
            Func<BusinessResponse<ReturnAirportTransfers>, List<ReturnAirportTransfers>> injector = (ret) =>
            {
                SearchResult<ReturnAirportTransfers> result = _eVoucherDA.GetTransfers();
                List<ReturnAirportTransfers> transfers = new List<ReturnAirportTransfers>();
                transfers = result.SearchResultList;
                ret.MetaData.TotalRecords = result.TotalRecords;
                return transfers;
            };
            return ExecuteBusiness("EVoucherBL.GetTransfers", injector);
        }


        public BusinessResponse<EVoucherDetails> GetExistingRefObj(string RequestReference)
        {
            Func<BusinessResponse<EVoucherDetails>, List<EVoucherDetails>> injector = (ret) =>
            {
                List<EVoucherDetails> details = new List<EVoucherDetails>();
                details.Add(_eVoucherDA.GetExistingRefObj(RequestReference));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.GetExistingRefObj", injector);
        }

        public string CalculateSHGOAmountInLKR(DateTime date, string currencyType, string amount)
        {
            string SHGOInLKR = _eVoucherDA.CalculateSHGOAmountInLKR(date, currencyType, amount);
            return SHGOInLKR;
        }

        public BusinessResponse<PaxDetails> GetExistingPaxInfo(string reqRef)
        {
            Func<BusinessResponse<PaxDetails>, List<PaxDetails>> injector = (ret) =>
            {
                SearchResult<PaxDetails> result = _eVoucherDA.GetExistingPaxInfo(reqRef);
                List<PaxDetails> details = new List<PaxDetails>();
                if (result != null)
                {
                    details = result.SearchResultList;
                    ret.MetaData.TotalRecords = result.TotalRecords;
                }
                return details;
            };
            return ExecuteBusiness("EVoucherBL.GetExistingPaxInfo", injector);
        }

        public BusinessResponse<PaxDetails> UpdatePaxInfo(PaymentAndHotelInfo detailsModel)
        {
            Func<BusinessResponse<PaxDetails>, List<PaxDetails>> injector = (ret) =>
            {
                List<PaxDetails> details = new List<PaxDetails>();
                details.Add(_eVoucherDA.UpdatePaxDetails(detailsModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.UpdatePaxInfoDetails", injector);
        }

        public BusinessResponse<PaxDetails> DeletePaymentDetails(PaymentAndHotelInfo detailsModel)
        {
            Func<BusinessResponse<PaxDetails>, List<PaxDetails>> injector = (ret) =>
            {
                List<PaxDetails> details = new List<PaxDetails>();
                details.Add(_eVoucherDA.DeletePaymentDetails(detailsModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.DeletePaxDetails", injector);
        }



        public BusinessResponse<HotelInfo> UpdateHotelDetails(ModelLib.ViewModel.HotelInfoViewModel hotelModel)
        {
            Func<BusinessResponse<HotelInfo>, List<HotelInfo>> injector = (ret) =>
            {
                List<HotelInfo> details = new List<HotelInfo>();
                details.Add(_eVoucherDA.UpdateHotelDetails(hotelModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.UpdateHotelDetails", injector);
        }

        public BusinessResponse<RoomInfo> UpdateRoomDetails(List<RoomInfo> list, string ReqRef, int hotelId)
        {
            Func<BusinessResponse<RoomInfo>, List<RoomInfo>> injector = (ret) =>
            {
                List<RoomInfo> details = new List<RoomInfo>();
                details.Add(_eVoucherDA.UpdateRoomDetails(list, ReqRef, hotelId));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.UpdateRoomDetails", injector);
        }

        public BusinessResponse<HotelInfo> GetExistingHotelInfo(string requestRef)
        {
            Func<BusinessResponse<HotelInfo>, List<HotelInfo>> injector = (ret) =>
            {
                List<HotelInfo> details = new List<HotelInfo>();
                details.Add(_eVoucherDA.GetHotelDetails(requestRef));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.GetHotelDetails", injector);
        }

        public BusinessResponse<RoomInfo> GetExistingRoomlInfo(string requestRef, string hotelId)
        {
            Func<BusinessResponse<RoomInfo>, List<RoomInfo>> injector = (ret) =>
            {
                SearchResult<RoomInfo> result = _eVoucherDA.GetRoomDetails(requestRef, hotelId);
                List<RoomInfo> details = new List<RoomInfo>();
                if (result != null)
                {
                    details = result.SearchResultList;
                    ret.MetaData.TotalRecords = result.TotalRecords;
                }
                return details;
            };
            return ExecuteBusiness("EVoucherBL.GetRoomDetails", injector);
        }

        public BusinessResponse<HotelInfo> SaveHotelDetails(HotelInfoViewModel hotelModel)
        {
            Func<BusinessResponse<HotelInfo>, List<HotelInfo>> injector = (ret) =>
            {
                List<HotelInfo> details = new List<HotelInfo>();
                details.Add(_eVoucherDA.SaveHotelDetails(hotelModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.SaveHotelDetails", injector);
        }

        public BusinessResponse<RoomInfo> DeleteRoomDetails(string ReqRef, int hotelId)
        {
            Func<BusinessResponse<RoomInfo>, List<RoomInfo>> injector = (ret) =>
            {
                List<RoomInfo> details = new List<RoomInfo>();
                details.Add(_eVoucherDA.DeleteRoomDetails(ReqRef, hotelId));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.DeleteRoomDetails", injector);
        }

        public BusinessResponse<EVoucherDetails> UpdateOtherEVoucherDetails(EVoucherDetails detailsModel)
        {
            Func<BusinessResponse<EVoucherDetails>, List<EVoucherDetails>> injector = (ret) =>
            {
                List<EVoucherDetails> details = new List<EVoucherDetails>();
                details.Add(_eVoucherDA.UpdateOtherEVoucherDetails(detailsModel));
                return details;
            };
            return ExecuteBusiness("EVoucherBL.UpdateOtherVoucherDetails", injector);
        }

    }
}
