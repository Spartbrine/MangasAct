using AutoMapper;
using MangaDTO;
using Manga;
namespace ResponseMappingProfile;

public class ResponseMappingProfileClass : Profile
{
    public ResponseMappingProfileClass(){
        CreateMap<Mangas, MangaDtoClass>()
            .ForMember(
                dest => dest.PublicationYear,
                opt => opt.MapFrom(src => src.PublicationDate.Date.Year)
            );
    }
}