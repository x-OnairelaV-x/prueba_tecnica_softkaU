import view from '../views/login.html'
import {httpClient} from './services/http.service'




export default async () =>{
    const divElement = document.createElement('div');
    divElement.innerHTML = view;

    const btnClick = divElement.querySelector('#login');

    await btnClick.addEventListener('click', async (e) => {
        e.preventDefault();

        var userNameInput = document.getElementById('userName')["value"];

        if(userNameInput != '')
        {
            const data =  { name: userNameInput}
            const player = await httpClient.post('https://localhost:7030/api/Player',data);
            sessionStorage.setItem("playerInfo", player);
            console.log(player);
            setTimeout("location.reload(true);",0);
        }
      });

    return divElement ;
}