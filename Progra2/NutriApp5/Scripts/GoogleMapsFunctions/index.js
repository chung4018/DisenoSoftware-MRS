//Variables globales utilizadas en el código
var map//contiene el mapa creado
var allMarkers = [];//contiene la lista de objetos que se han marcado en el mapa
var completeLoaded = false;
$(document).ready(function () {
    
   // alert("hi");
    loadMap();
    loadMarker();
});

function loadMap() {
    var lat, lon, myOptions;

    //check if user has geo feature
    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition(
        //get position
        function (position) {
           
            $("#latitudActual").attr('value', position.coords.latitude);
            $("#longitudActual").attr('value', position.coords.longitude);
            var lat = position.coords.latitude;
            var lon = position.coords.longitude;

            $("#latitudActual").attr('value', lat);
            $("#longitudActual").attr('value', lon);
            initMap();//inicializa el mapa
            //alert("MAPA: " + map);
            map.setZoom(15);
            map.setCenter(new google.maps.LatLng(lat, lon));           
        },
        // if there was an error
        function (error) {
            alert('ouch');
        });
    }
        //case the users browser doesn't support geolocations
    else {
        alert("Your browser doesn't support geolocations, please consider downloading Google Chrome");
    }
    
}

function setMarker(coords) {
   // alert("coords: " + coords[0] + " " + coords[1]);
   // alert(map.geolocation);
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(coords[0], coords[1]),
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        title: "This a new marker!",
        icon: "http://maps.google.com/mapfiles/ms/micons/blue.png"
    });
    google.maps.event.addListener(marker, 'dragend', function (event) {
        var lat = String(event.latLng.lat()).replace('.', ',');
        var lng = String(event.latLng.lng()).replace('.', ',');
        $("#LATITUD").attr('value', lat);
        $("#LONGUITUD").attr('value', lng);
            
    });
    allMarkers.push(marker);//se registra el marcador en el arreglo de marcadores
}

function initMap() {
    var mapOptions = {
        center: new google.maps.LatLng(0, 0),
        zoom: 1,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("mapa"),
                                      mapOptions);
    google.maps.event.addListenerOnce(map, 'idle', function () {
        
        addListeners();
        loadMarker();
        completeLoaded = true;
    });
}

function addListeners() {
    //se añade el evento click para definir los marcadores
    google.maps.event.addListener(map, 'click', function (event) {
        deleteAllMarkers();
        setMarker([event.latLng.lat(), event.latLng.lng()]);
        //se definen las coordenadas para que sean almacenadas en la BD
        var lat = String(event.latLng.lat()).replace('.', ',');
        var lng = String(event.latLng.lng()).replace('.', ',');
        $("#LATITUD").attr('value', lat);
        $("#LONGUITUD").attr('value', lng);

    });
}
function loadMarker() {
    // alert($("#LATITUD").attr('value') + "  " + $("#LONGUITUD").attr('value'));
    var lat = $("#LATITUD").attr('value').replace(',', '.');
    var lng = $("#LONGUITUD").attr('value').replace(',', '.');
    /*while (!completeLoaded) {

    }*/
    // alert("salio");
    if (!lat == 0)
        setMarker([lat, lng]);
    else
        alert("creando");
}
//elimina todos los marcadores que hayan en el mapa
function deleteAllMarkers() {
    for (var i = 0; i < allMarkers.length; i++) {
        allMarkers[i].setMap(null);
    }
    allMarkers = [];//reinicia la lista de marcadores que hay en el mapa
}