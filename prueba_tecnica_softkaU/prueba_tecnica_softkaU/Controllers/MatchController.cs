using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_softkaU.Dto;
using prueba_tecnica_softkaU.Infraestructure;
using prueba_tecnica_softkaU.Models;
using prueba_tecnica_softkaU.Models.Enum;
using prueba_tecnica_softkaU.Models.Extensions;
using prueba_tecnica_softkaU.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IRepository<Match> _respository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Option> _optionRepository;

        const string matchNoExits = "No existe una partida";

        public MatchController(IRepository<Match> respository,
            IRepository<Category> categoryRepository,
            IRepository<Option> optionRepository
            )
        {
            _respository = respository;
            _categoryRepository = categoryRepository;
            _optionRepository = optionRepository;
        }

        [HttpPost("CreateMatchAsync")]
        public async Task<int> CreateMatchAsync( CreateMatchDto input)
        {

            var level = await _respository.InsertAsync(new Match() { PlayerId = input.PlayerId });
            return level.Id;
        }


        [HttpGet("GetMatch")]
        public async Task<IEnumerable<MatchDto>> GetMatch(int id)
        {
            List<string> includes = new List<string>();
            includes.Add("Rounds");
            var Matches = await _respository.GetAsync(x => x.PlayerId == id, includes);
            var MatchesDtos = new List<MatchDto>();

            foreach (var match in Matches)
            {
                var rount = match.Rounds.Count();
                var lastRound = match.Rounds.Last();

                await CheckMatchStatus(match, rount, lastRound);

                MatchesDtos.Add(new MatchDto 
                { 
                    TotalPoints = match.TotalPoints,
                    Round = rount,
                    PlayerId = match.PlayerId, 
                    CompleteGame = match.CompleteGame,
                    Status = lastRound.Status.GetStatusDescription() });
            }
            return MatchesDtos;
        }

        [HttpGet("GetMyMatchesScore")]
        public async Task<MatchDto> GetMyMatchIfo(int id)
        {
            List<string> includes = new List<string>();
            includes.Add("Rounds");
            var Matches = await _respository.GetAsync(x => x.PlayerId == id, includes);
            var MatchesDtos = new List<MatchDto>();
            var match = Matches.FirstOrDefault();
            var lastRound = match.Rounds.LastOrDefault();
            return new MatchDto 
            { 
                TotalPoints = match.TotalPoints,
                Round = match.Rounds.Count(), 
                PlayerId = match.PlayerId,
                Status = lastRound!= null ? lastRound.Status.GetStatusDescription(): Status.Create.GetStatusDescription()
            };
        }

        private async Task CheckMatchStatus(Match match, int rount, Round lastRound)
        {
            if (!match.CompleteGame && rount < 5)
            {
                lastRound.Status = Models.Enum.Status.Lose;
                match.TotalPoints = 0;

                await _respository.UpdateAsync(match);
            }
        }

        [HttpPost("SendRetireAsync")]
        public async Task<SendRetireResponseDto> SendRetireAsync(SendRetireDto input)
        {
            SendRetireResponseDto response = new SendRetireResponseDto();

            List<string> includes = new List<string>();
            includes.Add("Rounds");
            var Matches = await _respository.GetAsync(x => x.Id == input.MatchId, includes);
            Match match = null;

            if (Matches.Any())
            {
                match = Matches.FirstOrDefault();
                match.CompleteGame = true;

                var lastRound = match.Rounds.Last();
                lastRound.Status = Models.Enum.Status.Retire;

                await _respository.UpdateAsync(match);
                response.Message = "Te has retirado.";
            }
            else
            {
                throw new Exception(matchNoExits);
            }

            return response;
        }


        [HttpPost("StartNewRoundAsync")]
        public async Task<StartRoundResponseDto> StartNewRoundAsync(StartRoundDto input)
        {
            StartRoundResponseDto response = new StartRoundResponseDto();

            List<string> includes = new List<string>();
            includes.Add("Rounds");
            var Matches = await _respository.GetAsync(x => x.Id == input.MatchId, includes);
            Match match = null;

            if (Matches.Any())
            {
                match = Matches.FirstOrDefault();
                if (match.Rounds.Count() < 5)
                {
                    response.MatchId = match.Id;

                    await CreateNewRound(match, input, response);
                    await SetRoundQuestion(response); 
                }
                else
                {
                    throw new Exception("Solo puedes jugar 5 rondas");
                }

            }
            else
            {
                throw new Exception(matchNoExits);
            }

            return response;
        }

        private async Task SetRoundQuestion(StartRoundResponseDto response)
        {
            List<string> includes = new List<string>();
            includes.Add(nameof(Level));
            includes.Add("Questions");

            var categories = await _categoryRepository.GetAsync(x => x.Level.Difficulty == response.CurrentRound, includes);
            var rand = new System.Random();
            var category = categories.Skip(rand.Next(categories.Count())).FirstOrDefault();

            var question = category.Questions.Skip(rand.Next(category.Questions.Count())).FirstOrDefault();

            var options = (await _optionRepository.GetAsync(x => x.QuestionId == question.Id));

            var rnd = new Random();
            var randomized = options.OrderBy(item => rnd.Next());

            response.questionDto = new QuestionDto()
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Description = question.Description,
                Options = new List<OptionsDto>()
            };

            foreach (var option in options)
            {
                response.questionDto.Options.Add(new OptionsDto { Description = option.Description, Id = option.Id });
            }

        }

        private async Task CreateNewRound(Match match, StartRoundDto input, StartRoundResponseDto response)
        {
            if(!match.Rounds.Any())
            {
                await CreateRound(match, input, response);
            }
            else
            {
                if (match.Rounds.Last().Status == Models.Enum.Status.Winner && !match.CompleteGame)
                {
                    await CreateRound(match, input, response); 
                }
                else
                {
                    var lastRound= match.Rounds.Last();
                    response.RoundId = lastRound.Id;
                    response.CurrentRound = lastRound.CurrentRound;
                }
            }

        }

        private async Task CreateRound(Match match, StartRoundDto input, StartRoundResponseDto response)
        {
            var lastRound = match.Rounds.LastOrDefault();
            var rountCount = match.Rounds.Any() ? lastRound.CurrentRound + 1 : 1;

            var currentRound = new Round { CurrentRound = rountCount, MatchId = input.MatchId };
            match.Rounds.Add(currentRound);

            await _respository.UpdateAsync(match);
            response.RoundId = currentRound.Id;
            response.CurrentRound = currentRound.CurrentRound;
        }

        [HttpPost("SendMatchRoundAnswerAsync")]
        public async Task<SendMatchRoundAnswerResponseDto> SendMatchRoundAnswerAsync(SendMatchRoundAnswerDto input)
        {
            var result = new SendMatchRoundAnswerResponseDto();
            var option = (await _optionRepository.GetAsync(x => x.Id == input.OptionId)).FirstOrDefault();

            result.Status = option.Correct ? Models.Enum.Status.Winner : Models.Enum.Status.Lose;


            List<string> includes = new List<string>();
            includes.Add("Rounds");
            var matches = await _respository.GetAsync(x => x.Id == input.MatchId, includes);


            if (matches.Any())
            {
                var match = matches.FirstOrDefault();
                var currentRount = match.Rounds.Where(x => x.Id == input.RoundId).FirstOrDefault();

                includes = new List<string>();
                includes.Add(nameof(Level));
                var category = (await _categoryRepository.GetAsync(x => x.Id == input.CategoryId, includes)).FirstOrDefault();

                currentRount.OptionId = input.OptionId;
                currentRount.Status = result.Status;
                currentRount.Points = option.Correct ? category.Level.Points : 0;

                match.TotalPoints = option.Correct ? match.TotalPoints + currentRount.Points : 0;
                match.CompleteGame = (match.Rounds.Count == 5) || !option.Correct;

                result.CompleteGame = match.CompleteGame;
                result.TotalPoints = match.TotalPoints;

                await _respository.UpdateAsync(match);

            }
            else
            {
                throw new Exception(matchNoExits);
            }
            return result;
        }
    }
}
