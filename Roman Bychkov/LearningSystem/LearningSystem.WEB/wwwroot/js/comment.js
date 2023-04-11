
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
            var image = null;
            if (obj.image === null)
                image = "/icon/anonim.png";
            else
                image = obj.image;

            const parentDiv = document.createElement("div");
            const newDiv = document.createElement("div");
            newDiv.setAttribute('class', 'comment-user-container');
           
            const a = document.createElement('a');

            a.setAttribute('href', '/Account/Profile?name=' + obj.userLogin);
         

            const img = document.createElement('img');
            img.setAttribute('class', 'profile-photo-comment');
            img.setAttribute('src', image);
            newDiv.appendChild(img);

            const b = document.createElement('b');
            b.innerHTML = "&nbsp;&nbsp;" + obj.userLogin;
            const p1 = document.createElement('p');
            p1.appendChild(b);
            newDiv.appendChild(p1);

            const p2 = document.createElement('p');
            p2.setAttribute('class', 'comment-date');
            p2.innerHTML = `&nbsp;&nbsp;${obj.createDays} ${obj.createTime}`;
            newDiv.appendChild(p2);

            a.appendChild(newDiv);

            const p3 = document.createElement('p');
            p3.setAttribute('class', 'comment-content');
            p3.innerText = obj?.comment;
            //a.appendChild(p3);
            parentDiv.appendChild(a);
            

            var formComment = document.getElementById("form-comment");
            formComment.parentNode.insertBefore(p3, formComment.nextSibling);
            formComment.parentNode.insertBefore(a, formComment.nextSibling);

            var myTextarea = document.getElementById("comment");
            myTextarea.value = "";
        }
        if (xhr.readyState === 4 && xhr.status === 400) {
            window.alert('Можно тільки 250 символів!')
        }
        if (xhr.readyState === 4 && xhr.status === 404) {
            window.alert('Нажаль, такого уроку вже не існує')
            window.location.href = "/Home/Index";
        }
        if (xhr.readyState === 4 && xhr.status === 401) {
            window.location.href = "/Account/Login";
        }
    });
   
    xhr.send(`comment=${commentInput.value}`);

});

