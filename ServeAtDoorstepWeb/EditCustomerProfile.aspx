<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomerProfile.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.EditCustomerProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="/js/jquerytools/jquery.tools.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/jquerytools/form.css" />
        
        <style>
        #map-canvas {
            height: 100%;
            margin: 0px;
            padding: 0px;
        }

        #panel {
            position: absolute;
            top: 5px;
            left: 50%;
            margin-left: -180px;
            z-index: 5;
            background-color: #fff;
            padding: 5px;
            border: 1px solid #999;
        }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false"></script>
    <script>
        var geocoder;
        var map;
        function initialize() {
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(41.850033, -87.6500523);
            var mapOptions = {
                zoom: 12,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        }

        function codeAddress() {
            //var address = document.getElementById("<%=hdnAddress.ClientID %>").value;

            var city = document.getElementById("<%=ddlCity.ClientID %>").options[document.getElementById("<%=ddlCity.ClientID %>").selectedIndex].text;
            var state = document.getElementById("<%=ddlState.ClientID %>").options[document.getElementById("<%=ddlState.ClientID %>").selectedIndex].text;

            var address = city + ", " + state + ", US";
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });
                } else {
                    alert('Geocode was not successful for the following reason: ' + status);
                }
            });
        }

        $(document).ready(
        function () {
            initialize();
            codeAddress();

        });
    </script>

    <p></p>
    <div style="padding: 10px 10px 10px 10px; font-family: 'Arial'; font-size: large; font-weight: bold; color: #FFFFCC; background-color: #808080">Edit Profile Information</div>
    <p></p>
    <div>
        <table>
            <tr>
                <td style="width: 200px; height: 200px;">
                    <span id="spnCusImage" runat="server"></span><br />
                    <div style="width: 100%;">
                    <table style="width: 100%;">
                        <tr >
                            <td style="width: 100%;height: 20px;"></td>
                        </tr>
                        <tr >
                            <td style="width: 100%;height: 20px; background-color:#4e98c8; color:wheat;text-align:center;">Login Name</td>
                        </tr>
                        <tr>
                            <td style="width: 100%;height: 30px;color:#2447a7;font-weight:600;">&nbsp;<asp:Label ID="lblLoginName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100%;height: 20px; background-color:#4e98c8; color:wheat;text-align:center;">E Mail</td>
                        </tr>
                        <tr>
                            <td style="width: 100%;height: 30px;color:#2447a7;font-weight:600;">&nbsp;<asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div id="divProfile">
                            <div style="border: thin solid #800080; width: 900px; border-radius: 10px 10px 10px 10px;">
                                <table style="width: 900px; height: auto;">
                                    <tr>
                                        <td colspan="4" class="auto-style1" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; font-size: large; color: wheat; vertical-align: middle; height: 35px;">&nbsp;&nbsp;Name & Address Info 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div id="divErrorMessage" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px;padding-left:25px;"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            &nbsp;<asp:Label ID="Label1" runat="server" Text="l1">First Name </asp:Label>
                                        </td>
                                        <td style="width: 30%;">
                                            <input type="text" id="txtFirstName" name="txtFirstName" class="CssTextbox" required="required" runat="server" style="width:200px;" />
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:0px;font-weight:600;">
                                            <asp:Label ID="Label7" runat="server" Text="l1">Country </asp:Label>

                                        </td>
                                        <td style="width: 30%;">
                                            <select id="ddlCountry" name="ddlCountry" runat="server" class="CssTextbox" style="width:200px;" />
                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            &nbsp;<asp:Label ID="Label2" runat="server" Text="l1">Last Name </asp:Label>
                                        </td>
                                        <td style="width: 30%;">
                                            <input type="text" id="txtLastName" name="txtLastName" class="CssTextbox" runat="server" style="width:200px;" />
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label8" runat="server" Text="l1">State </asp:Label>

                                        </td>
                                        <td style="width: 30%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:DropDownList ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" runat="server" ViewStateMode="Enabled" tabindex="10" style="width:200px;"
                                                EnableViewState="true" AutoPostBack="true" CssClass="CssTextbox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                           &nbsp;<asp:Label ID="Label3" runat="server" Text="l1">Gender</asp:Label>
                                        </td>
                                        <td style="width: 30%;">
                                            <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table"
                                                ForeColor="Black" Font-Bold="True" Height="17px" Width="402px">
                                                <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="Rather not say"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">City
                                        </td>
                                        <td style="width: 30%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server"></ajax:ToolkitScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true"
                                                RenderMode="Inline">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCity" runat="server" ViewStateMode="Enabled" tabindex="11" CssClass="CssTextbox"
                                                        EnableViewState="true" AutoPostBack="true" Style="width: 200px;">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlState" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            &nbsp;<asp:Label ID="Label4" runat="server" Text="l1">Address </asp:Label>
                                        </td>
                                        <td style="width: 30%;">
                                            <input type="text" id="txtAddress" name="txtAddress" class="CssTextbox" runat="server" style="width:200px;" />
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label9" runat="server" Text="l1">Zip code </asp:Label>

                                        </td>
                                        <td style="width: 30%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <input type="text" id="txtZipcode" name="txtZipcode" class="CssTextbox" runat="server" style="width:200px;" />

                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            &nbsp;<asp:Label ID="Label5" runat="server" Text="l1">Street name </asp:Label>
                                        </td>
                                        <td style="width: 30%;">
                                            <input type="text" id="txtStreetname" name="txtStreetname" class="CssTextbox" runat="server" style="width:200px;" />
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label6" runat="server" Text="l1">E Mail </asp:Label>

                                        </td>
                                        <td style="width: 30%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <input type="text" id="txtEmail" name="txtEmail" class="CssTextbox" runat="server" style="width:200px;" />

                                        </td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 30%;">
                                            &nbsp;
                                        </td>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label11" runat="server" Text="l1">Mobile </asp:Label>

                                        </td>
                                        <td style="width: 30%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <input type="text" id="txtMobile" name="txtMobile" class="CssTextbox" runat="server" style="width:200px;" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">&nbsp;</td>
                                    </tr>
                                    <tr style="border-top:thin solid #800080;border-bottom:thin solid #800080;">
                                        <td colspan="4">
                                            <div id="panel">
                                            </div>
                                            <div id="map-canvas" style="width: 100%; height: 300px;"></div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">&nbsp;</td>
                                    </tr>
                                    <tr style="height: 40px;">
                                        <td colspan="4">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnBlue" Width="75px" OnClick="btnUpdate_Click"></asp:Button>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnBlue" Width="75px" OnClick="btnReset_Click"></asp:Button>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBlue" Width="75px" OnClick="btnCancel_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>

    <input type="hidden" id="hdnAddress" name="hdnAddress" runat="server" />

    <script>

        $("#MainContent_txtFirstName").validator();

    </script>
</asp:Content>