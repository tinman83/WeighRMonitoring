
$(function () {

    GetReports();
    GetMachines();
    GetProducts();

    $('#reportsPara').on('change', function () {
        
        if (this.value == 'ProductionRunTimeReport' || this.value == 'MachinePerformanceReport') {
            $("#dtpDateTo").val("");
            $("#dtpDateTo").hide();
        } else {
            $("#dtpDateTo").show();
        }
    });
    

})

function GetReports() {

    var api_url = "/../api/Reports/GetReports";

    var parentId = ($('#ParentId').val() === "") ? '0' : $('#ParentId').val();

    var post_data = {
        "id": parentId
    };

    $.ajax({
        type: 'GET',
        url: api_url,
        data: post_data,
        dataType: 'json'
    })
     .done(function (data) {

         var reportsPara = $('#reportsPara');

         $('#reportsPara option').remove();

         reportsPara.append($("<option/>").val("").text("Select Report"));
         for (var i = 0; i < data.length; i++) {
             reportsPara.append($("<option/>").val(data[i].Name).text(data[i].Description));
             console.log(data[i]);
         }

     });

}

function GetProducts() {

    var api_url = "/../api/Product/GetProducts";

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

    var api_url = "/../api/Machine/GetMachines";

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