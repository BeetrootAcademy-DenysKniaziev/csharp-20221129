
const form = document.getElementById('form-comment');
const commentInput = document.querySelector('#comment');
const submitBtn = document.getElementById("comment-submit");


form.addEventListener('submit', function (e) {
    e.preventDefault(); 

    
    const xhr = new XMLHttpRequest();

    
    xhr.open('POST', form.action, true);
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.addEventListener('readystatechange', function () {
        if (xhr.readyState === 4 && (xhr.status === 200 || xhr.status === 201)) {
            var obj = JSON.parse(xhr.responseText);

            var newDiv = document.createElement("div");
            var newText = document.createTextNode(obj.userLogin + ' ' + obj.created);
            newDiv.appendChild(newText);

            var newP = document.createElement("p");
            newText = document.createTextNode(obj.comment);
            newP.appendChild(newText);

           
            var formComment = document.getElementById("form-comment");
    
            formComment.parentNode.insertBefore(newP, formComment.nextSibling);
            formComment.parentNode.insertBefore(newDiv, formComment.nextSibling);

            var myTextarea = document.getElementById("comment");

            
            myTextarea.value = "";
        }
        if (xhr.readyState === 4 && xhr.status === 400) {
            window.alert('Можно тільки 250 символів!')
        }
        if (xhr.readyState === 4 && xhr.status === 401) {
            window.location.href = "/Authentication/Login";
        }
    });
   
    xhr.send(`comment=${commentInput.value}`);

});

