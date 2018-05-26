var map;
var directionsDisplay; // Instanciaremos ele mais tarde, que será o nosso google.maps.DirectionsRenderer
var directionsService = new google.maps.DirectionsService();

function initialize() {   

    directionsDisplay = new google.maps.DirectionsRenderer(); // Instanciando...
    var latlng = new google.maps.LatLng(40.601203, -8.668173);

    var options = {
        zoom: 5,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map-canvas"), options);
    directionsDisplay.setMap(map); // Relacionamos o directionsDisplay com o mapa desejado
    
    var enderecoPartida = document.getElementById("startAddress").value; //$("#startAddress").val();//"Major João Batista lessa, 120"; //"@Model.StartAddress;//$("#txtEnderecoPartida").val();
    var enderecoChegada = document.getElementById("endAddress").value; //$("#endAddress").val();//"Cristovão Colombo, porto alegre";//@Model.EndAddress;//$("#txtEnderecoChegada").val();
    
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


  
  
