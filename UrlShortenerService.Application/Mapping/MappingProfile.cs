using AutoMapper;
using UrlShortenerService.Application.Features.Url.DTOs;
using UrlShortenerService.Core.Entities;

namespace UrlShortenerService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ShortUrl, ShortUrlDto>().ReverseMap();
        }
    }
}
