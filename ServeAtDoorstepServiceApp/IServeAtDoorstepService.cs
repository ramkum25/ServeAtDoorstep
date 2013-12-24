using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Web;
using ServeAtDoorstepData;
using ServeAtDoorstepDataAccess;

namespace ServeAtDoorstepServiceApp
{
    [ServiceContract]
    public interface IServeAtDoorstepService
    {
        #region .. CUSTOMER REGISTER ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCustomerRegister")]
        int AddCustomerRegister(CustomerDetails customerDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCustomerBankdet")]
        int AddCustomerBankdet(CusBankDetails cusbankDetails);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AvailableCustomer/{strLoginname}")]
        DataTable AvailableCustomer(string strLoginname);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AvailableCusMail/{strEmail}")]
        DataTable AvailableCusMail(string strEmail);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginCustomer")]
        int LoginCustomer(LoginDetails loginDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActivateCustomer/{customerId}")]
        bool ActivateCustomer(int customerId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ForgotPasswordCus/{cusEmail}")]
        DataTable ForgotPasswordCus(string cusEmail);

        #endregion

        #region .. VENDOR REGISTER ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorRegister")]
        int AddVendorRegister(VendorDetails vendorDetails);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AvailableVendor/{strLoginname}")]
        DataTable AvailableVendor(string strLoginname);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AvailableVenMail/{strEmail}")]
        DataTable AvailableVenMail(string strEmail);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginVendor")]
        int LoginVendor(LoginDetails loginDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ActivateVendor/{vendorId}")]
        bool ActivateVendor(int vendorId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "ForgotPasswordVen/{venEmail}")]
        DataTable ForgotPasswordVen(string venEmail);

        #endregion

        #region .. VENDOR MESSAGE ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorMessage")]
        int AddVendorMessage(VendorMessageDetails vendorMsgDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVenMessageById/{intMsgId}")]
        DataTable SelectVenMessageById(int intMsgId);

        #endregion

        #region .. SELECT VENDOR ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVendorByCategory/{categoryId}")]
        DataTable SelectVendorByCategory(int categoryId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectMessageByVendorId/{vendorId}")]
        DataTable SelectMessageByVendorId(int vendorId);

        #endregion

        #region .. CITY, STATE & COUNTRY ..

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllCategory")]
        DataTable SelectAllCategory();
        
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllMembership")]
        DataTable SelectAllMembership();
        
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllService")]
        DataTable SelectAllService();
        
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllCity")]
        DataTable SelectAllCity();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllState")]
        DataTable SelectAllState();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllCountry")]
        DataTable SelectAllCountry();

        #endregion

        #region .. SERVICE & MEMBERSHIP ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddService")]
        int AddService(ServiceDetails serviceDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddMembership")]
        int AddMembership(MembershipDetails membershipDetails);

        #endregion
    }
}
