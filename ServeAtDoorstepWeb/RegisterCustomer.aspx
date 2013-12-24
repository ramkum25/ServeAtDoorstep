<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCustomer.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.RegisterUser" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

    <div style="font-family: Terminal; color: #5F5F5F; padding-left:200px; ">
        <div id="divMessage"></div>
        <div style="font-size:40px;padding-left:100px;"><strong>Customer Registeration</strong></div>
        <%--<div id="divErrorMessage" runat="server" style="color:red;font-weight:700;padding-left:200px;background-color: #FFCCFF; border-radius:5px,5px;"></div>--%>
        <table style="padding-left:200px;">
             <tr>
                <td colspan="2" >
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                <div id="divErrorMessage" runat="server" style="color:red;font-weight:700; border-radius:5px,5px;"></div>
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Customer Login Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtUsername" name="txtUsername" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Password
                </td>
                <td>
                    <input type="password" runat="server" id="txtPassword" name="txtPassword" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Confirm Password
                </td>
                <td>
                    <input type="password" runat="server" id="txtConPassword" name="txtConPassword" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
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
                    Proile Picture
                </td>
                <td>
                     <asp:FileUpload ID="fileProfile" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;"  TabIndex="8" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    First Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtFirstname" name="txtFirstname" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Last Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtLastname" name="txtLastname" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr><tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Gender
                </td>
                <td>
                    <input type="radio" value="1" name="rdoGender"   />Male
                    <input type="radio" value="2" name="rdoGender"   />Female
                    <input type="radio" value="0" name="rdoGender"   />Rather not say
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Address
                </td>
                <td>
                    <input type="text" runat="server" id="txtAddress" name="txtAddress" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Street Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtStreet" name="txtStreet" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
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
                    <input type="text" runat="server" id="txtZipcode" name="txtZipcode" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
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
                    E Mail
                </td>
                <td>
                    <input type="text" runat="server" id="txtEmail" name="txtEmail" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Mobile Number
                </td>
                <td>
                    <input type="text" runat="server" id="txtMobile" name="txtMobile" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
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
                    Bank Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtBankname" name="txtBankname" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Cardholder Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtCardholdername" name="txtCardholdername" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Credit Card Number
                </td>
                <td>
                    <input type="text" runat="server" id="txtCredCardnumber" name="txtCredCardnumber" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
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
                    &nbsp;&nbsp;&nbsp;&nbsp;<input id="chkAgree" type="checkbox" name="chkAgree" runat="server" />I agree to the Serve At Doorstep Terms of Service and Privacy policy.
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
    <script type="text/javascript">
        $(function () {
            $('#<%=fileProfile.ClientID %>').change(function () {
            var fileExtension = ['jpeg', 'jpg', 'png', 'gif', 'bmp'];
            if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
                $(this).val("");
            }
        })
    })
</script>
</asp:Content>