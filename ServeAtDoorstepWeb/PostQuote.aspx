<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostQuote.aspx.cs" MasterPageFile="~/ServeHome.Master" Inherits="ServeAtDoorstepWeb.PostQuote" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <p>&nbsp;</p>
    <div style="font-family: Terminal; color: #5F5F5F">
        <div id="divMessage"></div>
        <div style="font-size:40px;padding-left:150px;"><strong>Post Quotes</strong></div>
        <div id="divErrorMessage"></div>
        <table style="padding-left:200px;">
            <tr>
                <td colspan="2" >
                &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Quote Title 
                </td>
                <td>
                    <input type="text" id="txtQuoteTitle" name="txtQuoteTitle" runat="server" maxlength="50" style="border-top-left-radius:5px;border-top-right-radius:5px;height:25px;width:250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Quote Description 
                </td>
                <td>
                    <textarea id="txtQuoteDesc" name="txtQuoteDesc" runat="server" maxlength="1000" style="border-top-left-radius:5px;border-top-right-radius:5px;height:50px;width:250px;"></textarea>
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Quote Keyword 
                </td>
                <td>
                    <textarea id="txtQuoteKey" name="txtQuoteKey" runat="server" maxlength="1000" style="border-top-left-radius:5px;border-top-right-radius:5px;height:50px;width:250px;"></textarea>
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;">
                    Category 
                </td>
                <td>
                    <select id="ddlCategory" name="ddlCategory" runat="server" style="border-top-left-radius:5px;border-top-right-radius:5px; border-top-style:solid;height:25px; width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width:250px;height:40px;font-size:20px;" colspan="2">
                     <asp:Button ID="btnPost" runat="server" Text="Post Quote" OnClick="btnPost_Click"
                            style="width: 120px;border-radius:10px 10px;height:30px;background-color:#3cc7e0;font-family:Tahoma;font-size:16px;font-weight:700;" />
                   
                </td>
            </tr>
            
        </table>

    </div>

</asp:Content>
