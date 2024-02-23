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

document.addEventListener('DOMContentLoaded', async function (e) {
    const hotlineHeaderLocalTimeElement = document.querySelector('.hotline-header__local-time strong');

    setInterval(() => {
        hotlineHeaderLocalTimeElement.innerHTML = new Date().toLocaleString('en-US');
    }, 250);

    const connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:5000/api/notification/news')
        .configureLogging(signalR.LogLevel.Information)
        .build();

    await connection.start();

    connection.on('AddedNews', (message) => {
        const hotlineContainer = document.querySelector('.hotline-container');

        hotlineContainer.insertAdjacentHTML('afterbegin', `
            <div class="hotline-container__item">
                <div class="hotline-container__item__added-time">
                    <strong data-bs-toggle="tooltip" data-bs-placement="top" data-bs-title="${new Date(message.addedAt).toLocaleTimeString('en-US')}">${new Date(message.addedAt).toLocaleTimeString('en-US')}</strong>
                </div>
                <div class="hotline-container__item__content">
                    <div class="hotline-container__item__content__news-source">
                        <a href="/sources/${message.editor?.source?.id}" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-title="${message.editor?.source?.title}">
                            <img class="hotline-container__item__content__news-source__logo" src="${message.editor?.source?.logo?.small}" />
                        </a>
                    </div>
                    <a class="hotline-container__item__content__news-title" href="/news/${message.id}" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-title="${message.title}">
                        ${message.title}
                    </a>
                </div>
            </div>
        `);
    });
});

const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));