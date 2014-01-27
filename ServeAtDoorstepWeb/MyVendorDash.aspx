<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyVendorDash.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.MyVendorDash" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

    <div style="height: 500px" >
        <div style="background-color: gray; height: 35px; font-family: Arial; font-size: 18px; color: white;text-align:left;vertical-align:central;
                    padding-left:25px;padding-top:10px; font-style:normal;font-weight:bold;">
            My Dashboard
        </div>
        <table style="width:100%;">
            <tr>
                <td style="height: 25px; width: 209px"></td>
                <td style="height: 25px"></td>
                <td style="height: 25px"></td>
                <td style="height: 25px"></td>
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
                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="lnkLiveQuiry" runat="server" Text="Live Inquiry" Height="20px" OnClick="lnkLiveQuiry_Click"></asp:LinkButton>
                                                <asp:Label ID="lnkLiveQuiryCnt" runat="server" Text="(0)" Height="20px" ForeColor="#3366ff"></asp:Label><br />
                                                <asp:LinkButton ID="lnkQuiryRespond" runat="server" Text="Inquiry responded" Height="20px" OnClick="lnkQuiryRespond_Click"></asp:LinkButton>
                                                <asp:Label ID="lnkQuiryRespondCnt" runat="server" Text="(0)" Height="20px" ForeColor="#3366ff"></asp:Label><br />
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Inquiry not responded" Height="20px"></asp:LinkButton>
                                                <asp:Label ID="Label2" runat="server" Text="(0)" Height="20px" ForeColor="#3366ff"></asp:Label><br />
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Communication with Customer" Height="20px"></asp:LinkButton>
                                                <asp:Label ID="Label3" runat="server" Text="(0)" Height="20px" ForeColor="#3366ff"></asp:Label><br />
                                                <asp:LinkButton ID="LinkButton4" runat="server" Text="" Height="20px"></asp:LinkButton><br />
                                                <asp:LinkButton ID="lnkLiveInquiry" runat="server" Text="" Height="20px"></asp:LinkButton><br />
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
                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="padding:8px 8px 8px 8px;">
                                            <div style="border:thin solid black; border-radius:7px 7px 7px 7px; padding:10px 10px 10px 10px;">
                                                <asp:LinkButton ID="LinkButton30" runat="server" Text="Feedback Received" Height="20px"></asp:LinkButton><br />
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