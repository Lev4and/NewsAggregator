using NewsAggregator.News.Entities;

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
            get => this.Single(newsSource => new Uri(newsSource.SiteUrl).Host == uri.Host);
        }

        public Sources()
        {
            Add(new NewsSource
            {
                Title = "РИА Новости",
                SiteUrl = "https://ria.ru/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//div[@class='article__title']/text()",
                    DescriptionXPath  = "//div[contains(@class, 'article__body')]",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='photoview__open']/img/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h1[@class='article__second-title']/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__info']//div[@class='article__info-date']/a/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "HH:mm dd.MM.yyyy"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'article__text ')]",
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'article__summary')]/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'article__date-autor-shortcode')]/div[contains(@class, 'article__date')]/time[@class='date']/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-d HH:mm"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//article",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'HeaderMedia_image')]//img[contains(@class, 'Image_image')]/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h3/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        PublishedAtTimeZoneInfoId = "UTC",
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy, HH:mm,"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM, HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM, HH:mm,"
                            }
                        }
                    }
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1[@class='topic-body__titles']/span[@class='topic-body__title']/text()",
                    DescriptionXPath = "//div[@class='topic-body__content']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'topic-body__title-image')]//img[contains(@class, 'picture__image')]/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'topic-body__title')]/text()",
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
                                Format = "HH:mm, dd MMMM yyyy"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()",
                        IsRequired = true
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'PageArticleContent_lead')]/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'PageArticleContent_date')]/text()",
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
                    NewsSiteUrl = "https://rg.ru/",
                    NewsUrlXPath = "//a[contains(@href, '.html')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Аргументы и факты",
                SiteUrl = "https://aif.ru/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article_text']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='img_box']/a[@class='zoom_js']/img/@src",
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'article__text')]/div[@class='article__text__overview']/span/text()",
                        IsRequired = false
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
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()",
                        IsRequired = true
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
                    NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments'))]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Коммерсантъ",
                SiteUrl = "https://www.kommersant.ru/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//p[@class='doc__text document_authors']/text()",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//header[@class='doc_header']/h2[contains(@class, 'doc_header__subheader')]/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='doc_header__time']/time[@class='doc_header__publish_time']/@datetime",
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
                    NewsSiteUrl = "https://www.kommersant.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Известия",
                SiteUrl = "https://iz.ru/",
                IsEnabled = false,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/span/text()",
                    DescriptionXPath = "//div[@itemprop='articleBody']",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'big_photo')]//div[@class='big_photo__img']//img/@src",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article_page__left__top__left']//div[@class='article_page__left__top__time']//time/@datetime",
                        PublishedAtCultureInfo = "ru-RU",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "yyyy-MM-ddTHH:mm:ssZ"
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
                IsEnabled = false,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1[@class='article__title']/text()",
                    DescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//a[@class='article__author']/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='article__media']//img/@src",
                        IsRequired = true
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[@class='article__intro']/p/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='article__meta']/time/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "Russian Standard Time",
                        IsRequired = true,
                        Formats = new List<NewsParsePublishedAtSettingsFormat>
                        {
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM yyyy HH:mm"
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
                    NewsSiteUrl = "https://tsargrad.tv/",
                    NewsUrlXPath = "//a[contains(@class, 'news-item__link')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "БелТА",
                SiteUrl = "https://www.belta.by/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='js-mediator-article']",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='inner_content']//div[@class='main_img']//img/@src",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[@class='date_full']/text()",
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
                    }
                },
                SearchSettings = new NewsSearchSettings
                {
                    NewsSiteUrl = "https://www.belta.by/",
                    NewsUrlXPath = "//a[contains(@href, 'https://www.belta.by/') and contains(@href, '/view/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "СвободнаяПресса",
                SiteUrl = "https://svpressa.ru/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1[@class='b-text__title']/text()",
                    DescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]",
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
                                Format = "dd MMMM yyyy HH:mm"
                            },
                            new NewsParsePublishedAtSettingsFormat
                            {
                                Format = "dd MMMM  HH:mm"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='b-material-incut-m-image']//@src",
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//article/div[@class='news_text']",
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//article/figure/img/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h4/text()",
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
                                Format = "dd MMMM yyyy, HH:mm"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//article/header/div[@class='article-head__title']/text()",
                    DescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//article//header//div[@class='article-head__author-name']/a[@rel='author']/span/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//article//header/div[@class='article-head__photo']/img/@src",
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
                                Format = "dd MMMM yyyy, HH:mm МСК"
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//article//header/div[contains(@class, 'styles_cover_media')]/img/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//article//header//p[contains(@class, 'styles_subtitle')]/text()",
                        IsRequired = false
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article//header//div[contains(@class, 'styles_meta')]//div[contains(@class, 'styles_metaItem')]/text()",
                        PublishedAtCultureInfo = "ru-RU",
                        PublishedAtTimeZoneInfoId = "UTC",
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()>1]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'article-entry')]//div[@class='entry-info']//a[@itemprop='author']//span[@itemprop='name']/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'article-entry')]//div[contains(@class, 'entry-body')]//div[@class='source-wrapper']/img[@itemprop='image']/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/p[position()=1]/text()",
                        IsRequired = true
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@itemprop='articleBody']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//span[@itemprop='author']/span[@itemprop='name']/@content",
                        IsRequired = true
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h4/text()",
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
                                Format = "dd MMMM yyyy в HH:mm"
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
                IsEnabled = false,
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
                        NameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//a[@class='glightbox']/img[contains(@class, 'pub-cover')]/@src",
                        IsRequired = true
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//div[@class='container-fluid shifted']/p[@class='announce lead']/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'publication-footer')]//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]/text()",
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@itemprop='articleBody']",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()",
                        IsRequired = false
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@class='b_article-media']//div[@class='mainarea-wrapper']/figure/img[@class='item-image-front']/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h2/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article/div[@class='b_article-header']//time[@itemprop='datePublished']/@datetime",
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
                IsEnabled = false,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]",
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//article[@itemprop='articleBody']/meta[@itemprop='datePublished']/@content",
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
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[contains(@class, 'full-article')]/div[@class='authors-block']//span[text()='Автор']/../a/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[contains(@class, 'full-article')]/div[contains(@class, 'gallery')]/picture/img/@src",
                        IsRequired = false
                    },
                    ParseSubTitleSettings = new NewsParseSubTitleSettings
                    {
                        TitleXPath = "//h1/text()",
                        IsRequired = true
                    },
                    ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                    {
                        PublishedAtXPath = "//div[contains(@class, 'full-article')]//time/text()",
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
                    NewsSiteUrl = "https://www.pravda.ru/",
                    NewsUrlXPath = "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href"
                }
            });

            Add(new NewsSource
            {
                Title = "Ura.ru",
                SiteUrl = "https://ura.news/",
                IsEnabled = true,
                ParseSettings = new NewsParseSettings
                {
                    TitleXPath = "//h1/text()",
                    DescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]",
                    ParseEditorSettings = new NewsParseEditorSettings
                    {
                        NameXPath = "//div[@itemprop='author']/span[@itemprop='name']/text()",
                        IsRequired = true
                    },
                    ParsePictureSettings = new NewsParsePictureSettings
                    {
                        UrlXPath = "//div[@itemprop='articleBody']//div[@itemprop='image']/picture/img[@itemprop='contentUrl']/@src",
                        IsRequired = true
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
        }
    }
}
