const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

function onClickSearchNewsFromModal() {
    document.querySelector('form[id="searchNewsModalForm"]').submit();
}