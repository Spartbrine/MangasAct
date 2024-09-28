using AutoMapper;
using Manga;
using MangaCreateDto;

namespace RequestCreateMappingProfile;

public class RequestCreateMappingProfileClass : Profile
{
    public RequestCreateMappingProfileClass()
    {
        CreateMap<MangaCreateDtoClass, Mangas>()
            .AfterMap(
                (src, dest)=>
                {
                    dest.PublicationDate = DateTime.Now;
                }
            );
    }
}