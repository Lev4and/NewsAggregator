using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsReactions
{
    public class Reactions : List<Reaction>
    {
        public Reactions()
        {
            Add(new AngryReaction());

            Add(new AstonishedReaction());

            Add(new FrownReaction());

            Add(new LaughingReaction());

            Add(new NeutralReaction());

            Add(new SmileReaction());

            Add(new SurpriseReaction());

            Add(new TearReaction());

            Add(new ThumbsDown());

            Add(new ThumbsUp());
        }
    }
}
