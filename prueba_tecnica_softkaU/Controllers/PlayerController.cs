using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_softkaU.Dto;
using prueba_tecnica_softkaU.Infraestructure;
using prueba_tecnica_softkaU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository<Player> _respository;

        public PlayerController(IRepository<Player> respository)
        {
            _respository = respository;
        }

        [HttpPost]
        public async Task<PlayerDto> PostAsync(CreatePlayerDto input)
        {
            Player player = null;
            var players = await _respository.GetAsync(x => x.Name == input.Name);

            if (!players.Any())
            {
                player = await _respository.InsertAsync(new Player() { Name = input.Name }); 
            }
            else
            {
                player = players.FirstOrDefault();
            }

            return new PlayerDto() { Id = player.Id, Name = player.Name };
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            var players = await _respository.GetAllAsync();
            var levelDtos = new List<PlayerDto>();
            foreach (var player in players)
            {
                levelDtos.Add(new PlayerDto { Name = player.Name, Id = player.Id});
            }
            return levelDtos;
        }
    }
}
