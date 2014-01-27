<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginO.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.LoginO" %>

<asp:Content ID="co1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <script type="text/javascript" src="css/ServeAtDoor.css"></script>
    <table>
        <tr>
            <td>
                <div style="width: 500px; padding-left: 100px;">
                    <table>
                        <tr>
                            <td style="font-family: Verdana; font-size: medium; font-weight: 800; height: 35px;">Account Information</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Already member? Login with your Username and Password On The Right!</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>New member? Click below as a</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnCustomer" runat="server" Text="Customer" OnClick="btnCustomer_Click"
                                    CssClass="btnYellow" Style="width: 200px;" />

                                <asp:Button ID="btnVendor" runat="server" Text="Vendor" OnClick="btnVendor_Click"
                                    CssClass="btnRed" Style="width: 200px;" />

                            </td>
                        </tr>
                    </table>
                </div>

            </td>
            <td>
                <div style="width: 50px;">&nbsp;</div>
            </td>
            <td>
                <div style="border: thin solid #800080; width: 400px; height: 325px;">
                    <table style="width: 400px; height: 287px;">
                        <tr>
                            <td colspan="2" class="auto-style1" style="background-color: #aed586; font-family: Verdana; font-weight: 500; font-size: large; color: #FFFFCC; vertical-align: middle;">&nbsp;&nbsp;
                                            <asp:Label ID="lblCaptionText" runat="server" Text="Login" Font-Names="Verdana"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="divErrMsg" runat="server" style="color: red; font-weight: 700;"></div>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center; padding-right: 10px;" class="auto-style3">
                                <input name="rdoLogType" value="1" type="radio" />&nbsp;&nbsp;Customer&nbsp;&nbsp;&nbsp;
                                            <input name="rdoLogType" value="2" type="radio" />&nbsp;&nbsp;Vendor
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px; padding-top: 20px;" class="auto-style3">
                                <strong><span class="auto-style2">User Name</span></strong>
                            </td>
                            <td class="auto-style2">
                                <input id="txtUsername" name="txtUsername" runat="server" type="text" style="border: 1px solid #1c1c1c; 
-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; font-size: 15px; font-family:Calibri, sans-serif; padding: 5px 5px 5px 5px; text-decoration: none; display: inline-block; color: #000000; background-color: #f2f2f2; margin-top: 10px; background-image: linear-gradient(to bottom, #f2f2f2, #ffffff);"
                                    class="easyui-validatebox" data-options="required:true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px; padding-top: 20px;" class="auto-style3">
                                <strong><span class="auto-style2">Password</span></strong>
                            </td>
                            <td class="auto-style2">
                                <input id="txtUserpassword" name="txtUserpassword" runat="server" type="password" style="border: 1px solid #1c1c1c;
 -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; font-size: 15px; font-family: Calibri, sans-serif; padding: 5px 5px 5px 5px; text-decoration: none; display: inline-block; color: #000000; background-color: #f2f2f2; margin-top: 10px; background-image: linear-gradient(to bottom, #f2f2f2, #ffffff);"
                                    class="easyui-validatebox" data-options="required:true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style3" style="height: 44px"></td>
                            <td class="auto-style2" style="height: 44px">
                                <input id="chkAgree" runat="server" type="checkbox" name="chkAgree" />&nbsp;&nbsp;Remember me next time
                                            <br />
                                <br />
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"
                                    CssClass="btnRed" Style="width: 120px;" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">
                                <asp:HyperLink ID="hlForgotPwd" runat="server"
                                    Style="font-size: 15px; color: blueviolet; margin: 0px 0px 0px 0px;" NavigateUrl="~/ForgotPassword.aspx">Forgot password</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>

            </td>
        </tr>
    </table>
</asp:Content>
