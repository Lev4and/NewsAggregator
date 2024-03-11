using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsTags
{
    public class Tags : List<NewsTag>
    {
        public const string RussiaNewsTag = "Russia";
        public const string UsaNewsTag = "USA";
        public const string UKNewsTag = "UK";
        public const string RussianNewsTag = "Russian";
        public const string EnglishNewsTag = "English";
        public const string PoliticsNewsTag = "Politics";
        public const string SportNewsTag = "Sport";
        public const string KhlNewsTag = "KHL";
        public const string HockeyNewsTag = "Hockey";
        public const string MoscowNewsTag = "Moscow";
        public const string SaintPetersburgNewsTag = "Saint-Petersburg";
        public const string ChelyabinskNewsTag = "Chelyabinsk";
        public const string BelarusNewsTag = "Belarus";
        public const string TechnologiesNewsTag = "Technologies";
        public const string InformationTechnologiesNewsTag = "IT";
        public const string VideoGamesNewsTag = "Video games";
        public const string CybersportNewsTag = "Cybersport";
        public const string CounterStrikeNewsTag = "Counter Strike";
        public const string NewYorkNewsTag = "New York";
        public const string AutoNewsTag = "Auto";
        public const string ComputerHardwareNewsTag = "Computer hardware";
        public const string MovieNewsTag = "Movie";
        public const string ShowBusinessNewsTag = "Show business";
        public const string TVNewsTag = "TV";
        public const string WomanNewsTag = "Woman";
        public const string TravelNewsTag = "Travel";
        public const string EconomyNewsTag = "Economy";
        public const string FinanceNewsTag = "Finance";
        public const string RadioNewsTag = "Radio";

        public NewsTag this[string name]
        {
            get => this.Single(newsTag => newsTag.Name == name);
        }

        public Tags()
        {
            Add(new NewsTag
            {
                Id = Guid.Parse("9503b07f-c97a-49e7-b177-97e3a293dc31"),
                Name = RussiaNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("f06891c5-6324-4bab-b836-a78a4d2c603d"),
                Name = UsaNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("cbb60009-18c3-479b-a09a-cfe976fb5abd"),
                Name = UKNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("d57fa572-a720-432c-a372-b8ade1a7edff"),
                Name = RussianNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("8e8ec992-5b4b-43d9-b290-73fbfcd8a32e"),
                Name = EnglishNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("302d7e19-c80f-4e1a-8877-3e9b17f9baeb"),
                Name = PoliticsNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("6c939d6c-0461-46c8-b9b6-83021b68df71"),
                Name = SportNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("3afdf0a8-2504-4436-8483-2b9566b881f2"),
                Name = KhlNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("aa8de58c-f61f-4b4c-ad4c-ff05245e052c"),
                Name = HockeyNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("9f2effc4-5f9d-419a-83a9-598c41afc2b8"),
                Name = MoscowNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("6fc28243-4b6e-4013-8121-0bc4d8397552"),
                Name = SaintPetersburgNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("54d48566-0e56-4e41-a2c6-35f71d9e35fe"),
                Name = ChelyabinskNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("5654a834-6f9a-4caa-a153-d4644204001c"),
                Name = BelarusNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("b99b8260-8eb2-4a30-8d59-2f251a83e68c"),
                Name = TechnologiesNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("529cd044-c4fe-4c50-8748-080584a48d12"),
                Name = InformationTechnologiesNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("2139e644-a9fa-49ce-8eea-7380e7936527"),
                Name = VideoGamesNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("4c65a245-2631-47ed-a84d-e4699e9a997c"),
                Name = CybersportNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("cfa03d74-4386-4e3f-a841-bb6498a02adc"),
                Name = CounterStrikeNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("e0a5af2c-cb45-40da-90d7-7ba59c662bcb"),
                Name = NewYorkNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("464a2260-130c-4a4b-8aa6-4f477cd1760f"),
                Name = AutoNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("34cc1d82-002a-4c8c-b783-e46d9c88dde5"),
                Name = ComputerHardwareNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("85e1d7f3-0150-48ac-9c29-17acec559f32"),
                Name = MovieNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("bcc08307-a922-4de1-aa17-8ff9dc438425"),
                Name = ShowBusinessNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("ae20fd4f-a451-42cb-aae6-875d0bfacaa7"),
                Name = TVNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("2e2cf727-d007-4293-8f2c-f8e54baf06ce"),
                Name = WomanNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("f74ca29a-e9bc-4111-94d7-ebe5beccd72c"),
                Name = TravelNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("47ea1951-5508-4647-a805-138a861974ff"),
                Name = EconomyNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("19db4d3d-b17a-45ff-9853-cdce9630c08f"),
                Name = FinanceNewsTag
            });

            Add(new NewsTag
            {
                Id = Guid.Parse("4aaeef66-ae04-4d75-8920-72fb30031c53"),
                Name = RadioNewsTag
            });
        }
    }
}
