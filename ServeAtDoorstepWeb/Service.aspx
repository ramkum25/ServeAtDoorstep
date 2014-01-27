<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.Service" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="c1" runat="server" ContentPlaceHolderID="MainContent">
    <style>
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
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

    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
    </ajax:ToolkitScriptManager>

    <div style="padding-top: 75px; padding-left: 200px">
        <table>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <span style="font-size: 18px; font-weight: bolder;">Service Details </span>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="padding-left: 10px; text-align: left;">
                    <asp:LinkButton ID="lnkAddService" runat="server" CssClass="btnRed" Style="width: 100px;" OnClick="lnkAddService_Click">Add Service</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>

                    <asp:GridView ID="gvService" runat="server" Width="700px" OnPageIndexChanging="gvService_PageIndexChanging"
                        OnRowDataBound="gvService_RowDataBound" AutoGenerateColumns="false"
                        RowStyle-Height="25px" RowStyle-ForeColor="#003300" AllowPaging="true" RowStyle-Wrap="true" HeaderStyle-Wrap="true"
                        OnRowDeleting="gvService_RowDeleting" OnRowEditing="gvService_RowEditing" PageSize="50"
                        DataKeyNames="ServiceID">
                        <Columns>
                            <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CategoryName" ItemStyle-Height="30px" HeaderText="Categoy Name" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="ServiceName" ItemStyle-Height="30px" HeaderText="Service Name" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="ServiceType" ItemStyle-Height="30px" HeaderText="Service Type" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="PriceRangeFrom" ItemStyle-Height="30px" HeaderText="Price Range From" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="PriceRangeTo" ItemStyle-Height="30px" HeaderText="Price Range To" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="NoOfPair" ItemStyle-Height="30px" HeaderText="No of Pair" HeaderStyle-BackColor="#ff8000" ItemStyle-Width="100px" />
                            <asp:TemplateField>
                                <HeaderTemplate>Action </HeaderTemplate>
                                <HeaderStyle BackColor="#ff8000" Width="75px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" OnClick="lnkEditImg_Click" ImageUrl="~/Image/Edit.jpg" ToolTip="Edit" Height="20px" Width="20px" />
                                    <asp:ImageButton ID="imgbtnDelete" Text="Edit" OnClick="lnkDelImg_Click" runat="server" ImageUrl="~/Image/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="ModalPopupViewMessage" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Width="500px" Style="display: none">
        <div>
            <div style="text-align: right; padding-left: 20px;">
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/image/close.png" Height="20px" Width="20px" OnClick="imgClose_Click" />
            </div>
            <table>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div id="divErrorMsg" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px;"></div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 70px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label1" runat="server" Text="Service Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServiceName" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="txtServiceDesc" runat="server" CssClass="ServeTextbox" MaxLength="300" Style="width: 200px; height: 100px;"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 35px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label3" runat="server" Text="Keyword"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServiceKey" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 18px; width: 150px;">
                        <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td style="padding-top: 10px;">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ServeDropdownlist" style="height:28px;"></asp:DropDownList>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label5" runat="server" Text="Service Type"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServiceType" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label6" runat="server" Text="Price Range From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceRanFrom" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label7" runat="server" Text="Price Range To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriceRanTo" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label8" runat="server" Text="No of Pair"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoPair" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label9" runat="server" Text="Brand Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrandName" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="padding-top: 15px; width: 150px;">
                        <asp:Label ID="Label10" runat="server" Text="Brand Type"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBrandType" runat="server" CssClass="ServeTextbox" Style="width: 200px"></asp:TextBox>
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 25px;"></td>
                    <td style="float: right; width: 150px;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnGreen" Width="100px" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnGreen" Width="100px" OnClick="btnCancel_Click" />
                    </td>
                    <td style="width: 25px;"></td>
                </tr>
            </table>
            <asp:HiddenField ID="hdnServiceId" runat="server" Value="0" />
        </div>
    </asp:Panel>


</asp:Content>
