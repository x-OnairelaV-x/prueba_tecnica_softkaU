import {pages} from '../controller/index'
let content = document.getElementById('root');


const router = async (route) => {
    console.log(route);
    content.innerHTML ='';
    
    if( sessionStorage.getItem("playerInfo"))
    {
        switch(route) {
            case '#/':{
               console.log('entro!!');
                return content.appendChild(await pages.home()); 
            }
               
            case '#/score':
                {
                    console.log('Score!!')
                    return content.appendChild( pages.score()); 
                }
                
            case '#/settings':
                {
                    console.log('Settings!!')
                    return content.appendChild(await pages.settings()); 
                }
            default:
                {
                    console.log('404!!')
                    return content.appendChild(pages.notFound()); 
                }
        } 
    }
    else
    {
        content.appendChild(await pages.login()); 
    }
 
}

export {router};