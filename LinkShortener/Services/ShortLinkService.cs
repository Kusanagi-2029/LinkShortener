using LinkShortener.Helpers;
using LinkShortener.Models;

namespace LinkShortener.Services
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly LinkShortenerContext _context;

        public ShortLinkService(LinkShortenerContext context)
        {
            _context = context;
        }

        public ShortLinks GetById(int id)
        {
            return _context.ShortLinks.Find(id);
        }

        public ShortLinks GetByPath(string path)
        {
            return _context.ShortLinks.Find(ShortLinkHelper.Decode((path)));
        }

        public ShortLinks GetByOriginalUrl(string originalUrl)
        {
            foreach (var ShortLinks in _context.ShortLinks) {
                if (ShortLinks.OriginalUrl == originalUrl) {
                    return ShortLinks;
                }
            }

            return null;
        }

        public int Save(ShortLinks ShortLinks)
        {
            _context.ShortLinks.Add(ShortLinks);
            _context.SaveChanges();

            return ShortLinks.Id;
        }
    }
}