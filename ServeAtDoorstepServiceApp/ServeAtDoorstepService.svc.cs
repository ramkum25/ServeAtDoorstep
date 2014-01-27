using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Web;
using ServeAtDoorstepCommon;
using ServeAtDoorstepData;
using ServeAtDoorstepDataAccess;

namespace ServeAtDoorstepServiceApp
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServeAtDoorstepService : IServeAtDoorstepService
    {
        DALComponent objDALComponent = new DALComponent();

        #region .. ADMIN ..

        public int LoginAdmin(LoginDetails loginDetails)
        {
            try
            {
                DALComponent objDALLog = new DALComponent();
                objDALLog.SetParameters("@loginName", SqlDbType.VarChar, 50, loginDetails.UserName);
                objDALLog.SetParameters("@loginPassword", SqlDbType.VarChar, 50, loginDetails.UserPassword);
                objDALLog.SqlCommandText = "[ValidateAdmin]";
                object y = objDALLog.SelectRecordValue();
                if (int.Parse(y.ToString()) > 0)
                    return int.Parse(y.ToString());
                else
                    return 0;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. CUSTOMER REGISTER ..

        public int AddCustomerRegister(CustomerDetails customerDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@CustomerID", SqlDbType.Int, 4, customerDetails.CustomerID);
                objDALRegister.SetParameters("@LoginName", SqlDbType.VarChar, 100, customerDetails.LoginName);
                objDALRegister.SetParameters("@ImagePath", SqlDbType.VarChar, 50, customerDetails.ImagePath);
                objDALRegister.SetParameters("@FirstName", SqlDbType.VarChar, 100, customerDetails.FirstName);
                objDALRegister.SetParameters("@LastName", SqlDbType.VarChar, 100, customerDetails.LastName);
                objDALRegister.SetParameters("@Gender", SqlDbType.Int, 4, customerDetails.Gender);
                objDALRegister.SetParameters("@LoginPassword", SqlDbType.VarChar, 50, customerDetails.LoginPassword);
                objDALRegister.SetParameters("@Email", SqlDbType.VarChar, 50, customerDetails.Email);
                objDALRegister.SetParameters("@Mobile", SqlDbType.VarChar, 50, customerDetails.Mobile);
                objDALRegister.SetParameters("@Address", SqlDbType.VarChar, 100, customerDetails.Address);
                objDALRegister.SetParameters("@StreetName", SqlDbType.VarChar, 50, customerDetails.StreetName);
                objDALRegister.SetParameters("@CityId", SqlDbType.Int, 4, customerDetails.CityId);
                objDALRegister.SetParameters("@StateId", SqlDbType.Int, 4, customerDetails.StateId);
                objDALRegister.SetParameters("@CountryId", SqlDbType.Int, 4, customerDetails.CountryId);
                objDALRegister.SetParameters("@ZipCode", SqlDbType.VarChar, 50, customerDetails.ZipCode);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateCustomer]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (customerDetails.CustomerID != 0)
                    return customerDetails.CustomerID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int AddCustomerBankdet(CusBankDetails cusbankDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@bankId", SqlDbType.Int, 4, cusbankDetails.BankId);
                objDALRegister.SetParameters("@customerId", SqlDbType.Int, 4, cusbankDetails.CustomerId);
                objDALRegister.SetParameters("@bankName", SqlDbType.VarChar, 200, cusbankDetails.BankName);
                objDALRegister.SetParameters("@cardholderName", SqlDbType.VarChar, 50, cusbankDetails.CardHolderName);
                objDALRegister.SetParameters("@creditcardNumber", SqlDbType.VarChar, 50, cusbankDetails.CreditCardNumber);
                objDALRegister.SetParameters("@cvcNumber", SqlDbType.VarChar, 50, cusbankDetails.CVCNumber);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateBankDetails]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (cusbankDetails.BankId != 0)
                    return cusbankDetails.BankId;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable AvailableCustomer(string strLoginname)
        {
            try
            {
                objDALComponent.SetParameters("@Loginname", SqlDbType.VarChar, 50, strLoginname);
                objDALComponent.SqlCommandText = "[AvailableCustomer]";
                return (objDALComponent.SelectRecord());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable AvailableCusMail(string strEmail)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@email", SqlDbType.VarChar, 50, strEmail);
                objDAL.SqlCommandText = "[AvailableCusMail]";
                return (objDAL.SelectRecord());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int LoginCustomer(LoginDetails loginDetails)
        {
            try
            {
                DALComponent objDALLog = new DALComponent();
                objDALLog.SetParameters("@loginName", SqlDbType.VarChar, 50, loginDetails.UserName);
                objDALLog.SetParameters("@loginPassword", SqlDbType.VarChar, 50, loginDetails.UserPassword);
                objDALLog.SqlCommandText = "[ValidateCustomer]";
                object y = objDALLog.SelectRecordValue();
                if (int.Parse(y.ToString()) > 0)
                    return int.Parse(y.ToString());
                else
                    return 0;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public bool ActivateCustomer(int customerId)
        {
            try
            {
                DALComponent objDALCon = new DALComponent();
                objDALCon.SetParameters("@customerid", SqlDbType.Int, 4, customerId);
                objDALCon.SqlCommandText = "ActivateCustomer";
                int x = objDALCon.CreateRecord();
                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable ForgotPasswordCus(string cusEmail)
        {
            try
            {
                DALComponent objDALCon = new DALComponent();
                objDALCon.SetParameters("@email", SqlDbType.VarChar, 50, cusEmail);
                objDALCon.SqlCommandText = "[SelectCustomerByEmail]";
                return objDALCon.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateCustomerImage(CustomerDetails cusDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@customerId", SqlDbType.Int, 4, cusDetails.CustomerID);
                objDAL.SetParameters("@imagepath", SqlDbType.VarChar, 100, cusDetails.ImagePath);
                objDAL.SqlCommandText = "[UpdateCustomerImage]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateCustomerPassword(CustomerDetails cusDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@customerId", SqlDbType.Int, 4, cusDetails.CustomerID);
                objDAL.SetParameters("@password", SqlDbType.VarChar, 100, cusDetails.LoginPassword);
                objDAL.SqlCommandText = "[UpdateCustomerPassword]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateCustomerEmail(CustomerDetails cusDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@customerId", SqlDbType.Int, 4, cusDetails.CustomerID);
                objDAL.SetParameters("@email", SqlDbType.VarChar, 100, cusDetails.Email);
                objDAL.SqlCommandText = "[UpdateCustomerEmail]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. CUSTOMER MESSAGE ..

        public int AddCustomerMessage(CustomerMessageDetails cusMessageDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@CustomerMessageId", SqlDbType.Int, 4, cusMessageDetails.CustomerMessageId);
                objDALRegister.SetParameters("@QuiryId", SqlDbType.Int, 4, cusMessageDetails.QuiryId);
                objDALRegister.SetParameters("@RecCustomerId", SqlDbType.Int, 4, cusMessageDetails.RecCustomerId);
                objDALRegister.SetParameters("@SendVendorId", SqlDbType.Int, 4, cusMessageDetails.SendVendorId);
                objDALRegister.SetParameters("@CategoryId", SqlDbType.Int, 4, cusMessageDetails.CategoryId);
                objDALRegister.SetParameters("@MessageTitle", SqlDbType.VarChar, 100, cusMessageDetails.MessageTitle);
                objDALRegister.SetParameters("@Description", SqlDbType.VarChar, 1000, cusMessageDetails.Description);
                objDALRegister.SetParameters("@Status", SqlDbType.VarChar, 10, cusMessageDetails.Status);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateCustomerMessage]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (cusMessageDetails.CustomerMessageId != 0)
                    return cusMessageDetails.CustomerMessageId;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectCusMessageById(int intMsgId)
        {
            try
            {
                DALComponent objDALVenMsg = new DALComponent();
                objDALVenMsg.SetParameters("@msgid", SqlDbType.Int, 4, intMsgId);
                objDALVenMsg.SqlCommandText = "SelectCusMessageById";
                return objDALVenMsg.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }
        #endregion

        #region .. SELECT CUSTOMER ..

        public DataTable GetCustomerById(int intCustomerId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@customerid", SqlDbType.Int, 4, intCustomerId);
                objDalComp.SqlCommandText = "[GetCustomerById]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectMessageByCustomerId(int customerId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@customerid", SqlDbType.Int, 4, customerId);
                objDalComp.SqlCommandText = "[SelectMessageByCustomerId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }
        
        public DataTable GetCustomerCountById(int intCustomerId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@customerid", SqlDbType.Int, 4, intCustomerId);
                objDalComp.SqlCommandText = "[GetCustomerCount]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. VENDOR REGISTER ..

        public int AddVendorRegister(VendorDetails vendorDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@VendorID", SqlDbType.Int, 4, vendorDetails.VendorID);
                objDALRegister.SetParameters("@LoginName", SqlDbType.VarChar, 50, vendorDetails.LoginName);
                objDALRegister.SetParameters("@LoginPassword", SqlDbType.VarChar, 50, vendorDetails.LoginPassword);
                objDALRegister.SetParameters("@VendorName", SqlDbType.VarChar, 50, vendorDetails.VendorName);
                objDALRegister.SetParameters("@VendorAddress", SqlDbType.VarChar, 50, vendorDetails.VendorAddress);
                objDALRegister.SetParameters("@VendorStreet", SqlDbType.VarChar, 50, vendorDetails.VendorStreet);
                objDALRegister.SetParameters("@VendorCityId", SqlDbType.Int, 4, vendorDetails.VendorCityId);
                objDALRegister.SetParameters("@VendorStateId", SqlDbType.Int, 4, vendorDetails.VendorStateId);
                objDALRegister.SetParameters("@VendorCountryId", SqlDbType.Int, 4, vendorDetails.VendorCountryId);
                objDALRegister.SetParameters("@VendorZipcode", SqlDbType.VarChar, 50, vendorDetails.VendorZipcode);
                objDALRegister.SetParameters("@VendorEmail", SqlDbType.VarChar, 50, vendorDetails.VendorEmail);
                objDALRegister.SetParameters("@VendorMobile", SqlDbType.VarChar, 50, vendorDetails.VendorMobile);
                objDALRegister.SetParameters("@VendorBusinessPhone", SqlDbType.VarChar, 50, vendorDetails.VendorBusinessPhone);
                objDALRegister.SetParameters("@CompanyName", SqlDbType.VarChar, 50, vendorDetails.CompanyName);
                objDALRegister.SetParameters("@OwnerName", SqlDbType.VarChar, 50, vendorDetails.OwnerName);
                objDALRegister.SetParameters("@ContactName", SqlDbType.VarChar, 50, vendorDetails.ContactName);
                objDALRegister.SetParameters("@ContactNumber", SqlDbType.VarChar, 50, vendorDetails.ContactNumber);
                objDALRegister.SetParameters("@CategoryId", SqlDbType.Int, 4, vendorDetails.CategoryId);
                objDALRegister.SetParameters("@CoverageArea", SqlDbType.VarChar, 50, vendorDetails.CoverageArea);
                objDALRegister.SetParameters("@WebsiteUrl", SqlDbType.VarChar, 50, vendorDetails.WebsiteUrl);
                objDALRegister.SetParameters("@GeoCode", SqlDbType.VarChar, 50, vendorDetails.GeoCode);
                objDALRegister.SetParameters("@MemberShipId", SqlDbType.Int, 4, vendorDetails.MemberShipId);
                objDALRegister.SetParameters("@CreditCardNumber", SqlDbType.VarChar, 50, vendorDetails.CreditCardNumber);
                objDALRegister.SetParameters("@CreditCardType", SqlDbType.VarChar, 50, vendorDetails.CreditCardType);
                objDALRegister.SetParameters("@CreditCardExpired", SqlDbType.VarChar, 50, vendorDetails.CreditCardExpired);
                objDALRegister.SetParameters("@CVCNumber", SqlDbType.VarChar, 50, vendorDetails.CVCNumber);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateVendor]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (vendorDetails.VendorID != 0)
                    return vendorDetails.VendorID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int AddVendorService(VendorServiceDetails vendorServDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@VendorServiceId", SqlDbType.Int, 4, vendorServDetails.VendorServiceId);
                objDALRegister.SetParameters("@VendorId", SqlDbType.Int, 4, vendorServDetails.VendorId);
                objDALRegister.SetParameters("@CategoryId", SqlDbType.Int, 4, vendorServDetails.CategoryId);
                objDALRegister.SetParameters("@ServiceId", SqlDbType.Int, 4, vendorServDetails.ServiceId);
                objDALRegister.SetParameters("@Status", SqlDbType.VarChar, 25, vendorServDetails.Status);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateVendorService]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (vendorServDetails.VendorServiceId != 0)
                    return vendorServDetails.VendorServiceId;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int AddVendorArea(VendorAreaDetails vendorAreaDetails)
        {
            try
            {
                DALComponent objDALArea = new DALComponent();
                objDALArea.SetParameters("@vendorAreaId", SqlDbType.Int, 4, vendorAreaDetails.VendorAreaID);
                objDALArea.SetParameters("@vendorId", SqlDbType.Int, 4, vendorAreaDetails.VendorId);
                objDALArea.SetParameters("@city", SqlDbType.VarChar, 50, vendorAreaDetails.VACityName);
                objDALArea.SetParameters("@state", SqlDbType.VarChar, 50, vendorAreaDetails.VAState);
                objDALArea.SetParameters("@zipcode", SqlDbType.VarChar, 50, vendorAreaDetails.VAZipcode);
                objDALArea.SetParameters("@distance", SqlDbType.VarChar, 50, vendorAreaDetails.VADistance);
                objDALArea.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALArea.SqlCommandText = "[CreateVendorArea]";
                int x = objDALArea.CreateRecord();
                object y = objDALArea.GetParameters("@idvalue");
                if (vendorAreaDetails.VendorAreaID != 0)
                    return vendorAreaDetails.VendorAreaID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable AvailableVendor(string strLoginname)
        {
            try
            {
                objDALComponent.SetParameters("@Loginname", SqlDbType.VarChar, 50, strLoginname);
                objDALComponent.SqlCommandText = "[AvailableVendor]";
                return (objDALComponent.SelectRecord());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable AvailableVenMail(string strEmail)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@email", SqlDbType.VarChar, 50, strEmail);
                objDAL.SqlCommandText = "[AvailableVenMail]";
                return (objDAL.SelectRecord());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int LoginVendor(LoginDetails loginDetails)
        {
            try
            {
                DALComponent objDALLog = new DALComponent();
                objDALLog.SetParameters("@loginName", SqlDbType.VarChar, 50, loginDetails.UserName);
                objDALLog.SetParameters("@loginPassword", SqlDbType.VarChar, 50, loginDetails.UserPassword);
                objDALLog.SqlCommandText = "[ValidateVendor]";
                object y = objDALLog.SelectRecordValue();
                if (int.Parse(y.ToString()) > 0)
                    return int.Parse(y.ToString());
                else
                    return 0;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public bool ActivateVendor(int vendorId)
        {
            try
            {
                DALComponent objDALCon = new DALComponent();
                objDALCon.SetParameters("@vendorid", SqlDbType.Int, 4, vendorId);
                objDALCon.SqlCommandText = "[ActivateVendor]";
                int x = objDALCon.CreateRecord();
                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable ForgotPasswordVen(string venEmail)
        {
            try
            {
                DALComponent objDALCon = new DALComponent();
                objDALCon.SetParameters("@email", SqlDbType.VarChar, 50, venEmail);
                objDALCon.SqlCommandText = "[SelectVendorByEmail]";
                return objDALCon.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateVendorPassword(VendorDetails venDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@vendorId", SqlDbType.Int, 4, venDetails.VendorID);
                objDAL.SetParameters("@password", SqlDbType.VarChar, 100, venDetails.LoginPassword);
                objDAL.SqlCommandText = "[UpdateVendorPassword]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateVendorEmail(VendorDetails venDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@vendorId", SqlDbType.Int, 4, venDetails.VendorID);
                objDAL.SetParameters("@email", SqlDbType.VarChar, 100, venDetails.VendorEmail);
                objDAL.SqlCommandText = "[UpdateVendorEmail]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. VENDOR MESSAGE ..

        public int AddVendorMessage(VendorMessageDetails vendorMsgDetails) 
        {
            try
            {
                DALComponent objDALVenMsg = new DALComponent();
                objDALVenMsg.SetParameters("@VendorMessageId", SqlDbType.Int, 4, vendorMsgDetails.VendorMessageId);
                objDALVenMsg.SetParameters("@QuiryId", SqlDbType.Int, 4, vendorMsgDetails.QuiryId);
                objDALVenMsg.SetParameters("@SendCustomerId", SqlDbType.Int, 4, vendorMsgDetails.SendCustomerId);
                objDALVenMsg.SetParameters("@VendorId", SqlDbType.Int, 4, vendorMsgDetails.VendorId);
                objDALVenMsg.SetParameters("@CategoryId", SqlDbType.Int, 4, vendorMsgDetails.CategoryId);
                objDALVenMsg.SetParameters("@MessageTitle", SqlDbType.VarChar, 100, vendorMsgDetails.MessageTitle);
                objDALVenMsg.SetParameters("@Description", SqlDbType.VarChar, 1000, vendorMsgDetails.Description);
                objDALVenMsg.SetParameters("@Status", SqlDbType.VarChar, 10, vendorMsgDetails.Status);
                objDALVenMsg.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALVenMsg.SqlCommandText = "[CreateVendorMessage]";
                int x = objDALVenMsg.CreateRecord();
                object y = objDALVenMsg.GetParameters("@idvalue");
                if (vendorMsgDetails.VendorMessageId != 0)
                    return vendorMsgDetails.VendorMessageId;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectVenMessageById(int intMsgId) 
        { 
            try
            {
                DALComponent objDALVenMsg = new DALComponent();
                objDALVenMsg.SetParameters("@msgid", SqlDbType.Int, 4, intMsgId);
                objDALVenMsg.SqlCommandText = "SelectVenMessageById";
                return objDALVenMsg.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectResMsgByVenId(int vendorId)
        {
            try
            {
                DALComponent objDALVenMsg = new DALComponent();
                objDALVenMsg.SetParameters("@vendorid", SqlDbType.Int, 4, vendorId);
                objDALVenMsg.SqlCommandText = "SelectResMsgByVenId";
                return objDALVenMsg.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }
        #endregion

        #region .. SELECT VENDOR ..

        public DataTable GetVendorById(int intVendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorid", SqlDbType.Int, 4, intVendorId);
                objDalComp.SqlCommandText = "[GetVendorById]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectVendorByCategory(int categoryId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@cateid", SqlDbType.Int, 4, categoryId);
                objDalComp.SqlCommandText = "[SelectVendorByCatid]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectVendorByService(int serviceId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@serviceid", SqlDbType.Int, 4, serviceId);
                objDalComp.SqlCommandText = "[SelectVendorByServId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectMessageByVendorId(int vendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorid", SqlDbType.Int, 4, vendorId);
                objDalComp.SqlCommandText = "[SelectMessageByVendorId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable GetVendorCountById(int intVendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorid", SqlDbType.Int, 4, intVendorId);
                objDalComp.SqlCommandText = "[GetVendorCount]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectAreaByVendorId(int vendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorid", SqlDbType.Int, 4, vendorId);
                objDalComp.SqlCommandText = "[SelectAreaByVendorId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable GetCategoryByVendorId(int intVendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorId", SqlDbType.Int, 4, intVendorId);
                objDalComp.SqlCommandText = "[GetCategoryByVendorId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. CITY, STATE & COUNTRY ..

        public DataTable SelectAllCity()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectCity";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectAllState()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectState";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectAllCountry()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectCountry";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectCityByStateId(int intStateId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@stateId", SqlDbType.Int, 4, intStateId);
                objDalComp.SqlCommandText = "[SelectCityByStateId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. CATEGORY, SERVICE & MEMBERSHIP ..

        public DataTable SelectAllCategory()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectCategory";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectAllMembership()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectMembership";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectAllService()
        {
            try
            {
                objDALComponent.SqlCommandText = "SelectService";
                return objDALComponent.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable AvailableCategory(string strCategoryName)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@catname", SqlDbType.VarChar, 50, strCategoryName);
                objDalComp.SqlCommandText = "[AvailableCategory]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
       
        }

        public int AddCategory(CategoryDetails categoryDetails)
        {
            try
            {
                DALComponent objDALCategory = new DALComponent();
                objDALCategory.SetParameters("@categoryId", SqlDbType.Int, 4, categoryDetails.CategoryID);
                objDALCategory.SetParameters("@categoryName", SqlDbType.VarChar, 50, categoryDetails.CategoryName);
                objDALCategory.SetParameters("@categoryDesc", SqlDbType.VarChar, 300, categoryDetails.CategoryDescription);
                objDALCategory.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALCategory.SqlCommandText = "[CreateCategory]";
                int x = objDALCategory.CreateRecord();
                object y = objDALCategory.GetParameters("@idvalue");
                if (categoryDetails.CategoryID != 0)
                    return categoryDetails.CategoryID;
                else
                    return Int32.Parse(y.ToString());
                
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        
        }

        public void DeleteCategoryById(int intCategoryId)
        {
            try
            {
                objDALComponent.SetParameters("@categoryId", SqlDbType.Int, 4, intCategoryId);
                objDALComponent.SqlCommandText = "[DeleteCategoryById]";
                int x = objDALComponent.DeleteRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int AddService(ServiceDetails serviceDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@serviceID", SqlDbType.Int, 4, serviceDetails.ServiceID);
                objDALRegister.SetParameters("@serviceName", SqlDbType.VarChar, 50, serviceDetails.ServiceName);
                objDALRegister.SetParameters("@serviceDesc", SqlDbType.VarChar, 300, serviceDetails.ServiceDescription);
                objDALRegister.SetParameters("@serviceKeyw", SqlDbType.VarChar, 300, serviceDetails.ServiceKeyword);
                objDALRegister.SetParameters("@categoryId", SqlDbType.Int, 4, serviceDetails.CategoryId);
                objDALRegister.SetParameters("@serviceType", SqlDbType.VarChar, 50, serviceDetails.ServiceType);
                objDALRegister.SetParameters("@priceRangeFrom", SqlDbType.VarChar, 50, serviceDetails.PriceRangeFrom);
                objDALRegister.SetParameters("@priceRangeTo", SqlDbType.VarChar, 50, serviceDetails.PriceRangeTo);
                objDALRegister.SetParameters("@noOfPair", SqlDbType.Int, 4, serviceDetails.NoOfPair);
                objDALRegister.SetParameters("@brandName", SqlDbType.VarChar, 50, serviceDetails.BrandName);
                objDALRegister.SetParameters("@brandType", SqlDbType.VarChar, 50, serviceDetails.BrandType);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateService]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (serviceDetails.ServiceID != 0)
                    return serviceDetails.ServiceID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void DeleteServiceById(int intServiceId)
        {
            try
            {
                objDALComponent.SetParameters("@serviceId", SqlDbType.Int, 4, intServiceId);
                objDALComponent.SqlCommandText = "[DelServiceById]";
                int x = objDALComponent.DeleteRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public int AddMembership(MembershipDetails membershipDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@memberShipID", SqlDbType.Int, 4, membershipDetails.MemberShipID);
                objDALRegister.SetParameters("@memberShipName", SqlDbType.VarChar, 50, membershipDetails.MemberShipName);
                objDALRegister.SetParameters("@memberShipType", SqlDbType.NChar, 10, membershipDetails.MemberShipType);
                objDALRegister.SetParameters("@memberShipAmount", SqlDbType.Decimal, 9, membershipDetails.MemberShipAmount);
                objDALRegister.SetParameters("@memberShipDays", SqlDbType.Int, 4, membershipDetails.MemberShipDays);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateMembership]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (membershipDetails.MemberShipID != 0)
                    return membershipDetails.MemberShipID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void DelMembershipById(int intMemberId)
        {
            try
            {
                objDALComponent.SetParameters("@memberId", SqlDbType.Int, 4, intMemberId);
                objDALComponent.SqlCommandText = "[DelMembershipById]";
                int x = objDALComponent.DeleteRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable GetMembershipById(int intMemberId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@memberid", SqlDbType.Int, 4, intMemberId);
                objDalComp.SqlCommandText = "[GetMembershipById]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }


        public DataTable SelectServiceByCatID(int intCategoryId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@CategoryId", SqlDbType.Int, 4, intCategoryId);
                objDalComp.SqlCommandText = "[SelectServiceByCatId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable GetServiceById(int intServiceId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@serviceid", SqlDbType.Int, 4, intServiceId);
                objDalComp.SqlCommandText = "[GetServiceById]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        #endregion

        #region .. INQUIRY DETAILS ..

        public int AddInquiryDetails(InquiryDetails quiryDetails)
        {
            try
            {
                DALComponent objDALRegister = new DALComponent();
                objDALRegister.SetParameters("@InquiryID", SqlDbType.Int, 4, quiryDetails.InquiryID);
                objDALRegister.SetParameters("@InquiryTitle", SqlDbType.VarChar, 100, quiryDetails.InquiryTitle);
                objDALRegister.SetParameters("@Description", SqlDbType.VarChar, 300, quiryDetails.Description);
                objDALRegister.SetParameters("@Keywords", SqlDbType.VarChar, 300, quiryDetails.Keywords);
                objDALRegister.SetParameters("@CategoryId", SqlDbType.Int, 4, quiryDetails.CategoryId);
                objDALRegister.SetParameters("@ServiceId", SqlDbType.Int, 4, quiryDetails.ServiceId);
                objDALRegister.SetParameters("@CustomerId", SqlDbType.Int, 4, quiryDetails.CustomerId);
                objDALRegister.SetParameters("@CityId", SqlDbType.Int, 4, quiryDetails.CityId);
                objDALRegister.SetParameters("@ImagePath", SqlDbType.VarChar, 500, quiryDetails.ImagePath);
                objDALRegister.SetParameters("@VideoPath", SqlDbType.VarChar, 200, quiryDetails.VideoPath);
                objDALRegister.SetParameters("@idvalue", SqlDbType.Int, true);
                objDALRegister.SqlCommandText = "[CreateInquiryDetails]";
                int x = objDALRegister.CreateRecord();
                object y = objDALRegister.GetParameters("@idvalue");
                if (quiryDetails.InquiryID != 0)
                    return quiryDetails.InquiryID;
                else
                    return Int32.Parse(y.ToString());
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectInquiryByCustomerId(int customerId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@customerid", SqlDbType.Int, 4, customerId);
                objDalComp.SqlCommandText = "[SelectInquiryByCusId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable SelectInquiryByVendorId(int vendorId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@vendorid", SqlDbType.Int, 4, vendorId);
                objDalComp.SqlCommandText = "[SelectInquiryByVendorId]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public DataTable GetInquiryById(int quiryId)
        {
            try
            {
                DALComponent objDalComp = new DALComponent();
                objDalComp.SetParameters("@quiryid", SqlDbType.Int, 4, quiryId);
                objDalComp.SqlCommandText = "[GetInquiryById]";
                return objDalComp.SelectRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }

        public void UpdateInquiryImages(InquiryDetails quiryDetails)
        {
            try
            {
                DALComponent objDAL = new DALComponent();
                objDAL.SetParameters("@inquiryId", SqlDbType.Int, 4, quiryDetails.InquiryID);
                objDAL.SetParameters("@imagepath", SqlDbType.VarChar, 500, quiryDetails.ImagePath);
                objDAL.SetParameters("@videopath", SqlDbType.VarChar, 200, quiryDetails.VideoPath);
                objDAL.SqlCommandText = "[UpdateInquiryImages]";
                int x = objDAL.UpdateRecord();
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException("Data error=" + sqlEx.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }


        #endregion

        public void DoSendMail(SendMailDetails sendmailDetails)
        {
            try
            {
                string mUname = ConfigurationManager.AppSettings["mailUsername"].ToString();
                string mPwd = ConfigurationManager.AppSettings["mailPassword"].ToString();
                string mFrom = "";
                string mTo = sendmailDetails.MailID.Trim();
                string mCC = "";

                string mSubject = sendmailDetails.MailSubject.Trim();
                string mMsg = sendmailDetails.MailContent.Trim();

                UtilityClass.SendMail(mUname, mPwd, mFrom, mTo, mCC, mSubject, mMsg, true);
            }
            catch (SystemException sex)
            {
                throw new ApplicationException("Error=" + sex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error=" + ex.Message.ToString());
            }
        }


    }
}
