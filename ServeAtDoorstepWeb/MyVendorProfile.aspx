<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyVendorProfile.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.MyVendorProfile" %>

<asp:Content ID="d3" runat="server" ContentPlaceHolderID="MainContent">
    
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
            var address = document.getElementById("<%=hdnAddress.ClientID %>").value;
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
    <input type="hidden" id="hdnAddress" name="hdnAddress" runat="server" />

    <p></p>
    <div style="padding: 10px 10px 10px 10px; font-family: 'Arial'; font-size: large; font-weight: bold; color: #FFFFCC; background-color: #808080">My Profile Information</div>
    <p></p>

    <div style="width: 100%;">
        <table style="width: 100%;">
            <tr>
                <td style="width: 15%;">
                    <div id="divVendorInfo" runat="server"></div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lnkEditProfile" runat="server" OnClick="lnkEditProfile_Click" ForeColor="#009999">Edit Profile</asp:LinkButton>
                </td>
                <td style="width: 55%;">
                    <div id="divAddressInfo" runat="server"></div>
                </td>
                <td style="width: 30%; background-color:lightgray;">
                    <div id="divBusinessInfo" runat="server"></div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <div id="panel">
                    </div>
                    <div id="map-canvas" style="width: 100%; height: 400px;"></div>
                </td>
                <td style="background-color:lightgray;">
                    <div id="divCategory">
                        <br />
                        <br />
                        <br />
                        <span  style="font-family: calibri; font-size: large; font-weight: bolder; color: #006666">Category :</span>
                        <br />
                        <span id="spnCategory" runat="server"></span>
                    </div>
                </td>
            </tr>
            <tr style="height:20px;">
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div id="Div1">
                    </div>
                </td>
                <td>
                    <div style="border: thin solid #800080; width: 100%; border-radius: 10px 10px 10px 10px;">
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; 
                                font-size: large; color: wheat; vertical-align: middle; height: 30px;width: 100%;">&nbsp;&nbsp;Membership Details
                                </td>
                            </tr>
                            <tr style="height:5px;">
                                <td>
                                &nbsp;
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="width:30%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                    Type
                                </td>
                                <td style="width:70%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;"">
                                    <asp:Label ID="lblMemName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="width:30%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                    Days Remaining
                                </td>
                                <td style="width:70%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;"">
                                    <asp:Label ID="lblDaysRemain" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="width:30%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                    Credit Card Type
                                </td>
                                <td style="width:70%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;"">
                                    <asp:Label ID="lblCardType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height:35px;">
                                <td style="width:30%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                    Credit Card Number
                                </td>
                                <td style="width:70%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;"">
                                    <asp:Label ID="lblCardNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>

                    </div>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
