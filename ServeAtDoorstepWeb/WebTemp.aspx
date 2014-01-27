<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebTemp.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.WebTemp" %>

<asp:Content ID="c2" ContentPlaceHolderID="MainContent" runat="server">

    <table width="80%" align="center">
        <tr>
            <td>
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Tab 1" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server"
                    OnClick="Tab1_Click" />
                <asp:Button Text="Tab 2" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server"
                    OnClick="Tab2_Click" />
                <asp:Button Text="Tab 3" BorderStyle="None" ID="Tab3" CssClass="Initial" runat="server"
                    OnClick="Tab3_Click" />
                <asp:MultiView ID="MainView" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    <h3>
                                        <span>View 1 </span>
                                    </h3>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    <h3>
                                        View 2
                                    </h3>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                    <h3>
                                        View 3
                                    </h3>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>