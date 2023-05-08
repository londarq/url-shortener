namespace url_shortener.Models;

public class Url
{
    public int Id { get; set; }
    public string TargetUrl { get; set; }
    public string ShortUrl { get; set; }
    public string UserName { get; set; }
}
