define([], function () {
    var login = async function (email,password,callback) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
       var request = await fetch('http://localhost:5001/api/auth', {
            method: 'POST',
            body: JSON.stringify({"email":email(),"password":password()}),
           headers: headers
       }).then(function (response) {
           if (response.status == 200) {

           }
           else {
               alert("Incorrect credentials");
           }
           return response;
       });
        var data = await request.json();
        callback(data);
    };
    return {
        login
    };
});