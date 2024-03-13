document.addEventListener('DOMContentLoaded', function (e) {
    var searchNewsModal = document.querySelector('div.modal#searchNewsModal');
    var searchNewsModalSubmit = searchNewsModal.querySelector('button.btn-primary');
    searchNewsModalSubmit.addEventListener('click', function () {
        searchNewsModal.querySelector('form#searchNewsModalForm').submit();
    });
});