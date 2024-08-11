﻿using DartsApp.RestAPI.DTOs.PlayerDto;
using DartsApp.RestAPI.Entities;

namespace DartsApp.RestAPI.Servicies.Interfaces
{
    public interface IPlayerService: IBaseService<PlayerCreateDto, Player>
    {
        new Task<IEnumerable<PlayerViewDto>> GetAllAsync();
        Task<PlayerRankingDto> GetPlayerWithHighestRankingPlace();
        Task<IEnumerable<PlayerRankingDto>> GetPlayersWithoutRankingPoints();
        Task<IEnumerable<PlayerRankingDto>> GetPlayersWithRankingPointsUnder200();
        string GetPlayerStatisticsByPlayerId(int id);


    }
}
