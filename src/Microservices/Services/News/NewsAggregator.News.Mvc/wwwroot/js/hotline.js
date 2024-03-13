document.addEventListener('DOMContentLoaded', async function (e) {
    const hotlineHeaderLocalTimeElement = document.querySelector('.hotline-header__local-time strong');

    if (hotlineHeaderLocalTimeElement) {
        setInterval(() => {
            hotlineHeaderLocalTimeElement.innerHTML = moment().format('h:mm:ss A');
        }, 250);

        const connection = new signalR.HubConnectionBuilder()
            .withUrl(`http://${window.location.hostname}/api/notification/news`)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        await connection.start();

        connection.on('AddedNews', (message) => {
            const hotlineContainer = document.querySelector('.hotline-container');

            hotlineContainer.insertAdjacentHTML('afterbegin', `
                <div class="hotline-container__item">
                    <div class="hotline-container__item__added-time">
                        <strong data-bs-toggle="tooltip" data-bs-placement="top" data-bs-title="${new Date(message.addedAt).toUTCString()}">${new Date(message.addedAt).toLocaleTimeString('en-US')}</strong>
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

            const tooltipTriggerList = hotlineContainer.querySelectorAll('[data-bs-toggle="tooltip"]');
            const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));
        });
    }
});