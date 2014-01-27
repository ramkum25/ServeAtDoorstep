<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.Category" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="MainContent">

    <style type="text/css">
        .web_dialog_overlay {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            background: #000000;
            opacity: .15;
            filter: alpha(opacity=15);
            -moz-opacity: .15;
            z-index: 101;
            display: none;
        }

        .web_dialog {
            display: none;
            position: fixed;
            width: 380px;
            height: 250px;
            top: 50%;
            left: 50%;
            margin-left: -190px;
            margin-top: -100px;
            background-color: #ffffff;
            border: 2px solid #336699;
            padding: 0px;
            z-index: 102;
            font-family: Verdana;
            font-size: 10pt;
        }

        .web_dialog_title {
            border-bottom: solid 2px #336699;
            background-color: black;
            padding: 4px;
            color: White;
            font-weight: bold;
        }

            .web_dialog_title a {
                color: White;
                text-decoration: none;
            }

        .align_right {
            text-align: right;
        }

        .auto-style7 {
            height: 31px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#btnAdd").click(function (e) {
                ShowDialog(false);
                e.preventDefault();
            });

            $("#btnShowModal").click(function (e) {
                ShowDialog(true);
                e.preventDefault();
            });

            $("#btnClose").click(function (e) {
                $('input[id$=txtcategory]').val('');
                $('input[id$=txtcategoryDesc]').val('');
                HideDialog();
                e.preventDefault();
            });

            $("#btnSubmit").click(function (e) {
                HideDialog();
                e.preventDefault();
            });
        });

        function ShowDialog(modal) {
            $("#overlay").show();
            $("#dialog").fadeIn(300);

            if (modal) {
                $("#overlay").unbind("click");
            }
            else {
                $("#overlay").click(function (e) {
                    HideDialog();
                });
            }
        }

        function HideDialog() {
            $("#overlay").hide();
            $("#dialog").fadeOut(300);
        }

    </script>

    <div style="padding-top: 50px;padding-left: 150px;">
        <table style="height: 200px;">
            <tr>
                <td style="font-family: 'Century Gothic';font-size: 16px; font-weight:bold; height: 25px; width: 800px; text-align: left;">Category</td>
            </tr>
            <tr>
                <td style="text-align: left; padding-left: 30px;" class="auto-style7">
                    <input type="button" id="btnAdd" value="Add Catgory" class="btnRed" style=" width: 180px;" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px;">
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="CategoryID" Font-Names="Arial"
                        Width="700px" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" OnCancelCommand="DataList1_CancelCommand"
                        OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand"
                        OnUpdateCommand="DataList1_UpdateCommand">
                        <HeaderTemplate>

                            <table width="100%">

                                <tr align="center" style="background-color:#336699;color:white;height:30px">

                                    <td width="10%">S No</td>
                                    <td width="35%">Category  Name  

                                    </td>
                                    
                                    <td width="35%">Category  Description  

                                    </td>

                                    <td width="0%">&nbsp;</td>
                                    <td width="20%">Action</td>

                                </tr>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr align="left">
                                <td style="width:10%;height:28px;">
                                                <%# ((DataListItem)Container).ItemIndex + 1%>
                                </td>
                                <td style="width:35%;">
                                    <%# DataBinder.Eval(Container.DataItem, "CategoryName") %>
                                </td>
                                <td style="width:35%;">
                                    <%# DataBinder.Eval(Container.DataItem, "CategoryDescription") %>
                                </td>
                                <td style="visibility: hidden; width:0%;">
                                    <%# DataBinder.Eval(Container.DataItem, "CategoryID") %>
                                </td>
                                <td  style="width:20%;">
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit"> Edit </asp:LinkButton>
                                    &nbsp;|&nbsp;
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete"> Delete </asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtId" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>'>
                                    </asp:TextBox>
                                </td>
                                <td style="width:25%;">
                                    <asp:TextBox ID="txtCName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryName") %>'
                                        Height="24" Width="200" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" >
                                    </asp:TextBox>
                                </td>
                                <td style="width:30%;">
                                    <asp:TextBox ID="txtCDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CategoryDescription") %>'
                                        Height="24" Width="250" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" MaxLength="300">
                                    </asp:TextBox>
                                </td>

                                <td style="width:20%;">
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update">Update </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" runat="server" CommandName="cancel">Cancel </asp:LinkButton>
                                </td>
                            </tr>
                        </EditItemTemplate> 
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                        <FooterStyle BackColor="Tan" />
                        <SelectedItemStyle ForeColor="GhostWhite" />
                        <AlternatingItemStyle />
                        <HeaderStyle Font-Bold="True" />
                    </asp:DataList>
                    <table width="700px" id="tblPaging" runat="server">

                        <tr>

                            <td height="10px"></td>

                        </tr>

                        <tr id="PagingRow" runat="server">

                            <td colspan="3" style="background-color: #3D3D3D; padding-left: 15px;">

                                <table width="99%" class="pagingBackground" cellpadding="2" cellspacing="2">

                                    <tr>

                                        <td width="20%"></td>

                                        <td align="center" width="50"></td>

                                        <td align="center"></td>

                                        <td align="center" width="20%"></td>

                                    </tr>

                                    <tr>

                                        <td width="20%" align="left" style="color: #FFFFFF">&nbsp;  

                                            <asp:Label ID="LabelPageFirstRecord" runat="server"></asp:Label>

                                            <asp:Label ID="label2" runat="server" Text="-"></asp:Label>

                                            <asp:Label ID="LabelPageLastRecord" runat="server"></asp:Label>

                                            <asp:Label ID="label3" runat="server" Text="of"></asp:Label>

                                            <asp:Label ID="LabelTotalRecords" runat="server"></asp:Label>

                                        </td>

                                        <td width="50" align="center"></td>

                                        <td align="center" id="tdPageNumbers" runat="server" style="color: #FFFFFF">

                                            <asp:LinkButton ID="LinkButtonFirst" runat="server" ForeColor="White" OnClick="LinkButtonFirst_Click" CssClass="PagerLinkStyle">  

