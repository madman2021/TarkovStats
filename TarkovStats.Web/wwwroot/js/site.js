$(document).ready(function () {
    $("#map-Factory").focus();
    $("#map-header").toggleClass("bg-primary", true);
    $(".radio-by-number").keyup(function (key) {
        var group = $(this.parentNode);
        var numberPressed = String.fromCharCode(key.keyCode);
        var number = parseInt(numberPressed);

        if (isNaN(number)) {
            return;
        }
        var inputs = group.find("input");
        if (number > 0 && number <= inputs.length) {
            var item = inputs[number - 1];
            item.checked = true;
            if(group[0].id==="maps"){
                $("#Input_ExpTotal").focus();
            }
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