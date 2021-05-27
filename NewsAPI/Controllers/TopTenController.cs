using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace NewsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TopTenController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Test(int id)
        {
            //Взято из пакета Lucene
            string[] RUSSIAN_STOP_WORDS_30 = new string[] {
            "а", "без", "более", "бы", "был", "была", "были", "было", "быть", "в",
            "вам", "вас", "весь", "во", "вот", "все", "всего", "всех", "вы", "где",
            "да", "даже", "для", "до", "его", "ее", "ей", "ею", "если", "есть",
            "еще", "же", "за", "здесь", "и", "из", "или", "им", "их", "к", "как",
            "ко", "когда", "кто", "ли", "либо", "мне", "может", "мы", "на", "надо",
            "наш", "не", "него", "нее", "нет", "ни", "них", "но", "ну", "о", "об",
            "однако", "он", "она", "они", "оно", "от", "очень", "по", "под", "при",
            "с", "со", "так", "также", "такой", "там", "те", "тем", "то", "того",
            "тоже", "той", "только", "том", "ты", "у", "уже", "хотя", "чего", "чей",
            "чем", "что", "чтобы", "чье", "чья", "эта", "эти", "это", "я" };


            NewsDbContext news = new NewsDbContext();
            var result = news.News.FirstOrDefault(x => x.NewsId == id).Text;
            var result1 = result
            .Split(new[] { '.', '?', '!', ' ', ';', ':', ',' })
            .Where(x => x.Length > 3)
            .GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .Take(10);

            return Ok(result1);
        }
    }
}
