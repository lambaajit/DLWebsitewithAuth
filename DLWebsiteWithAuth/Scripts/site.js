$(document).ready(function () {
    $("#submit").on("click", function () {
        var isChecked = $("#Terms").is(":checked");
        if (isChecked == false) {
            alert("CheckBox not checked.");
            return false;
        }
        return true;
    });

});
