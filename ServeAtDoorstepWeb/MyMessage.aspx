<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessage.aspx.cs" MasterPageFile="~/ServeHome.Master" Inherits="ServeAtDoorstepWeb.MyMessage" %>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl"
    TagPrefix="ASPP" %>
    <p>&nbsp;</p>

    <div style="padding-left:150px;"><h2>My Messages</h2></div>
    <p>&nbsp;</p>
    <div id="div1" style="text-align:center;padding-left:250px;">
    <asp:GridView ID="gvVendorMessage" runat="server" DataKeyNames="VendorMessageId" BorderColor="Tan" BorderWidth="1px" OnRowDataBound="gvVendorMessage_RowDataBound"
        OnRowCommand="gvVendorMessage_RowCommand" OnRowCreated="gvVendorMessage_RowCreated"
                GridLines="Both"  AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvVendorMessage_PageIndexChanging"
                PageSize="50" Width="750px" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center"
                RowStyle-Height="30px" RowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true" AlternatingRowStyle-Height="30px"
                 >
                <Columns>
                    <asp:BoundField DataField="MessageTitle" HeaderText="Message Title" ItemStyle-Width="200px" ItemStyle-Height="30px"/>
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" ItemStyle-Width="150px" ItemStyle-Height="30px"/>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" ItemStyle-Width="150px" ItemStyle-Height="30px"/>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Right" >
                       <HeaderTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" />
                        </HeaderTemplate>
                         <ItemTemplate>
                            <asp:LinkButton ID="lnbtnView" runat="server" Text="Click to View" CommandName="VIEW" CommandArgument="1"
                            />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        <PagerSettings FirstPageText="First" LastPageText="Last" 
            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
        
            </asp:GridView>
        </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <div id="div2" style="text-align:left;">

    <ASPP:PopupPanel HeaderText="Message Details" ID="pupMessage" runat="server" Width="500px"  BorderWidth="5px" BorderColor="WhiteSmoke"
            OnCloseWindowClick="MycloseWindow" >
            <PopupWindow runat="server">
                <ASPP:PopupWindow ID="PopupWindow2" runat="server" Width="500px" >
                    <br />
                    <div id="divMsg" style="width:500px; padding-left:75px;">
                    <table>
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
                    </table>
                        </div>
                    <br />
                </ASPP:PopupWindow>
                <ASPP:PopupWindow ID="pupReply" runat="server">
                    <div id="divReply" style="width:600px; padding-left:40px;">
                        <asp:Label ID="Label1" runat="server">Reply </asp:Label>
                        <br />
                        <asp:TextBox ID="txtReply" TextMode="MultiLine" MaxLength="1000" Height="60px" Width="400px" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnReply" runat="server" Text="Send Reply" OnClick="btnReply_Click" />
                    </div>
                 </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    </div>
</asp:Content>