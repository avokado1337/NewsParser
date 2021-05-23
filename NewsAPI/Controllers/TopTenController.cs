using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopTenController : ControllerBase
    {
        //public IActionResult Test(int id)
        //{
        //    NewsDbContext news = new NewsDbContext();
        //    var result = news.News.Where(x => x.NewsId = id).Select(p => p.Text).GroupBy(p => p).OrderByDescending(p => p.Count()).Take(10).ToArray();
        //    return Ok(result);
        //}
    }
}
