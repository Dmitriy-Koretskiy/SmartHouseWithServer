function checkConfiguration() {
    $.ajax({
        url: '/Home/CheckConfiguration',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $(".errorList").empty();
            $.each(result, function (i, item) {
                $(".errorList").append($("<p></p>").html("<b>Room name: </b>" + item.RoomName + "  <b>Device:</b> " + item.DeviceName));
            });
        }
    });
}

function refresh() {
    $.ajax({
        url: '/Home/RefreshConfiguration',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $(".errorList").empty();
            $.each(result, function (i, item) {
                $(".errorList").append($("<p></p>").html("<b>Room name: </b>" + item.RoomName + "  <b>Device:</b> " + item.DeviceName));
            });
        }
    });
}

$("#checkConfig").click(function () {
    checkConfiguration();
});

$("#refreshConfig").click(function () {
    refresh();

});
