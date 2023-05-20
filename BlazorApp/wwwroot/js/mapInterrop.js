let maps = {};

function initializeLeafletMap(mapId) {
    let map = L.map(mapId).setView([45.750000, 4.850000], 13); // Coordonnées de Lyon
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
    maps[mapId] = map;
}

function addMarkerToMap(mapId, id, latitude, longitude, adress, nbVoitures ,nbPlacesLibre) {
    let marker = L.marker([latitude, longitude]).addTo(maps[mapId]);
    marker.bindPopup(`<strong>Adresse :</strong> ${adress}<br>
                     <strong>Nombre de voitures libres :</strong> ${nbVoitures}<br>
                     <strong>Nombre de places :</strong> ${nbPlacesLibre}`);
}