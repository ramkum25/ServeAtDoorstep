<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="ServeAtDoorstepWeb.AddService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/boilerplate.css" rel="stylesheet" type="text/css" />
    <link href="css/newServeStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/ServeAtDoor.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function RefreshParent() {
            window.opener.RefreshParent();

            if (window.opener.progressWindow)
		
            {
                window.opener.progressWindow.close()
            }
            window.close();
        }
        window.onunload = RefreshParent;
    </script>
   <%-- <script>
        window.onunload = refreshParent;
        function refreshParent() {
            var retVal = confirm("Are you sure ?");
            if( retVal == true ){
                window.opener.location.reload();
            else
             return false;
            }
            }
</script>--%>
</head>
<body onunload="RefreshParent();">
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="l1" runat="server" Visible="false"></asp:Label></h1>

            <div>

                <table>
                    <tr>
                        <td colspan="4">&nbsp;</td>
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
                            <asp:TextBox TextMode="MultiLine" ID="txtServiceDesc" runat="server" CssClass="ServeTextbox" Style="width: 200px; height: 100px;"></asp:TextBox>
                        </td>
                        <td style="width: 25px;"></td>
                    </tr>
                    <tr>
                        <td style="width: 25px;"></td>
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
                        <td style="padding-top: 15px; width: 150px;">
                            <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ServeDropdownlist"></asp:DropDownList>
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
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnGreen" Width="100px" OnClientClick="parent.parent.GB_hide();" />
                        </td>
                        <td style="width: 25px;"></td>
                    </tr>
                </table>
            </div>
            <p>&nbsp;</p>
        </div>
    </form>
</body>
</html>
