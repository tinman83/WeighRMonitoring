google.charts.load('current', { 'packages': ['corechart', 'line', 'gauge'] });
google.charts.setOnLoadCallback(function () {
    GetDensityTrend();
    GetKpis();
});
$(function () {

    GetMachines();
    GetProducts();
    GetDashboard();

    $('#machinesPara').on('change', function () {
        GetDashboard();
        GetKpis();
    });

    $('#productsPara').on('change', function () {
        GetDashboard();
        GetDensityTrend();
        GetKpis();
    });

    $('#durationPara').on('change', function () {
        GetDashboard();
        GetDensityTrend();
        GetKpis();
    });


    setInterval(function () {
        GetDashboard();
        GetDensityTrend();
        GetKpis();
    }, 60 * 1000); // 60 * 1000 milsec

})

function GetProducts() {

    var api_url = "api/Product/GetProducts";

    var post_data = {
    };


    $.ajax({
        type: 'GET',
        url: api_url,
        data: post_data,
        dataType: 'json'
    })
     .done(function (data) {

         var productsPara = $('#productsPara');

         $('#productsPara option').remove();

         productsPara.append($("<option/>").val("All").text("All Products"));
         for (var i = 0; i < data.length; i++) {
             productsPara.append($("<option/>").val(data[i].ProductCode).text(data[i].Name));
             console.log(data[i]);
         }

     });

}


function GetMachines() {

    var api_url = "api/Machine/GetMachines";

    var post_data = {
    };


    $.ajax({
        type: 'GET',
        url: api_url,
        data: post_data,
        dataType: 'json'
    })
     .done(function (data) {

         var machinesPara = $('#machinesPara');

         $('#machinesPara option').remove();

         machinesPara.append($("<option/>").val("All").text("All Filling Machines"));
         for (var i = 0; i < data.length; i++) {
             machinesPara.append($("<option/>").val(data[i].MachineName).text(data[i].MachineName));
         }

     });

}

function GetDashboard() {

    var clientId = ($('#ClientId').val() === "") ? 'test@techcentre.cloresol.com' : $('#ClientId').val();
    var plant = "All";
    var machine = ($('#machinesPara').val() === "") ? 'All' : $('#machinesPara').val();
    var productCode = ($('#productsPara').val() === "") ? 'All' : $('#productsPara').val();
    var duration = ($('#durationPara').val() === "") ? '0' : $('#durationPara').val();
    var dateFrom = null;
    var dateTo = null;

    var para = new DashboardParameters(clientId,plant, machine, productCode, duration, dateFrom, dateTo);

    $.ajax({
        type: 'POST',
        url: "api/Dashboard",
        data: JSON.stringify(para),
        contentType: 'application/json',
    })
     .done(function (data) {

         $("#numberOfUnits").text(data.Units);
         $("#totalWeight").text(data.ActualWeight.toFixed(2));
         $("#tagetWeight").text(data.RequiredWeight.toFixed(2));
         $("#averageTargetWeightDiviation").text(data.PercDiffWeight.toFixed(2));
         $("#averageWeight").text(data.AverageWeight.toFixed(2));

     });

    

}

function GetDensityTrend() {

    var clientId = ($('#ClientId').val() === "") ? 'test@techcentre.cloresol.com' : $('#ClientId').val();
    var plant = "All";
    var machine = ($('#machinesPara').val() === "") ? 'All' : $('#machinesPara').val();
    var productCode = ($('#productsPara').val() === "") ? 'All' : $('#productsPara').val();
    var duration = ($('#durationPara').val() === "") ? '0' : $('#durationPara').val();
    var dateFrom = null;
    var dateTo = null;

    var para = new DashboardParameters(clientId, plant, machine, productCode, duration, dateFrom, dateTo);

    $.ajax({
        type: 'POST',
        url: "api/DensityTrend",
        data: JSON.stringify(para),
        contentType: 'application/json',
    })
     .done(function (data) {

         console.log(data);
         drawDensityTrendlines(data);

     });

}

function GetKpis() {

    var clientId = ($('#ClientId').val() === "") ? 'test@techcentre.cloresol.com' : $('#ClientId').val();
    var plant = "All";
    var machine = ($('#machinesPara').val() === "") ? 'All' : $('#machinesPara').val();
    var productCode = ($('#productsPara').val() === "") ? 'All' : $('#productsPara').val();
    var duration = ($('#durationPara').val() === "") ? '0' : $('#durationPara').val();
    var dateFrom = null;
    var dateTo = null;

    var para = new DashboardParameters(clientId, plant, machine, productCode, duration, dateFrom, dateTo);

    $.ajax({
        type: 'POST',
        url: "api/KPIReport",
        data: JSON.stringify(para),
        contentType: 'application/json',
    })
     .done(function (data) {

         console.log(data);
         drawKPIGauges(data);

     });

}

function DashboardParameters(clientId,plant, fillingMachine, productCode, duration, dateFrom, dateTo) {

    this.ClientId = clientId;
    this.Plant=plant ;
    this.FillingMachine = fillingMachine;
    this.ProductCode =productCode ;
    this.Duration = duration;
    this.DateFrom =dateFrom ;
    this.DateTo = dateTo;

}


function drawDensityTrendlines(dt) {

    var data = new google.visualization.DataTable();

    data.addColumn('string', 'Batch Code');
    data.addColumn('number', 'Density');

    var tableRows = Array();
    for (var i = 0; i < dt.length; i++) {
        var dataRow = dt[i];
        var row = [dataRow.BatchCode, dataRow.avgDensity];
        console.log(row);
        tableRows.push(row);
    }

    data.addRows(tableRows);

    var options = {
        legend: { position: 'none' },
        hAxis: {
            title: 'Batch Code',
        },
        vAxis: {
            title: 'Density',
        }
    };

    var chart = new google.visualization.LineChart(document.getElementById('density_chart'));
    chart.draw(data, options);

}

function drawKPIGauges(dt) {

    var data = google.visualization.arrayToDataTable([
      ['Label', 'Value'],
      ['Precision', dt.Precision],
      ['Performance', dt.Performance],
      ['Efficiency', dt.Efficiency]
    ]);

    var options = {
        height: 120,
        redFrom: 90, redTo: 100,
        yellowFrom: 75, yellowTo: 90,
        minorTicks: 5
    };

    var chart = new google.visualization.Gauge(document.getElementById('equipmentEffectiveness_div'));

    chart.draw(data, options);

}