document.addEventListener('DOMContentLoaded', async function (e) {
    const timeElements = document.querySelectorAll('time[datetime][format]');

    if (timeElements) {
        timeElements.forEach(function (timeElement) {
            const dateTime = timeElement.getAttribute('datetime');
            const dateTimeFormat = timeElement.getAttribute('format');
            timeElement.innerHTML = ` ${moment(dateTime, 'DD-MM-YYYYTHH:mm:ssZ').local().format(dateTimeFormat)} `;
        });
    }
})