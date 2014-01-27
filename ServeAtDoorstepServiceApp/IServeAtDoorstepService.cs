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
        #region .. ADMIN ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "LoginAdmin")]
        int LoginAdmin(LoginDetails loginDetails);

        #endregion

        #region .. CUSTOMER REGISTER ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCustomerRegister")]
        int AddCustomerRegister(CustomerDetails customerDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCustomerBankdet")]
        int AddCustomerBankdet(CusBankDetails cusbankDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCustomerMessage")]
        int AddCustomerMessage(CustomerMessageDetails cusMessageDetails);

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

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateCustomerImage")]
        void UpdateCustomerImage(CustomerDetails cusDetails);
        
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateCustomerPassword")]
        void UpdateCustomerPassword(CustomerDetails cusDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateCustomerEmail")]
        void UpdateCustomerEmail(CustomerDetails cusDetails);

        #endregion

        #region .. SELECT CUSTOMER ..

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCustomerById/{intCustomerId}")]
        DataTable GetCustomerById(int intCustomerId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectMessageByCustomerId/{customerId}")]
        DataTable SelectMessageByCustomerId(int customerId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCustomerCountById/{intCustomerId}")]
        DataTable GetCustomerCountById(int intCustomerId);

        #endregion

        #region .. VENDOR REGISTER ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorRegister")]
        int AddVendorRegister(VendorDetails vendorDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorService")]
        int AddVendorService(VendorServiceDetails vendorServDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorArea")]
        int AddVendorArea(VendorAreaDetails vendorAreaDetails);

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

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateVendorPassword")]
        void UpdateVendorPassword(VendorDetails venDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateVendorEmail")]
        void UpdateVendorEmail(VendorDetails venDetails);

        #endregion

        #region .. VENDOR MESSAGE ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddVendorMessage")]
        int AddVendorMessage(VendorMessageDetails vendorMsgDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVenMessageById/{intMsgId}")]
        DataTable SelectVenMessageById(int intMsgId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVenMessageById/{vendorId}")]
        DataTable SelectResMsgByVenId(int vendorId);

        #endregion

        #region .. SELECT VENDOR ..

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVendorById/{intVendorId}")]
        DataTable GetVendorById(int intVendorId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVendorByCategory/{categoryId}")]
        DataTable SelectVendorByCategory(int categoryId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectVendorByService/{serviceId}")]
        DataTable SelectVendorByService(int serviceId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectMessageByVendorId/{vendorId}")]
        DataTable SelectMessageByVendorId(int vendorId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetVendorCountById/{intVendorId}")]
        DataTable GetVendorCountById(int intVendorId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAreaByVendorId/{vendorId}")]
        DataTable SelectAreaByVendorId(int vendorId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCategoryByVendorId/{intVendorId}")]
        DataTable GetCategoryByVendorId(int intVendorId);

        #endregion

        #region .. CITY, STATE & COUNTRY ..

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllCity")]
        DataTable SelectAllCity();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllState")]
        DataTable SelectAllState();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectAllCountry")]
        DataTable SelectAllCountry();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectCityByStateId/{intStateId}")]
        DataTable SelectCityByStateId(int intStateId);

        #endregion

        #region .. CATEGORY, SERVICE & MEMBERSHIP ..

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
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AvailableCategory/{strCategoryName}")]
        DataTable AvailableCategory(string strCategoryName);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddCategory")]
        int AddCategory(CategoryDetails categoryDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteCategoryById/{intCategoryId}")]
        void DeleteCategoryById(int intCategoryId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddService")]
        int AddService(ServiceDetails serviceDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DeleteServiceById")]
        void DeleteServiceById(int intServiceId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddMembership")]
        int AddMembership(MembershipDetails membershipDetails);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DelMembershipById/{intMemberId}")]
        void DelMembershipById(int intMemberId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetMembershipById/{intMemberId}")]
        DataTable GetMembershipById(int intMemberId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectServiceByCatID/{intCategoryId}")]
        DataTable SelectServiceByCatID(int intCategoryId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetServiceById/{intServiceId}")]
        DataTable GetServiceById(int intServiceId);

        #endregion

        #region .. INQUIRY DETAILS ..

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "AddInquiryDetails")]
        int AddInquiryDetails(InquiryDetails quiryDetails);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectInquiryByCustomerId/{customerId}")]
        DataTable SelectInquiryByCustomerId(int customerId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "SelectInquiryByVendorId/{vendorId}")]
        DataTable SelectInquiryByVendorId(int vendorId);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetInquiryById/{quiryId}")]
        DataTable GetInquiryById(int quiryId);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "UpdateInquiryImages")]
        void UpdateInquiryImages(InquiryDetails quiryDetails);

        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "DoSendMail")]
        void DoSendMail(SendMailDetails sendmailDetails);


    }
}
