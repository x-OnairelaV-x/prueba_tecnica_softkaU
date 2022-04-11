import Round from './round.controller';
import Match from './startMatch.controller';
import FinishGame from './finishGame.controller';

const matchComponents = {
   round: Round,
   match: Match, 
   finishGame: FinishGame
} 

export {matchComponents};