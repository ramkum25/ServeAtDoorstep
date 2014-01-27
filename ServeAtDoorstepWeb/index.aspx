<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.index" %>

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
            <div id="divMainItem" runat="server" class="ServItem">
            </div>
        </div>


    <style type="text/css" media="screen">
    <!--
        * {
            margin: 0;
            padding: 0;
        }
        
        body {
            padding: 10px;
        }
        
        h1 {
            margin: 10px 0;
            font-family: 'Trebuchet MS', Helvetica;
        }
        
        p {
            margin: 10px 0;
            font-family: 'Trebuchet MS', Helvetica;
        }
        
        .bubbleInfo {
            position: relative;
            top: 0px;
            left: 0px;
            width: 900px;
        }
        .trigger {
        }
     
        /* Bubble pop-up */
        .priceFrom {
        padding-top:6px;width:50%;height:25px;background-color:#790d0d;
        color:white;
        background-image: linear-gradient(to bottom, #f327dd, #790d0d);
        }
        .priceTo {
        padding-top:6px;width:50%;height:25px;background-color:#7285e1;
        color:white;

       background-image: linear-gradient(to bottom, #000067, #7285e1);   }
        .popup {
        	position: absolute;
        	display: none;
        	z-index: 50;
            width:700px;
        	border-collapse: collapse;
        }

        .popup td.corner {
        	height: 15px;
        	width: 19px;
        }

        .popup td#topleft { background-image: url(image/bubble/bubble-1.png); }
        .popup td.top { background-image: url(image/bubble/bubble-2.png); }
        .popup td#topright { background-image: url(image/bubble/bubble-3.png); }
        .popup td.left { background-image: url(image/bubble/bubble-4.png); }
        .popup td.right { background-image: url(image/bubble/bubble-5.png); }
        .popup td#bottomleft { background-image: url(image/bubble/bubble-6.png); }
        .popup td.bottom { background-image: url(image/bubble/bubble-7.png); text-align: center;}
        .popup td.bottom img { display: block; margin: 0 auto; }
        .popup td#bottomright { background-image: url(image/bubble/bubble-8.png); }

        .popup table.popup-contents {
        	font-size: 12px;
        	background-color: #b6ff00;
            background-image: linear-gradient(to bottom, #b6ee89, #b6ff00);

        	color: #161442;
            width:225px;
            height:90px;
            border-radius:9px;
            border-color:indianred;
        	font-family: "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", sans-serif;
        	}

        table.popup-contents th {
        	text-align: right;
            width:40%;
        	text-transform: lowercase;
        	}

        table.popup-contents td {
        	text-align: left;
        	text-transform: uppercase;
            width:60%;

        	}

        tr#release-notes th {
        	text-align: left;
        	text-indent: -9999px;
        	background: url(http://jqueryfordesigners.com/demo/images/coda/starburst.gif) no-repeat top right;
        	height: 17px;
        	}

        tr#release-notes td a {
        	color: #333;
        }
        
    -->
    </style>
    <script type="text/javascript">
    <!--

    $(function () {
        $('.bubbleInfo').each(function () {
            var distance = 10;
            var time = 250;
            var hideDelay = 500;

            var hideDelayTimer = null;

            var beingShown = false;
            var shown = false;
            var trigger = $('.trigger', this);
            var info = $('.popup', this).css('opacity', 0);


            $([trigger.get(0), info.get(0)]).mouseover(function () {
                if (hideDelayTimer) clearTimeout(hideDelayTimer);
                if (beingShown || shown) {
                    // don't trigger the animation again
                    return;
                } else {
                    // reset position of info box
                    beingShown = true;

                    info.css({
                        top: -90,
                        left: -33,
                        display: 'block'
                    }).animate({
                        top: '-=' + distance + 'px',
                        opacity: 1
                    }, time, 'swing', function () {
                        beingShown = false;
                        shown = true;
                    });
                }

                return false;
            }).mouseout(function () {
                if (hideDelayTimer) clearTimeout(hideDelayTimer);
                hideDelayTimer = setTimeout(function () {
                    hideDelayTimer = null;
                    info.animate({
                        top: '-=' + distance + 'px',
                        opacity: 0
                    }, time, 'swing', function () {
                        shown = false;
                        info.css('display', 'none');
                    });

                }, hideDelay);

                return false;
            });
        });
    });

    //-->
    </script>
</asp:Content>