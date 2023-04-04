document.addEventListener('DOMContentLoaded', function () {
    var alertDanger = document.querySelector('.alert-window');
    if (alertDanger) {
        setTimeout(function () {
            alertDanger.remove();
        }, 3000);
    }
});