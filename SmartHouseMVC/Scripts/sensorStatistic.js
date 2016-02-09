
function drowChart(dataArray) {

    var points = [];

    for (var i = 0; i < dataArray.length; i++) {
        var point = dataArray[i];
        var re = /-?\d+/;
        var m = re.exec(point.TimeMeasurement);
        var d = new Date(parseInt(m[0]));
        points.push({
            x: d,
            y: point.Value
        });
    }

    var chart = new CanvasJS.Chart("chartContainer",
    {
        title: {
            text: dataArray[0].SensorName
        },
        axisX: {
            title: "time",
            gridThickness: 2,
            interval: 2,
            //intervalType: "hour",
            valueFormatString: "hh mm ss",
            //  labelAngle: -20
        },
        axisY: {
            title: "Value"
        },

        data: [
		{
		    type: "splineArea", //change it to line, area, bar, pie, etc
		    dataPoints: points
		}
        ]
    });

    chart.render();
};

$(document).ready(function () {
    $("button.displayChartLastHour").click(function () {

        $.ajax({
            url: '/Room/GetSensorStatisticLastHour',
            type: 'GET',
            dataType: 'json',
            data: { sensorId: this.dataset.sensorid },
            success: function (result) {
                drowChart(result);
            }
        });

        $("#chartContainer").show();
    });

    $("button.displayChartThisDay").click(function () {

        $.ajax({
            url: '/Room/GetSensorStatisticThisDay',
            type: 'GET',
            dataType: 'json',
            data: { sensorId: this.dataset.sensorid },
            success: function (result) {
                drowChart(result);
            }
        });

        $("#chartContainer").show();
    });


    $("button.hideChart").click(function () {
        $("#chartContainer").hide();
    });
});