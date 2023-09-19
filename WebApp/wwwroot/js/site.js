// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('click', '.search-filter', function () {    
    let filterValue = $("input[name = 'SearchString']").val();
    let filterName = 'rooms';
    $.get("/Apartment/Filter", { filterName: filterName, filterValue: filterValue }, function (data) {
        $(".table").html(data)
        let dataPoints = $(".dataPoints").data("points")
        dataPoints.forEach((e) => e.x = Date.parse(e.x))
        //Better to construct options first and then pass it as a parameter
        var options = {

            title: {
                text: "График медианы стоимости квартир"
            },
            axisX: {
                title: "Месяцы",
                valueFormatString: "MMM, YY",
                interval: 0,
                intervalType: "month",
                includeZero: true
            },
            axisY: {
                title: "Цена",
                suffix: " Руб",
                includeZero: true
            },
            animationEnabled: true,
            exportEnabled: false,
            yValueFormatString: "#,##0.##",
            data: [
                {
                    xValueType: "dateTime",
                    xValueFormatString: "MMM, YY",
                    type: "column", //change it to line, area, column, pie, etc
                    dataPoints: dataPoints
                }
            ]
        };
        $("#chartContainer").CanvasJSChart(options);
    });
});



window.onload = function () {
    
    let dataPoints = $(".dataPoints").data("points")
    dataPoints.forEach((e) => e.x = Date.parse(e.x))    
    //Better to construct options first and then pass it as a parameter
    var options = {
        
        title: {
            text: "График медианы стоимости квартир"
        },
        axisX: {
            title: "Месяцы",
            valueFormatString: "MMM, YY",
            interval: 1,
            intervalType: "month",
            includeZero: true
        },
        axisY: {
            title: "Цена",
            suffix: " Руб",
            includeZero: true
        },
        animationEnabled: true,
        exportEnabled: false,        
        yValueFormatString: "#,##0.##",        
        data: [
            {
                xValueType: "dateTime",
                xValueFormatString: "MMM, YY",
                type: "column", //change it to line, area, column, pie, etc
                dataPoints: dataPoints
            }
        ]
    };
    $("#chartContainer").CanvasJSChart(options);

}