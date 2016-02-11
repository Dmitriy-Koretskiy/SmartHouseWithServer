function checkConfiguration() {
    $.ajax({
        url: '/Home/CheckConfiguration',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $.each(result, function (i, item) {
                $(".errorList").append($("<p></p>").html(item.RoomName + " " + item.DeviceName));
            });
        }
    });
}

$("button.checkConfig").click(checkConfiguration());
