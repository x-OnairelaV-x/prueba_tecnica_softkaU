import view from '../views/settingView/settings.html'
import {httpClient} from './services/http.service'

const getLevel = async () =>{
    const response = await httpClient.get('https://localhost:7030/api/Level')
    return  response;
}


export default async () =>{
    const divElement = document.createElement('div');
    divElement.innerHTML = view;

    const levelElement= divElement.querySelector('#level');

    const levels = await getLevel();
    console.log(levels);
    levels.forEach(level => {
        levelElement.innerHTML +=`
        <li class="list-group boder-prymary bg-dark text-white">
          <h5>Difficulty: ${level.difficulty}</h5>
          <p> Points: ${level.points} </P>
        </li>
        `;
    });
    console.log(viu);

    return divElement;
}