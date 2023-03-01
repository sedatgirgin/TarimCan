//import "../../../global/plugins/bootbox/bootbox.min.js";

function ShowErrorMessageBox(message) {
    bootbox.dialog({
        message: message,
        title: "Hata !", buttons: {
            danger: { label: "Tamam", className: "red" }
        }
    });
}

function ShowInfoFunctionBox(message) {
    bootbox.dialog({
        message: message,
        title: "Bilgi !", buttons: {
            danger: { label: "Tamam", className: "orange" }
        }
    });
}

