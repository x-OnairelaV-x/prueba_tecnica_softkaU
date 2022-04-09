using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_softkaU.Dto;
using prueba_tecnica_softkaU.Infraestructure;
using prueba_tecnica_softkaU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prueba_tecnica_softkaU.Models.Extensions;

namespace prueba_tecnica_softkaU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IRepository<Level> _respository;

        public LevelController(IRepository<Level> respository)
        {
            _respository = respository;
        }

        [HttpPost]
        public async Task<int> PostAsync(CreateLevelDto input)
        {

            var level = await _respository.InsertAsync(new Level() { Difficulty = input.Difficulty, Points = input.Points });
            return level.Id;
        }

        [HttpGet]
        public async Task<IEnumerable<LevelDto>> GetAllAsync()
        {
            var levels = await _respository.GetAllAsync();
            var levelDtos = new List<LevelDto>();
            foreach (var level in levels)
            {
                levelDtos.Add(new LevelDto { Difficulty = level.Difficulty, Id = level.Id, Points = level.Points });
            }
            return levelDtos;
        }
    }
}
