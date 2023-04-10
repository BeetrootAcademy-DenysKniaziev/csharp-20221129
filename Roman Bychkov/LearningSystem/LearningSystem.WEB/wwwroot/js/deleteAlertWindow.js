document.addEventListener('DOMContentLoaded', function () {
    var alertDanger = document.querySelector('.alert-window');
    if (alertDanger) {
        setTimeout(function () {
            if (alertDanger.parentNode) {
                alertDanger.parentNode.removeChild(alertDanger);
            }
        }, 3000);
    }
});