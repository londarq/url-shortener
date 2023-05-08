using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using url_shortener.Context;

namespace url_shortener.Controllers
{
    [ApiController]
    [Route("/{shortUrl}")]
    public class UrlRedirectController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UrlRedirectController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> RedirectAsync(string shortUrl)
        {
            var dbUrl = await _context.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);

            if (dbUrl != null)
            {
                return RedirectPermanent(dbUrl.TargetUrl);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
