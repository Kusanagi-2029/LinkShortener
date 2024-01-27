using LinkShortener.Models;

namespace LinkShortener.Services
{
    public interface IShortLinkService
    {
        ShortLinks GetById(int id);

        ShortLinks GetByPath(string path);

        ShortLinks GetByOriginalUrl(string originalUrl);

        int Save(ShortLinks ShortLinks);
    }
}