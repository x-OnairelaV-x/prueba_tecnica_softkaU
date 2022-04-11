import view from '../views/score.html'

export default () =>{
    const divElement = document.createElement('div');
    divElement.innerHTML = view;
    return divElement;
}