First  

                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButtonPrevious" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButtonPrevious_Click">  

Prev
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButton1_Click">1</asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButton1_Click">2</asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButton1_Click">3</asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton4" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButton1_Click">4</asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton5" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButton1_Click">5</asp:LinkButton>

                                            <asp:LinkButton ID="LinkButtonNext" runat="server" ForeColor="White" CssClass="PagerLinkStyle" OnClick="LinkButtonNext_Click">  

    Next

                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButtonLast" runat="server" ForeColor="White" OnClick="LinkButtonLast_Click" CssClass="PagerLinkStyle">  

    Last

                                            </asp:LinkButton>

                                        </td>

                                        <td width="20%" align="right"></td>

                                    </tr>

                                    <tr>

                                        <td width="20%"></td>

                                        <td align="center" width="50"></td>

                                        <td align="center"></td>

                                        <td align="center" width="20%"></td>

                                    </tr>

                                </table>

                            </td>

                        </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="output"></div>

    <div id="overlay" class="web_dialog_overlay"></div>

    <div id="dialog" class="web_dialog">
        <table style="width: 100%; border: 0px;" cellpadding="3" cellspacing="0">
            <tr>
                <td class="web_dialog_title">Category </td>
                <td class="web_dialog_title align_right">
                    <a href="#" id="btnClose">Close</a>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 25px;">
                    <label>Category Name</label>
                    <asp:TextBox ID="txtcategory" runat="server" Height="24" Width="300" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 25px;">
                    <label>Category Description</label>
                    <asp:TextBox ID="txtcategoryDesc" TextMode="MultiLine" runat="server" Height="24" Width="300" 
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" MaxLength="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Width="100" runat="server" Text="Add" OnClick="btnSave_Click" BorderStyle="Groove" 
                        CssClass="SubmitButton" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
