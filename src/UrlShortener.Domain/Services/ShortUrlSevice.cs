using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UrlShortener.Data;
using UrlShortener.Data.Models;
using UrlShortener.Domain.Repositories;

namespace UrlShortener.Domain.Services
{
    public class ShortUrlSevice : IShortUrlService
    {
        private IShortUrlRepository _shortUrlRepository;
        private const string _domainUrl = "http://localhost:5167/";
        public ShortUrlSevice(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        public string? CreateUrl(string destination)
        {
            if (!Uri.TryCreate(destination, UriKind.Absolute, out Uri? destinationUri))
            {
                return null;
            }

            var path = _shortUrlRepository.GetPath(destination);
            if (path != null) return path;

            var shortUrlId = Guid.NewGuid();
            path = getUrlChunk(shortUrlId);
            _shortUrlRepository.CreateUrl(shortUrlId, destination, path);
            return _domainUrl + path;
        }

        private string getUrlChunk(Guid shortUrlId)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(Convert.ToBase64String(shortUrlId.ToByteArray()), "");
        }

        public string? GetDestination(string path)
        {
            return _shortUrlRepository.GetDestination(path);
        }

        public List<string> GetShortUrls()
        {
            return _shortUrlRepository.GetShortUrls().Select(x => _domainUrl + x).ToList();
        }
    }
}
