$(document).ready(function () {
    $(".show-button").click(function ()
    {
        if (document.getElementById("hidden-text").getAttribute("class") == "panel-body hidden") {
            document.getElementById("hidden-text").setAttribute("class", "panel-body show");
        } else {
            document.getElementById("hidden-text").setAttribute("class", "panel-body hidden");
        }
    });
})
