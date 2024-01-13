using NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class NewsSources : List<NewsSource>
    {
        public NewsSources()
        {
            Add(new NewsSource
            {
                Title = "РИА Новости",
                SiteUrl = "https://ria.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//div[@class='article__title']/text()",
                    DescriptionXPath  = "//div[contains(@class, 'article__body')]",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='photoview__open']/img/@src"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h1[@class='article__second-title']/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__info']//div[@class='article__info-date']/a/text()",
                        PublishedAtFormat = "HH:mm dd.MM.yyyy",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://ria.ru/",
                    NewsUrlXPath = "//a[contains(@class, 'cell-list__item-link')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "RT на русском",
                SiteUrl = "https://russian.rt.com/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'article__text ')]",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'article__summary')]/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime",
                        PublishedAtFormat = "yyyy-MM-d HH:mm",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://russian.rt.com/",
                    NewsUrlXPath = "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "ТАСС",
                SiteUrl = "https://tass.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//article",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h3/text()"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://tass.ru/",
                    NewsUrlXPath = "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Лента.Ру",
                SiteUrl = "https://lenta.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()",
                    DescriptionXPath = "//div[@class='topic-body__content']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()"
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'topic-body__title')]/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()",
                        PublishedAtFormat = "HH:mm, d M yyyy",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://lenta.ru/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Российская газета",
                SiteUrl = "https://rg.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'PageArticleContent_lead')]/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'PageArticleContent_date')]/text()",
                        PublishedAtFormat = "dd.MM.yyyy HH:mm",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://rg.ru/",
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Аргументы и факты",
                SiteUrl = "https://aif.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article_text']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()"
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='img_box']/a[@class='zoom_js']/img/@src"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article_top']//div[@class='date']//time/text()",
                        PublishedAtFormat = "dd.MM.yyyy HH:mm",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://aif.ru/",
                    NewsUrlXPath = "//span[contains(@class, 'item_text__title')]/../@href"
                }
            });

            Add(new NewsSource
            {
                Title = "РБК",
                SiteUrl = "https://www.rbc.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime",
                        PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.rbc.ru/",
                    NewsUrlXPath = "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Storts.ru",
                SiteUrl = "https://www.sports.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//header[@class='news-item__header']//time/@content",
                        PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.sports.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Коммерсантъ",
                SiteUrl = "https://www.kommersant.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//p[@class='doc__text document_authors']/text()"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime",
                        PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.kommersant.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Известия",
                SiteUrl = "https://iz.ru/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/span/text()",
                    DescriptionXPath = "//div[@itemprop='articleBody']",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime",
                        PublishedAtFormat = "yyyy-MM-ddTHH:mm:ssZ",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://iz.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '?main_click')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Царьград",
                SiteUrl = "https://tsargrad.tv/",
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1[@class='article__title']/text()",
                    DescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//a[@class='article__author']/text()"
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='article__media']//img/@src"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[@class='article__intro']/p/text()"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://tsargrad.tv/",
                    NewsUrlXPath = "//a[contains(@class, 'news-item__link')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "iXBT.games",
                SiteUrl = "https://ixbt.games/",
                Logo = new NewsSourceLogo
                {
                    Url = "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='container-fluid shifted']/p[@class='announce lead']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title"
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src"
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()"
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()",
                        PublishedAtFormat = "yyyy-MM-dd HH:mm:ss",
                        PublishedAtCultureInfo = "ru-RU"
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://ixbt.games/news/",
                    NewsUrlXPath = "//a[@class='card-link']/@href"
                }
            });
        }
    }
}
