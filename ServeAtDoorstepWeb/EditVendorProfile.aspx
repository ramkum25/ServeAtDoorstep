<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditVendorProfile.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.EditVendorProfile" %>

<asp:Content ID="f4" ContentPlaceHolderID="MainContent" runat="server">

    <p></p>
    <div style="padding: 10px 10px 10px 10px; font-family: 'Arial'; font-size: large; font-weight: bold; color: #FFFFCC; background-color: #808080">Edit Profile Information</div>
    <p></p>
    <div>
        <table>
            <tr>
                <td style="width: 200px; height: 200px;">
                    <span id="spnCusImage" runat="server"></span>
                    <br />
                    <div style="width: 100%;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 100%; height: 20px;"></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 20px; background-color: #4e98c8; color: wheat; text-align: center;">Login Name</td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 30px; color: #2447a7; font-weight: 600;">&nbsp;<asp:Label ID="lblLoginName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 20px; background-color: #4e98c8; color: wheat; text-align: center;">E Mail</td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 30px; color: #2447a7; font-weight: 600;">&nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div id="divProfile">
                            <div style="border: thin solid #800080; width: 900px; border-radius: 10px 10px 10px 10px;">
                                <table style="width: 900px; height: auto;">
                                    <tr>
                                        <td colspan="3" class="auto-style1" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; font-size: large; color: wheat; vertical-align: middle; height: 35px;">&nbsp;&nbsp;Name & Address Information 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <div id="divErrorMessage" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px; padding-left: 25px;"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;
                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%; font-family: Calibri; font-size: 14px; color: maroon; padding-left: 5px; font-weight: 600;">&nbsp;<asp:Label ID="Label1" runat="server" Text="l1">Vendor Name </asp:Label>
                                        </td>
                                        <td style="width: 30%;" colspan="2">
                                            <input type="text" id="txtVendorName" name="txtVendorName" class="CssTextbox" required="required" runat="server" style="width: 200px;" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hdnAddress" name="hdnAddress" runat="server" />

</asp:Content>
