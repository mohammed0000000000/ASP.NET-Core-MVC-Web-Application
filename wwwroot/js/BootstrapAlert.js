function PresentClosableBootstrapAlert(placeHodlerElemId, alertType = "info", alertHeading, alertMsg) {
    var alertHtml = `<div class="alert alert-${alertType} alert-dismissible fade show" role="alert">
                <strong>${alertHeading}!</strong> ${alertMsg}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>`
    $(placeHodlerElemId).html(alertHtml);
}
function CloseAlert(placeHodlerElemId) {
    $(placeHodlerElemId).html("");
}