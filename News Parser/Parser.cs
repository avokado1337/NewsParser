using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Parser
{
    class Parser
    {
        public static void newsParser()
        {
            using (var context = new NewsDbContext())
            {
                Console.OutputEncoding = Encoding.UTF8;

                //Putting the links in the variables

                Console.WriteLine("Введите количество страниц для парсинга:");
                string str = Console.ReadLine();

                int userInput = int.Parse(str);


                for (var i = 1; i <= userInput; i++)
                {
                    var urlNews = @"https://tengrinews.kz/news/page/" + i;

                    var urlMain = @"https://tengrinews.kz";

                    var htmlWeb = new HtmlWeb();

                    var htmlDoc = htmlWeb.Load(urlNews);


                    var nextPage = htmlDoc.DocumentNode.SelectSingleNode("//ul[@class='tn-pagination']/li[last()]/a");

                    var currentPage = htmlDoc.DocumentNode.SelectSingleNode("//li[@class='tn-active']/span/text()");


                    Console.WriteLine("Номер текущей страницы: " + currentPage.InnerText.ToString());

                    List<string> listOfLinks = new List<string>();

                    var row = new NewsModel();


                    //Getting the links of the news articles
                    var NewsLinksNode = htmlDoc.DocumentNode.SelectNodes("//*[@class='tn-link']");
                    //Creating a list and putting all the parsed links into it.
                    foreach (var links in NewsLinksNode)
                    {
                        var newsLinks = urlMain + links.GetAttributeValue("href", null);

                        List<string> listOfLinks1 = newsLinks.Split(new char[] { ',' }).ToList();

                        listOfLinks.AddRange(listOfLinks1);
                    }

                    //Iterating through the list of links
                    foreach (var newsInfo in listOfLinks)
                    {

                        var htmlNews = htmlWeb.Load(newsInfo);

                        //Getting the titles
                        var newsTitle = htmlNews.DocumentNode.SelectSingleNode("//section[@class='tn-single-section tn-container']/div[@class='tn-content']/h1[@class='tn-content-title']/text()");
                        Console.WriteLine(newsTitle.InnerText.Trim());

                        ////Getting dates
                        //var newsDate = htmlNews.DocumentNode.SelectSingleNode("//h1[@class='tn-content-title']/span[@class='tn-hidden']/text()");

                        ////Getting the dates
                        //var today = DateTime.Today;
                        //var yesterday = today.AddDays(-1);
                        //string normalFormat = newsDate.InnerText.ToString().Trim();
                        //var parsedDate = DateTime.Parse(normalFormat.Replace("вчера", yesterday.ToString("dd-MM-yy").Replace("сегодня", today.ToString("dd-MM-yy").ToString().Trim())));

                        ////Getting texts
                        //var newsText = htmlNews.DocumentNode.SelectNodes(".//article[@class='tn-news-text']/p[position() != last() and position() != last() - 1]/text()");
                        //StringBuilder sb = new StringBuilder();
                        //foreach (var node in newsText)
                        //{
                        //    sb.Append(node.InnerText);
                        //}

                        ////Getting themes
                        //var newsTheme = htmlNews.DocumentNode.SelectSingleNode("//ol[@class='tn-bread-crumbs']/li[last()]/a/span/text()");


                        //context.News.Add(new NewsModel
                        //{
                        //    Title = newsTitle.InnerText.ToString().Trim().Replace("&quot;", @""""),
                        //    Theme = newsTheme.InnerText.ToString().Trim().Replace("&quot;", @""""),
                        //    Text = sb.ToString().Trim().Replace("&quot;", @""""),
                        //    newsDate = parsedDate
                        //});

                        //context.SaveChanges();
                    }
                    Console.WriteLine("Success!");
                }
            }
        }
    }
}

