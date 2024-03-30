document.addEventListener('DOMContentLoaded', function (e) {
    var newsReactionsContainer = document.querySelector('div.news-reactions');
    var newsReactions = newsReactionsContainer?.querySelectorAll('div.news-reactions__reaction[data-reaction-newsId][data-reaction-id]');

    if (newsReactions) {
        newsReactions.forEach(function (newsReactionElement) {
            newsReactionElement.addEventListener('click', async function () {
                var newsId = newsReactionElement.getAttribute('data-reaction-newsId');
                var reactionId = newsReactionElement.getAttribute('data-reaction-id');

                try {
                    await axios.post(`http://${window.location.hostname}/news/${newsId}/sendNewsReaction?reactionId=${reactionId}`);
                    alert('Sending a reaction to the news was successful.');
                } catch (error) {
                    alert('An error occurred when sending a reaction to the news');
                }
            });
        });
    }
});