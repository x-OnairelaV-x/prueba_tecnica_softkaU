import view from '../views/home/components/round.html'
import {httpClient} from './services/http.service'


const startMatchAsync = async (matchId) =>{
    console.log(matchId);
    console.log("load question");

    const data =  { matchId: matchId};
    const match = await httpClient.post('https://localhost:7030/api/Match/StartNewRoundAsync',data);
    console.log(match);
    return match;
}

const sendAnswerAsync = async (optionId) =>{
    console.log(optionId);
    console.log("Send answer");

     if(sessionStorage.getItem("RoundData"))
     {
        const roundInfo = JSON.parse(sessionStorage.getItem("RoundData")); 
        console.log(roundInfo);
        const data =  { 
            matchId: roundInfo.matchId, 
            optionId: optionId , 
            roundId: roundInfo.roundId,
            categoryId: roundInfo.questionDto.categoryId
        };
        console.log(data);
        const response = await httpClient.post('https://localhost:7030/api/Match/SendMatchRoundAnswerAsync',data);
        
        debugger;
        console.log(response);
        return response;
     }

     return null;
}

const sendRetireAsync = async () =>{
    console.log("Send Retire");

     if(sessionStorage.getItem("RoundData"))
     {
        const roundInfo = JSON.parse(sessionStorage.getItem("RoundData")); 
        console.log(roundInfo);
        const data =  { 
            matchId: roundInfo.matchId
        };
        console.log(data);
        const response = await httpClient.post('https://localhost:7030/api/Match/SendRetireAsync',data);
        
        debugger;
        console.log(response);
        return response;
     }

     return null;
}

const loadQuestionMatchAsync = async (matchId, divElement) =>{
    console.log("load start");

    const startMatchResponse =  await startMatchAsync(matchId);
    sessionStorage.setItem("RoundData", JSON.stringify(startMatchResponse));

    console.log(startMatchResponse);

    const questionElement= divElement.querySelector('#question');
    questionElement.innerHTML +=` <label id="${startMatchResponse.questionDto.id}" for="exampleFormControlSelect1">${startMatchResponse.questionDto.description}</label>`;


    const anwerElement= divElement.querySelector('#answer');
    anwerElement.innerHTML = ``;

    startMatchResponse.questionDto.options.forEach(options => {
        anwerElement.innerHTML +=`
        <div class="form-check">
            <input class="form-check-input" type="radio" name="exampleRadios" id="${options.id}" value="${options.id}">
            <label class="form-check-label" for="exampleRadios2">
            ${options.description}
            </label>
        </div>`;
    });
}

export default async (matchId) =>{

    console.log("Start Round view");
    const divElement = document.createElement('div');
    divElement.innerHTML = view;
    const btnSendAnnswer = divElement.querySelector('#btnSendAnswer');
    const btnRetire = divElement.querySelector('#btnRetire');

    if( !sessionStorage.getItem("points"))
    {
        await loadQuestionMatchAsync(matchId, divElement);
    }else
    {
        btnSendAnnswer.style.visibility = 'hidden';
    }

    await btnSendAnnswer.addEventListener('click', async (e) => {
        e.preventDefault();
        console.log("entro al boton");
        var value= document.querySelector('.form-check-input:checked').value;
        var response = await sendAnswerAsync(value);
        
        if(response.completeGame || response.status == 0 || response.status == 1)
        {
            sessionStorage.setItem("points", JSON.stringify(response) );
        }

        const  name  = e.target;
        console.log(name);
        setTimeout("location.reload(true);",0);
    });

    await btnRetire.addEventListener('click', async (e) => {
        e.preventDefault();
        console.log("entro al boton retirar ");
        var response = await sendRetireAsync();
        
        if(response.completeGame || response.status == 0 || response.status == 1)
        {
            sessionStorage.setItem("points", JSON.stringify(response) );
        }

        const  name  = e.target;
        console.log(name);
        setTimeout("location.reload(true);",0);
    });
    return divElement;
}