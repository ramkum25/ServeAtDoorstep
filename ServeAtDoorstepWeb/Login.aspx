<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServeAtDoorstepWeb.Login" MasterPageFile="~/Serve.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="co1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="css/tabStyleSheet.css" />
    <style>
        .ajax__tab_tab {
            width:186px;
        }
        .ajax__tab_outer {
        }
    </style>

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
                <ajax:ToolkitScriptManager ID="t1" runat="server"></ajax:ToolkitScriptManager>
                <ajax:TabContainer ID="tabLogin" runat="server" CssClass="ajax__tab_red-theme" >
                    <ajax:TabPanel ID="tpnlCustomer" runat="server">
                    <HeaderTemplate>
                        CUSTOMER    
                        
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlCustomer" runat="server" style="">
                            <div style=" width: 400px; height: 325px;">
                    <table style="width: 400px; height: 287px;">
                        <%--<tr>
                            <td colspan="2" class="auto-style1" style="background-color: #aed586; font-family: Verdana; font-weight: 500; font-size: large; color: #FFFFCC; vertical-align: middle;">&nbsp;&nbsp;
                                            <asp:Label ID="lblCaptionText" runat="server" Text="Login" Font-Names="Verdana"></asp:Label>

                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">
                                <div id="divCusErrMsg" runat="server" style="color: red; font-weight: 700;"></div>
                                &nbsp;
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" style="text-align: center; padding-right: 10px;" class="auto-style3">
                                <input name="rdoLogType" value="1" type="radio" />&nbsp;&nbsp;Customer&nbsp;&nbsp;&nbsp;
                                            <input name="rdoLogType" value="2" type="radio" />&nbsp;&nbsp;Vendor
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px; padding-top: 20px;" class="auto-style3">
                                <strong><span class="auto-style2">User Name</span></strong>
                            </td>
                            <td class="auto-style2">
                                <input id="txtCUsername" name="txtCUsername" runat="server" type="text" style="border: 1px solid #1c1c1c; 
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
                                <input id="txtCUserpassword" name="txtCUserpassword" runat="server" type="password" style="border: 1px solid #1c1c1c;
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
                                <input id="chkCusAgree" runat="server" type="checkbox" name="chkAgree" />&nbsp;&nbsp;Remember me next time
                                            <br />
                                <br />
                                <asp:Button ID="btnCusLogin" runat="server" Text="Login" OnClick="btnCusLogin_Click"
                                    CssClass="btnBlue" Style="width: 120px;" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">
                                <asp:HyperLink ID="hlCusForgotPwd" runat="server"
                                    Style="font-size: 15px; color: blueviolet; margin: 0px 0px 0px 0px;" NavigateUrl="~/ForgotPassword.aspx?type=cus">Forgot password</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                        </asp:Panel>
                    </ContentTemplate>
                </ajax:TabPanel>
                    <ajax:TabPanel ID="tpnlVendor" runat="server">
                    <HeaderTemplate>
                        VENDOR
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlVendor" runat="server">
                            <div style=" width: 400px; height: 325px;">
                    <table style="width: 400px; height: 287px;">
                        <%--<tr>
                            <td colspan="2" class="auto-style1" style="background-color: #aed586; font-family: Verdana; font-weight: 500; font-size: large; color: #FFFFCC; vertical-align: middle;">&nbsp;&nbsp;
                                            <asp:Label ID="Label1" runat="server" Text="Login" Font-Names="Verdana"></asp:Label>

                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">
                                <div id="divVenErrMsg" runat="server" style="color: red; font-weight: 700;"></div>
                                &nbsp;
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" style="text-align: center; padding-right: 10px;" class="auto-style3">
                                <input name="rdoLogType" value="1" type="radio" />&nbsp;&nbsp;Customer&nbsp;&nbsp;&nbsp;
                                            <input name="rdoLogType" value="2" type="radio" />&nbsp;&nbsp;Vendor
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px; padding-top: 20px;" class="auto-style3">
                                <strong><span class="auto-style2">User Name</span></strong>
                            </td>
                            <td class="auto-style2">
                                <input id="txtVUsername" name="txtVUsername" runat="server" type="text" style="border: 1px solid #1c1c1c; 
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
                                <input id="txtVUserpassword" name="txtVUserpassword" runat="server" type="password" style="border: 1px solid #1c1c1c;
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
                                <input id="chkVenAgree" runat="server" type="checkbox" name="chkAgree" />&nbsp;&nbsp;Remember me next time
                                            <br />
                                <br />
                                <asp:Button ID="btnVenLogin" runat="server" Text="Login" OnClick="btnVenLogin_Click"
                                    CssClass="btnBlue" Style="width: 120px;" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style2">
                                <asp:HyperLink ID="hlVenForgotPwd" runat="server"
                                    Style="font-size: 15px; color: blueviolet; margin: 0px 0px 0px 0px;" NavigateUrl="~/ForgotPassword.aspx?type=ven">Forgot password</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                        </asp:Panel>
                    </ContentTemplate>
                </ajax:TabPanel>
                </ajax:TabContainer>

            </td>
        </tr>
    </table>
    
</asp:Content>