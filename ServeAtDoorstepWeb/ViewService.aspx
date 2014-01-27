<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewService.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.ViewService" %>


<asp:Content ID="C1" ContentPlaceHolderID="MainContent" runat="server">
        <div id="MainSection">
            <div id="divCategory" class="MainCategory" runat="server">
                    <br/>
                    <strong>
                        <label id="currentLocation" runat="server">/ Current Location:</label></strong>
                    <small style="color: #C03;">&nbsp;&nbsp;&nbsp;[Change]</small>
                    <br/>
                    <hr/>
            </div>
                    
            <div id="MainItem">
                        <p>&nbsp;</p>
                <div style="border: thin solid #808080;width: 800px; border-radius:10px 10px 0px 0px;">
                    <table style="width: 800px;">
                        <tr >
                            <td colspan="2" class="auto-style1" style="border-radius:10px 10px 0px 0px;background-color: #5b6aa5;height:40px;text-align:center;
                            font-family: sans-serif; font-weight: 500; font-size: large; color: #FFFFCC;vertical-align:middle;">
                                Service Details

                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Service Name
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblServiceName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Service Type
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblServiceType" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Category Name
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblCategoryName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Brand Name
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblBrandName" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Brand Type
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblBrandType" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Price Range
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblPriceRange" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                             <td style="background-color:#808080;color:white;font-weight:bolder;
                            font-size:14px;width:150px;height:30px;text-align:center;vertical-align:middle;">
                                Description
                            </td>
                            <td style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                            <td colspan="2" style="font-weight:bolder;font-size:14px;height:30px;text-align:left;vertical-align:middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td colspan="2" class="auto-style1" style="background-color: #808080;height:40px;text-align:center;
                            font-family: sans-serif; font-weight: 500; font-size: large; color: #FFFFCC;vertical-align:middle;">
                                List of Vendors  Available

                            </td>
                        </tr>
                        <tr style="border: thin solid #808080;">   
                            <td colspan="2" style="font-weight:bolder;font-size:14px;height:30px;vertical-align:middle;">
                                <div style="padding:25px 50px;">
                                <asp:GridView runat="server" ID="gvVendor" DataKeyNames="VendorID" AutoGenerateColumns="false" Visible="false"
                                    Width="650px">
                                    <RowStyle BackColor="#EFF3FB" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No" ItemStyle-Height="30px" ItemStyle-Width="40px"  >
                                           <ItemTemplate>    
                                               <%# ((GridViewRow)Container).RowIndex + 1%>
                                           </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="VendorAddress" HeaderText="Vendor Address" ItemStyle-Width="160px" />
                                        <asp:BoundField DataField="VendorEmail" HeaderText="E mail" ItemStyle-Width="100px"/>
                                        <asp:BoundField DataField="VendorMobile" HeaderText="Mobile" ItemStyle-Width="100px"/>
                                    </Columns>
                                </asp:GridView>

                                    <div id="divVendor" runat="server"></div>
                                </div>
                            </td>
                        </tr>
                    </table>

                </div>

            </div>
        </div>

</asp:Content>