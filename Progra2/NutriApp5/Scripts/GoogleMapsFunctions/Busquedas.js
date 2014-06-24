$(document).ready(function () {

    $("#realizarBusqueda").click(function () {
        var stringBuscado = $("#stringBuscado").val()
        var condicionSelected = $('#condicionSelected').val();
        var buscarEn = $('#buscarEn').val();
        var resultado = "";

        $.getJSON(this.href, $.param({ stringBuscado: stringBuscado, condicionSelected: condicionSelected, buscarEn: buscarEn }, true), function (result) {
            
            resultado = result.message;
            
            $("#resultadoBusqueda").html(resultado);
            cargaLinksUbicaciones();
        });

        //alert(resultado);
        return false;
    });
});

var map;//contiene el mapa que se utiliza para los comercios
var allMarkers = [];//contiene la lista de objetos que se han marcado en el mapa
var completeLoaded = false;
var infowindow = new google.maps.InfoWindow();
var comercioArray = [];
var marker;

function cargaLinksUbicaciones() {
    $(".showUbication").each(function () {
        $(this).unbind('click').click(function () {
            //se anade la posicion del comercio
            var lat = $(this).attr("latitud").replace(',', '.');
            var lon = $(this).attr("longitud").replace(',','.');
           
            var nombre = $(this).attr("nombre");
            comercioArray = [nombre, lat, lon];

            deleteAllMarkers();
            loadMap();      
        });
    });
}


function marcarPosiciones() {
   // alert("CargaMAPA");
    var lat, lon, myOptions;

    //check if user has geo feature
    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition(
        //get position
        function (position) {
            var lat = position.coords.latitude;
            var lon = position.coords.longitude;

            map.setCenter(new google.maps.LatLng(lat, lon));
          //  alert("typeof" + typeof (lon));
            var markers = [
                [comercioArray[0], parseFloat(comercioArray[1]).toPrecision(15), parseFloat(comercioArray[2]).toPrecision(15)],
                ["Usted está aquí", lat, lon]
            ];
            


            for (var i = 0; i < markers.length; i++) {
              // alert("nombre: " + markers[i][0] + " lat: " + markers[i][1] + " lon: " + markers[i][2]);
               marker = new google.maps.Marker({
                    position: new google.maps.LatLng(markers[i][1], markers[i][2]),
                    map: map,
                   title:markers[i][0]
               });
               allMarkers.push(marker);//se registra el marcador en el arreglo de marcadores
           
                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent(markers[i][0]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
            }
            
        },
        // if there was an error
        function (error) {
            alert(error.message);
        });
    }
        //case the users browser doesn't support geolocations
    else {
        alert("Your browser doesn't support geolocations, please consider downloading Google Chrome");
    }

}



function loadMap() {
    if (map == undefined) {
        initMap();//inicializa el mapa
    } else {
        marcarPosiciones();
    }
}

function setMarker(coords,etiqueta) {
    //alert(coords[0]+" "+ coords[1]+"MAP; "+map);
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(coords[0], coords[1]),
        map: map,
        draggable: false,
        animation: google.maps.Animation.DROP,
        title: etiqueta,
        icon: "http://maps.google.com/mapfiles/ms/micons/blue.png"
    });
    allMarkers.push(marker);//se registra el marcador en el arreglo de marcadores
}

function initMap() {
    var mapOptions = {
        center: new google.maps.LatLng(0, 0),
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("mapaComercio"),
                                      mapOptions);
    google.maps.event.addListenerOnce(map, 'idle', function () {
       
        completeLoaded = true;
        marcarPosiciones();
        
    });
}

//elimina todos los marcadores que hayan en el mapa
function deleteAllMarkers() {
    for (var i = 0; i < allMarkers.length; i++) {
        allMarkers[i].setMap(null);
    }
    allMarkers = [];//reinicia la lista de marcadores que hay en el mapa
}
