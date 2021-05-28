using Microsoft.AspNetCore.Authorization;
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
        private NewsDbContext _context;

        public SearchController(NewsDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetByWord (string word)
        {
                //NewsDbContext news = new NewsDbContext();
                var result = _context.News.Where(x => x.Text.Contains(word));
                return Ok(result);
            }
        }
    }
