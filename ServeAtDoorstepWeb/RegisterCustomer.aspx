<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCustomer.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.RegisterUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="js/easyUI/themes/icon.css" />
    <script type="text/javascript" src="js/easyUI/jquery.min.js"></script>
    <script type="text/javascript" src="js/easyUI/jquery.easyui.min.js"></script>
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

         $(function () {
             $('#<%=fileProfile.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png' and '.gif' formats are allowed.");
                    $(this).val("");
                    document.getElementById('fileName1').value = "";

                }
                else {
                    document.getElementById('fileName1').value = $(this).val();
                }

            });

        });
    </script>
    <p>&nbsp;</p>
     <style>
      #map-canvas {
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

    <div style="font-family: sans-serif; color: #5F5F5F; padding-left: 160px;">

        <div style="font-size: 25px; padding-left: 0px; background-color: #597abf; vertical-align: middle; width: 80%; color: whitesmoke; height: 40px; text-align: left; border-radius: 10px 10px 0px 0px">
            <strong>&nbsp;&nbsp;&nbsp;Customer Registeration</strong>
        </div>
        <div style="font-family: Verdana; color: #5F5F5F; padding-left: 100px;">
            <div id="divMessage"></div>
            <%--<div id="divErrorMessage" runat="server" style="color:red;font-weight:700;padding-left:200px;background-color: #FFCCFF; border-radius:5px,5px;"></div>--%>
            <table style="padding-left: 200px;">
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="divErrorMessage" runat="server" style="color: red; font-weight: 700; border-radius: 5px,5px;"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Customer Login Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtUsername" name="txtUsername" maxlength="50" 
                            style="border-top-left-radius: 5px; font-family:Verdana; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" tabindex="1" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Password
                    </td>
                    <td>
                        <input type="password" runat="server" id="txtPassword" name="txtPassword" maxlength="50" tabindex="2" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Confirm Password
                    </td>
                    <td>
                        <input type="password" runat="server" id="txtConPassword" name="txtConPassword" maxlength="50"  tabindex="3" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
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
                    <td style="width: 250px; height: 40px; font-size: 14px;">Proile Picture
                    </td>
                    <td>
                        <asp:FileUpload ID="fileProfile" runat="server"  Style="font-family:Verdana;border-top-left-radius: 5px; border-top-right-radius: 5px; height: 25px; width: 250px; font-size: 15px;" TabIndex="8" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">First Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtFirstname" name="txtFirstname" maxlength="50"  tabindex="5"
                            style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Last Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtLastname" name="txtLastname" maxlength="50"  tabindex="6" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 15px;">Gender
                    </td>
                    <td>
                        <input type="radio" value="1" name="rdoGender"  tabindex="7"/>Male
                    <input type="radio" value="2" name="rdoGender" />Female
                    <input type="radio" value="0" name="rdoGender"  />Rather not say
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Address
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtAddress" name="txtAddress" maxlength="50" tabindex="8" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Street Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtStreet" name="txtStreet" maxlength="50" tabindex="9" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Country
                    </td>
                    <td>
                        <select id="ddlCountry" name="ddlCountry" runat="server" style="font-family:Verdana;border-top-left-radius: 5px; border-top-right-radius: 5px; font-size: 15px; border-top-style: solid; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">State
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" ViewStateMode="Enabled" tabindex="10"
                            EnableViewState="true" AutoPostBack="true" Style="border-top-left-radius: 5px; font-family:Verdana;border-top-right-radius: 5px; font-size: 15px; 
                            border-top-style: solid; height: 25px; width: 250px;">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">City
                    </td>
                    <td>
                        <ajax:ToolkitScriptManager ID="ScriptManager1" runat="server"></ajax:ToolkitScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true"
                            RenderMode="Inline">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCity" runat="server" ViewStateMode="Enabled" tabindex="11"
                                    EnableViewState="true" AutoPostBack="true" Style="border-top-left-radius: 5px;font-family:Verdana; border-top-right-radius: 5px; font-size: 15px; border-top-style: solid; height: 25px; width: 250px;">
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
                    <td style="width: 250px; height: 40px; font-size: 14px;">Zip Code
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtZipcode" name="txtZipcode" maxlength="50" tabindex="12" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
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
                    <td style="width: 250px; height: 40px; font-size: 14px;">E Mail
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtEmail" name="txtEmail" maxlength="50" tabindex="13" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Mobile Number
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtMobile" name="txtMobile" maxlength="50" tabindex="14" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
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
                    <td style="width: 250px; height: 40px; font-size: 14px;">Bank Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtBankname" name="txtBankname" maxlength="50" tabindex="15" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Cardholder Name
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtCardholdername" name="txtCardholdername" tabindex="16" maxlength="50" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">Credit Card Number
                    </td>
                    <td>
                        <input type="text" runat="server" id="txtCredCardnumber" name="txtCredCardnumber" tabindex="17" maxlength="50" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;">CVC Number
                    </td>
                    <td>
                        <input type="text" id="txtCVC" name="txtCVC" runat="server" maxlength="50" tabindex="18" style="font-family:Verdana;border-top-left-radius: 5px; font-size: 15px; border-top-right-radius: 5px; height: 25px; width: 250px;" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;<input id="chkAgree" type="checkbox" tabindex="19" name="chkAgree" runat="server" />&nbsp;I agree to the Serve At Doorstep Terms of Service and Privacy policy.
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 40px; font-size: 14px;" colspan="2">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btnBlue" tabindex="20"
                            Style="width: 120px;" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btnBlue" tabindex="21"
                        Style="width: 120px;" />

                    </td>
                </tr>

            </table>

        </div>

    </div>
    <script type="text/javascript">
        $(function () {
            $('#<%#fileProfile.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png', 'gif', 'bmp'];
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    alert("Only '.jpeg','.jpg', '.png', '.gif', '.bmp' formats are allowed.");
                    $(this).val("");
                }
            })
        });
    </script>

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
                <td colspan="2" style="height: 10%; color: black; font-weight: bold; font-size: larger" align="center">Registered Successully.</td>
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
                <td colspan="2">&nbsp;
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
