<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginVendor.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.LoginVendor" %>

<asp:Content ID="co1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding-left:400px;padding-top:100px;padding-bottom:50px;">
<div style="border: thin solid #800080;width: 400px; height: 250px; border-radius:10px 10px 10px 10px;">
                        <table style="width: 400px; height: 237px;">
                            <tr>
                                <td colspan="2" class="auto-style1" style="border-radius:10px 10px 0px 0px;background-color: #660033;
     font-family: sans-serif; font-weight: 500; font-size: large; color: #FFFFCC;vertical-align:middle;">
                                    &nbsp;&nbsp;
                                    <asp:Label ID="lblCaptionText" runat="server" Text="Vendor Login" Font-Names="Verdana"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="divErrMsg" runat="server" style="color:red;font-weight:700;"></div>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:10px;" class="auto-style3">
                                    <strong><span class="auto-style2">User Name</span></strong>
                                </td>
                                <td class="auto-style2">
                                    <input id="txtUsername" name="txtUsername" runat="server" type="text" class="easyui-validatebox" data-options="required:true" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;padding-right:10px;" class="auto-style3">                    
                                    <strong><span class="auto-style2">Password</span></strong>
                                </td>
                                <td class="auto-style2">
                                    <input id="txtUserpassword" name="txtUserpassword" runat="server" type="password" class="easyui-validatebox" data-options="required:true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style2">
                                    <input id="chkAgree" type="checkbox" runat="server" name="chkAgree" />Remember me next time
                                    <br />
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" style="width:120px;" OnClick="btnLogin_Click" /><br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style2">
                                    <asp:HyperLink ID="hlRegAccount" runat="server" style="font-size: 18px; margin:0px 0px 0px 0px;" NavigateUrl="~/RegisterVendor.aspx" >Register</asp:HyperLink>
                                    <br />
                                    <asp:HyperLink ID="hlForgotPwd" runat="server" style="font-size: 18px; margin:0px 0px 0px 0px;" NavigateUrl="~/ForgotPassword.aspx?type=ven">Forgot password</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                        </div>

        </div>
</asp:Content>
