$(document).ready(function () {
    $("#map-Factory").focus();
    $("#map-header").toggleClass("bg-primary", true);
    $(".map-selector").keyup(function (key) {
        var numberPressed = String.fromCharCode(key.keyCode);

        var number = parseInt(numberPressed);

        if (isNaN(number)) {
            return;
        }

        if (number > 0 && number <= 9) {
            var map = $("#maps").find("input")[number - 1];
            map.checked = true;
            $("#Input_PmcKills").focus();
        }
    });

    $(".map-selector").focusin(function () {
        $("#map-header").toggleClass("bg-primary", true);
        $("#map-info").show();
    });
    $(".map-selector").focusout(function () {
        $("#map-header").toggleClass("bg-primary", false);
        $("#map-info").hide();
    });
    $(".stat").focusin(function () {
        $("#stat-header").toggleClass("bg-primary", true);
    });
    $(".stat").focusout(function () {
        $("#stat-header").toggleClass("bg-primary", false);
    });
    $(".result").focusout(function () {
        $("#result-header").toggleClass("bg-primary", false);
    });
    $(".result").focusin(function () {
        $("#result-header").toggleClass("bg-primary", true);
    });

    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
    
});

function confirmDelete(e)
{
    if(!confirm("Are you sure you want to delete the selected item?")){
        console.log("not confirm");
        e.preventDefault();
    }
}