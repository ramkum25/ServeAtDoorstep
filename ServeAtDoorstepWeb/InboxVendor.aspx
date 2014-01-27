<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InboxVendor.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.InboxVendor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .fancy-green .ajax__tab_header {
            background: url(image/green_bg_Tab.gif) repeat-x;
            cursor: pointer;
            color: black;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(image/green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(image/green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 15px;
            font-weight: bold;
            color: black;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: black;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 13pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }

        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <p>&nbsp;</p>

    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
    </ajax:ToolkitScriptManager>
    <div style="width: 80%; padding-left: 100px;">

        <div style="width: 100%; text-align: left; padding-left: 0px;">
            <ajax:TabContainer ID="tabMessage" runat="server" CssClass="fancy fancy-green" ForeColor="Black">

                <ajax:TabPanel ID="tpnlInquiry" runat="server">
                    <HeaderTemplate>
                        INQUIRY
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlInquiry" runat="server">
                            <div id="div2" style="text-align: center; padding-left: 50px; height: 300px;">
                                <div>&nbsp;</div>
                                <asp:GridView ID="gvQuiry" runat="server" DataKeyNames="InquiryID" BorderColor="Tan" BorderWidth="1px"
                                    OnRowDataBound="gvQuiry_RowDataBound" AutoGenerateColumns="False" AllowPaging="True" 
                                    OnPageIndexChanging="gvQuiry_PageIndexChanging"
                                    PageSize="50" Width="750px">
                                    <AlternatingRowStyle BackColor="White" Height="30px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>

                                            <ItemStyle Height="25px" Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="imgCus" runat="server" Height="40px" Width="40px" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                            <ItemStyle Height="25px" Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InquiryTitle" HeaderText="Quiry Title">
                                            <ItemStyle Height="25px" Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name">
                                            <ItemStyle Height="25px" Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CreatedOn" HeaderText="Posted Date">
                                            <ItemStyle Height="25px" Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkQuiryView" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnQuiryReply" runat="server" ImageUrl="~/image/replyblue.jpg" Height="25px" Width="25px" OnClick="btnQuiryReply_Click" />
                                                <asp:ImageButton ID="btnQuiryView" runat="server" ImageUrl="~/image/viewblue.png" Height="25px" Width="25px" OnClick="btnQuiryView_Click" />
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="30px" HorizontalAlign="Center" VerticalAlign="Top" Wrap="True" />

                                    <PagerSettings FirstPageText="First" LastPageText="Last"
                                        Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />

                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

                                    <RowStyle BackColor="#EFF3FB" Font-Names="Verdana" Font-Size="13px" ForeColor="Black" VerticalAlign="Middle" HorizontalAlign="Center" Height="30px" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </ajax:TabPanel>
                <ajax:TabPanel ID="tpnlResMessage" runat="server">
                    <HeaderTemplate>
                        RESPOND MESSAGE
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlResMsg" runat="server">
                            <div id="div3" style="text-align: center; padding-left: 50px; height: 300px;">
                                <div>&nbsp;</div>
                                <asp:GridView ID="gvRespondMsg" runat="server" DataKeyNames="VendorMessageId" BorderColor="Tan" BorderWidth="1px" 
                                    OnRowDataBound="gvRespondMsg_RowDataBound"
                                    GridLines="Both" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvRespondMsg_PageIndexChanging"
                                    PageSize="50" Width="750px" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center"
                                    RowStyle-Height="30px" RowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true" 
                                    AlternatingRowStyle-Height="30px">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" Font-Names="Verdana" Font-Size="13px" ForeColor="Black" VerticalAlign="Middle" HorizontalAlign="Center" Height="30px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="imgCus" runat="server" Height="40px" Width="40px" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name">
                                            <ItemStyle Height="25px" Width="100px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MessageTitle" HeaderText="Message Title" ItemStyle-Width="200px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="CreatedOn" HeaderText="Posted On" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkResMsgView" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnbtnResMsgView" runat="server" Text="View" ForeColor="ControlDark" OnClick="lnbtnResMsgView_Click" />
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
                <ajax:TabPanel ID="tpnlSendMessage" runat="server">
                    <HeaderTemplate>
                        SEND MESSAGE
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlSendMsg" runat="server">
                            <div id="div1" style="text-align: center; padding-left: 50px; height: 300px;">
                                <div>&nbsp;</div>
                                <asp:GridView ID="gvCustomerMessage" runat="server" DataKeyNames="CustomerMessageId" BorderColor="Tan" BorderWidth="1px" OnRowDataBound="gvCustomerMessage_RowDataBound"
                                    GridLines="Both" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvCustomerMessage_PageIndexChanging"
                                    PageSize="50" Width="750px" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center"
                                    RowStyle-Height="30px" RowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true" AlternatingRowStyle-Height="30px">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" Font-Names="Verdana" Font-Size="13px" ForeColor="Black" VerticalAlign="Middle" HorizontalAlign="Center" Height="30px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="MessageTitle" HeaderText="Message Title" ItemStyle-Width="200px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkNewMsgView" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnbtnNewMsgView" runat="server" Text="Click to View" ForeColor="ControlDark" OnClick="lnbtnNewMsgView_Click" />
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
            </ajax:TabContainer>
        </div>
    </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="ModalPopupViewMessage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="400px" Width="600px" Style="display: none">
        <div style="border: Solid 3px #c1af4c; width: 100%; height: 100%; border-radius: 5px;">
            <table style="border: Solid 3px #c1af4c; width: 100%; height: 100%; border-radius: 5px;">
                <tr style="background-color: #c1af4c">
                    <td style="height: 10%; color: White; font-weight: bold; font-size: larger; text-align: 'center'">Message Details
                    </td>
                    <td style="height: 10%; color: White; font-weight: bold; font-size: larger" align="RIGHT">
                        <asp:ImageButton ID="imgCloseMsg" runat="server" ImageUrl="~/image/close.png" Height="25px" Width="25px" OnClick="imgCloseMsg_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px;">Message Title</td>
                    <td style="width: 200px;">
                        <asp:Label ID="lblMsgTitle" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Message From</td>
                    <td>
                        <asp:Label ID="lblVendorName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Cateegory</td>
                    <td>
                        <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Sent on</td>
                    <td>
                        <asp:Label ID="lblMsgDate" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td>
                        <asp:Label ID="lblMsgDesc" runat="server"></asp:Label></td>
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
                        <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" CssClass="SubmitButton" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="SubmitButton" />
                    </td>
                </tr>

            </table>
        </div>

    </asp:Panel>

    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <asp:Button ID="btnShowPopQryReply" runat="server" Style="display: none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="modpopInquiryReply" runat="server" TargetControlID="btnShowPopQryReply" PopupControlID="pnlpopupInquiryReply"
        CancelControlID="btnCancelInquiryReply" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopupInquiryReply" runat="server" BackColor="#ffffcc" Height="450px" Width="650px" Style="display: none">
        <div style="border: thin 1px black; width: 100%; height: 100%; border-radius: 5px;">
            <table style="border: thin 1px black; width: 100%; height: 100%; border-radius: 5px;">
                <tr>
                    <td colspan="2" style="height: 25px; color: black; font-weight: bold; font-size: larger; text-align: 'center'">&nbsp;&nbsp;Inquiry reply details
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/close.png" Height="15px" Width="16px" OnClick="imgCloseMsg_Click" />
                    </td>
                </tr>
                <tr style="border-top-color: black; border-top-style: solid; border-top-width: 2px;">
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--<div style="float: left; display: block; width: 100%;height:150px;padding-left:25px;">
                            <table>
                                <tr>
                                    <td>
                                        <div>
                                            <img src="image/cussatisfy.jpg" width="100" height="100" />
                                        </div>
                                    </td>
                                    <td>
                                        <div style="margin-left: 25px;font-family:Calibri;font-size:12px;height:25px;">MESSAGE TITLE</div>
                                        <div style="margin-left: 25px;font-family:Calibri;font-size:12px;height:25px;">MESSAGE TITLE</div>
                                        <div style="margin-left: 25px;font-family:Calibri;font-size:12px;height:25px;">MESSAGE TITLE</div>
                                        <div style="margin-left: 25px;font-family:Calibri;font-size:12px;height:25px;">MESSAGE TITLE</div>
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
                        <span id="spnInquiryDet" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 0px; width: 100px; text-align: right;">
                        <asp:Label ID="Label7" runat="server">Subject&nbsp;&nbsp; </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInquirySubject" TextMode="SingleLine" MaxLength="1000" Height="20px" Width="400px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 0px; width: 75px; text-align: right;">
                        <asp:Label ID="Label8" runat="server">Reply&nbsp;&nbsp;&nbsp;&nbsp; </asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInquiryReply" TextMode="MultiLine" MaxLength="1000" Height="100px" Width="400px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 120px;">
                        <asp:Button ID="btnInquiryReply" runat="server" Text="Reply" OnClick="btnInquiryReply_Click" CssClass="SubmitButton" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancelInquiryReply" runat="server" Text="Cancel" CssClass="SubmitButton" />
                    </td>
                </tr>

            </table>
        </div>
        <asp:HiddenField ID="hdnCategoryId" runat="server" />
        <asp:HiddenField ID="hdnCustomerId" runat="server" />
        <asp:HiddenField ID="hdnVendorId" runat="server" />
        <asp:HiddenField ID="hdnQuoteId" runat="server" />
    </asp:Panel>

    <script type="text/javascript">

        function ConfirmationBox(serviename) {

            var result = confirm('Are you sure you want to delete ' + serviename + ' Details?');
            if (result) {

                return true;
            }
            else {
                return false;
            }
        }

    </script>
</asp:Content>
