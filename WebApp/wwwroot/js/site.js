// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('click', '.search-filter', function () {    
    let filterValue = $("input[name = 'SearchString']").val();
    let filterName = 'rooms';
    $.get("/Apartment/Filter", { filterName: filterName, filterValue: filterValue }, function (data) {
        $(".table").html(data)
    });
});