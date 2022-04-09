using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Dto
{
    public class MatchBaseDto
    {
        public int PlayerId { get; set; }
    }
    public class CreateMatchDto: MatchBaseDto
    {
    }


    public class MatchDto
    {
        public int PlayerId { get; set; }
        public Double TotalPoints { get; set; }
        public int Round { get; set; }
        public string Status { get; set; }
        public bool CompleteGame { get; set; }
    }

    public class SendMatchRoundAnswerDto
    {
        public int MatchId { get; set; }
        public int OptionId { get; set; }
        public int RoundId { get; set; }
        public int CategoryId { get; set; }
    }

    public class StartRoundDto
    {
        public int MatchId { get; set; }
    }

    public class StartRoundResponseDto
    {
        public int MatchId { get; set; }
        public int RoundId { get; set; }
        public int CurrentRound { get; set; }
        public QuestionDto questionDto { get; set; }
    }

    public class SendMatchRoundAnswerResponseDto
    {
        public Models.Enum.Status Status { get; set; }
        public bool CompleteGame { get; set; }
        public double TotalPoints { get; set; }
    }

    public class SendRetireDto
    {
        public int MatchId { get; set; }
    }

    public class SendRetireResponseDto
    {
        public string Message { get; set; }
    }
}
