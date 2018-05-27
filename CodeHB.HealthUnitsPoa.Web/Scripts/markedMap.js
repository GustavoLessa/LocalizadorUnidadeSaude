var map;
var infoWindow;

function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(40.601203, -8.668173),//Lat e long de porto alegre
        zoom: 9,
        mapTypeId: 'roadmap',
    };

    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

    infoWindow = new google.maps.InfoWindow();

    //event listner para quando clicar no mapa fechar os detalhes da marcação
    google.maps.event.addListener(map, 'click', function () { 
        infoWindow.close();
    });

    displayMarkers();
}
google.maps.event.addDomListener(window, 'load', initialize);

// Esta função vai percorrer a informação contida na variável markersData
// e cria os marcadores através da função createMarker
function displayMarkers() {

    // esta variável vai definir a área de mapa a abranger e o nível do zoom
    // de acordo com as posições dos marcadores
    var bounds = new google.maps.LatLngBounds();

    $.ajax({
        url: '/Maps/GetPins/', // aqui vai a URL do método
        dataType: 'json',
        success: function (response) {
            for (var i = 0; i < response.length; i++) {

                var latlng = new google.maps.LatLng(response[i].Latitude, response[i].Longitude);
                var name = response[i].Name;
                var phone = response[i].Phone;
                var address = response[i].Address;

                createMarker(latlng, name, phone, address);

                // Os valores de latitude e longitude do marcador são adicionados à
                // variável bounds
                bounds.extend(latlng);
            }

            // Depois de criados todos os marcadores,
            // a API, através da sua função fitBounds, vai redefinir o nível do zoom
            // e consequentemente a área do mapa abrangida de acordo com
            // as posições dos marcadores
            map.fitBounds(bounds);
        }
    });


    // Depois de criados todos os marcadores
    // a API através da sua função fitBounds vai redefinir o nível do zoom
    // e consequentemente a área do mapa abrangida.
    //map.fitBounds(bounds);
}

// Função que cria os marcadores e define o conteúdo de cada Info Window.
function createMarker(latlng, name, phone, address) {
    var marker = new google.maps.Marker({
        map: map,
        position: latlng,
        title: name
    });

    // Evento que dá instrução à API para estar alerta ao click no marcador.
    // Define o conteúdo e abre a Info Window.
    google.maps.event.addListener(marker, 'click', function () {

        // Variável que define a estrutura do HTML a inserir na Info Window.
        var iwContent = '<div id="iw_container">' +
            '<div class="iw_title"><b>' + name + '</b></div>' +
            '<div class="iw_content">' + phone + '<br />' +
            address + '</div></div>';

        // O conteúdo da variável iwContent é inserido na Info Window.
        infoWindow.setContent(iwContent);

        // A Info Window é aberta.
        infoWindow.open(map, marker);
    });
}