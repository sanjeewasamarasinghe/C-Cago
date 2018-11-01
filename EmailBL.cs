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
    public class EmailBL : BusinessBase
    {
        EmailDA _emailDA;
        public EmailBL()
            : base(GlobalSettings.CustomerLogger)
        {
            
            _emailDA = new EmailDA();
           
        }
         public BusinessResponse<EmailDetailsModels> GetPassengerDetailsForEmailByReqRef(EmailDetailsModels email)    
        {
             Func<BusinessResponse<EmailDetailsModels>, List<EmailDetailsModels>> injector = (ret) =>
            {
                List<EmailDetailsModels> emailList = new List<EmailDetailsModels>();
                emailList.Add(_emailDA.GetByID(email));
                return emailList;
            };
             return ExecuteBusiness("EmailBL.GetPassengerDetailsForEmailByReqRef", injector); 
        }

       
    }
}
