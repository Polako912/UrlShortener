using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Dtos;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Profiles
{
    public class ShortenedUrlProfile : Profile
    {
        public ShortenedUrlProfile()
        {
            CreateMap<ShortenedUrl, ShortenedUrlDto>();
        }
    }
}