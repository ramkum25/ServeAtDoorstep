<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterVendor.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.RegisterVendor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/icon.css" />
    <script type="text/javascript" src="js/easyUI/jquery.min.js"></script>
    <script type="text/javascript" src="js/easyUI/jquery.easyui.min.js"></script>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    
    <script type="text/javascript">

        // extend the 'equals' rule
        $.extend($.fn.validatebox.defaults.rules, {
            equals: {
                validator: function (value, param) {
                    return value == $(param[0]).val();
                },
                message: 'Field do not match.'
            }
        });

        $.extend($.fn.validatebox.defaults.rules, {
            minLength: {
                validator: function (value, param) {
                    return value.length >= param[0];
                },
                message: 'Please enter at least {0} characters.'
            }
        });
    </script>
    <style>
      html, body, #map-canvas {
        height: 100%;
        margin: 0px;
        padding: 0px
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
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        $(function () {
            $('#MainContent_ddlCity').select(function () {
                     alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");

            });
        });
        var geocoder;
        var map;
        function initialize() {
            geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(41.850033, -87.6500523);
            var mapOptions = {
                zoom: 8,
                center: latlng
            }
            map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
        }

        function codeAddress() {

            var city = document.getElementById("<%=ddlCity.ClientID %>").options[document.getElementById("<%=ddlCity.ClientID %>").selectedIndex].text;
            var state = document.getElementById("<%=ddlState.ClientID %>").options[document.getElementById("<%=ddlState.ClientID %>").selectedIndex].text;
            
            var address = city + ", " + state + ", US";
            //  alert(address);
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

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
    <p>&nbsp;</p>
    <div style=" color: #5F5F5F; padding-left: 80px;">

        <div style="font-size: 25px; padding-left: 0px; background-color: #597abf; vertical-align: middle; width: 100%; color: whitesmoke; height: 40px; text-align: left; border-radius: 10px 10px 0px 0px">
            <strong>&nbsp;&nbsp;&nbsp;Vendor Registeration</strong>
        </div>
        <div style=" color: #5F5F5F; padding-left: 80px;">
            <div id="divMessage"></div>

            <table style="padding-left: 60px;">
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div style="background-color: aliceblue;">
                            (<span style="color: red;">*</span>) indicates mandatory fields.
                        </div>
                        <br />
                        <div id="divErrorMessage" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Vendor Login Name
                    </td>
                    <td>
                        <input type="text" id="txtLoginname" name="txtLoginname" runat="server" maxlength="50" style="border-top-left-radius: 5px; 
                            border-top-right-radius: 5px; height: 25px; width: 250px; font-size: 15px; font-family:Arial;"
                            class="easyui-validatebox" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Password
                    </td>
                    <td>
                        <input type="password" id="txtPassword" name="txtPassword" runat="server" maxlength="50" style="border-top-left-radius: 5px; 
border-top-right-radius: 5px; height: 25px; width: 250px; font-size: 15px; font-family:Arial;"
                            class="easyui-validatebox" data-options="required:true,validType:'minLength[6]'" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Confirm Password
                    </td>
                    <td>
                        <input type="password" id="txtConPassword" name="txtConPassword" runat="server" maxlength="50" style="border-top-left-radius: 5px; 
border-top-right-radius: 5px; height: 25px; width: 250px; font-size: 15px; font-family:Arial;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 700px;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr style="visibility: collapse;">
                    <td style="width: 250px; height: 10px; font-size: 15px;">Coverage Area
                    </td>
                    <td>
                        <input type="text" id="txtCoverageArea" name="txtCoverageArea" runat="server" maxlength="50" style="border-top-left-radius: 5px; border-top-right-radius: 5px; height: 5px; width: 250px; font-size: 15px;"
                            visible="false" />
                    </td>
                </tr>
                <tr style="padding-top: 2em;">
                    <td style="width: 250px; height: 125px; font-size: 15px;">Select Category
                    </td>
                    <td>
                        <asp:CheckBoxList ID="chkCateList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" RepeatLayout="Table"
                            CellSpacing="5" CellPadding="6" Font-Size="16px">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr style="padding-top: 10px;">
                    <td style="width: 250px; height: 40px; font-size: 15px;">Company Name
                    </td>
                    <td>
                        <input type="text" id="txtCompanyName" name="txtCompanyName" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Owner Name
                    </td>
                    <td>
                        <input type="text" id="txtOwnerName" name="txtOwnerName" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Contact Name
                    </td>
                    <td>
                        <input type="text" id="txtContactName" name="txtContactName" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Contact Number
                    </td>
                    <td>
                        <input type="text" id="txtContactNo" name="txtContactNo" runat="server" maxlength="50" style="border-top-left-radius: 5px;font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Mobile Number
                    </td>
                    <td>
                        <input type="text" id="txtMobileNo" name="txtMobileNo" runat="server" maxlength="50" style="border-top-left-radius: 5px;font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Business Phone Number
                    </td>
                    <td>
                        <input type="text" id="txtBusinessNo" name="txtBusinessNo" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">E Mail
                    </td>
                    <td>
                        <input type="text" id="txtEmail" name="txtEmail" runat="server" maxlength="50" style="border-top-left-radius: 5px;font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Website URL
                    </td>
                    <td>
                        <input type="text" id="txtWebsiteUrl" name="txtWebsiteUrl" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 700px;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Vendor Name
                    </td>
                    <td>
                        <input type="text" id="txtVendorName" name="txtVendorName" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Address
                    </td>
                    <td>
                        <input type="text" id="txtAddress" name="txtAddress" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Street Name
                    </td>
                    <td>
                        <input type="text" id="txtStreet" name="txtStreet" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Country
                    </td>
                    <td>
                        <select id="ddlCountry" name="ddlCountry" runat="server" style="border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; font-family:Arial; border-top-style: solid; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">State
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" ViewStateMode="Enabled"
                        EnableViewState="true" AutoPostBack="true" Style="border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; font-family:Arial; border-top-style: solid; height: 25px; width: 250px;">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">City
                    </td>
                    <td>
                        <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server"></ajax:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true"
                        RenderMode="Inline">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCity" runat="server" ViewStateMode="Enabled"
                                    EnableViewState="true" AutoPostBack="true" Style="border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; font-family:Arial; border-top-style: solid; height: 25px; width: 250px;">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                            <%--<select id="ddlCity" name="ddlCity" runat="server" style="border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; border-top-style: solid; height: 25px; width: 250px;" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Zip Code
                    </td>
                    <td>
                        <input type="text" id="txtZipcode" name="txtZipcode" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 700px;">
                        <div id="map-canvas" style="width:700px;height:300px;"></div>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 700px;">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Membership Type
                    </td>
                    <td>
                        <select id="ddlMembership" name="ddlMembership" runat="server" style="border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; font-family:Arial; border-top-style: solid; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Credit Card Type
                    </td>
                    <td>
                        <input type="text" id="txtCredCardType" name="txtCredCardType" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Credit Card Number
                    </td>
                    <td>
                        <input type="text" id="txtCredCardNo" name="txtCredCardNo" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Credit Card Expired Date
                    </td>
                    <td>
                        <input type="text" id="txtExpiredDate" name="txtExpiredDate" runat="server" class="easyui-datebox" data-options="required:true" style="border-top-left-radius: 5px; border-top-right-radius: 5px; height: 25px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">CVC Number
                    </td>
                    <td>
                        <input type="text" id="txtCVC" name="txtCVC" runat="server" maxlength="50" style="border-top-left-radius: 5px; font-size: 15px; font-family:Arial; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;<input id="chkAgree" name="chkAgree" runat="server" type="checkbox" />&nbsp;I agree to the Serve At Doorstep Terms of Service and Privacy policy.
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;" colspan="2">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btnBlue"
                            Style="width: 120px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btnBlue"
                        Style="width: 120px;" />

                    </td>
                </tr>

            </table>

        </div>

    </div>

    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>

    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click"/>--%>

    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <p>&nbsp;</p>
    <ajax:ModalPopupExtender ID="ModalPopupSuccess" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
         BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="190px" Width="300px" Style="display: none;border-radius:8px;">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <table style="border: Solid 3px #fff;border-radius:8px; width: 100%; height: 100%;">
            <tr style="background-color: #b6ff00">
                <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger" align="center">Registered Successully.</td>
            </tr>
            <tr>
                <td colspan="2" style="width: 200px;">
                    <br />
                    We send activation link mail to your <br />
                    <asp:Label ID="lblEmailId" runat="server"></asp:Label>.<br /><br />
                    Goto your Inbox
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnOK" runat="server" Text="OK"  CssClass="SubmitButton" OnClick="btnOK_Click" />
                </td>
            </tr>

        </table></ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>

   
</asp:Content>
