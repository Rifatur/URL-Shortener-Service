using AutoMapper;
using MediatR;
using UrlShortenerService.Core.Entities;
using UrlShortenerService.Core.Interfaces;

namespace UrlShortenerService.Application.Features.Url.Commands.Create
{
    public record CreateShortUrlCommand(string OriginalUrl) : IRequest<int>;


    public class CreateShortUrlCommandHandler : IRequestHandler<CreateShortUrlCommand, int>
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IMapper _mapper;

        public CreateShortUrlCommandHandler(IUrlRepository urlRepository, IMapper mapper)
        {
            _urlRepository = urlRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
        {

            var shortUrl = new ShortUrl
            {
                OriginalUrl = request.OriginalUrl,
                ShortenedUrl = GenerateShortUrl()
            };
            await _urlRepository.AddAsync(shortUrl);
            return shortUrl.Id;

        }
        private string GenerateShortUrl()
        {
            // Implement short URL generation logic here
            return Guid.NewGuid().ToString().Substring(0, 6); // Example
        }

    }


}
