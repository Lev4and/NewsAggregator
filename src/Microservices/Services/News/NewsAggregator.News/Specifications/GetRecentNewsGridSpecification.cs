using NewsAggregator.Domain.Specification;

namespace NewsAggregator.News.Specifications
{
    public class GetRecentNewsGridSpecification : GridSpecificationBase<Entities.News>
    {
        public GetRecentNewsGridSpecification(GetRecentNewsGridSpecificationOptions options)
        {
            AddInclude(news => news.Editor);
            AddInclude(news => news.Editor.Source);
            AddInclude(news => news.Editor.Source.Logo);
            AddInclude(news => news.SubTitle);
            AddInclude(news => news.Picture);

            ApplyFilter(news => news.PublishedAt != null);

            if (options.PictureRequired)
            {
                ApplyFilter(news => news.Picture != null);
            }

            if (options.SubTitleRequired)
            {
                ApplyFilter(news => news.SubTitle != null);
            }

            ApplyOrderByDescending(news => news.PublishedAt);

            ApplyPaging(0, options.Take);
        }
    }

    public class GetRecentNewsGridSpecificationOptions
    {
        public int Take { get; }

        public bool PictureRequired { get; }

        public bool SubTitleRequired { get; }

        public GetRecentNewsGridSpecificationOptions(int take, bool pictureRequired, bool subTitleRequired)
        {
            Take = take;
            PictureRequired = pictureRequired;
            SubTitleRequired = subTitleRequired;
        }
    }
}
