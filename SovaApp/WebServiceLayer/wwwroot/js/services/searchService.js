define([], function () {

    var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im9neXVuQGdtYWlsLmNvbSIsIm5iZiI6MTU3NTg0MTc1OSwiZXhwIjoxNTc1ODUyNTU5LCJpYXQiOjE1NzU4NDE3NTl9.pdGW61RwdPp3fUNjHcxMjhza41jfu2IJOLIjTqHcySQ";
    var headers = new Headers();
    //headers.append('Content-Type', 'application/json');
    headers.append('Authorization','Bearer ' + token);


    var searchByKeyword = async function (query, callback) {
        var response = await fetch("http://localhost:5001/api/search/keywords/" + query, {
            method: 'GET',
            headers:headers
        });
        var data = await response.json();
        callback(data);
    }

    return {
        searchByKeyword
    };
});