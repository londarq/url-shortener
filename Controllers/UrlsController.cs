using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using url_shortener.Context;
using url_shortener.Models;

namespace url_shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UrlsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UrlsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Urls
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Url>>> GetUrls()
        {
            return await _context.Urls.ToListAsync();
        }

        // GET: api/Urls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Url>> GetUrl(int id)
        {
            var url = await _context.Urls.FindAsync(id);

            if (url == null)
            {
                return NotFound();
            }
            
            return url;
        }

        // POST: api/Urls
        [HttpPost]
        public async Task<ActionResult<Url>> PostUrl([FromBody] LongUrl longUrl)
        {
            if (string.IsNullOrEmpty(longUrl.url))
            {
                return BadRequest("Request body is empty.");
            }

            if (!Uri.IsWellFormedUriString(Uri.UnescapeDataString(longUrl.url), UriKind.Absolute))
            {
                return BadRequest("The URL you entered is not valid.");
            }

            var existingUrl = await _context.Urls.FirstOrDefaultAsync(u => u.TargetUrl == longUrl.url);

            if (existingUrl != null)
            {
                return NoContent();
            }

            string shortUrl;

            do
            {
                shortUrl = GenerateShortForm();
            } while (await _context.Urls.AnyAsync(u => u.ShortUrl == shortUrl));

            var newUrl = await _context.Urls.AddAsync(new Url()
            {
                ShortUrl = shortUrl,
                TargetUrl = longUrl.url,
                UserName = User?.Identity.Name ?? "test"
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostUrl), new { id = newUrl.Entity.Id }, newUrl.Entity);
        }

        // DELETE: api/Urls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            
            if (url == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin") || url.UserName == User.Identity.Name)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Forbid();
            }
        }

        static string GenerateShortForm()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
