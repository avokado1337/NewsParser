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
        [HttpGet]
        public ActionResult DateRange (DateTime from, DateTime to)
        {
            NewsDbContext news = new NewsDbContext();
            var result = news.News.Where(x => x.newsDate >= from && x.newsDate <= to);
            return Ok(result);
        }

    }
}
