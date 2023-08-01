using AutoMapper;
using entityFrameworkPractice.DTOs;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.Utilities
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap< Actor, ActorDTO>();
            CreateMap<CommentCreationDTO, Comment>();
            CreateMap<MovieCreationDTO, Movie>().
                ForMember(ent => ent.Genres,
                dto => dto.MapFrom(campo => campo.Genres.Select(id => new Genre { Id = id })));
            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
