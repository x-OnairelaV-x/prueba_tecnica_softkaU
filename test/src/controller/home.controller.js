import views from '../views/home/home.html'
import {matchComponents} from './matchComponentsIndex'


export default async ()  => {
     const divElement = document.createElement('div');
     divElement.innerHTML = views; 
 
     let content = divElement.querySelector('#matchRoot');

     console.log(content);
     const idMatch = sessionStorage.getItem("matchId")
     if( sessionStorage.getItem("matchId"))
     {
        console.log(idMatch);
        console.log("Round view");

        const points = sessionStorage.getItem("points");
        debugger;
        if( !sessionStorage.getItem("points"))
        {
          content.appendChild(await matchComponents.round(idMatch));
        }  else {
         content.appendChild(await matchComponents.finishGame(points));
        }
     }
     else
     {
        content.appendChild(await matchComponents.match());
     }

     return divElement;
};
