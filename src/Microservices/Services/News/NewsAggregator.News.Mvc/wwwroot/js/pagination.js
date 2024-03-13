document.addEventListener('DOMContentLoaded', function (e) {
    var pagination = document.querySelector('nav[aria-label="Page navigation"]');
    var paginationButtons = pagination?.querySelectorAll('a.page-link[data-form-id][data-page]');

    if (paginationButtons) {
        paginationButtons.forEach(function (button) {
            button.addEventListener('click', function () {
                const form = document.querySelector(`form[id="${button.getAttribute('data-form-id')}"]`);
                const formSubmitButton = form.querySelector('button[type="submit"]');
                const formPageHiddenInput = form.querySelector('input[type="hidden"][name="page"]');

                formPageHiddenInput.setAttribute('value', button.getAttribute('data-page'));

                formSubmitButton.click();
            });
        });
    }
});