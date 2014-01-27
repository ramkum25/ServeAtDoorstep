<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.MyMessage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <style type="text/css">
.fancy-green .ajax__tab_header
{
	background: url(image/green_bg_Tab.gif) repeat-x;
	cursor:pointer;
}
.fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
{
	background: url(image/green_left_Tab.gif) no-repeat left top;
}
.fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
{
	background: url(image/green_right_Tab.gif) no-repeat right top;
}
.fancy .ajax__tab_header
{
	font-size: 13px;
	font-weight: bold;
	color: #000;
	font-family: sans-serif;
}
.fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
{
	height: 46px;
}
.fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
{
	height: 46px;
	margin-left: 16px; /* offset the width of the left image */
}
.fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
{
	margin: 16px 16px 0px 0px;
}
.fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
{
	color: #fff;
}
.fancy .ajax__tab_body
{
	font-family: Arial;
	font-size: 10pt;
	border-top: 0;
	border:1px solid #999999;
	padding: 8px;
	background-color: #ffffff;
}
.modalBackground
{
background-color: Gray;
filter: alpha(opacity=80);
opacity: 0.8;
z-index: 10000;
}
</style>
    <p>&nbsp;</p>
    
<ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
</ajax:ToolkitScriptManager>

    <div style=" width:80%;text-align:center;padding-left:100px;" >
<ajax:TabContainer ID="tabMessage" runat="server" CssClass="fancy fancy-green">
<ajax:TabPanel ID="tpnlNewMessage" runat="server" >
<HeaderTemplate>
NEW MESSAGE
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="pnlNewMsg" runat="server">
    <div id="div1" style="text-align:center;padding-left:50px;height:300px;">
        <div>&nbsp;</div>
    <asp:GridView ID="gvVendorMessage" runat="server" DataKeyNames="VendorMessageId" BorderColor="Tan" BorderWidth="1px" OnRowDataBound="gvVendorMessage_RowDataBound"
        OnRowCommand="gvVendorMessage_RowCommand" OnRowCreated="gvVendorMessage_RowCreated"
                GridLines="Both"  AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvVendorMessage_PageIndexChanging"
                PageSize="50" Width="750px" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center"
                RowStyle-Height="30px" RowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true" AlternatingRowStyle-Height="30px"
                 >
                <RowStyle BackColor="#EFF3FB" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" ItemStyle-Width="50px"  >
                        <ItemTemplate>    
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="imgCus" runat="server" Height="40px" Width="40px" />
                        </ItemTemplate>
                    </asp:TemplateField>       
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ItemStyle-Width="150px" ItemStyle-Height="30px"/>
                    <asp:BoundField DataField="MessageTitle" HeaderText="Message Title" ItemStyle-Width="200px" ItemStyle-Height="30px"/>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" ItemStyle-Width="150px" ItemStyle-Height="30px"/>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Right" >
                       <HeaderTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" />
                        </HeaderTemplate>
                         <ItemTemplate>
                            <asp:LinkButton ID="lnbtnView" runat="server" Text="Click to View" OnClick="lnbtnView_Click" ForeColor="ControlDark"
                            />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        <PagerSettings FirstPageText="First" LastPageText="Last" 
            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
        
            </asp:GridView>
        </div>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
<ajax:TabPanel ID="tpnlSendMessage" runat="server" >
<HeaderTemplate>
SEND MESSAGE
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="pnlSendMsg" runat="server">


</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
<ajax:TabPanel ID="tpnlAccMessage" runat="server" >
<HeaderTemplate>
ACCEPT MESSAGE
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="pnlAccMsg" runat="server">


</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
</ajax:TabContainer>
</div>
    
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="ModalPopupViewMessage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                            CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="400px" Width="600px" style="display:none">
        <table style="border:Solid 3px #D55500; width:100%;height:100%;">
            <tr style="background-color:#D55500">
                <td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Message Details</td>
            </tr>
            <tr>
                <td style="width:100px;">Message Title</td>
                <td style="width:200px;"><asp:Label ID="lblMsgTitle" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Message From</td>
                <td><asp:Label ID="lblCustomerName" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Cateegory</td>
                <td><asp:Label ID="lblCategory" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Sent on</td>
                <td><asp:Label ID="lblMsgDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td> Description</td>
                <td><asp:Label ID="lblMsgDesc" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server">Reply </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtReply" TextMode="MultiLine" MaxLength="1000" Height="60px" Width="400px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnReply" runat="server" Text="Send Reply" OnClick="btnReply_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
            
        </table>
        <asp:HiddenField ID="hdnCategoryId" runat="server" />
        <asp:HiddenField ID="hdnCustomerId" runat="server" />
        <asp:HiddenField ID="hdnVendorId" runat="server" />
        <asp:HiddenField ID="hdnQuoteId" runat="server" />
</asp:Panel>

</asp:Content>