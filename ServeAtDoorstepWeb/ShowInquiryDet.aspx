<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInquiryDet.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.ShowInquiryDet" %>

<asp:Content ID="c1" runat="server" ContentPlaceHolderID="MainContent">

    <script src="js/lightbox/js/modernizr.custom.js"></script>
    <link rel="shortcut icon" href="js/lightbox/img/demopage/favicon.ico" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Karla:400,700" />
    <link rel="stylesheet" href="js/lightbox/css/screen.css" media="screen"/>
    <link rel="stylesheet" href="js/lightbox/css/lightbox.css" media="screen" />
    
    <link href="js/jsImgSlider/themes/1/js-image-slider.css" rel="stylesheet" type="text/css" />
    <script src="js/jsImgSlider/themes/1/js-image-slider.js" type="text/javascript"></script>
    <link href="js/jsImgSlider/generic.css" rel="stylesheet" type="text/css" />
    <style>
        .divModalBackground {
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
            opacity: 0.5;
            width: 100%;
            background-color: #999988;
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 800;
        }
    </style>
    <script type="text/javascript">
        function init() {
            var objdiv = document.getElementById('<%=Panel1.ClientID%>')
            if (objdiv) {
                objdiv.style.visibility = 'hidden';
            }
        }

        init();
    </script>
    <script src="js/lightbox/js/jquery-1.10.2.min.js"></script>
    <script src="js/lightbox/js/lightbox-2.6.min.js"></script>
    <script>
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-2196019-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

    <div id="MainSection">
        <div id="MainItem">
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btnBlue" Style="width: 78px;" />
            <div style="padding-left: 150px;">
                <h3 style="clear: both;">INQUIRY Details</h3>
            </div>
            <div style="padding-left: 150px;">
                <div style="border-radius: 5px 5px 5px 5px; border: 2px solid #0b5c76; width: 750px;">
                    <table style="width: 750px;">
                        <tr style="height: 35px; width: 100%; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white;
                             background-color: #93a4a9; vertical-align: middle;">&nbsp;&nbsp;Title
                            </td>
                            <td style="vertical-align: middle; width: 350px;">
                                <span style="font-family: sans-serif; font-size: 15px;">
                                    <strong>
                                        &nbsp;&nbsp;<asp:Label ID="lblTitle" runat="server" Text="Title"></asp:Label>
                                    </strong>
                                </span>
                            </td>

                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle; width: 100px;">&nbsp;&nbsp;Posted On :
                            </td>
                            <td style="vertical-align: middle;">
                                <span style="font-family: Arial; font-size: 15px; font-weight: 700;">
                                    &nbsp;&nbsp;<asp:Label ID="lblPostedOn" runat="server" Text="Title"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr style="height: 35px; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle;">
                                &nbsp;&nbsp; Name
                            </td>
                            <td style="vertical-align: middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblCustomerName" runat="server" Text="Catgory"></asp:Label>

                            </td>
                            <td></td>
                            <td rowspan="5" style="border: thin solid #0b5c76;text-align:center;vertical-align:middle;">
                                <span id="spnCusImage" runat="server"></span>
                            </td>

                        </tr>
                        <tr style="height: 35px; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle;">
                                &nbsp;&nbsp;Address

                            </td>
                            <td style="vertical-align: middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblAddress" runat="server" Text="Catgory"></asp:Label>

                            </td>
                            <td></td>
                        </tr>
                        <tr style="height: 35px; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle;">&nbsp;&nbsp;City
                            </td>
                            <td style="vertical-align: middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblCity" runat="server" Text="Catgory"></asp:Label>

                            </td>
                            <td></td>
                        </tr>
                        <tr style="height: 35px; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle;">&nbsp;&nbsp;State & Zip
                            </td>
                            <td style="vertical-align: middle;">
                                &nbsp;&nbsp;<asp:Label ID="lblState" runat="server" Text="Catgory"></asp:Label>

                            </td>
                            <td></td>
                        </tr>
                        <tr style="height: 35px; border: thin solid #0b5c76;">
                            <td style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; vertical-align: middle;">&nbsp;&nbsp;Catgory
                            </td>
                            <td style="vertical-align: middle;">
                               &nbsp;&nbsp; <asp:Label ID="lblCatgory" runat="server" Text="Catgory"></asp:Label>

                            </td>
                            <td></td>
                        </tr>
                        <tr style="height: 30px; border: thin solid #0b5c76;">
                            <td colspan="4" style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; 
vertical-align: middle;">&nbsp;&nbsp;Uploaded Images
                                <br />
                            </td>
                        </tr>
                        <tr style="border: thin solid #0b5c76;">
                            <td colspan="4" style="height: 200px;">
                                <div class="image-row" style="padding: 25px;">
                                    <div class="image-set" id="divQuiryImag" runat="server">
                                    </div>
                                </div>
                                <%--<span id="spnImgSlide" runat="server"></span>--%>
                                <p>&nbsp;</p>
                            </td>
                        </tr>
                        <tr style="height: 30px; border: thin solid #0b5c76;">
                            <td colspan="4" style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; 
vertical-align: middle;">&nbsp;&nbsp;Uploaded Video
                                <br />
                            </td>
                        </tr>
                        <tr style="border: thin solid #0b5c76;">
                            <td colspan="4" style="text-align: center;">
                                <br />
                                <span id="spnVideo" style="padding: 25px;" runat="server"></span>
                            </td>
                        </tr>
                        <tr style="height: 30px; border: thin solid #0b5c76;">
                            <td colspan="4" style="font-family: Calibri; font-size: 14px; font-weight: 600; color: white; background-color: #93a4a9; 
vertical-align: middle;">&nbsp;&nbsp;Description
                                <br />
                            </td>
                        </tr>

                        <tr style="border: thin solid #0b5c76; height: 150px;">
                            <td colspan="4">
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDesc" runat="server" Text="Title"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>


        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="900px" Width="100%" CssClass="divModalBackground" Visible="true">
        <asp:Image runat="Server" ID="ImageLoader" CssClass="LoadingProgress" ImageUrl="~/image/loading.gif" />
    </asp:Panel>
</asp:Content>
