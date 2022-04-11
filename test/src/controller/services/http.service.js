const Post = async (url ,data) =>{
    const response =  fetch(url, {
         method: 'POST',
         headers: {
             'Content-Type': 'application/json',
         },
         body: JSON.stringify(data),
         })
         .then((response) => response.json())
         //Then with the data from the response in JSON...
         .then((data) => {
             console.log('Success:', data);
             return data ;
         
         })
         //Then with the error genereted...
         .catch((error) => {
             console.error('Error:', error);
             return error;
 
         });
     return response;
 }

 const Get = async (url) =>{
    const response = await fetch(url)
    .then((response) => response.json())
    //Then with the data from the response in JSON...
    .then((data) => {
        console.log('Success:', data);
        return data ;
    
    })
    //Then with the error genereted...
    .catch((error) => {
        console.error('Error:', error);
        return error;

    });
     return response;
 }

 const GetHeaders = async (url) =>{
     console.log(url);
    const response =  fetch(url, {
         method: 'GET',
         mode: 'cors',
         headers: {
             'authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjU3IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6ImpvaGFubl9ibGRyQGhvdG1haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiam9oYW5uX2JsZHJAaG90bWFpbC5jb20iLCJBc3BOZXQuSWRlbnRpdHkuU2VjdXJpdHlTdGFtcCI6IklWRUNBVlU0V1hYSVJSN1BUV1RENFJaN05ER1hLVEQzIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiU3VwcGxpZXIiLCJodHRwOi8vd3d3LmFzcG5ldGJvaWxlcnBsYXRlLmNvbS9pZGVudGl0eS9jbGFpbXMvdGVuYW50SWQiOiIzMSIsInN1YiI6IjU3IiwianRpIjoiOWQ5NWY4YTYtYzkzMS00MjA3LTk0YmUtYzViNDBjMzEwNzI4IiwiaWF0IjoxNjQyODExNTY3LCJuYmYiOjE2NDI4MTE1NjcsImV4cCI6MTY0Mjg5Nzk2NywiaXNzIjoiVml1IiwiYXVkIjoiVml1In0.h9ajjdVvKFKdfScVzS4Ssi39vShydlejuB6Pv0ew1Yg',
             'accept': 'application/json,text/plain, */*',
             'refere': 'https://viu-front.azurewebsites.net/',
             'Access-Control-Allow-Origin': '*',
             'Cookie': 'ARRAffinity=7c93c2c1f843e1a222bace867c336a454f48cafa5ab0e9d267fe5119e4db9312; ARRAffinitySameSite=7c93c2c1f843e1a222bace867c336a454f48cafa5ab0e9d267fe5119e4db9312'
         }
         })
         .then((response) => response.json())
         //Then with the data from the response in JSON...
         .then((data) => {
             console.log('Success:', data);
             return data ;
         
         })
         //Then with the error genereted...
         .catch((error) => {
             console.error('Error:', error);
             return error;
 
         });
     return response;
 }

 const httpClient = {
    post: Post,
    get:Get,
    getHeaders: GetHeaders
 }

 export {httpClient};