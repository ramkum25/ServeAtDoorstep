<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ServeAtDoorstepWeb.WebForm2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Show your Current Location in Google Maps
</title>
<style type="text/css"> gb
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
</style>
<script type="text/javascript"
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyByJmQq7PkPaznZUFsH7AesFNUz82U8iOc&sensor=false">
</script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places">
</script>
<script type="text/javascript">
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success);
    } else {
        alert("Geo Location is not supported on your current browser!");
    }
    function success(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        var city = position.coords.locality;
        var myLatlng = new google.maps.LatLng(latitude, longitude);
        var myOptions = {
            center: myLatlng,
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            title: "lat: " + latitude + " long: " + longitude
        });

        marker.setMap(map);
        var infowindow = new google.maps.InfoWindow({ content: "<b>User Address</b><br/> Latitude:" + latitude + "<br /> Longitude:" + longitude + "" });
        infowindow.open(map, marker);
    }
</script>
</head>
<body >
<form id="form1" runat="server">
<center>
<div id="map_canvas" style="width: 800px; height: 400px">
</div>
</center>
</form>
</body>
</html>
