<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterVendor.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.RegisterVendor" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/icon.css">
    <script type="text/javascript" src="js/easyUI/jquery.min.js"></script>
    <script type="text/javascript" src="js/easyUI/jquery.easyui.min.js"></script>s
    <div style="font-family: Terminal; color: #5F5F5F">
        <div id="divMessage"></div>
        <div style="font-size:40px;padding-left:150px;"><strong>Vendor Registeration</strong></div>
        <table style="padding-left:200px;">
            <tr>
                <td colspan="2" >
                <div id="divErrorMessage" runat="server" style="color:red;font-weight:700; border-radius:5px,5px;"></div>
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Vendor Login Name
                </td>
                <td>
                    <input type="text" id="txtLoginname" name="txtLoginname" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Password
                </td>
                <td>
                    <input type="password" id="txtPassword" name="txtPassword" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Confirm Password
                </td>
                <td>
                    <input type="password" id="txtConPassword" name="txtConPassword" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width:700px;">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                &nbsp;
                </td>
            </tr>
             <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Coverage Area
                </td>
                <td>
                    <input type="text" id="txtCoverageArea" name="txtCoverageArea" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
             <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Select Category
                </td>
                <td>
                    <asp:CheckBoxList ID="chkCateList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" RepeatLayout="Table" CellSpacing="2" CellPadding="4">

                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Company Name
                </td>
                <td>
                    <input type="text" id="txtCompanyName" name="txtCompanyName" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Owner Name
                </td>
                <td>
                    <input type="text" id="txtOwnerName" name="txtOwnerName" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Contact Name
                </td>
                <td>
                    <input type="text" id="txtContactName" name="txtContactName" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Contact Number
                </td>
                <td>
                    <input type="text" id="txtContactNo" name="txtContactNo" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Mobile Number
                </td>
                <td>
                    <input type="text" id="txtMobileNo" name="txtMobileNo" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Business Phone Number
                </td>
                <td>
                    <input type="text" id="txtBusinessNo" name="txtBusinessNo" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    E Mail
                </td>
                <td>
                    <input type="text" id="txtEmail" name="txtEmail" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Website URL
                </td>
                <td>
                    <input type="text" id="txtWebsiteUrl" name="txtWebsiteUrl" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width:700px;">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Vendor Name
                </td>
                <td>
                    <input type="text" id="txtVendorName" name="txtVendorName" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Address
                </td>
                <td>
                    <input type="text" id="txtAddress" name="txtAddress" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Street Name
                </td>
                <td>
                    <input type="text" id="txtStreet" name="txtStreet" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Country
                </td>
                <td>
                    <select id="ddlCountry" name="ddlCountry" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px; border-top-style:solid;height:25px; width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    State
                </td>
                <td>
                    <select id="ddlState" name="ddlState" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px; border-top-style:solid;height:25px; width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    City
                </td>
                <td>
                    <select id="ddlCity" name="ddlCity" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px; border-top-style:solid;height:25px; width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Zip Code
                </td>
                <td>
                    <input type="text" id="txtZipcode" name="txtZipcode" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2" style="width:700px;">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Membership Type
                </td>
                <td>
                    <select id="ddlMembership" name="ddlMembership" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px; border-top-style:solid;height:25px; width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Credit Card Type
                </td>
                <td>
                    <input type="text" id="txtCredCardType" name="txtCredCardType" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Credit Card Number
                </td>
                <td>
                    <input type="text" id="txtCredCardNo" name="txtCredCardNo" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Credit Card Expired Date
                </td>
                <td>
                    <input type="text" id="txtExpiredDate" name="txtExpiredDate" runat="server" class="easyui-datebox" data-options="required:true" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    CVC Number
                </td>
                <td>
                    <input type="text" id="txtCVC" name="txtCVC" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="chkAgree" name="chkAgree" runat="server" type="checkbox" />I agree to the Serve At Doorstep Terms of Service and Privacy policy.
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;" colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"
                            style="width: 120px;border-radius:10px 10px;height:30px;background-color:#3cc7e0;font-family:Tahoma;font-size:16px;font-weight:700;" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            style="width: 120px;border-radius:10px 10px;height:30px;background-color:#3cc7e0;font-family:Tahoma;font-size:16px;font-weight:700;" />
                    
                </td>
            </tr>
            
        </table>

    </div>

</asp:Content>
