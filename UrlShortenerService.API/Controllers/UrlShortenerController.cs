using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerService.Application.Features.Url.Commands.Create;
using UrlShortenerService.Application.Features.Url.Commands.Update;
using UrlShortenerService.Application.Features.Url.Queries;
using UrlShortenerService.Core.Interfaces;

namespace UrlShortenerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUrlRepository _urlRepository;

        public UrlShortenerController(IMediator mediator, IUrlRepository urlRepository)
        {
            _mediator = mediator;
            _urlRepository = urlRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShortUrlCommand command)
        {
            var id = await _mediator.Send(command);
            var createdShortUrl = await _urlRepository.GetByIdAsync(id);

            if (createdShortUrl == null)
            {
                return NotFound("Shortened URL not found after creation.");
            }
            return CreatedAtAction(nameof(Get), new { shortenedUrl = createdShortUrl.ShortenedUrl }, createdShortUrl);
        }

        [HttpGet("{shortenedUrl}")]
        public async Task<IActionResult> Get(string shortenedUrl)
        {
            var shortUrl = await _mediator.Send(new GetShortUrlQuery { ShortenedUrl = shortenedUrl });
            if (shortUrl == null) return NotFound();

            return Ok(shortUrl);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateShortUrlCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("URL ID Mismatch");
            }
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
