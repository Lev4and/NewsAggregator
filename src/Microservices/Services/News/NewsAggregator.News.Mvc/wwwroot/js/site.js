document.addEventListener('DOMContentLoaded', function (e) {
    var searchNewsModal = document.querySelector('div.modal#searchNewsModal');
    var searchNewsModalSubmit = searchNewsModal.querySelector('button.btn-primary');
    searchNewsModalSubmit.addEventListener('click', function () {
        searchNewsModal.querySelector('form#searchNewsModalForm').submit();
    });
});

document.addEventListener('DOMContentLoaded', function (e) {
    var pagination = document.querySelector('nav[aria-label="Page navigation"]');
    var paginationButtons = pagination?.querySelectorAll('a.page-link[data-form-id][data-page]');
    paginationButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            const form = document.querySelector(`form[id="${button.getAttribute('data-form-id')}"]`);
            const formSubmitButton = form.querySelector('button[type="submit"]');
            const formPageHiddenInput = form.querySelector('input[type="hidden"][name="page"]');

            formPageHiddenInput.setAttribute('value', button.getAttribute('data-page'));

            formSubmitButton.click();
        });
    });
});

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));