window.blazorHelpers = {
    closeModal: function (id) {
        var modalElement = document.getElementById(id);
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        if (modalInstance) {
            modalInstance.hide();
        }
    },
    openModal: function (id) {
        var modalElement = document.getElementById(id);
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        if (modalInstance) {
            modalInstance.show();
        } else {
            new bootstrap.Modal(modalElement).show();
        }
    }
};