var map;
var directionsDisplay; 
var directionsService = new google.maps.DirectionsService();

function initialize() {   

    directionsDisplay = new google.maps.DirectionsRenderer(); // Instanciando...
    var latlng = new google.maps.LatLng(40.601203, -8.668173);//Lat e long de porto alegre

    var options = {
        zoom: 5,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map-canvas"), options);
    directionsDisplay.setMap(map); // Relaciona o directionsDisplay com o mapa desejado
    directionsDisplay.setPanel(document.getElementById("trajeto-texto")); // Mostra o mapa de direções

    var enderecoPartida = document.getElementById("startAddress").value;
    var enderecoChegada = document.getElementById("endAddress").value;
    
    var request = { // Novo objeto google.maps.DirectionsRequest, contendo:
        origin: enderecoPartida, // origem
        destination: enderecoChegada, // destino
        travelMode: google.maps.TravelMode.DRIVING // meio de transporte, nesse caso, de carro
    };

    directionsService.route(request, function (result, status) {
        if (status == google.maps.DirectionsStatus.OK) { // Se deu tudo certo
            directionsDisplay.setDirections(result); // Renderizamos no mapa o resultado
        }
    });
}

initialize();


  
  
