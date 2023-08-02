using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Domain.Entities;

namespace entityFrameworkPractice.src.Application.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap<Actor, ActorCreationDTO>();
            CreateMap<Actor, ActorDTO>();
            CreateMap<CommentCreationDTO, Comment>();
            CreateMap<MovieCreationDTO, Movie>().
                ForMember(ent => ent.Genres,
                dto => dto.MapFrom(campo => campo.Genres.Select(id => new Genre { Id = id })));
            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
