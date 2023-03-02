$(function () {

    $('#us2').locationpicker({
        location: { latitude: 49.11270084710533, longitude: 31.926757812499993 },
        radius: 0,
        inputBinding: {
            latitudeInput: $('#lat'),
            longitudeInput: $('#lng'),
            locationNameInput: $('#location')
        },
        enableAutocomplete: true,
        //onchanged: function (currentLocation, radius, isMarkerDropped) {
        //    alert("Location changed. New location (" + currentLocation.latitude + ", " + currentLocation.longitude + ")");
        //}
    });


});
