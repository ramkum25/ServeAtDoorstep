<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCustomerProfile.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.MyCustomerProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="MainContent">
    <script src="js/lightbox/js/modernizr.custom.js"></script>
    <link rel="shortcut icon" href="js/lightbox/img/demopage/favicon.ico" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Karla:400,700" />
    <link rel="stylesheet" href="js/lightbox/css/screen.css" media="screen" />
    <link rel="stylesheet" href="js/lightbox/css/lightbox.css" media="screen" />
    <style>
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
    </style>
    <style type="text/css">
        .file_input_textbox {
            float: left;
        }

        .file_input_div {
            position: absolute;
            width: 120px;
            height: 25px;
            overflow: hidden;
        }

        .file_input_button {
            width: 120px;
            position: relative;
            font-family: Calibri;
            font-size: 14px;
            font-weight: bold;
            top: 0px;
            height: 25px;
            background-color: #ebedda;
            color: #000000;
            border: 1px solid black;
            border-radius: 10px 10px 10px 10px;
        }

        .file_input_hidden {
            font-size: 25px;
            position: absolute;
            right: 0px;
            top: 0px;
            opacity: 0;
            background-color: #f2eceb;
            filter: alpha(opacity=0);
            -ms-filter: "alpha(opacity=0)";
            -khtml-opacity: 0;
            -moz-opacity: 0;
        }
    </style>

    <script type="text/javascript">
        $(function () {

            $('#<%=FileUpload1.ClientID %>').change(function () {
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

    <p></p>
    <div style="padding: 10px 10px 10px 10px; font-family: 'Arial'; font-size: large; font-weight: bold; color: #FFFFCC; background-color: #808080">My Profile Information</div>
    <p></p>
    <div>
        <table>
            <tr>
                <td style="width: 200px; height: 200px;">
                    <span id="spnCusImage" runat="server"></span>
                    &nbsp; &nbsp; &nbsp;<asp:LinkButton ID="lbtnChangePic" runat="server" ForeColor="RosyBrown" Style="padding-left: 25px;" OnClick="lbtnChangePic_Click">Change Picture</asp:LinkButton>
                </td>
                <td colspan="2">
                    <asp:Panel runat="server">
                        <div>
                            <div style="border: thin solid #800080; width: 850px; border-radius: 10px 10px 10px 10px;">
                                <table style="width: 850px; height: 250px;">
                                    <tr>
                                        <td colspan="4" class="auto-style1" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; font-size: large; color: wheat; vertical-align: middle; height: 35px;">&nbsp;&nbsp;Name & Address Info 
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkEditPassword" runat="server" ForeColor="White" OnClick="lnkEditPassword_Click">Change Password</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton ID="lnkEditProfile" runat="server" ForeColor="White" OnClick="lnkEditProfile_Click">Edit profile</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 12%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Name :</asp:Label>
                                        </td>
                                        <td style="width: 35%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusName"></asp:Label>
                                        </td>
                                        <td style="width: 15%;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Address :</asp:Label>
                                        </td>
                                        <td style="width: 37%;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusStreet"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Gender :</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusGender"></asp:Label>
                                        </td>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1" Visible="false">Street Name</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusAddr"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Login Name :</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusLogName"></asp:Label>
                                        </td>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1" Visible="false">City</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusCity"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Password :</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusLogPwd"></asp:Label>
                                        </td>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1" Visible="false">State</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusState"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">E-Mail :</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusEmail"></asp:Label>
                                        </td>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1" Visible="false">Country</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusCountry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1">Mobile :</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusMobile"></asp:Label>
                                        </td>
                                        <td style="font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label runat="server" Text="l1" Visible="false">Zip Code</asp:Label>
                                        </td>
                                        <td style="font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCusZip"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 200px; height: 200px;">&nbsp;
                </td>
                <td colspan="2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div>
                            <div style="border: thin solid #800080; width: 850px; border-radius: 10px 10px 10px 10px;">
                                <table style="width: 850px; height: 237px;">
                                    <tr>
                                        <td colspan="4" class="auto-style1" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; font-size: large; color: wheat; vertical-align: middle; height: 35px;">&nbsp;&nbsp;Location
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <div id="panel">
                                            </div>
                                            <div id="map-canvas" style="width: 100%; height: 400px;"></div>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 200px; height: 200px;">&nbsp;
                </td>
                <td>
                    <asp:Panel ID="Panel2" runat="server">
                        <div>
                            <div style="border: thin solid #800080; width: 500px; border-radius: 10px 10px 10px 10px;">
                                <table style="width: 500px; height: 200px;">
                                    <tr>
                                        <td colspan="2" class="auto-style1" style="border-radius: 10px 10px 0px 0px; background-color: #4e98c8; font-family: Arial; font-weight: 500; font-size: large; color: wheat; vertical-align: middle; height: 30px;">&nbsp;&nbsp;Bank Info
                                            
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                            <asp:LinkButton ID="lnkEditBank" runat="server" ForeColor="White" OnClick="lnkEditBank_Click">Edit</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 30px;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label1" runat="server" Text="l1">Bank Name :</asp:Label>
                                        </td>
                                        <td style="width: 300px; height: 30px;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblBankName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 30px;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label5" runat="server" Text="l1">Card Holder Name :</asp:Label>
                                        </td>
                                        <td style="width: 300px; height: 30px;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblHolderName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 30px;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label16" runat="server" Text="l1">Credit Card No :</asp:Label>
                                        </td>
                                        <td style="width: 300px; height: 30px;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCardNo"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 30px;font-family:Calibri;font-size:14px;color:maroon;padding-left:5px;font-weight:600;">
                                            <asp:Label ID="Label18" runat="server" Text="l1">CVC No :</asp:Label>
                                        </td>
                                        <td style="width: 300px; height: 30px;font-family:'Global Sans Serif';font-size:17px;color:#05202e;font-weight:900;">
                                            <asp:Label runat="server" ID="lblCVC"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </td>
                <td style="padding-left: 50px;">
                    
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hdnAddress" name="hdnAddress" runat="server" />
    <ajax:ToolkitScriptManager ID="scriptmanager1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:Button ID="btnShowPopupPic" runat="server" Style="display: none" />
    <ajax:ModalPopupExtender ID="modalpopPicture" runat="server" TargetControlID="btnShowPopupPic" PopupControlID="pnlpopupPic"
        CancelControlID="btnCancelPic" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopupPic" runat="server" BackColor="#FFFFCC" Height="175px" Width="500px" Style="display: none;border-radius:6px;">
        <div style="height: 30px;padding-top:5PX; font-family: Arial;vertical-align:middle;text-align:center; font-size: 18px;background-color:#d5d370;border-top-left-radius:6px;border-top-right-radius:6px;">
            &nbsp;Change Profile Picture  &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/image/close.png" Height="17px" Width="17px" OnClick="imgClose_Click" />
        </div>
        <p></p>
        <div id="divErrorPic" runat="server"></div>
        <table>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td style="font-size: 13px; font-weight: normal;">Upload Image<br />
                    <span style="font-size: 10px;">(max 50 KB)</span>
                </td>
                <td style="padding-left: 25px;">
                    <table>
                        <tr>
                            <td style="">
                                <input type="text" id="fileName1" name="fileName1" class="InputTextbox"
                                    style="height: 20px; width: 200px;" readonly="readonly" />&nbsp;&nbsp;
                            </td>
                            <td>
                                <div class="file_input_div">
                                    <input type="button" value="Browse..." class="file_input_button" />
                                    <input id="FileUpload1" runat="server" name="FileUpload1" type="file" class="file_input_hidden" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <p></p>
        <p></p>
        <div style="padding-left: 120px;">
            <asp:Button ID="btnSavePic" runat="server" Text="Save" CssClass="SubmitButton" OnClick="btnSavePic_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelPic" runat="server" Text="Cancel" CssClass="SubmitButton"></asp:Button>
        </div>
    </asp:Panel>

    <asp:Button ID="btnShowPopupBank" runat="server" Style="display: none" />
    <ajax:ModalPopupExtender ID="modalpopBank" runat="server" TargetControlID="btnShowPopupBank" PopupControlID="pnlpopupBank"
        CancelControlID="btnCancelBank" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopupBank" runat="server" BackColor="#FFFFCC" Height="300px" Width="500px" Style="display: none;border-radius:6px;" >
        <div style="height: 30px;padding-top:5PX; font-family: 'Harlow Solid';vertical-align:middle;text-align:center; font-size: 18px;background-color:#d5d370;border-top-left-radius:6px;border-top-right-radius:6px;">
            &nbsp;Bank Details  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgCloseBank" runat="server" ImageUrl="~/image/close.png" Height="17px" Width="17px" OnClick="imgCloseBank_Click" />
        </div>
        <p></p>
        <div id="divErrorBank" runat="server"></div>
        <table>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">Bank Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtBankname" name="txtBankname" maxlength="50" style="width: 200px;"
                        class="ServeTextbox" />
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">Cardholder Name
                </td>
                <td>
                    <input type="text" runat="server" id="txtCardholdername" name="txtCardholdername" maxlength="50" class="ServeTextbox" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">Credit Card Number
                </td>
                <td>
                    <input type="text" runat="server" id="txtCredCardnumber" name="txtCredCardnumber" maxlength="50" class="ServeTextbox" style="width: 200px;" />
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">CVC Number
                </td>
                <td>
                    <input type="text" id="txtCVC" name="txtCVC" runat="server" maxlength="50" class="ServeTextbox" style="width: 200px;" />
                </td>
            </tr>
        </table>
        <p></p>
        <p></p>
        <div style="padding-left: 120px;">
            <asp:Button ID="btnSaveBank" runat="server" Text="Save" CssClass="SubmitButton" OnClick="btnSaveBank_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelBank" runat="server" Text="Cancel" CssClass="SubmitButton"></asp:Button>
        </div>
    </asp:Panel>
    <asp:Button ID="btnShowPopupPwd" runat="server" Style="display: none" />
    <ajax:ModalPopupExtender ID="modalpopPassword" runat="server" TargetControlID="btnShowPopupPwd" PopupControlID="pnlpopupPwd"
        CancelControlID="btnCancelPwd" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel ID="pnlpopupPwd" runat="server" BackColor="#FFFFCC" Height="200px" Width="500px" Style="display: none;border-radius:6px;">
       <script src="/js/jquerytools/jquery.tools.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/jquerytools/form.css" />
     <div style="height: 30px;padding-top:5PX; font-family: Arial;vertical-align:middle;text-align:center; font-size: 18px;background-color:#d5d370;border-top-left-radius:6px;border-top-right-radius:6px;">
            &nbsp;Change Password  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgClosePwd" runat="server" ImageUrl="~/image/close.png" Height="17px" Width="17px" OnClick="imgClosePwd_Click" />
        </div>
        <p></p>
        <div id="divErrorPwd" runat="server"></div>
        <table>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">New Password
                </td>
                <td>
                    <input type="password" runat="server" id="txtNewPwd" name="txtNewPwd" maxlength="50" style="width: 200px;"
                        class="ServeTextbox" />
                </td>
            </tr>
            <tr>
                <td style="width: 160px; height: 30px; font-size: 12px; padding-left: 50px; padding-top: 15px;">Confirm Password
                </td>
                <td>
                    <input type="password" runat="server" id="txtConPwd" name="txtConPwd" maxlength="50" class="ServeTextbox" style="width: 200px;" />
                </td>
            </tr>
        </table>
        <p></p>
        <p></p>
        <div style="padding-left: 120px;">
            <asp:Button ID="btnSavePwd" runat="server" Text="Save" CssClass="SubmitButton" OnClick="btnSavePwd_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelPwd" runat="server" Text="Cancel" CssClass="SubmitButton"></asp:Button>
        </div>
    </asp:Panel>

        

</asp:Content>
