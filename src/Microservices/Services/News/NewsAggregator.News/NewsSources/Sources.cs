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
            Add(new NewsSource
            {
                Id = Guid.Parse("b8d20577-6c4c-4bd7-a1b1-b58bb4914541"),
                Title = "РИА Новости",
                SiteUrl = "https://ria.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("a0faaf8f-34af-43f7-af18-782f9c6214d4"),
                    Small = "https://cdnn21.img.ria.ru/i/favicons/favicon.ico",
                    Original = "https://cdnn21.img.ria.ru/i/favicons/favicon.svg"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("aec9b965-2433-4bf0-ac3d-0f01775a6a75"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b246f291-1cb3-42fc-904c-fdca50162d28"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3f0c3643-d21d-4e8e-bf55-a01b42011215"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("9d11efde-ae9c-42a7-ac57-649bf5891e8a"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]",
                    TextDescriptionXPath = "//div[contains(@class, 'article__body')]//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("28112804-6fee-47fe-ad2e-9cdf4e982a82"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("f3733384-2b0f-4b5e-bf44-040e6452b896"),
                        UrlXPath = "//div[@class='article__header']//div[@class='media__video']//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("5118a64e-b1fe-4226-b0f6-da9d0eb13ed0"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("b5afbf6f-9a28-4814-8ec0-80b43048c284"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("fdae85e3-de1e-4d29-a496-fa6ffedc616a"),
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("3c897305-c4ad-42b1-9cb8-a550d075139c"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("c4c8a06a-a104-4e0e-87d1-4fa02bdfa36a"),
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("bea34033-d382-4e18-9957-ad079cdb9a61"),
                    NewsSiteUrl = "https://ria.ru/",
                    NewsUrlXPath = "//a[contains(@class, 'cell-list__item-link')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("5d8e3050-5444-4709-afc3-18a8d46a71ba"),
                Title = "RT на русском",
                SiteUrl = "https://russian.rt.com/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("021335ce-8d6b-47fc-9de8-503f4c248982"),
                    Small = "https://russian.rt.com/favicon.ico",
                    Original = "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4cac9f6e-f034-4600-8272-a04aeca7f0b4"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("dd4ff481-d8d3-410d-ad32-e39cf572071d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c549c18b-8e40-4196-b6d7-ff9c9cb516ba"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("da641510-f1dd-4fce-b895-cbf32dca79bf"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__text ')]",
                    TextDescriptionXPath = "//div[contains(@class, 'article__text ')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("0c0b371b-5c93-4577-b625-7d520237ce5d"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("3b81d060-ce40-45bb-8ceb-81c10e88e2a8"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("e1a6a4f1-57ab-48e6-aaee-b9ece2104cf3"),
                        NameXPath = "//meta[@name='mediator_author']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("a17cf1af-be32-4074-9b36-6f5481ecbf14"),
                        PublishedAtXPath = "//meta[@name='mediator_published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("56366b43-4d17-44a6-9bdd-1cb63ec7dcfb"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("84cb0a27-b2ef-4cd4-93d2-fcb0fdecf1d0"),
                    NewsSiteUrl = "https://russian.rt.com/",
                    NewsUrlXPath = "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("7e889af8-0f19-44ab-96d4-241fd64fbcdb"),
                Title = "ТАСС",
                SiteUrl = "https://tass.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("29e9a963-8850-4c05-9714-a4b59af20be4"),
                    Small = "https://tass.ru/favicon/57.png",
                    Original = "https://tass.ru/favicon/180.svg"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("bc9d7be6-2e7e-4b7c-9859-b8047ce7ef81"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("20725e40-3f1d-4089-8d74-9d08ae3f127d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("33e821e2-c90d-45ed-a905-269ca20bf28f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("28bff881-79f7-400c-ab5d-489176c269bb"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/*",
                    TextDescriptionXPath = "//article/*//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("afb5bb1e-5cb0-4176-b2e0-99f6efb399dd"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("c8a3d258-c774-4ac2-85ae-08f7ede167d4"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("076e2817-f0e0-4f4a-ae55-08210a7e1a7d"),
                        PublishedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "UTC",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("da39c45c-178d-4b8c-8944-9d77de2690d0"),
                                Format = "d MMMM yyyy, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("2f4dba30-cd44-4a34-a28b-50d3d6db53d1"),
                                Format = "d MMMM yyyy, HH:mm,"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("509eae6c-481c-4a9d-9a9a-bd20b2ae533e"),
                                Format = "d MMMM, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("3d264810-c568-4d66-9762-43c1467a6cd2"),
                                Format = "d MMMM, HH:mm,"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("307744f1-4338-481a-b849-b8d88c196cc3"),
                        ModifiedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "UTC",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("4084a0b1-75dd-4ab0-9b43-d2d569dfc7c7"),
                                Format = "\"обновлено\" d MMMM yyyy, HH:mm"
                            },
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("61a158be-a01d-42c1-a474-2bbc66775a60"),
                                Format = "\"обновлено\" d MMMM, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("022c7083-ea41-4e42-b40e-a0d72dfb7956"),
                    NewsSiteUrl = "https://tass.ru/",
                    NewsUrlXPath = "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275"),
                Title = "Лента.Ру",
                SiteUrl = "https://lenta.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("ef6ba8cf-50e4-432b-9329-19097bff75e2"),
                    Small = "https://icdn.lenta.ru/favicon.ico",
                    Original = "https://icdn.lenta.ru/images/icons/icon-256x256.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("585e40dd-ec2b-41b6-b505-59603e1031f8"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("5178aad8-b861-4640-afc6-c3bd1749ae94"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3e8627f0-f07d-4cab-a30b-08282bbdf928"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='topic-body__content']",
                    TextDescriptionXPath = "//div[@class='topic-body__content']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("6718a708-10eb-4943-be1b-5be29565414f"),
                        NameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("d5de3a68-32d4-4553-ae39-ad3eb1509cc5"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("55100c78-3692-482c-af91-808f1a4f29a4"),
                        UrlXPath = "//div[contains(@class, 'eagleplayer')]//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("527db9fa-2e2a-4f4e-b9eb-b9055994211f"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("b2514b4f-e07a-44e1-977b-9013bd07ea0c"),
                        PublishedAtXPath = "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("013ad3fa-fc09-4bce-a62a-5b23dfaf4b55"),
                                Format = "HH:mm, d MMMM yyyy"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("25667b44-614f-4c19-ad74-3be0c5f8c743"),
                    NewsSiteUrl = "https://lenta.ru/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("31b6f068-3f00-4250-bc74-62146525ba95"),
                Title = "Российская газета",
                SiteUrl = "https://rg.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("f1b5322f-8f12-4a8d-ba28-ee5aaed34228"),
                    Small = "https://rg.ru/favicon.ico",
                    Original = "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("5385f93d-42d7-4798-9868-d5c75a86fd8f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("000a5ecc-fee2-486f-88de-ca43ce445849"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("33e60843-feb6-4f42-b171-b5dbd423ed3b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("52014d82-bd2b-47fb-9ba1-668df2126197"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]",
                    TextDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("8e018d32-828c-478d-a19f-8a06fd1fa797"),
                        NameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("0ae45f17-84aa-42b2-801b-ff153d8d99b1"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("8bface35-e140-4937-8b51-06597bcfc862"),
                        UrlXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("f179e895-457c-4ccf-88ff-b4562edb1f33"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("e07f5d48-7c9a-4425-ae9f-788d26a63f23"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("bd0d7dc4-64d5-4daa-a89d-ca0609a09d29"),
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("90f502b6-e728-4f0a-b937-c264a9e683fd"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("a622e5c8-becb-44ac-809b-89da6191fa11"),
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("938c857a-640d-413d-98bf-1f5c1872dbae"),
                    NewsSiteUrl = "https://rg.ru/",
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("9268835d-553d-4fbe-a0cb-0545b8019c68"),
                Title = "Аргументы и факты",
                SiteUrl = "https://aif.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("3472a1e0-4bf9-418a-8e9e-94830248020b"),
                    Small = "https://aif.ru/img/icon/favicon-32x32.png?44f",
                    Original = "https://aif.ru/img/icon/apple-touch-icon.png?44f"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("7c4772ef-afbb-4264-92b5-77389e8c0990"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("d194cd94-eb02-471e-900c-2f298405b7c5"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3241b406-31e8-41a2-b9cd-efc585789d48"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article_text']",
                    TextDescriptionXPath = "//div[@class='article_text']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("17461131-afc7-41bd-af3b-0f2cda2dd935"),
                        NameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("de397d9b-55d7-45f3-b03b-66584a58d137"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("c8d55c4c-0a8b-4133-b85d-6ca0df5a5671"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("21890de7-31ad-4c9e-a749-05f565d45905"),
                        PublishedAtXPath = "//div[@class='article_top']//div[@class='date']//time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("098793a2-d99d-494b-afba-e727e26214b7"),
                                Format = "dd.MM.yyyy HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("1dde178c-c061-428a-b0e3-1d7b7ddc5c7b"),
                    NewsSiteUrl = "https://aif.ru/",
                    NewsUrlXPath = "//span[contains(@class, 'item_text__title')]/../@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("950d59d6-d94c-4396-a55e-cbcd2a9b533c"),
                Title = "РБК",
                SiteUrl = "https://www.rbc.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("a77ffd9e-beb2-43d6-bf02-94ad9bc1eccd"),
                    Small = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png",
                    Original = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a1ba384a-04c5-4886-a113-36d86fc8cf60"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("75e4331e-76d5-48d0-998b-0765b6b7854d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c7585125-4dbc-4b56-aa3a-422a96ade9fb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("929687ee-eb6f-4e95-852d-9635657d7f89"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]",
                    TextDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("9a6e6c25-1720-4eea-b8df-2195d32dfb46"),
                        NameXPath = "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("07eddb61-de8e-46d8-ae6a-8f146d04e693"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("7ab23797-333a-428f-a8c2-620267ac2310"),
                        UrlXPath = "//meta[@itemprop='url']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("6f87ed33-a16c-465a-8784-33c69ef9bb0c"),
                        PublishedAtXPath = "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("7a4a173c-cad8-4a09-adef-caecda7f5283"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("ffa17401-2b75-485d-a098-da254f125362"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("06d2ec66-84f2-448c-808e-d5a50facb4cc"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("0f9c275f-d418-4fea-abbf-ad3cda6d678c"),
                    NewsSiteUrl = "https://www.rbc.ru/",
                    NewsUrlXPath = "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("3e1f065a-c135-4429-941e-d870886b4147"),
                Title = "Storts.ru",
                SiteUrl = "https://www.sports.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("5531cc3d-cee5-490a-aaac-20b826e1135b"),
                    Small = "https://www.sports.ru/apple-touch-icon-76.png",
                    Original = "https://www.sports.ru/apple-touch-icon-1024.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b2a8ec2b-61da-45fd-b98f-6b32d0ccf331"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c3fc77db-1764-4453-a6e9-6f85ef5fde66"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("0ac9ad4a-29b6-4689-aadc-b3b75a3b034c"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SportNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("8c399ef5-9d29-4442-a621-52867b8e7f6d"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                    TextDescriptionXPath = "//div[contains(@class, 'news-item__content')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("30955c5b-0b5c-4655-9581-4972b4fc0df5"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("1119d2b6-db6a-4750-8263-9fb0025cc536"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("02333a48-69aa-4492-a33f-3ac9324d3970"),
                        NameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("dc0d0ef7-eb9e-4632-b75e-9d7d9ba44daa"),
                        PublishedAtXPath = "//header[@class='news-item__header']//time/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("a614d044-0c1d-4a5a-b547-a22ec2fdd1c0"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("d292849b-0727-4311-b0ff-da147c4d344a"),
                    NewsSiteUrl = "https://www.sports.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("baaa533a-cb1a-46e7-bb9e-79d631affc87"),
                Title = "Коммерсантъ",
                SiteUrl = "https://www.kommersant.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("52cd41a3-05b6-4ed0-87d0-bb62bd1a742a"),
                    Small = "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png",
                    Original = "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("ca9c9fa1-182d-416f-af3c-53b470edbbaa"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6884348a-7db9-49b3-81db-8300d6e0d72e"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6d9524d2-1101-493e-bd71-53d8ecf0e8de"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                    TextDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("39793598-0239-4802-87f3-f04d404eee1c"),
                        NameXPath = "//p[@class='doc__text document_authors']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("b07f324a-9029-4214-8521-01187ec7376d"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("7c9e261c-a090-44f1-92b8-e4d0e6b1d9b5"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("47328c5f-5e86-4b2d-be25-fe9198a946fc"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("cdc7b365-0e9b-405d-b948-4c074942dcc3"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("25fa301c-d896-4a5e-b580-2dba44900fb6"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("d2673a76-54a4-4013-8596-c648d3e16aa7"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("465f7ae0-072e-4df3-8d24-7a194b478c2a"),
                    NewsSiteUrl = "https://www.kommersant.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("31252741-4d0b-448f-b85c-d6538f7ca565"),
                Title = "Известия",
                SiteUrl = "https://iz.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("a5431839-5bf7-46f6-a2eb-c93b4b18e24f"),
                    Small = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png",
                    Original = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a881440d-08a1-41e0-86a7-64b3dec4d5d4"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("fd0b4b8f-5731-4e4f-a96b-f80093af1630"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6a065cf7-5a1e-445f-98d1-043b96aa75e8"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("9de1ef08-878b-4559-85af-a8b14d7ce68b"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("d553ac3d-a4af-4359-9e9b-802bf0c62bcc"),
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("ee437f1b-e11b-48cd-9db5-645c3537edf1"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("8dfefc74-7200-46f5-94be-3fe0efa0894c"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("00106a66-61a0-4abd-b58e-9f9b4ed2c07d"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("d647a983-f4e1-4610-9ee7-5d8163fdd865"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("59699417-64ea-4f42-9573-68a21d4fdbe7"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("73cf32f0-bb16-4319-935b-76de58df264b"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("4c8ceb60-a498-4b5a-b574-a84b2d890e59"),
                    NewsSiteUrl = "https://iz.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '?main_click')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c"),
                Title = "Царьград",
                SiteUrl = "https://tsargrad.tv/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("a1e75a31-deae-4634-8bd8-eea983e60bfc"),
                    Small = "https://tsargrad.tv/favicons/favicon-32x32.png?s2",
                    Original = "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("97b780f9-1854-4ee2-88f9-cc9027152826"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("745d9370-217a-4c3c-9289-215003e963f2"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("660485e7-ff2a-4375-979a-62769a8becfa"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("4c29ab0b-01eb-466e-8dc3-fe05886f4332"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                    TextDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("5e370949-45e8-4537-8855-cba4ecc363b4"),
                        NameXPath = "//a[@class='article__author']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("bb45ff0a-06f3-46ea-9921-c4f45270334e"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("4d2c5172-fc50-4854-bd47-44511c0fd763"),
                        UrlXPath = "//meta[@property='og:video']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("0f75da21-14e8-47a2-81e2-01c5e05b5f9f"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("a4130bc3-4c5f-451f-92f1-73e1c1745fc6"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("490ce35b-c2e5-4008-93f1-632720e22073"),
                                Format = "yyyy-MM-ddTHH:mmzzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("39d1b1e4-aa28-41b0-a55a-fffe8e406645"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("c18f4a2e-e149-4310-9311-f46c52acada0"),
                                Format = "yyyy-MM-ddTHH:mmzzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("27aa8343-30f4-40ef-a8ab-20d41e3097c4"),
                    NewsSiteUrl = "https://tsargrad.tv/",
                    NewsUrlXPath = "//a[contains(@class, 'news-item__link')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("fc0a229f-bde4-4f61-b4eb-75d1285665dd"),
                Title = "БелТА",
                SiteUrl = "http://www.belta.by/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("4975ba0c-d5eb-44cf-8743-2aa7d621c5d1"),
                    Small = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg",
                    Original = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9bed47b1-ba64-453a-91df-0c08b9ab61c1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("393c3856-dbc5-4620-9a35-635894691dfc"),
                        Tag = new NewsTag
                        {
                            Name = Tags.BelarusNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("2565182d-475e-4217-8b8d-b2ba9dbeb092"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("77a6c5a1-b883-444f-ba7e-f0289943947f"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='js-mediator-article']",
                    TextDescriptionXPath = "//div[@class='js-mediator-article']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("48759786-80ce-4ea1-84c2-f5cbb3b3e9d9"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("e8ae178c-a3c7-4ec4-8af8-d1431ef0b1a5"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("20903a2a-fdf2-4909-8478-bbfd57c492be"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("c0ff192d-ad34-459b-8fe8-49d20e6c5f41"),
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("62afc18d-a34f-4989-8c4c-2a5d7deabf6b"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("9ac871c4-a009-4f03-8920-3166aa64deeb"),
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("d9c7c3b0-bdc7-4bcc-afec-9423cb451086"),
                    NewsSiteUrl = "http://www.belta.by/",
                    NewsUrlXPath = "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("6854c858-b82d-44f5-bb48-620c9bf9825d"),
                Title = "СвободнаяПресса",
                SiteUrl = "https://svpressa.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("1949e476-a28c-49c7-8cef-114ed2f70618"),
                    Small = "https://svpressa.ru/favicon-32x32.png?v=1471426270000",
                    Original = "https://svpressa.ru/favicon-96x96.png?v=1471426270000"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("95d32d18-c7c5-4749-8166-7d83d9ad9bf6"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a02eecd4-f17b-42eb-beea-331873191aa9"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("151e6d99-9d03-4acb-8058-0f49bbb4a589"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("68faffa0-b7e6-44bb-a958-441eb532bfbb"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]",
                    TextDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("e20418bb-871d-4c31-a56b-9038d36a37e1"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("ac6a9a56-dada-4c70-b614-1b8fa635a812"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("47aebca8-87d6-4241-81c5-a65b23518f8a"),
                        NameXPath = "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("89fc1310-fff8-4cdc-aff5-c4285f9ab73c"),
                        PublishedAtXPath = "//div[@class='b-text__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("558de16f-ff6b-412c-9526-c6dd265565f4"),
                                Format = "d MMMM yyyy HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("d7afea6f-76d6-4684-86ce-f4d232f21786"),
                                Format = "d MMMM  HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("beacb8f7-d53b-4785-a799-57b69c4cd3fc"),
                    NewsSiteUrl = "https://svpressa.ru/all/news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("3e24ec11-86a4-4db8-9337-35a00988da7d"),
                Title = "Москва 24",
                SiteUrl = "https://www.m24.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("7e056d72-a4a4-4608-b393-b56d976a2bad"),
                    Small = "https://www.m24.ru/img/fav/favicon-32x32.png",
                    Original = "https://www.m24.ru/img/fav/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("06b2c915-82cf-4115-a537-cbc91d80783a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e3566a06-d006-4937-9bb5-90eade9d2bac"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("8949a721-7dfc-428c-a03d-6721e5b35879"),
                        Tag = new NewsTag
                        {
                            Name = Tags.MoscowNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("f6ef6598-401b-4cd8-8654-f3009b41593f"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]",
                    TextDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("8cb13ca5-b19a-47dd-93f4-13f82a2afaab"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("7e8d5e93-0edd-4054-8d1b-86b738bca16b"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("f0a8b4c3-22d5-4aa7-be0c-0250cfa04d53"),
                        UrlXPath = "//meta[@property='og:video:url']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("4a6be1f2-8429-4185-a9c6-03aeda076dcd"),
                        PublishedAtXPath = "//p[@class='b-material__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("b871e83e-0792-470a-8610-4264a83c16b1"),
                                Format = "dd MMMM yyyy, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("6c0231f6-71e1-4911-959c-9c93c1408781"),
                                Format = "dd MMMM, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("7b5a7ff9-dc44-4399-8049-30505337726e"),
                                Format = "HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("6d057994-d84f-4437-a8bc-bd4e427493ca"),
                    NewsSiteUrl = "https://www.m24.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("e2ce0a01-9d10-4133-a989-618739aa3854"),
                Title = "ВЗГЛЯД.РУ",
                SiteUrl = "https://vz.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("f22a5c00-53d0-43b8-93a3-1cdac2e103cc"),
                    Small = "https://vz.ru/static/images/favicon.ico",
                    Original = "https://vz.ru/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("0b19d00f-4483-4f55-818a-a7b34925b37b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4f514879-ca5a-45a2-9c9c-4834f7f98bd7"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b12ca17b-650c-4fbb-84a3-10057f365551"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("a1b03754-30d4-4c65-946d-10995830a159"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/div[@class='news_text']",
                    TextDescriptionXPath = "//article/div[@class='news_text']//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("86d081ed-0909-49c3-98fe-324f17415c27"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("4087fb58-d428-4c26-b88d-b20e5715a6f8"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("c8b007a9-e3db-4231-9a5f-5aa3f103e49a"),
                        NameXPath = "//article/p[@class='author']/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("f02b9ed4-7b5b-4572-bf74-604513ced86b"),
                        PublishedAtXPath = "//article/div[@class='header']/span/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("8e6578d8-62d7-4761-a9a2-60e8cfd4da58"),
                                Format = "d MMMM yyyy, HH:mm\" •\""
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("3b9ca981-bc22-40e2-93be-e08c99369c45"),
                    NewsSiteUrl = "https://vz.ru/",
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("49bcf6b7-15bc-4f30-a3d6-3c88837aa039"),
                Title = "Чемпионат.com",
                SiteUrl = "https://www.championat.com/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("3fbe2b42-7817-422b-a3e1-020942b42d4b"),
                    Small = "https://st.championat.com/i/favicon/favicon-32x32.png",
                    Original = "https://st.championat.com/i/favicon/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("5ec2412d-81f3-4157-924d-44ad65e0a24a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4998ee1a-d54c-4d29-be1d-8df7c60ee7b3"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("1a3984fc-b3b1-4d9f-bdff-716636bb2353"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SportNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("052241f9-e3e7-4722-9f56-7202de4a331e"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]",
                    TextDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("86d2ce89-f28a-4779-be9c-1832701f99d4"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("4664ca50-bfde-4200-a8eb-af35872e79dd"),
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("2e408438-34d0-4ec7-9183-f14c49c50ad6"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("a5685486-3a98-45aa-96b7-d25cd5e40c5d"),
                        PublishedAtXPath = "//article//header//time[@class='article-head__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("a3e3e93d-5850-4f27-885b-d80d10d72a8e"),
                                Format = "d MMMM yyyy, HH:mm \"МСК\""
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("e69f2b5a-89e8-43df-aa5d-ca4139af6f95"),
                    NewsSiteUrl = "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news",
                    NewsUrlXPath = "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("170a9aef-a708-41a4-8370-a8526f2c055f"),
                Title = "Life",
                SiteUrl = "https://life.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("53f0c42f-abe9-46e6-8c49-a4939e81be95"),
                    Small = "https://life.ru/favicon-32%D1%8532.png",
                    Original = "https://life.ru/appletouch/apple-icon-180%D1%85180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("2d10c3ff-332e-46bb-a37b-0ca725ee91a1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c2535359-45dd-458c-9b5a-bf7991047d9b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e219d7a3-c5d4-4f54-a275-75c5bc9df4cb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("3373c5b8-57e2-402b-9dfb-a0ae19e92336"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]",
                    TextDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("cae0e909-1bff-4b11-8c86-70eff32fa743"),
                        NameXPath = "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("784347e1-cdbd-42dc-a71e-c0bf6dc1bd60"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("60431c05-e7a1-4c09-a2d3-940896b52565"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("4a335cad-bc2f-442e-9c89-74da04bbde90"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("715c49ba-24ae-40af-b0b5-cacd488cb00e"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("83f72716-09c4-4c46-97fc-255431a7f616"),
                    NewsSiteUrl = "https://life.ru/s/novosti",
                    NewsUrlXPath = "//a[contains(@href, '/p/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("5aebacd6-b4d5-4839-b2f0-533ff3329941"),
                Title = "3Dnews.ru",
                SiteUrl = "https://3dnews.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("d1418d56-a990-448a-8334-a8cc8cec1b00"),
                    Small = "https://3dnews.ru/assets/3dnews_logo_color.png",
                    Original = "https://3dnews.ru/assets/images/3dnews_logo_soc.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("d6846cf7-bca1-48d3-b78d-188d94e2f80a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b6d1bfd8-38e9-4365-936d-ed3c6c09b357"),
                        Tag = new NewsTag
                        {
                            Name = Tags.InformationTechnologiesNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c8f40af2-f3b9-40de-ab83-dd5e74962bfb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TechnologiesNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4762d902-fdfe-413d-9c8d-76e619e81c7d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ComputerHardwareNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("44d47f91-a811-4cc3-a70f-f12236d1476d"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]",
                    TextDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("a5a0d928-4db3-49a7-8a52-2ba8d93fd651"),
                        NameXPath = "//meta[@name='mediator_author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("09f7efa7-635a-4a7b-9e00-dbee344eaf0a"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("4a01f0ed-4373-4b4c-be4c-5d8b23cd7b4b"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("82ed5673-25e2-497f-aaea-3dd42ecd4f85"),
                        PublishedAtXPath = "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("04d00724-05cc-4ca5-a951-889b75da6f97"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("0896d6d1-cbe7-4103-a47e-d9be4ad3c550"),
                    NewsSiteUrl = "https://3dnews.ru/news/",
                    NewsUrlXPath = "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("e023416d-7d91-4d92-bd5f-37d57c54f6b4"),
                Title = "iXBT.com",
                SiteUrl = "https://www.ixbt.com/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("427cf0f1-b0ef-4ab9-b181-63710edcf220"),
                    Small = "https://www.ixbt.com/favicon.ico",
                    Original = "https://www.ixbt.com/favicon.ico"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("5136ab36-5504-49e6-9422-0afeff788cbf"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("fc69d2fa-df60-45d6-8e79-41105f488cbf"),
                        Tag = new NewsTag
                        {
                            Name = Tags.InformationTechnologiesNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f534eefe-6616-4631-8354-c8e86140632b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TechnologiesNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("688e1338-51ad-40c5-a537-4fcc91fd0ed0"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ComputerHardwareNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("f6679100-82e3-4e0d-98a9-de90246ccf3a"),
                        NameXPath = "//span[@itemprop='author']/span[@itemprop='name']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("df87f204-4c84-408d-b84b-392e39d40b1f"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("7bf75c22-3ba4-42df-987a-468cbae9d132"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("fed30888-ff5a-4843-8a23-fa452ed88675"),
                        PublishedAtXPath = "//div[@class='b-article__top-author']/p[@class='date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("63435dc7-a82d-43d8-80e9-f5e1307ec3ab"),
                                Format = "d MMMM yyyy \"в\" HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("890e7953-5769-4023-922c-45094cb89251"),
                    NewsSiteUrl = "https://www.ixbt.com/news/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("604e9548-9b99-4bd4-ab90-4bf90b4a1807"),
                Title = "iXBT.games",
                SiteUrl = "https://ixbt.games/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("def8f81b-0a9b-44fb-a6bc-26f398fb175c"),
                    Small = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png",
                    Original = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("7afa8562-f5b4-4cdf-92c0-af0594d4be4d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("ce7a5f4b-071f-4c3e-af81-758a1b918c39"),
                        Tag = new NewsTag
                        {
                            Name = Tags.VideoGamesNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("f1b027fc-2809-4eaa-9858-c49a8756852f"),
                    TitleXPath = "//meta[@name='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]",
                    TextDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("325ee59a-478b-4ea2-991b-06c65c269bbe"),
                        NameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("140c9334-8e52-4c07-a0a2-f4842820af31"),
                        UrlXPath = "//meta[@name='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("1f572948-8062-4f2a-9603-54fd0815ff44"),
                        TitleXPath = "//meta[@name='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("2622b86a-c47b-4143-a11e-f2aad18faa8e"),
                        PublishedAtXPath = "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("04fe3029-59e0-4670-9a51-99593a0f8041"),
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("52805bca-3e28-413b-8da3-77c9411f6ae1"),
                    NewsSiteUrl = "https://ixbt.games/news/",
                    NewsUrlXPath = "//a[@class='card-link']/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8"),
                Title = "Газета.Ru",
                SiteUrl = "https://www.gazeta.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("d7e0f8bc-64ec-4450-b8bb-82689f1d9012"),
                    Small = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg",
                    Original = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("025c4e26-53d0-469f-9c52-3cec92eda13a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("25a4e9e3-c047-485a-9684-c3f897c6d8b8"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("fa9322b8-0640-43ea-847f-4a05bf1b160d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("60a60886-4da0-4c2c-8635-a8ec57827667"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("91108b0c-0f51-4946-b639-e9b8e67c48b9"),
                        NameXPath = "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("c9ff2c75-e65b-4fb4-a3a0-789c15973fac"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("34d00cc0-a590-4e50-a6d8-6c4c7511c4d8"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("b208c066-da95-4c32-baec-ff448a07f62d"),
                        PublishedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("5161d08b-a97d-4fa1-ad5a-069c3b5dc41a"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("b8e85938-97a8-47bf-aa33-c5bca3708e0e"),
                    NewsSiteUrl = "https://www.gazeta.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("57597b92-2b9d-422e-b0a7-9b11326c879b"),
                Title = "Интерфакс",
                SiteUrl = "https://www.interfax.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("db46c593-155d-4775-b999-dbe4eb772fb1"),
                    Small = "https://www.interfax.ru/touch-icon-iphone.png",
                    Original = "https://www.interfax.ru/touch-icon-ipad-retina.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f60c2ec2-8e72-462f-8144-987d9ba37751"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("ad8b55a9-c949-469f-956a-5624ecb7f577"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("dc2ed602-baa8-4a9e-8f38-b1cf40d5bb59"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]",
                    TextDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("552e2547-f0f4-4536-ac2b-0368eb0d03c6"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("515be790-404d-48ca-8d97-642a505b2149"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("e762bdb6-dfae-410b-9478-3ff4b45dbe70"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("3d3f9878-e5a6-4163-acb9-afe1346b3cf2"),
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("b8626e48-242d-48e4-aa30-8ca2936a0d59"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("10a053d0-a81c-42a6-a032-1a217bc6e9c1"),
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("cf99e4fc-dbe3-4be7-9f98-1eccfc954f39"),
                    NewsSiteUrl = "https://www.interfax.ru/",
                    NewsUrlXPath = "//div[@class='timeline']//a[@tabindex=5]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("13f235b7-a6f6-4da4-83a1-13b5af26700a"),
                Title = "Правда.ру",
                SiteUrl = "https://www.pravda.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("52827f36-597f-424c-bc69-6e71f2bdde5c"),
                    Small = "https://www.pravda.ru/favicon.ico",
                    Original = "https://www.pravda.ru/pix/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("311ea1df-f338-4d3a-83f9-9f69c9fb5593"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e33ba004-f85b-4714-a381-ee25fafd52f0"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("99d1cd54-f21d-407d-b1e1-54a6bd79f6ab"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"),
                    TitleXPath = "//meta[@name='title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]",
                    TextDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("20786554-85aa-42a5-80f3-953dccb09f55"),
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("48dd42bd-47ea-4a97-aeff-bb84db84e6b2"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("c4d81a5f-b716-4dec-9ddf-3c908343be6a"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("a2c411a5-4b6a-4ed8-b383-b1a4f05b4605"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("94e51912-995a-4976-a4a0-4cc03ffe4e82"),
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("91c40a45-f102-46d4-bd9b-4e11869f18cd"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("4601b17e-822b-4b19-862c-a0a6c5b7a23c"),
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("99d95b1b-1ecf-42ec-8e95-e4dcc217762d"),
                    NewsSiteUrl = "https://www.pravda.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("e16286a8-78a9-4b86-ba4b-c844f7099336"),
                Title = "Ura.ru",
                SiteUrl = "https://ura.news/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("8db8aa26-06f6-4ebf-b2f6-81a02a20a288"),
                    Small = "https://s.ura.news/favicon.ico?3",
                    Original = "https://ura.news/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("1e00ba56-95e3-41d7-8eb0-fb2a839faf9c"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f28044d3-15c7-4bee-9b92-8b418e03a191"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9f83d191-c57f-4c08-bdf9-6b0c97b8367c"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("d477dceb-5655-432b-8bca-b2ca2d944d87"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("c4ac25c5-d5da-4126-b298-8803c12b4930"),
                        TitleXPath = "//meta[@itemprop='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("6d70075b-0b7b-4da3-8e5b-a312f268a3a9"),
                        NameXPath = "//div[@itemprop='author']/span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("fc8fc0b9-ccd3-4dcf-9b07-1e7031097188"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("3f29a12c-5e1c-45de-bf8b-96897f8ac962"),
                        PublishedAtXPath = "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("0b9c2546-034c-44d5-b328-fc29b3b96db4"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("62c58603-8696-4a94-bd69-de1938895b9b"),
                    NewsSiteUrl = "https://ura.news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("321e1615-6328-4532-85ac-22d53d59c164"),
                Title = "74.ru",
                SiteUrl = "https://74.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("f3318dd0-6ed3-4b25-ab34-6f4330317853"),
                    Small = "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico",
                    Original = "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9d6cd55b-f966-4e6a-973d-d548d7183da2"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("32ea560c-f4ef-4bb9-844c-72206f5f0e5f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("cbc029ee-c8f0-493a-b9e7-837420e76734"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ChelyabinskNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("e4542056-2c68-43c6-a85c-9e4899556800"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("ce13e4cd-82df-4d2b-87e1-9256c5ef8c7c"),
                        NameXPath = "//div[@itemprop='author']//p[@itemprop='name']/text()",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("64c04564-82ae-449f-9264-840c277b648c"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("7e4b4a81-f9e7-4830-9127-6fd86379db9a"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("79e88ebb-d542-4d19-a212-6c21f2688c77"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("78b09bbf-a311-4d1a-9d00-d054898f1354"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("0a1fc27b-5f76-4a98-acd2-c3f98852d1c0"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("3217adeb-8d21-4a5c-82df-83883177308f"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("e1e2fd1c-8939-4531-90b3-3a8879319fb9"),
                    NewsSiteUrl = "https://74.ru/",
                    NewsUrlXPath = "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("70873440-0058-4669-aa74-352489f9e6da"),
                Title = "Первый областной",
                SiteUrl = "https://www.1obl.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("68fa8065-fdc2-4e15-b2b1-3adb91d2d862"),
                    Small = "https://www.1obl.ru/favicon-32x32.png",
                    Original = "https://www.1obl.ru/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("0eedd3af-e5dd-45f7-af31-15b9dee5c89f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("1536f46f-ea14-4fb8-b8d5-9aae924266ff"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b3e5aec3-aee3-41a6-a797-e56c87d2f920"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ChelyabinskNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("921d7c0a-c084-4188-b243-d08580f65142"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("f28a4798-e796-400d-ab07-ddb5bb21be43"),
                        NameXPath = "//*[@itemprop='author']/*[@itemprop='name']//text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("baa19068-8f2f-445e-8450-27967074fac5"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("6996d64b-f805-4868-a6d1-6d287f568e83"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("c00312de-2ba3-4047-b80c-e5624577ad29"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("b0dec36b-12b0-4ff1-af8c-7feff35137de"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("9980ee74-f655-40af-b44e-c9feb0e0bd40"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("05acbeac-ea1d-41c7-b658-ab3971501e2b"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("5337753f-c43d-4ffa-b966-6e926c3a0a1c"),
                    NewsSiteUrl = "https://www.1obl.ru/news/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("797060c0-3b47-4654-9176-32d719baad69"),
                Title = "Cybersport.ru",
                SiteUrl = "https://www.cybersport.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("375423fe-7b3a-4296-80f1-4072577524c0"),
                    Small = "https://www.cybersport.ru/favicon-32x32.png",
                    Original = "https://www.cybersport.ru/favicon-192x192.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9c690333-2c73-4cfc-b113-b4feb4fbc30a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("ab8a6089-a6b8-4031-934e-d296f8253fd3"),
                        Tag = new NewsTag
                        {
                            Name = Tags.CybersportNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("2753275a-efd1-41e9-84cd-8b5399cb2ea3"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SportNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("11795391-d20d-48df-ab38-30f796737a43"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]",
                    TextDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("b28db8a4-5df8-4f99-9d5e-7013a3d053c8"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("051b16f3-07e7-49c7-ae63-d49e01d685e6"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("da19d28d-156b-47a0-868b-18f4ec0c8114"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("6c536ec8-3a65-4fa3-9862-f7744d5b1e1f"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("da1fb28b-2afb-461a-9cf2-6e65a9c6963d"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("61f79112-d8a1-4562-8a1d-6f5e64928a50"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("f75f5b07-588f-4a4d-afb2-3558f99b54d7"),
                    NewsSiteUrl = "https://www.cybersport.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/tags/')]/@href",
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("e4b3e286-3589-49de-892b-d0d06e719115"),
                Title = "HLTV.org",
                SiteUrl = "https://www.hltv.org/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("5195571a-9041-4d0e-a9d1-dddbc5c9cb39"),
                    Small = "https://www.hltv.org/img/static/favicon/favicon-32x32.png",
                    Original = "https://www.hltv.org/img/static/favicon/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("508b2fd4-609d-4ce2-925a-a18c7b9889db"),
                        Tag = new NewsTag
                        {
                            Name = Tags.EnglishNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("1bc5683b-b0fa-4a72-b9d8-bfc9c45360c6"),
                        Tag = new NewsTag
                        {
                            Name = Tags.CounterStrikeNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6ce3a3ff-775d-4606-a3eb-462daa663500"),
                        Tag = new NewsTag
                        {
                            Name = Tags.CybersportNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("d6550af5-7e26-49cc-b9bb-65ddfe9ccd67"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SportNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]",
                    TextDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("15009b74-1ebf-4de7-b127-24e412d887b1"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("7d69c14b-403d-4216-ac58-f66c87bee0c8"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("b5ff5316-a5a2-44b7-855f-7af3788ab3e9"),
                        UrlXPath = "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("7a85f179-0e73-4d6e-9792-5d93a47e0484"),
                        NameXPath = "//article//span[@class='author']/a[@class='authorName']/span/text()",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("5c23cab5-7864-429b-9080-ba88f81c6751"),
                        PublishedAtXPath = "//article//div[@class='article-info']/div[@class='date']/text()",
                        PublishedAtCultureInfo = "en-US",
                        PublishedAtTimeZoneInfoId = "Central Europe Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("055ce086-a067-43f4-98ad-4b3b039328d6"),
                                Format = "d-M-yyyy HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("01116c2c-7bf6-496d-96f6-9d10d4b14e97"),
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://www.hltv.org/",
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("136c7569-601c-4f16-9ca4-bd14bfa8c16a"),
                Title = "The New York Times",
                SiteUrl = "https://www.nytimes.com/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("e1eeadd2-6075-447a-8cda-0952e46496fc"),
                    Small = "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png",
                    Original = "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("85583770-ceb5-4114-b5dd-b00cc6dcb199"),
                        Tag = new NewsTag
                        {
                            Name = Tags.EnglishNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("934a294d-04fc-4f74-971c-1dac01b70086"),
                        Tag = new NewsTag
                        {
                            Name = Tags.UsaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f739b571-d14b-4366-8c75-4b39aadd24f7"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("dd0ea6e1-0684-4a1e-b143-37bdb1ba7c5a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.NewYorkNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("3c4ef27a-3157-4eff-a441-1e409c4b6c34"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@name='articleBody']/*",
                    TextDescriptionXPath = "//section[@name='articleBody']/*//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("75075f9b-f14d-4720-8311-933ae0383523"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("a8742001-52bb-4beb-852c-913eff64dceb"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("48a9b834-59bb-4398-8526-318c506c58eb"),
                        NameXPath = "//span[@itemprop='name']/a/text()",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("ccc2a5c5-02fd-4a8d-ace5-7f41742f442b"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "en-US",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("e0b7abad-a103-4050-92c5-36017a518376"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("4adf1a9f-ac4c-4f17-932b-aac460d0d2f2"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "en-US",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("83158dac-180c-45f5-b13f-82b253c3f0be"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("035b1374-e0cd-4b0a-a567-e0feff9852ff"),
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.nytimes.com/"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07"),
                Title = "CNN",
                SiteUrl = "https://edition.cnn.com/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("9f083bc5-a246-46d7-a2fe-eaa32d79a821"),
                    Small = "https://edition.cnn.com/media/sites/cnn/favicon.ico",
                    Original = "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e9e871d8-2a97-4117-bdd3-99a28be03cad"),
                        Tag = new NewsTag
                        {
                            Name = Tags.EnglishNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6225f6e1-2901-4727-8aa5-c34d46730169"),
                        Tag = new NewsTag
                        {
                            Name = Tags.UKNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6db9856b-05fa-4036-b700-6f6288bc8318"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("5c40c521-5f8b-4fd2-984c-78c7a3e583bd"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TVNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("3238cb06-5baa-4d87-a6a7-d3b826c1da59"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("f32f03ee-4548-4259-ac50-d791451cb1d7"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("502c8f33-a803-4578-83b9-a024d2b92510"),
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("1fe09b4f-73bd-4979-8206-439489299a64"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "en-US",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>()
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("fb9e24ab-9e5b-4641-ac8b-df59d34811d1"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("033e507a-cb9d-403f-a8cb-48238e03607b"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "en-US",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>()
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("ff02bb15-206e-4c8b-940e-c077740c4e8d"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("d9bee236-e02e-4940-a97f-7aa259961369"),
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://edition.cnn.com/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("cb68ce1c-c741-41df-a1c9-8ce34529b421"),
                Title = "Комсомольская правда",
                SiteUrl = "https://www.kp.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("4cf43716-885c-4a85-8d23-0ecc987da590"),
                    Small = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png",
                    Original = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3442ffd8-d296-4f9a-8b56-e1c83a468053"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("d49cfbc4-2c58-4d27-b68c-6ead4192affc"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b460f29d-8f45-4d10-9529-145c54287a6f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]",
                    TextDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("e68f6ef8-cd76-4fc8-b98b-cb2bc02c3dfd"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("375e4eca-f067-486a-a3cd-5045165dd9e1"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("d153a1fc-66c6-4313-adc9-36850ec82124"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("79934951-c9f9-4230-8eb5-2d3a80f4d4f4"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("700ffddc-d0a5-450a-b756-deabd7bfed18"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("fa45d026-0db8-4968-8753-da586b527e27"),
                                Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("69765f00-a717-43b7-8c2e-59213979a3ed"),
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://www.kp.ru/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("a71c23bf-67e9-4955-bc8e-6226bd86ba90"),
                Title = "Журнал \"За рулем\"",
                SiteUrl = "https://www.zr.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("7083afb5-2799-44f7-a508-60369598da29"),
                    Small = "https://www.zr.ru/favicons/favicon.ico",
                    Original = "https://www.zr.ru/favicons/safari-pinned-tab.svg",
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("942b3d98-af39-40f6-a2d4-e4acb4d48df2"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("050c5ae6-0a40-40fc-b900-4e16ec28159c"),
                        Tag = new NewsTag
                        {
                            Name = Tags.AutoNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("2d46f779-c13c-4699-9460-629e254a6444"),
                    TitleXPath = "//meta[@name='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]",
                    TextDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("e250183d-d316-4ef3-b7cf-887ce77ac342"),
                        TitleXPath = "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("679b3f84-a212-422b-a41d-3544ae6c997a"),
                        UrlXPath = "//meta[@name='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("6ef19113-6578-47ed-93c8-b2b61cd13d08"),
                        NameXPath = "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()",
                        IsRequired = false,
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("1b2f8ada-c349-4930-98ed-896d0b89093c"),
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href",
                    NewsSiteUrl = "https://www.zr.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("454f4f08-58cf-4ab7-9012-1e5ba663570c"),
                Title = "АвтоВзгляд",
                SiteUrl = "https://www.avtovzglyad.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("ef6108bf-e9c1-4f8b-b4f7-7e933b1c7ac3"),
                    Small = "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png",
                    Original = "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f603da29-65c5-4713-80bd-ec8023b9c94d"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a5c23469-5399-4848-bf82-14e195c357ac"),
                        Tag = new NewsTag
                        {
                            Name = Tags.AutoNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("e3fcdd00-2152-4d84-8f8c-bf70e4996990"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']/*[not(name()='script')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("999110e1-29e6-4a98-8361-743dd7f8bf07"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("4b846398-fc4c-4c1f-adac-2bc61fea6752"),
                        NameXPath = "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("1f4694bc-c0d7-405c-ae73-88053c0ebc14"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("c6115996-838b-4309-813e-d520085af7df"),
                        PublishedAtXPath = "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("9c7e361a-0096-483d-8f8a-edae7e347e1a"),
                                Format = "d MMMM yyyy"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("a169d814-b17e-4062-a2b5-1599ede6783c"),
                    NewsUrlXPath = "//a[@class='news-card__link']/@href",
                    NewsSiteUrl = "https://www.avtovzglyad.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("dac8cec6-c84d-4287-b0b9-71f4cf304c7e"),
                Title = "Overclockers",
                SiteUrl = "https://overclockers.ru/",
                IsEnabled = true,
                IsSystem = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("955eb645-e135-46d6-990e-1348bcc962d8"),
                    Small = "https://overclockers.ru/assets/apple-touch-icon.png",
                    Original = "https://overclockers.ru/assets/apple-touch-icon-120x120.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4d30d497-e95e-428f-b8ed-b38f67a62894"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c5e74bb8-c08b-4498-baad-11ce59564015"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ComputerHardwareNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"),
                    TitleXPath = "//a[@class='header']/text()",
                    HtmlDescriptionXPath = "//div[contains(@class, 'material-content')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'material-content')]/p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("c694b06f-3d99-4ec4-b939-374b524b728f"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("73e2d740-d23b-44d5-b0a4-634da72f0daf"),
                        NameXPath = "//span[@class='author']/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("da259816-c238-4a5e-af4b-be606546572f"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("8208ff9e-fbf8-4206-b4d8-e7f7287b2dec"),
                        PublishedAtXPath = "//span[@class='date']/time/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("677d695e-ddcc-4a66-aa7f-ff1ccdb726dd"),
                                Format = "yyyy-MM-dd HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("773dc871-3e67-4375-9ded-71969f1e0a81"),
                    NewsUrlXPath = "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href",
                    NewsSiteUrl = "https://overclockers.ru/news"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("296270ec-026b-4011-83ff-1466ba577864"),
                Title = "KinoNews.ru",
                SiteUrl = "https://www.kinonews.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("1aa24985-d52d-4f4e-8113-022a0216a2af"),
                    Small = "https://www.kinonews.ru/favicon.ico",
                    Original = "https://www.kinonews.ru/favicon.ico"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("eb0ca62c-bf7c-40c8-946d-fadfd107cffb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("24eaf488-7213-4419-8f9e-edb3222c7004"),
                        Tag = new NewsTag
                        {
                            Name = Tags.MovieNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("32cad97f-b071-4e24-bdc9-10e5e58cf99b"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='textart']/div[not(@class)]/*",
                    TextDescriptionXPath = "//div[@class='textart']/div[not(@class)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("9e43be0a-592d-4c1a-8525-9545d8fada04"),
                        TitleXPath = "//div[@class='block-page-new']/h2/text()",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("d577c838-8fed-45ba-850b-18bf437c06f3"),
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("f30aba5c-0d63-4f7b-9f68-1dc1629cd449"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("8bf5f85a-aba6-48a5-8704-3f6c4f51d9d1"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("699ff8c9-5f7e-4216-8e21-23627129bab9"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("a6f6a030-99b0-4828-af01-5c01d655be30"),
                    NewsUrlXPath = "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href",
                    NewsSiteUrl = "https://www.kinonews.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("ba078388-eedf-4ccb-af5f-3f686f4ece4a"),
                Title = "7дней.ru",
                SiteUrl = "https://7days.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("d227ada8-0869-4320-8e0b-29b4b57ace6f"),
                    Small = "https://7days.ru/favicon-32x32.png",
                    Original = "https://7days.ru/android-icon-192x192.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("0ee0d08c-66c0-4f83-ad46-92e3971d13d8"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e19e6158-1b33-4f1b-9757-6b50f180f007"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ShowBusinessNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("692ba156-95b9-4a24-9b0c-71b769e8d3a8"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]",
                    TextDescriptionXPath = "//div[@class='material-7days__paragraf-content']//p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("255720d2-2188-4d40-ac74-86e2f87c78c7"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("efc3e79b-1827-40e8-a072-7f1cac6e991b"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("9bfd49d6-dcb9-4a65-80f5-c9ac3b6b490d"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("d70086c1-dd34-40a7-b8d5-225689fd993c"),
                                Format = "yyyy-MM-dd"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("6dc53704-3d38-47f9-9efa-7604da400355"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("d5896f93-bbef-44cb-82c4-6c0c73e4f4c9"),
                                Format = "yyyy-MM-dd"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("62fe0769-6882-48b6-91c1-0f7a205aca05"),
                    NewsUrlXPath = "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://7days.ru/news/"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("05765a1b-b174-4ad1-9f63-3189a52303f9"),
                Title = "Сетевое издание «Онлайн журнал StarHit (СтарХит)",
                SiteUrl = "https://www.starhit.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("5f715b2b-8509-4425-aaed-2da285f295d0"),
                    Small = "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png",
                    Original = "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4ee63615-d18c-4f48-8b9a-8aff52d12006"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("50d237f6-59fa-44bc-96f4-344bab93f074"),
                        Tag = new NewsTag
                        {
                            Name = Tags.ShowBusinessNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("49c1bb0c-b546-4142-a7ba-4925f71a933c"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("e3d307d2-0cd5-42d2-9c7c-2fab779bb299"),
                        TitleXPath = "//p[contains(@itemprop, 'alternativeHeadline')]/text()",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("dd3601cc-4a2c-480f-9860-9f5183d8c67a"),
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("1927aaba-9fb9-4caf-a3f6-1586a082e21a"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("e6bd53e0-c868-451c-87a5-e048343b2759"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("95c6753e-1df4-4708-9b80-6976c6b91292"),
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("348a6cf9-f469-4f19-a12c-bdc3f525947c"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("9baa0874-10a0-4e13-8fc9-fb95036b8958"),
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("3dd178c2-7dd6-4f7d-9fa3-8aad161b000a"),
                    NewsUrlXPath = "//a[@class='announce-inline-tile__label-container']/@href",
                    NewsSiteUrl = "https://www.starhit.ru/novosti/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("b5594347-6ec0-44c0-b381-7ae47f04fa56"),
                Title = "StopGame",
                SiteUrl = "https://stopgame.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("495799aa-0817-433e-9abe-5481c0f3d569"),
                    Small = "https://stopgame.ru/favicon.ico",
                    Original = "https://stopgame.ru/favicon_512.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("39b9de90-e868-41c1-8390-632d344850d7"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("853e103e-0105-46c0-869b-3b7c3ed19a46"),
                        Tag = new NewsTag
                        {
                            Name = Tags.VideoGamesNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("be3e061e-25f4-4b43-a9f6-45db165b6000"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*",
                    TextDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("568f8fd4-3715-4895-a979-509ce2da11e2"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("118e708c-8b15-496c-bffd-1f30c5679ba8"),
                        NameXPath = "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("bf4cfe59-066b-4d7c-ab2c-ca2690648826"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("cea22ad0-6634-4def-9b5b-f1e754ce2d8d"),
                    NewsUrlXPath = "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href",
                    NewsSiteUrl = "https://stopgame.ru/news"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("c169d8ad-a9fe-44e9-af6a-fd337ae10000"),
                Title = "РЕН ТВ",
                SiteUrl = "https://ren.tv/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("504e7035-e6bb-434a-939c-5b4515ad4e48"),
                    Small = "https://ren.tv/favicon-32x32.png",
                    Original = "https://ren.tv/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("30042a38-0f29-4378-b9e9-12c64a043913"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3073fa94-5ff5-411f-b8b7-25663045c4da"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("8512f634-1ddd-405a-841d-45545534904f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6159dd07-94f5-471e-b6ea-0cd73b2de872"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TVNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("cba88caa-d8af-4e40-b8fa-14946187e939"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='widgets__item__text__inside']/*",
                    TextDescriptionXPath = "//div[@class='widgets__item__text__inside']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("19df7bef-b4dd-4a35-991a-49c9a28ebfeb"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("3291c20c-0487-47a3-a428-fdcb0bdde0b6"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("0cea5575-ec4f-4b14-a0cc-49185e1d1768"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("6b286540-6b0b-42b6-a696-aed7dd5844c8"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("350279da-c53a-42a7-abad-a3097a881261"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("7258af78-93ae-46b1-9c4a-418769158262"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("f0a00f38-8859-4603-91db-251ada2ae73e"),
                    NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://ren.tv/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("c7b863af-0565-4bec-9238-9383272637ef"),
                Title = "Новороссия",
                SiteUrl = "https://www.novorosinform.org/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("bafc4c68-8558-46d1-b778-0c2137188d93"),
                    Small = "https://www.novorosinform.org/favicon.ico?v3",
                    Original = "https://www.novorosinform.org/favicon.ico?v3"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("95fe22e4-5977-4f74-947d-9cc8dba28f47"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b27c172f-99b0-4441-a3a4-d499e302d509"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a06bb1f8-a548-44b5-8d41-02af27aeeaf7"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("611bd50e-69f5-4598-8ad6-8b19771f1044"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='only__text']/*",
                    TextDescriptionXPath = "//div[@class='only__text']/*[not(name()='script')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("eb234374-29cf-43b4-ae0f-5e8a80aaf132"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("62ed2534-e043-4f4d-a1ac-b9be0a4d9bbd"),
                        NameXPath = "//div[@class='article__content']//strong[text()='Автор:']/../text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("6f3531a6-db42-459a-ab24-08493edc3ac0"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("bc3f2794-f10e-4745-ba8e-286b6aa58707"),
                        PublishedAtXPath = "//div[@class='article__content']//time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("f9ff1b0c-54ca-43d5-8781-01783db54288"),
                                Format = "dd MMMM HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("81fdba6b-e423-47c5-b9bf-cd08dc7fce42"),
                                Format = "dd MMMM yyyy HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("285b962c-f8e9-4b05-95e9-81a0ff26cd26"),
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.novorosinform.org/"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("33b14253-7c02-4b79-8490-c8ed10312230"),
                Title = "Пятый канал",
                SiteUrl = "https://www.5-tv.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("c4d13a4c-2f0d-41a4-a5e0-543e6a7dbad8"),
                    Small = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png",
                    Original = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a12ba2dd-791c-44c0-963c-d0d0224f7aef"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c55962cf-5967-4d67-a1a6-b2d1a856930b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("0b335897-3cb8-4bd8-8e01-3435785fdc9c"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("3a64826a-9a6f-4d7d-9798-1c86350846d1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TVNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@id='article_body']/*",
                    TextDescriptionXPath = "//div[@id='article_body']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("b96057cb-5a77-4785-a20d-c7bbb0c4752e"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("5b0a65b8-54c9-432e-8962-d3016e02c01e"),
                        NameXPath = "//meta[@name='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("0da669ee-feb9-4403-bc90-9af266fab309"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        Id = Guid.Parse("5a25f140-9895-4deb-9e9e-d048799446d3"),
                        UrlXPath = "//meta[@property='og:video']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("f3f8cc16-9599-42fa-acea-c66be06e0d13"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("af484c5e-0924-4f42-bcc5-8c4407ea9a92"),
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("c8cda125-f32f-492a-9d65-c1e0abb69300"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("97301aa5-3306-4948-a4f9-0ad1c5d3cda0"),
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("0bd7b701-63de-48e9-8494-4faf1193e218"),
                    NewsUrlXPath = "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href",
                    NewsSiteUrl = "https://www.5-tv.ru/news/"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("6c5fe2d4-8547-4fb0-8966-d148f8d77af7"),
                Title = "НТВ",
                SiteUrl = "https://www.ntv.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("4af4b3b2-ca3d-4421-976f-0406c515033a"),
                    Small = "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png",
                    Original = "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("93013951-10cd-474a-834f-fa528a3fd95b"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f075a7a6-561f-4cdf-b71e-dd7a1f8f960f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a3c4d53e-42e2-4639-a0e6-adb0ce838bdb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a12d8fd1-873f-4ac7-b4c5-4bffc6cb3479"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TVNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*",
                    TextDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("7d88f1e1-8458-403d-8d83-3d076b4cedd4"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("0f72771a-3c4e-4a38-9ab5-fe96f01728af"),
                        NameXPath = "//meta[@property='author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("a6d5c07c-a1a6-4b00-9b58-babe896712fb"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("cbe14234-0158-487c-b0c0-2117107b9a34"),
                        PublishedAtXPath = "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("c0377df6-a447-44bb-9698-cd37f084d4be"),
                                Format = "dd.MM.yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("6b670151-2211-4da1-9313-86e1d58c9893"),
                    NewsUrlXPath = "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href",
                    NewsSiteUrl = "https://www.ntv.ru/novosti/"
                }
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("068fb7bb-4b76-4261-bc9a-274625fe8890"),
                Title = "ФОНТАНКА.ру",
                SiteUrl = "https://www.fontanka.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("872f13d3-d28d-44c4-bf38-ab69bb554e4a"),
                    Small = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png",
                    Original = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("22aacfa5-7c90-4d6f-9b04-79805d6d01e3"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4b63e46c-1f07-4dc7-8c63-2a8eab4fb054"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("674e3fd9-f4a8-4b81-9f11-4de28cc824dd"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SaintPetersburgNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("d36d75dc-add7-4e21-8a31-2f40f4033b14"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']//p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("2656349d-0958-4779-a36a-cca96fe04b6a"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("b6c8fbce-f0fa-4d28-b166-8ee9efb9f04f"),
                        NameXPath = "//meta[@property='ajur:article:authors']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("b9639099-40e4-4346-93ed-1aa69d2fd95c"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("fdad3f1e-646d-4fe0-b46f-cf5a2d320981"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("c66b5e6c-d604-4a55-b38f-f9ae415ecd1c"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("92324d14-49b0-409a-96e1-6a37a8691c6e"),
                    NewsUrlXPath = "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href",
                    NewsSiteUrl = "https://www.fontanka.ru/24hours_news.html"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("60747323-2a4c-44e1-880d-7e5e36642645"),
                Title = "ИА REGNUM",
                SiteUrl = "https://regnum.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("a786f93c-3c1d-4561-a699-58fba081cc37"),
                    Small = "https://regnum.ru/favicons/favicon-32x32.png?v=202305",
                    Original = "https://regnum.ru/favicons/apple-touch-icon.png?v=202305"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("53a0fa14-82ed-49a0-9f6c-0ad21e2c8ff8"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("2134a235-9b9d-4010-b627-2de04e044a0f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("70b71eaf-20ce-489e-bf24-77201fb2a506"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("14db83c2-cee9-47a2-b8fc-210bbbd399aa"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]",
                    TextDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("4b514907-cb5c-4b5c-aaa9-1d581955c40b"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("e9c5bd35-588d-49c8-b0d0-3eda43d0afea"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("505e7e1d-72a9-4f64-b2ab-faf55410329f"),
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://regnum.ru/news"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236"),
                Title = "Женский журнал WomanHit.ru",
                SiteUrl = "https://www.womanhit.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("1a1a5026-c9a6-4d74-9f36-721b47a79548"),
                    Small = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2",
                    Original = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e71cb8fe-52b0-4e6e-b344-0e5631996192"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("f0c920e4-64c9-4b1f-b3ce-780a1d0c34b3"),
                        Tag = new NewsTag
                        {
                            Name = Tags.WomanNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("a7d88817-12e6-434a-8c25-949dde2609f4"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//span[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//span[@itemprop='articleBody']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("45ebf04d-7b70-4c43-882d-af3d6ac3c687"),
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("e70fb7e3-35e6-4afa-ace8-b93a95bf5121"),
                        NameXPath = "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("84f20ff4-fb12-45de-b7de-e9d7844f6935"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("f4df8c3f-efa8-4fa5-bb34-91942ecec22a"),
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("7ff54b73-3ea0-49c6-9702-ad9fe746e1c9"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("75386858-8fad-48aa-bea8-d5aec36c1f8f"),
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("4acbd680-8c5e-48a3-ae91-d66c2107150a"),
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("09a55b0c-4a3f-497c-9626-9b5b5e12ca26"),
                    NewsUrlXPath = "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href",
                    NewsSiteUrl = "https://www.womanhit.ru/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("b2fb23b4-3f6d-440c-9ec0-99216f233fd0"),
                Title = "Русская весна",
                SiteUrl = "https://rusvesna.su/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("3ee815d8-a253-47c7-9084-22cddbb490d4"),
                    Small = "https://rusvesna.su/favicon.ico",
                    Original = "https://rusvesna.su/favicon.ico"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9730da62-1ba7-4f35-a1e0-6b7a0d6c4e3f"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("83188472-1463-4bcf-8d36-6166906332ac"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6939baf3-2726-4b72-9ef2-ad710cdecc88"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("c965a1d0-83b6-4018-a4a5-9c426a02943e"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("191181df-86e6-43c2-9643-5e9bb0ad62ac"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("181a1d07-35cc-4e75-9a36-330c319c6590"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("8ff05689-5c68-4f41-9023-4bfead386fed"),
                        PublishedAtXPath = "//span[@class='submitted-by']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("a28a5ac8-e766-4c34-823a-a5703f3ef96b"),
                                Format = "dd.MM.yyyy \"-\" HH:mm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("a62f2d07-0e56-4bdc-a6de-c061d313bea9"),
                        ModifiedAtXPath = "//meta[@property='og:updated_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("331d2e46-95f3-42de-9a4c-a7dd3312647a"),
                                Format = "yyyy-MM-dd HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("4305d788-135a-4922-8cfb-7d5b8971835e"),
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://rusvesna.su/news"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("b9ec9be8-e1f2-49d6-b461-b61872bb369c"),
                Title = "TravelAsk",
                SiteUrl = "https://travelask.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("915e2d86-b519-4034-a44f-991b0a446607"),
                    Small = "https://s9.travelask.ru/favicons/favicon-32x32.png",
                    Original = "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("374ede54-919b-4c31-9738-18b31de40898"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("bad63cda-47c7-45ef-867c-c271c48b2e13"),
                        Tag = new NewsTag
                        {
                            Name = Tags.TravelNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("c8e216e4-355b-42c5-babf-cb9ae005b27c"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("a7340062-15ee-4ea9-b6c5-1ea46f299c49"),
                        NameXPath = "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("9fcdbc5c-80af-454f-84f8-a8411f6b0184"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("eaf8f8a4-7781-4285-b447-1e3309b2edbf"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("05a46c75-81a5-4b37-b01f-7ef41ba35858"),
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("4aeb273b-8983-4ed7-adf0-74ff9bdfb4ab"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("b86762b0-61e7-4b60-8d55-84285b2ba9f9"),
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("a13340f1-b8ad-4aed-8db3-3ce1bc26b977"),
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://travelask.ru/news"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("65141fc2-760f-4866-86c5-08cc764cabac"),
                Title = "SMART-LAB",
                SiteUrl = "https://smart-lab.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("6b5da5aa-29f4-4ee9-a310-db70936a1ff1"),
                    Small = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico",
                    Original = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("6a63cd8b-9bfd-4c7b-9fc4-add3af28ab09"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("afed64e4-db23-4f41-9519-6570621c0b30"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("e86d098a-4561-40b9-83e0-d35612ecfafe"),
                        Tag = new NewsTag
                        {
                            Name = Tags.EconomyNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("985748c8-d5a4-48c5-a41b-b23c8726d297"),
                        Tag = new NewsTag
                        {
                            Name = Tags.FinanceNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("289bab5a-8dd4-4ca7-a510-ff6a496b3993"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*",
                    TextDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("a33df3a5-b0b4-4c61-8978-67452ed955c9"),
                        TitleXPath = "//meta[@name='DESCRIPTION']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("c89266cc-1f5c-4839-8b7c-e86ba789c36d"),
                        NameXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("2b7405f0-8db7-447b-a239-4b8454cba04b"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("22c82c40-fe3a-4394-ab34-295e3c094dcf"),
                        PublishedAtXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("664d9377-1900-4561-aa21-c2b0a7a1f8ac"),
                                Format = "dd MMMM yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("e33af74d-60d3-4b07-8a1f-f35dd3a2965a"),
                    NewsUrlXPath = "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href",
                    NewsSiteUrl = "https://smart-lab.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("9e3453b3-be81-4f3b-93da-45192677c6a9"),
                Title = "Финам.Ру",
                SiteUrl = "https://www.finam.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("9e7d94a1-3960-4019-aa85-e4f384ec14ea"),
                    Small = "https://www.finam.ru/favicon.png",
                    Original = "https://www.finam.ru/favicon-144x144.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("9d0a0cea-e52f-4418-8652-3a152788a1ff"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("a0d39b98-3a62-4153-9a5f-b678bd754ff0"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("53d62165-056b-4061-9415-696925c16912"),
                        Tag = new NewsTag
                        {
                            Name = Tags.EconomyNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4ef14b7a-d41d-4eab-b58d-db7ce19bcdbb"),
                        Tag = new NewsTag
                        {
                            Name = Tags.FinanceNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("688c8958-8946-4e0c-a943-3a614eedf013"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("0f7f9888-b12e-48cc-931c-8380d9e8e7e4"),
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("6d23a40c-508d-4914-9c4e-4ca0e9db1985"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("80bc5b20-336c-4ac1-9ee0-e231d0ef74c7"),
                        PublishedAtXPath = "//span[@id='publication-date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("be418012-872b-49b6-bce4-f91a9bf8ef1d"),
                                Format = "dd.MM.yyyy HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("8325b474-7ad4-40bc-a721-82cf3f01d4c2"),
                    NewsUrlXPath = "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href",
                    NewsSiteUrl = "https://www.finam.ru/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("9519622d-50f0-4a8d-8728-c58c12255b6f"),
                Title = "КХЛ",
                SiteUrl = "https://www.khl.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("b22f3762-d5d6-4102-9817-a719bb0c220c"),
                    Small = "https://www.khl.ru/img/icons/32x32.png",
                    Original = "https://www.khl.ru/img/icons/152x152.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("683efe05-2dee-444a-95e9-5f23909ef186"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("06253ef3-b019-488a-a553-9da5fafb3ac1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("931d85e9-49d4-44dd-b062-d8c7ce5d241a"),
                        Tag = new NewsTag
                        {
                            Name = Tags.SportNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("89efc9f8-a1a8-4ca4-accb-72741ca89d18"),
                        Tag = new NewsTag
                        {
                            Name = Tags.HockeyNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("c3d9032b-5b1b-4c67-9267-fcf6a890a660"),
                        Tag = new NewsTag
                        {
                            Name = Tags.KhlNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]",
                    TextDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("a811b3a1-c233-4875-9930-b99032c4fe99"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("9dc5c8f6-835a-44c5-bb98-2d988cd7001d"),
                        NameXPath = "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("99e62b88-dd05-4581-a2e1-eb1f2616a05f"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("d3c31d01-f7fd-42e6-8378-3df623d1fc09"),
                        PublishedAtXPath = "//div[@class='newsDetail-body__item-subHeader']/time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("9b3343e0-5099-4696-a6b4-c00035cc78b3"),
                                Format = "d MMMM yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("d6c237fe-b4c2-47b1-918f-298f4a9eafdf"),
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.khl.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("1994c4bc-aeb9-4242-81df-5bafffca6fd0"),
                Title = "Радио Sputnik",
                SiteUrl = "https://radiosputnik.ru/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("e8db752b-966e-4c0f-9cab-895cda0de469"),
                    Small = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico",
                    Original = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4f09a167-0888-4ee7-9f0a-0cf691870de1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("8477f4da-0bb6-4f77-9d5b-e8681d275e34"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("4b5473d0-5275-4615-94e2-596a86b383dd"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("faddd74b-9234-4412-be8c-74b05ce04dc7"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RadioNewsTag
                        }
                    },
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("dd419d1c-db40-4fd4-8f12-34206242d7cc"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("cbcb009b-37f0-4cf5-882c-df9a9e7dc908"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("3dc22c77-8081-46cf-b981-fb88b2bfcece"),
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("b1ce7387-38c3-475c-a085-0984b9ba8b00"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("3785f3c0-c9d3-4e29-a0b8-46fa78983506"),
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("5b48664a-bb06-480d-bbd4-c7acebf918db"),
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        Id = Guid.Parse("458c1359-0212-451f-9c05-a6d043114989"),
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Id = Guid.Parse("405dd507-6429-4fd3-a76f-7c211adbb18e"),
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("112b8f16-4de2-4679-bed3-cf3c4ce5e1ed"),
                    NewsUrlXPath = "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://radiosputnik.ru/"
                },
            });

            Add(new NewsSource
            {
                Id = Guid.Parse("3a346f18-1781-408b-bc8d-2f8e4cbc64ea"),
                Title = "Meduza",
                SiteUrl = "https://meduza.io/",
                IsSystem = true,
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Id = Guid.Parse("6e7dee47-3b1c-4ec8-b2c7-b6ec29fcc6f5"),
                    Small = "https://meduza.io/favicon-32x32.png",
                    Original = "https://meduza.io/apple-touch-icon-180.png"
                },
                Tags = new List<NewsSourceTag>
                {
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("b681073b-3a8a-469e-8d03-db44364f0557"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussianNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("eeb9e776-c05e-499f-ad3d-49dd23a8f1e1"),
                        Tag = new NewsTag
                        {
                            Name = Tags.RussiaNewsTag
                        }
                    },
                    new NewsSourceTag
                    {
                        Id = Guid.Parse("2765ef2f-338c-4f92-a1d2-4ed1dc54ed83"),
                        Tag = new NewsTag
                        {
                            Name = Tags.PoliticsNewsTag
                        }
                    }
                },
                ParseSettings = new NewsParseSettings
                {
                    Id = Guid.Parse("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"),
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]",
                    TextDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        Id = Guid.Parse("4ff736eb-a44a-4880-aa4f-f70988527bfe"),
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        Id = Guid.Parse("8f7062f8-e5f9-429b-900f-98412ea04f84"),
                        NameXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        Id = Guid.Parse("d8dc9296-e936-406b-aad9-916f05f1b3fe"),
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        Id = Guid.Parse("5e7874b1-13e9-4cf5-a96a-6612fe3661cf"),
                        PublishedAtXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "UTC",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Id = Guid.Parse("a9340a6d-ec66-49fc-8150-3a6a698e999e"),
                                Format = "HH:mm, d MMMM yyyy"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    Id = Guid.Parse("04980ca4-2525-446d-ba36-b6ec342d951e"),
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://meduza.io/"
                },
            });
        }
    }
}
