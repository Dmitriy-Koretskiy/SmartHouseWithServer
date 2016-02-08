
    function refreshTriggerState() {
        $(".lastState").each(function () {
            var id = this.id;
           
            $.ajax({
                url: '/Room/RefreshTriggerState',
                type: 'GET',
                dataType: 'json',
                data: { triggerId: id },
                success: function (result) {
                    $("#" + id +".lastState").html(result);
                }
            })
        });
    }

    $(document).ready(function () {

     //  refreshTriggerState(); 

        window.setInterval("refreshTriggerState()", 2000);

    });
