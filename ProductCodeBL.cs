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
    public class ProductCodeBL : BusinessBase
    {
        ProductCodeDA _productCodeDA;
        public ProductCodeBL()
            : base(GlobalSettings.CustomerLogger)
        {
            _productCodeDA = new ProductCodeDA();

        }
        public BusinessResponse<ProductCode> GetProductCodeDetails()
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                SearchResult<ProductCode> hotelDetails = _productCodeDA.GetProductCodeDetails();
                List<ProductCode> det = new List<ProductCode>();
                det = hotelDetails.SearchResultList;
                return det;
            };

            return ExecuteBusiness<ProductCode>("ProductCodeBL.GetHotelDetails", injector);

        }

        public BusinessResponse<ProductCode> GetByID(ProductCode curr)
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                List<ProductCode> det = new List<ProductCode>();
                det.Add(_productCodeDA.GetByID(curr));
                return det;
            };
            return ExecuteBusiness<ProductCode>("ProductCodeBL.GetByID", injector);
        }

        public BusinessResponse<ProductCode> Delete(ProductCode hotel)
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                List<ProductCode> det = new List<ProductCode>();
                det.Add(_productCodeDA.Delete(hotel));
                return det;
            };

            return ExecuteBusiness<ProductCode>("ProductCodeBL.Delete", injector);
        }


        public BusinessResponse<ProductCode> SaveProductCodeInfo(ProductCode model)
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                List<ProductCode> details = new List<ProductCode>();
                details.Add(_productCodeDA.Save(model));
                return details;
            };
            return ExecuteBusiness("ProductCodeBL.SaveProductCodeInfo", injector);
        }

        public BusinessResponse<ProductCode> SearchByName(string searchQ)
        {
            Func<BusinessResponse<ProductCode>, List<ProductCode>> injector = (ret) =>
            {
                SearchResult<ProductCode> Details = _productCodeDA.Find(searchQ);
                List<ProductCode> DetailsRes = new List<ProductCode>();
                DetailsRes = Details.SearchResultList;
                ret.MetaData.TotalRecords = Details.TotalRecords;
                return DetailsRes;
            };
            return ExecuteBusiness("ProdcutBL.SearchByName", injector);
        }
    }
}
