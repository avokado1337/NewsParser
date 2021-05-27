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
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetByWord (string word)
        {
                NewsDbContext news = new NewsDbContext();
                var result = news.News.Where(x => x.Text.Contains(word));
                return Ok(result);
            }
        }
    }
