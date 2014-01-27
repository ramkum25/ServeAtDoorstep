<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.ForgotPassword" %>

<asp:Content ID="w" runat="server" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/icon.css" />
    <script type="text/javascript" src="js/easyUI/jquery.min.js"></script>
    <script type="text/javascript" src="js/easyUI/jquery.easyui.min.js"></script>
    
    <div style="background-color:#aed586;height:35px;vertical-align:middle;padding-left:75px;padding-top:12px;
            text-align:left;font-family:'Century Gothic';font-size:16px;font-weight:bold;">
        FORGOT PASSWORD
    </div>

    <p>&nbsp;</p>
    <div id="divMessage" runat="server">
    </div>
    <div id="divErrorMessage" runat="server">
    </div>
    <div>
        <table>
            <tr>
                <td style="padding-top:10px;">
                    Enter your Email Address
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="ServeTextbox" Width="200px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnGreen" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>

</asp:Content>