# NewsParser
Парсинг новостного портала TengriNews.kz и API к нему.
Состоит из 2 проектов, Консольного приложения и Web API. 

Парсинг происходит через консольное приложение, выбором библиотеки для парсинга был HtmlAgilityPack.
Почему именно он? Потому что я лично нашел его более гибким чем, скажем, AngleSharp, и у меня уже был опыт с HtmlAgilityPack. Выбор HTML нодов через XPath сильно упрощает парсинг и позволяет точечно парсить нужные теги и текст.

Базой данных был выбран SQL SERVER EXPRESS. Бесплатная и легковесная версия SQL SERVER. 
База данных тоже находится в консольном приложении, таким образом заполнение базы происходит прямо во время парсинга.


Выбором для написания API стал ASP.NET CORE WEB API, и написание двух контроллеров на поиск по слову и по временному промежутку.
____________________________________________________________
Были добавлены аутентификация и авторизация с помощью Identity и JWT Bearer token. 
Следовал по гайду https://www.c-sharpcorner.com/article/authentication-and-authorization-in-asp-net-core-web-api-with-json-web-tokens/
Также Модели, Миграции и контекст базы данных были перенесены в новосозданный Data Access Layer. Причина этого была в том, что было множество трудностей с доступом к контексту данных в проекте для парсинга, поэтому и был создана эта библиотека классов в которую я и перенес модели и контекст.
