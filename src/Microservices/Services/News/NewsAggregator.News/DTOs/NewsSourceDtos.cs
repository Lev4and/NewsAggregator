using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.DTOs
{
    public class NewsSourceDtos : List<NewsSourceDto>
    {
        public NewsSourceDtos()
        {
            Add(new NewsSourceDto
            {
                Title = "РИА Новости",
                SiteUrl = "https://ria.ru/",
                NewsSiteUrl = "https://ria.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//div[@class='article__title']/text()",
                    SubTitleXPath = "//h1[@class='article__second-title']/text()",
                    EditorNameXPath = null,
                    PictureUrlXPath = "//div[@class='photoview__open']/img/@src",
                    DescriptionXPath = "//div[contains(@class, 'article__body')]",
                    PublishedAtXPath = "//div[@class='article__info']//div[@class='article__info-date']/a/text()",
                    PublishedAtFormat = "HH:mm dd.MM.yyyy",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@class, 'cell-list__item-link')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "RT на русском",
                SiteUrl = "https://russian.rt.com/",
                NewsSiteUrl = "https://russian.rt.com/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//div[contains(@class, 'article__summary')]/text()",
                    EditorNameXPath = null,
                    PictureUrlXPath = null,
                    DescriptionXPath = "//div[contains(@class, 'article__text ')]",
                    PublishedAtXPath = "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime",
                    PublishedAtFormat = "yyyy-MM-d HH:mm",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "ТАСС",
                SiteUrl = "https://tass.ru/",
                NewsSiteUrl = "https://tass.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//h3/text()",
                    EditorNameXPath = null,
                    PictureUrlXPath = "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src",
                    DescriptionXPath = "//article",
                    PublishedAtXPath = null,
                    PublishedAtFormat = null,
                    PublishedAtCultureInfo = null
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/')]/@href",
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Лента.Ру",
                SiteUrl = "https://lenta.ru/",
                NewsSiteUrl = "https://lenta.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()",
                    SubTitleXPath = "//div[contains(@class, 'topic-body__title')]/text()",
                    EditorNameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()",
                    PictureUrlXPath = "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src",
                    DescriptionXPath = "//div[@class='topic-body__content']",
                    PublishedAtXPath = "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()",
                    PublishedAtFormat = "HH:mm, d M yyyy",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') or starts-with(@href, '/articles/')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Российская газета",
                SiteUrl = "https://rg.ru/",
                NewsSiteUrl = "https://rg.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//div[contains(@class, 'PageArticleContent_lead')]/text()",
                    EditorNameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()",
                    PictureUrlXPath = null,
                    DescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]",
                    PublishedAtXPath = "//div[contains(@class, 'PageArticleContent_date')]/text()",
                    PublishedAtFormat = "dd.MM.yyyy HH:mm",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Аргументы и факты",
                SiteUrl = "https://aif.ru/",
                NewsSiteUrl = "https://aif.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = null,
                    EditorNameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()",
                    PictureUrlXPath = "//div[@class='img_box']/a[@class='zoom_js']/img/@src",
                    DescriptionXPath = "//div[@class='article_text']",
                    PublishedAtXPath = "//div[@class='article_top']//div[@class='date']//time/text()",
                    PublishedAtFormat = "dd.MM.yyyy HH:mm",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//span[contains(@class, 'item_text__title')]/../@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "РБК",
                SiteUrl = "https://www.rbc.ru/",
                NewsSiteUrl = "https://www.rbc.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()",
                    EditorNameXPath = "//div[@class='article__authors']//span[@class='article__authors__author']/span[@class='article__authors__author__name']/text()",
                    PictureUrlXPath = null,
                    DescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]",
                    PublishedAtXPath = "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime",
                    PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Storts.ru",
                SiteUrl = "https://www.sports.ru/",
                NewsSiteUrl = "https://www.sports.ru/news/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = null,
                    EditorNameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()",
                    PictureUrlXPath = null,
                    DescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                    PublishedAtXPath = "//header[@class='news-item__header']//time/@content",
                    PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Коммерсантъ",
                SiteUrl = "https://www.kommersant.ru/",
                NewsSiteUrl = "https://www.kommersant.ru/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//header[@class='doc_header']/h2[@class='doc_header__subheader']/text()",
                    EditorNameXPath = "//p[@class='doc__text document_authors']/text()",
                    PictureUrlXPath = null,
                    DescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                    PublishedAtXPath = "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime",
                    PublishedAtFormat = "yyyy-MM-ddTHH:mm:sszzz",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Известия",
                SiteUrl = "https://iz.ru/",
                NewsSiteUrl = "https://iz.ru/news/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/span/text()",
                    SubTitleXPath = null,
                    EditorNameXPath = null,
                    PictureUrlXPath = "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src",
                    DescriptionXPath = "//div[@itemprop='articleBody']",
                    PublishedAtXPath = "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime",
                    PublishedAtFormat = "yyyy-MM-ddTHH:mm:ssZ",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@href, '?main_click')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "Царьград",
                SiteUrl = "https://tsargrad.tv/",
                NewsSiteUrl = "https://tsargrad.tv/",
                LogoUrl = null,
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1[@class='article__title']/text()",
                    SubTitleXPath = "//div[@class='article__intro']/p/text()",
                    EditorNameXPath = "//a[@class='article__author']/text()",
                    PictureUrlXPath = "//div[@class='article__media']//img/@src",
                    DescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                    PublishedAtXPath = null,
                    PublishedAtFormat = null,
                    PublishedAtCultureInfo = null
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[contains(@class, 'news-item__link')]/@href"
                }
            });

            Add(new NewsSourceDto
            {
                Title = "iXBT.games",
                SiteUrl = "https://ixbt.games/",
                NewsSiteUrl = "https://ixbt.games/news/",
                LogoUrl = "https://sun13-2.userapi.com/s/v1/ig2/_ID-2w6Llad8ig5_987dKAfh1pyLdj7HfLHqGx9HxyDjoEDN7wxR0ZWJm5ja1Ey6UuQXaEYEBW1Zd51cpRrjSGfS.jpg?size=100x100&quality=96&crop=22,22,626,626&ava=1",
                ParseSettings = new NewsParserOptions
                {
                    TitleXPath = "//h1/text()",
                    SubTitleXPath = "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()",
                    EditorNameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title",
                    PictureUrlXPath = "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src",
                    DescriptionXPath = "//div[@class='container-fluid shifted']/p[@class='announce lead']",
                    PublishedAtXPath = "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()",
                    PublishedAtFormat = "yyyy-MM-dd HH:mm:ss",
                    PublishedAtCultureInfo = "ru-RU"
                },
                SearchSettings = new NewsUrlsParserOptions
                {
                    NewsUrlXPath = "//a[@class='card-link']/@href"
                }
            });
        }
    }
}
