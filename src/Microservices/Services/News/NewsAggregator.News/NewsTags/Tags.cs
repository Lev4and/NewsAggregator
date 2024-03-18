using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class Tags : List<NewsTag>
    {
        public NewsTag this[string name]
        {
            get => this.Single(newsTag => newsTag.Name == name);
        }

        public Tags()
        {
            Add(new RussiaNewsTag());

            Add(new UsaNewsTag());

            Add(new UKNewsTag());

            Add(new RussianNewsTag());

            Add(new EnglishNewsTag());

            Add(new PoliticsNewsTag());

            Add(new SportNewsTag());

            Add(new KhlNewsTag());

            Add(new HockeyNewsTag());

            Add(new MoscowNewsTag());

            Add(new SaintPetersburgNewsTag());

            Add(new ChelyabinskNewsTag());

            Add(new BelarusNewsTag());

            Add(new TechnologiesNewsTag());

            Add(new InformationTechnologiesNewsTag());

            Add(new VideoGamesNewsTag());

            Add(new CybersportNewsTag());

            Add(new CounterStrikeNewsTag());

            Add(new NewYorkNewsTag());

            Add(new AutoNewsTag());

            Add(new ComputerHardwareNewsTag());

            Add(new MovieNewsTag());

            Add(new ShowBusinessNewsTag());

            Add(new TVNewsTag());

            Add(new WomanNewsTag());

            Add(new TravelNewsTag());

            Add(new EconomyNewsTag());

            Add(new FinanceNewsTag());

            Add(new RadioNewsTag());
        }
    }
}
