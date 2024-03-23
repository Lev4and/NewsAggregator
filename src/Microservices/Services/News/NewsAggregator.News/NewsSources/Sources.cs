using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class Sources : List<NewsSource>
    {
        public NewsSource this[string title]
        {
            get => this.Single(newsSource => newsSource.Title == title);
        }

        public NewsSource this[Uri uri]
        {
            get => this.Single(newsSource =>
                new Uri(newsSource.SiteUrl).GetDomain() == uri.GetDomain());
        }

        public Sources()
        {
            Add(new RiaNewsNewsSource());

            Add(new RussiaTodayNewsSource());

            Add(new TassNewsSource());

            Add(new LentaRuNewsSource());

            Add(new RussianGazetaNewsSource());

            Add(new AifNewsSource());

            Add(new RbcNewsSource());

            Add(new SportsRuNewsSource());

            Add(new KommersantNewsSource());

            Add(new IzvestiaNewsSource());

            Add(new TsargradNewsSource());

            Add(new BeltaNewsSource());

            Add(new SvobodnayaPressaNewsSource());

            Add(new Moscow24NewsSource());

            Add(new VzglyadNewsSource());

            Add(new ChampionatNewsSource());

            Add(new LifeNewsSource());

            Add(new _3DNewsNewsSource());

            Add(new IXbtNewsSource());

            Add(new IXbtGamesNewsSource());

            Add(new GazetaRuNewsSource());

            Add(new InterfaxNewsSource());

            Add(new PravdaRuNewsSource());

            Add(new UraNewsSource());

            Add(new _74RuNewsSource());

            Add(new PervyyOblastnoyNewsSource());

            Add(new CybersportRuNewsSource());

            Add(new HltvOrgNewsSource());

            Add(new TheNewYorkTimesNewsSource());

            Add(new CnnNewsSource());

            Add(new KomsomolskayaPravdaNewsSource());

            Add(new ZhurnalZaRulemNewsSource());

            Add(new AvtoVzglyadNewsSource());

            Add(new OverclockersNewsSource());

            Add(new KinoNewsRuNewsSource());

            Add(new _7DaysRuNewsSource());

            Add(new StarHitNewsSource());

            Add(new StopGameNewsSource());

            Add(new RenTvNewsSource());

            Add(new NovorossiyaNewsSource());

            Add(new _5TVNewsSource());

            Add(new NtvNewsSource());

            Add(new FontankaRuNewsSource());

            Add(new RegnumNewsSource());

            Add(new WomanHitRuNewsSource());

            Add(new RusskayaVesnaNewsSource());

            Add(new TravelAskNewsSource());

            Add(new SmartLabNewsSource());

            Add(new FinamRuNewsSource());

            Add(new KhlNewsSource());

            Add(new RadioSputnikNewsSource());

            Add(new MeduzaNewsSource());

            Add(new HuffPostNewsSource());

            Add(new FoxNewsNewsSource());

            Add(new PoliticoNewsSource());
        }
    }
}
