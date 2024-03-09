﻿using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;

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
                Title = "РИА Новости",
                SiteUrl = "https://ria.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://cdnn21.img.ria.ru/i/favicons/favicon.ico",
                    Original = "https://cdnn21.img.ria.ru/i/favicons/favicon.svg"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]",
                    TextDescriptionXPath = "//div[contains(@class, 'article__body')]//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//div[@class='article__header']//div[@class='media__video']//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyyMMddTHHmm"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://russian.rt.com/favicon.ico",
                    Original = "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__text ')]",
                    TextDescriptionXPath = "//div[contains(@class, 'article__text ')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='mediator_author']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@name='mediator_published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://tass.ru/favicon/57.png",
                    Original = "https://tass.ru/favicon/180.svg"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/*",
                    TextDescriptionXPath = "//article/*//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "UTC",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy, HH:mm,"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM, HH:mm,"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "UTC",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "\"обновлено\" d MMMM yyyy, HH:mm"
                            },
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "\"обновлено\" d MMMM, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://tass.ru/",
                    NewsUrlXPath = "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Лента.Ру",
                SiteUrl = "https://lenta.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://icdn.lenta.ru/favicon.ico",
                    Original = "https://icdn.lenta.ru/images/icons/icon-256x256.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='topic-body__content']",
                    TextDescriptionXPath = "//div[@class='topic-body__content']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//div[contains(@class, 'eagleplayer')]//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "HH:mm, d MMMM yyyy"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://lenta.ru/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Российская газета",
                SiteUrl = "https://rg.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://rg.ru/favicon.ico",
                    Original = "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]",
                    TextDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://aif.ru/img/icon/favicon-32x32.png?44f",
                    Original = "https://aif.ru/img/icon/apple-touch-icon.png?44f"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article_text']",
                    TextDescriptionXPath = "//div[@class='article_text']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article_top']//div[@class='date']//time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd.MM.yyyy HH:mm"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png",
                    Original = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]",
                    TextDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@itemprop='url']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.sports.ru/apple-touch-icon-76.png",
                    Original = "https://www.sports.ru/apple-touch-icon-1024.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                    TextDescriptionXPath = "//div[contains(@class, 'news-item__content')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//header[@class='news-item__header']//time/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.sports.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Коммерсантъ",
                SiteUrl = "https://www.kommersant.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png",
                    Original = "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                    TextDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//p[@class='doc__text document_authors']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png",
                    Original = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
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
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://tsargrad.tv/favicons/favicon-32x32.png?s2",
                    Original = "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                    TextDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//a[@class='article__author']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//meta[@property='og:video']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mmzzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mmzzz"
                            }
                        }
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
                Title = "БелТА",
                SiteUrl = "http://www.belta.by/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg",
                    Original = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='js-mediator-article']",
                    TextDescriptionXPath = "//div[@class='js-mediator-article']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "http://www.belta.by/",
                    NewsUrlXPath = "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "СвободнаяПресса",
                SiteUrl = "https://svpressa.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://svpressa.ru/favicon-32x32.png?v=1471426270000",
                    Original = "https://svpressa.ru/favicon-96x96.png?v=1471426270000"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]",
                    TextDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='b-text__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM  HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://svpressa.ru/all/news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href"
                },
            });

            Add(new NewsSource
            {
                Title = "Москва 24",
                SiteUrl = "https://www.m24.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.m24.ru/img/fav/favicon-32x32.png",
                    Original = "https://www.m24.ru/img/fav/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]",
                    TextDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//meta[@property='og:video:url']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//p[@class='b-material__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.m24.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "ВЗГЛЯД.РУ",
                SiteUrl = "https://vz.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://vz.ru/static/images/favicon.ico",
                    Original = "https://vz.ru/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/div[@class='news_text']",
                    TextDescriptionXPath = "//article/div[@class='news_text']//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//article/p[@class='author']/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article/div[@class='header']/span/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy, HH:mm\" •\""
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://vz.ru/",
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Чемпионат.com",
                SiteUrl = "https://www.championat.com/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://st.championat.com/i/favicon/favicon-32x32.png",
                    Original = "https://st.championat.com/i/favicon/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]",
                    TextDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article//header//time[@class='article-head__date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy, HH:mm \"МСК\""
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news",
                    NewsUrlXPath = "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Life",
                SiteUrl = "https://life.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://life.ru/favicon-32%D1%8532.png",
                    Original = "https://life.ru/appletouch/apple-icon-180%D1%85180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]",
                    TextDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://life.ru/s/novosti",
                    NewsUrlXPath = "//a[contains(@href, '/p/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "3Dnews.ru",
                SiteUrl = "https://3dnews.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://3dnews.ru/assets/3dnews_logo_color.png",
                    Original = "https://3dnews.ru/assets/images/3dnews_logo_soc.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]",
                    TextDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='mediator_author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://3dnews.ru/news/",
                    NewsUrlXPath = "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href"
                }
            });

            Add(new NewsSource
            {
                Title = "iXBT.com",
                SiteUrl = "https://www.ixbt.com/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.ixbt.com/favicon.ico",
                    Original = "https://www.ixbt.com/favicon.ico"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//span[@itemprop='author']/span[@itemprop='name']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='b-article__top-author']/p[@class='date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy \"в\" HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.ixbt.com/news/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "iXBT.games",
                SiteUrl = "https://ixbt.games/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png",
                    Original = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@name='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]",
                    TextDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@name='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd HH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://ixbt.games/news/",
                    NewsUrlXPath = "//a[@class='card-link']/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Газета.Ru",
                SiteUrl = "https://www.gazeta.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg",
                    Original = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.gazeta.ru/news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Интерфакс",
                SiteUrl = "https://www.interfax.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.interfax.ru/touch-icon-iphone.png",
                    Original = "https://www.interfax.ru/touch-icon-ipad-retina.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]",
                    TextDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.interfax.ru/",
                    NewsUrlXPath = "//div[@class='timeline']//a[@tabindex=5]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Правда.ру",
                SiteUrl = "https://www.pravda.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.pravda.ru/favicon.ico",
                    Original = "https://www.pravda.ru/pix/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@name='title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]",
                    TextDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.pravda.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Ura.ru",
                SiteUrl = "https://ura.news/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://s.ura.news/favicon.ico?3",
                    Original = "https://ura.news/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@itemprop='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@itemprop='author']/span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://ura.news/",
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "74.ru",
                SiteUrl = "https://74.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico",
                    Original = "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@itemprop='author']//p[@itemprop='name']/text()",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://74.ru/",
                    NewsUrlXPath = "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Первый областной",
                SiteUrl = "https://www.1obl.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.1obl.ru/favicon-32x32.png",
                    Original = "https://www.1obl.ru/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//*[@itemprop='author']/*[@itemprop='name']//text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.1obl.ru/news/",
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Cybersport.ru",
                SiteUrl = "https://www.cybersport.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.cybersport.ru/favicon-32x32.png",
                    Original = "https://www.cybersport.ru/favicon-192x192.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]",
                    TextDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.cybersport.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/tags/')]/@href",
                },
            });

            Add(new NewsSource
            {
                Title = "HLTV.org",
                SiteUrl = "https://www.hltv.org/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.hltv.org/img/static/favicon/favicon-32x32.png",
                    Original = "https://www.hltv.org/img/static/favicon/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings 
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]",
                    TextDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//article//span[@class='author']/a[@class='authorName']/span/text()",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article//div[@class='article-info']/div[@class='date']/text()",
                        PublishedAtCultureInfo = "en-US",
                        PublishedAtTimeZoneInfoId = "Central Europe Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d-M-yyyy HH:mm"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://www.hltv.org/",
                },
            });

            Add(new NewsSource
            {
                Title = "The New York Times",
                SiteUrl = "https://www.nytimes.com/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png",
                    Original = "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@name='articleBody']/*",
                    TextDescriptionXPath = "//section[@name='articleBody']/*//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//span[@itemprop='name']/a/text()",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "en-US",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "en-US",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.nytimes.com/"
                }
            });

            Add(new NewsSource
            {
                Title = "CNN",
                SiteUrl = "https://edition.cnn.com/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://edition.cnn.com/media/sites/cnn/favicon.ico",
                    Original = "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "en-US",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>()
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "en-US",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>() 
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://edition.cnn.com/"
                },
            });

            Add(new NewsSource
            {
                Title = "Комсомольская правда",
                SiteUrl = "https://www.kp.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png",
                    Original = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]",
                    TextDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://www.kp.ru/"
                },
            });

            Add(new NewsSource
            {
                Title = "Журнал \"За рулем\"",
                SiteUrl = "https://www.zr.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.zr.ru/favicons/favicon.ico",
                    Original = "https://www.zr.ru/favicons/safari-pinned-tab.svg",
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@name='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]",
                    TextDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@name='og:image']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()",
                        IsRequired = false,
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href",
                    NewsSiteUrl = "https://www.zr.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "АвтоВзгляд",
                SiteUrl = "https://www.avtovzglyad.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png",
                    Original = "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']/*[not(name()='script')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[@class='news-card__link']/@href",
                    NewsSiteUrl = "https://www.avtovzglyad.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "Overclockers",
                SiteUrl = "https://overclockers.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://overclockers.ru/assets/apple-touch-icon.png",
                    Original = "https://overclockers.ru/assets/apple-touch-icon-120x120.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//a[@class='header']/text()",
                    HtmlDescriptionXPath = "//div[contains(@class, 'material-content')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'material-content')]/p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//span[@class='author']/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//span[@class='date']/time/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href",
                    NewsSiteUrl = "https://overclockers.ru/news"
                },
            });

            Add(new NewsSource
            {
                Title = "KinoNews.ru",
                SiteUrl = "https://www.kinonews.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.kinonews.ru/favicon.ico",
                    Original = "https://www.kinonews.ru/favicon.ico"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='textart']/div[not(@class)]/*",
                    TextDescriptionXPath = "//div[@class='textart']/div[not(@class)]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[@class='block-page-new']/h2/text()",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href",
                    NewsSiteUrl = "https://www.kinonews.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "7дней.ru",
                SiteUrl = "https://7days.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://7days.ru/favicon-32x32.png",
                    Original = "https://7days.ru/android-icon-192x192.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]",
                    TextDescriptionXPath = "//div[@class='material-7days__paragraf-content']//p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://7days.ru/news/"
                }
            });

            Add(new NewsSource
            {
                Title = "Сетевое издание «Онлайн журнал StarHit (СтарХит)",
                SiteUrl = "https://www.starhit.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png",
                    Original = "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//p[contains(@itemprop, 'alternativeHeadline')]/text()",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='author']/@content",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[@class='announce-inline-tile__label-container']/@href",
                    NewsSiteUrl = "https://www.starhit.ru/novosti/"
                },
            });

            Add(new NewsSource
            {
                Title = "StopGame",
                SiteUrl = "https://stopgame.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://stopgame.ru/favicon.ico",
                    Original = "https://stopgame.ru/favicon_512.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*",
                    TextDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false,
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()",
                        IsRequired = false,
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false,
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href",
                    NewsSiteUrl = "https://stopgame.ru/news"
                },
            });

            Add(new NewsSource
            {
                Title = "РЕН ТВ",
                SiteUrl = "https://ren.tv/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://ren.tv/favicon-32x32.png",
                    Original = "https://ren.tv/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='widgets__item__text__inside']/*",
                    TextDescriptionXPath = "//div[@class='widgets__item__text__inside']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://ren.tv/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "Новороссия",
                SiteUrl = "https://www.novorosinform.org/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.novorosinform.org/favicon.ico?v3",
                    Original = "https://www.novorosinform.org/favicon.ico?v3"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='only__text']/*",
                    TextDescriptionXPath = "//div[@class='only__text']/*[not(name()='script')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article__content']//strong[text()='Автор:']/../text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__content']//time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.novorosinform.org/"
                }
            });

            Add(new NewsSource
            {
                Title = "Пятый канал",
                SiteUrl = "https://www.5-tv.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png",
                    Original = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@id='article_body']/*",
                    TextDescriptionXPath = "//div[@id='article_body']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@name='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParseVideoSettings = new NewsParseVideoSettings
                    {
                        UrlXPath = "//meta[@property='og:video']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href",
                    NewsSiteUrl = "https://www.5-tv.ru/news/"
                }
            });

            Add(new NewsSource
            {
                Title = "НТВ",
                SiteUrl = "https://www.ntv.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png",
                    Original = "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*",
                    TextDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd.MM.yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href",
                    NewsSiteUrl = "https://www.ntv.ru/novosti/"
                }
            });

            Add(new NewsSource
            {
                Title = "ФОНТАНКА.ру",
                SiteUrl = "https://www.fontanka.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png",
                    Original = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//section[@itemprop='articleBody']//p//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='ajur:article:authors']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//section//ul/li[@class='IBae3']//a[@class='IBd3']/@href",
                    NewsSiteUrl = "https://www.fontanka.ru/24hours_news.html"
                },
            });

            Add(new NewsSource
            {
                Title = "ИА REGNUM",
                SiteUrl = "https://regnum.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://regnum.ru/favicons/favicon-32x32.png?v=202305",
                    Original = "https://regnum.ru/favicons/apple-touch-icon.png?v=202305"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]",
                    TextDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://regnum.ru/news"
                },
            });

            Add(new NewsSource
            {
                Title = "Женский журнал WomanHit.ru",
                SiteUrl = "https://www.womanhit.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2",
                    Original = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//span[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//span[@itemprop='articleBody']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings 
                    {
                        NameXPath = "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:sszzz"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href",
                    NewsSiteUrl = "https://www.womanhit.ru/"
                },
            });

            Add(new NewsSource
            {
                Title = "Русская весна",
                SiteUrl = "https://rusvesna.su/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://rusvesna.su/favicon.ico",
                    Original = "https://rusvesna.su/favicon.ico"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//span[@class='submitted-by']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd.MM.yyyy \"-\" HH:mm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='og:updated_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-dd HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://rusvesna.su/news"
                },
            });

            Add(new NewsSource
            {
                Title = "TravelAsk",
                SiteUrl = "https://travelask.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://s9.travelask.ru/favicons/favicon-32x32.png",
                    Original = "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                    TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://travelask.ru/news"
                },
            });

            Add(new NewsSource
            {
                Title = "SMART-LAB",
                SiteUrl = "https://smart-lab.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico",
                    Original = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*",
                    TextDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@name='DESCRIPTION']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href",
                    NewsSiteUrl = "https://smart-lab.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "Финам.Ру",
                SiteUrl = "https://www.finam.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.finam.ru/favicon.png",
                    Original = "https://www.finam.ru/favicon-144x144.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//span[@id='publication-date']/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd.MM.yyyy HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href",
                    NewsSiteUrl = "https://www.finam.ru/"
                },
            });

            Add(new NewsSource
            {
                Title = "КХЛ",
                SiteUrl = "https://www.khl.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://www.khl.ru/img/icons/32x32.png",
                    Original = "https://www.khl.ru/img/icons/152x152.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]",
                    TextDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='newsDetail-body__item-subHeader']/time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "d MMMM yyyy, HH:mm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://www.khl.ru/news/"
                },
            });

            Add(new NewsSource
            {
                Title = "Радио Sputnik",
                SiteUrl = "https://radiosputnik.ru/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico",
                    Original = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]/*",
                    TextDescriptionXPath = "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//meta[@property='article:author']/@content",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                    ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                    {
                        ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                        ModifiedAtCultureInfo = "ru-RU",
                        ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = false,
                        Formats = new List<NewsParseModifiedAtSettingsFormat>
                        {
                            new NewsParseModifiedAtSettingsFormat
                            {
                                Format = "yyyyMMddTHHmm"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href",
                    NewsSiteUrl = "https://radiosputnik.ru/"
                },
            });

            Add(new NewsSource
            {
                Title = "Meduza",
                SiteUrl = "https://meduza.io/",
                IsEnabled = true,
                Logo = new NewsSourceLogo
                {
                    Small = "https://meduza.io/favicon-32x32.png",
                    Original = "https://meduza.io/apple-touch-icon-180.png"
                },
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//meta[@property='og:title']/@content",
                    HtmlDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]",
                    TextDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//meta[@property='og:description']/@content",
                        IsRequired = false
                    },
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//meta[@property='og:image']/@content",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "UTC",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "HH:mm, d MMMM yyyy"
                            }
                        }
                    },
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                    NewsSiteUrl = "https://meduza.io/"
                },
            });
        }
    }
}
