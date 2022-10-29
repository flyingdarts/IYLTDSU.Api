using AutoMapper;
using IYLTDSU.Api.Requests.X01.Game;
using IYLTDSU.Api.Requests.X01.GameDart;
using IYLTDSU.Business.X01.GameDarts;
using IYLTDSU.Business.X01.Games.Create;
using IYLTDSU.Domain;

namespace IYLTDSU.Api.Mappers
{
    public class GamesMapper : Profile
    {
        public GamesMapper()
        {
            CreateMap<CreateX01GameRequest, CreateX01GameCommand>();
            CreateMap<CreateX01GameDetail, CreateX01GameResponse>()
                .ForMember(x => x.GameStatus, opt => opt.MapFrom(src => src.Game.Status))
                .ForMember(x => x.Players, opt => opt.MapFrom(src => src.GamePlayers
                      .Select(x => new GamePlayerDetail { PlayerId = x.PlayerId })))
                .ForMember(x => x.GameId, opt => opt.MapFrom(src => src.Game.GameId));

            CreateMap<CreateX01GameDartRequest, CreateX01GameDartCommand>();
            CreateMap<CreateX01GameDartDetail, CreateX01GameDartResponse>();

            CreateMap<GamePlayerDetail, GamePlayerResponseModelDto>();
        }
    }
}