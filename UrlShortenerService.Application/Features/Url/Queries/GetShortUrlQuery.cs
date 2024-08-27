using AutoMapper;
using MediatR;
using UrlShortenerService.Application.Features.Url.DTOs;
using UrlShortenerService.Core.Interfaces;

namespace UrlShortenerService.Application.Features.Url.Queries
{
    public class GetShortUrlQuery : IRequest<ShortUrlDto>
    {
        public string ShortenedUrl { get; set; } = string.Empty;
    }


    public class GetShortUrlQueryHandler : IRequestHandler<GetShortUrlQuery, ShortUrlDto>
    {

        private readonly IUrlRepository _urlRepository;
        private readonly IMapper _mapper;

        public GetShortUrlQueryHandler(IUrlRepository urlRepository, IMapper mapper)
        {
            _urlRepository = urlRepository;
            _mapper = mapper;
        }

        public async Task<ShortUrlDto> Handle(GetShortUrlQuery request, CancellationToken cancellationToken)
        {
            var shortUrl = await _urlRepository.GetByShortUrlAsync(request.ShortenedUrl);
            if (shortUrl != null)
            {
                shortUrl.AccessCount++;
                await _urlRepository.UpdateAsync(shortUrl);
            }

            return _mapper.Map<ShortUrlDto>(shortUrl);
        }
    }

}
