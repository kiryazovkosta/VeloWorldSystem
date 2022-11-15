window.onload = function(event) {
    let confirmDeleteButton = document.getElementById('confirmDelete');
    let confirmUndeleteButton = document.getElementById('confirmUndelete');
    confirmDeleteButton.addEventListener("click", closeModal);
    confirmUndeleteButton.addEventListener("click", closeModal);
}

function setId(id) {
    document.getElementById('selectedId').value = id;
}

function closeModal(event) {
    console.log(event.target.id);
    const area = document.getElementById('areaName').value;
    const controller = document.getElementById('controllerName').value;
    const id = document.getElementById('selectedId').value;
    const action = event.target.id === 'confirmDelete' ? 'Delete' : 'Undelete';
    const dialog = event.target.id === 'confirmDelete' ? $("#deleteModal") : $("#undeleteModal");
    let url = `/${controller}/${action}/${id}`;
    if (area !== undefined && area !== "") {
        url = `/${area}${url}`
    }
    console.log(url);

    $.ajax({
        type: "POST",
        url: url,
        data: {id: id },
        success: function (result) {
            hide(dialog);
        },
        error: function () {
            hide(dialog);
        }
    });
}

function hide(display) {
    display.modal('hide');
    window.location.reload();
}