<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.WebForm1" %>

<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="greybox/gb_styles.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    var GB_ROOT_DIR = '<%# this.ResolveClientUrl("~/greybox/")%>';
    </script>
    <%--Include grybox javascript files--%>
    <script type="text/javascript" src='<%# this.ResolveClientUrl("~/greybox/AJS.js") %>'></script>

    <script type="text/javascript" src='<%# this.ResolveClientUrl("~/greybox/AJS_fx.js") %>'></script>

    <script type="text/javascript" src='<%# this.ResolveClientUrl("~/greybox/gb_scripts.js") %>'></script>
    
    <div style="width: 80%; padding-left: 100px;">

        <div style="width: 100%; text-align: left; padding-left: 0px;">

                            <div id="div2" style="text-align: center; padding-left: 50px; height: 300px;">
                                <div>&nbsp;</div>
                                <asp:GridView ID="gvQuiry" runat="server" DataKeyNames="InquiryID" BorderColor="Tan" BorderWidth="1px" OnRowDataBound="gvQuiry_RowDataBound"
                                    GridLines="Both" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvQuiry_PageIndexChanging"
                                    PageSize="50" Width="750px" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-HorizontalAlign="Center"
                                    RowStyle-Height="30px" RowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Center" HeaderStyle-Wrap="true" AlternatingRowStyle-Height="30px">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="InquiryTitle" HeaderText="Quiry Title" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" ItemStyle-Width="200px" ItemStyle-Height="30px" />
                                        <asp:BoundField DataField="CreatedOn" HeaderText="Posted Date" ItemStyle-Width="150px" ItemStyle-Height="30px" />
                                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Right">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="lnkQuiryView" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnbtnQuiryView" runat="server" Text="Click to View" ForeColor="ControlDark" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings FirstPageText="First" LastPageText="Last"
                                        Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />

                                </asp:GridView>
                            </div>
        </div>
    </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <asp:LinkButton ID="btnCenterWindow" runat="server" Text="Launch center popup window"
                        OnClientClick="return OpenCenterWindow('zz1','view');"></asp:LinkButton>

    <script type="text/javascript">

        function OpenCenterWindow(QuiryId, strAction) {

            alert('hi');
            var caption = "INQUIRY DETAILS";
            var sID = QuiryId;
            var sACT = strAction;
            var url = "../ShowInquiry.aspx?sQID=" + sID + "&sAct=" + sACT;
            return GB_showCenter(caption, url, 450, 700)

        }

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
