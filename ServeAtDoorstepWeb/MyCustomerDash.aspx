<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Serve.Master" CodeBehind="MyCustomerDash.aspx.cs" Inherits="ServeAtDoorstepWeb.MyCustomerDash" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    
    <div style="height: 500px" >
        
        <table style="width:100%;">
            <tr>
                <td style="height: 25px; width: 209px"></td>
                <td style="height: 25px"></td>
                <td style="height: 25px"></td>
                <td style="height: 25px"></td>
            </tr>
            <tr>
                <td style="width: 200px; height: 50px"></td>
                <td style="height: 50px"></td>
                <td style="height: 50px"></td>
                <td style="height: 50px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table style="width:100%;">
                        <tr>
                            <td style="height: 200px; width: 50px;"></td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Inquiry</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="hlNewInquiry" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">New Inquiry</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Live Inquiry" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton2" runat="server" Text="Inquiry responded" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Inquiry not responded" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Communication with vendor" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton4" runat="server" Text="Cancelled / Expired Inquiry" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="lnkLiveInquiry" runat="server" Text="Old Inquiry list" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Orders</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">New Order</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton6" runat="server" Text="Order placed" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton7" runat="server" Text="Order cancelled" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton8" runat="server" Text="Order pending for acceptance" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton9" runat="server" Text="Order in process" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton10" runat="server" Text="Orders completed" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton11" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Payment</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">New Payment</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton12" runat="server" Text="Advance Payment" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton13" runat="server" Text="Pending Payment" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton14" runat="server" Text="Full Payment" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton15" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton16" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton17" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 50px;  width: 50px;"></td>
                        </tr>
                        <tr>
                            <td style="height: 200px; width: 50px;"></td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Pickup</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">Initiate Pickup</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton18" runat="server" Text="Goods await pickup" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton19" runat="server" Text="Goods picked up" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton20" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton21" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton22" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton23" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Delivery</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">Confirm to receive</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton24" runat="server" Text="Goods Await Delivery" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton25" runat="server" Text="Goods Delivered" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton26" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton27" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton28" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton29" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 200px; width: 200px;">
                                <table style="width:100%;">
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;"><span style="font-weight:bolder;">Feedback</span></td>
                                    </tr>
                                    <tr style="width:100%;height:25px;">
                                        <td style="padding-left:15px;">
                                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Success.aspx" ForeColor="Green" Font-Bold="true">New Feedback</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton30" runat="server" Text="Feedback Posted" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton31" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton32" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton33" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton34" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="LinkButton35" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="height: 50px;  width: 50px;"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
    </div>

</asp:Content>