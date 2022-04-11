import Home from './home.controller';
import Score from './score.controller';
import NotFound from './404.controller';
import Settings from './settings.controller';
import Login from './login.controller';

const pages = {
   home: Home,
   score: Score,
   notFound: NotFound,
   settings: Settings,
   login: Login
} 

export {pages};