using MediatR;
using UrlShortenerService.Core.Interfaces;

namespace UrlShortenerService.Application.Features.Url.Commands.Update
{
    public class UpdateShortUrlCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortenedUrl { get; set; } = string.Empty;
    }



    public class UpdateShortUrlCommandHandler : IRequestHandler<UpdateShortUrlCommand, Unit>
    {
        private readonly IUrlRepository _urlRepository;

        public UpdateShortUrlCommandHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }
        public async Task<Unit> Handle(UpdateShortUrlCommand request, CancellationToken cancellationToken)
        {
            var shortUrl = await _urlRepository.GetByIdAsync(request.Id);
            if (shortUrl == null)
            {

            }
            // Update properties
            shortUrl.OriginalUrl = request.OriginalUrl;
            shortUrl.ShortenedUrl = request.ShortenedUrl;

            await _urlRepository.UpdateAsync(shortUrl);

            return Unit.Value;

        }
    }
}
