using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class MovieNewsTag : NewsTag
    {
        public MovieNewsTag()
        {
            Id = Guid.Parse("85e1d7f3-0150-48ac-9c29-17acec559f32");
            Name = "Movie";
        }
    }
}
