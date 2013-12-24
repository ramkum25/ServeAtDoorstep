<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/Serve.Master" Inherits="ServeAtDoorstepWeb.WebForm1" %>

<asp:Content ID="c1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="map"  style="width:600px; height:400px;">
</div>

//Direction Div

<div id="directionsPanel" style="float: left; min-height: 0px; max-height: 432px;
overflow-y: scroll; width: 100%;">
</div>

//total Distance

<div id="km" style="display: none;">
<p>
Total Distance: <span id="total"></span>
</p>
</div>

 <script src="http://maps.google.com/maps/api/js?v=3&sensor=false&#8221; type="text/javascript"></script>

<script type="text/javascript">

             var icon = new google.maps.MarkerImage(“http://maps.google.com/mapfiles/ms/micons/blue.png&#8221;,

            new google.maps.Size(32, 32), new google.maps.Point(0, 0),

            new google.maps.Point(16, 32));

        var center = null;

        var map = null;

        var currentPopup;

        var bounds = new google.maps.LatLngBounds();

          var rendererOptions = {

            draggable: true

        };

         var directionsDisplay = new google.maps.DirectionsRenderer(rendererOptions);

        var directionsService = new google.maps.DirectionsService();

        var australia = new google.maps.LatLng(28.64186, 77.29457);

           function addMarker(lat, lng, info) {

                            // alert(“lat="+lat,+"ln="+lng,info);

 

            var StoreNAme= lat.split(“{“);      

            var str = StoreNAme[0];

            var n = str.split(“:");

            lat = n[0];

            lng = n[1];

            info = n[2];

            var pt = new google.maps.LatLng(lat, lng);

            bounds.extend(pt);

           

            var key = n[2];           

            key=key.replace(/ /g,"_");

//pop box

            info= ‘<div style="widht:300px;"><div style="float:left; widht:30%;"><img src="img_shop.png" style="width: 57px;" ></div><div style=" widht:70%; margin-top: 3px;"><span>Store Name:</span><b><span>’+StoreNAme[1]+’</span></b><br /><span style=" margin-top: 5px;">’+n[2]+’</span></div><div style="float:left;  margin-top: 7px;"><input type="hidden" id="sourceAddress" name="sourceAddress" value=’+key+’><input type="text" size="30″ id="text_search" value="" name="txtarch"> <input type="button" id=’+key+’  onclick="myFunction(this)" value="Get Direction" name="bSearch"></div>’;

           

            var marker = new google.maps.Marker({

                position: pt,

                icon: icon,

                map: map

            });

           

            var popup = new google.maps.InfoWindow({

                content: info,

                maxWidth: 300,

                

            });

 

            google.maps.event.addListener(marker, “click", function () {

                if (currentPopup != null) {

                    currentPopup.close();

                    currentPopup = null;

                }

                                        

 

                popup.open(map, marker);

                currentPopup = popup;

            });

            google.maps.event.addListener(popup, “closeclick", function () {

                //map.panTo(center);

                currentPopup = null;

            });

 

            google.maps.event.addListener(directionsDisplay, ‘directions_changed’,                   function () {

                          

                computeTotalDistance(directionsDisplay.directions);

            });

                           

 

        }



        function initMap() {



            map = new google.maps.Map(document.getElementById(“map"), {

                         

                center: new google.maps.LatLng(0, 0),

                zoom: 1,

                mapTypeId: google.maps.MapTypeId.ROADMAP

               /* mapTypeControl: false,

                mapTypeControlOptions: {

                    style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR

                },

                navigationControl: true,

                navigationControlOptions: {

                    style: google.maps.NavigationControlStyle.SMALL

                }*/

            });

                         

            center = bounds.getCenter();

            map.fitBounds(bounds);



        }

        function calcRoute(origin1,destination1) {



              var request = {

                origin: origin1,

                destination:destination1,

               // waypoints: [{ location: 'jaipur, Rajasthan' }],

                travelMode: google.maps.TravelMode.DRIVING

            };

            directionsService.route(request, function (response, status) {                  

                         if (status == google.maps.DirectionsStatus.OK) {

                               

                    directionsDisplay.setDirections(response);

                }

                else

                {

                   alert(“Location not Found");

                }

 

            });

               directionsDisplay.setMap(map);

            directionsDisplay.setPanel(document.getElementById(‘directionsPanel’));

             var menu = document.getElementById(‘km’)

              menu.style.display="block";

              

        }

        function computeTotalDistance(result) {

            var total = 0;

            var myroute = result.routes[0];

            for (i = 0; i < myroute.legs.length; i++) {

                total += myroute.legs[i].distance.value;

            }

            total = total / 1000.

            document.getElementById(“total").innerHTML = total + " km";

        }    

      

       function myFunction(obj)

        {     

        var textvalue=document.getElementById(“text_search").value;

        var sourceAddress=document.getElementById(“sourceAddress").value;

         sourceAddress=sourceAddress.replace(/_/g," “);

              if(textvalue !=")

            {                calcRoute(textvalue,sourceAddress);

            }

            else

            {

                alert(“Please Enter the Destination Address");

            }    

        }

    </script>

 

</asp:Content>