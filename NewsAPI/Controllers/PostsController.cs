using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News_Parser;
using Microsoft.EntityFrameworkCore;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        //GET api/news/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsModel>> Get(int id)
        {
            using (var context = new NewsDbContext())
            {
                NewsModel news = await context.News.FirstOrDefaultAsync(x => x.NewsId == id);
                if (news == null)
                {
                    return NotFound();
                }
                return new ObjectResult(news);
            }
        }


        [HttpGet]
        public ActionResult DateRange (DateTime from, DateTime to)
        {
            NewsDbContext news = new NewsDbContext();
            var result = news.News.Where(x => x.newsDate >= from && x.newsDate <= to);
            return Ok(result);
        }

    }
}
