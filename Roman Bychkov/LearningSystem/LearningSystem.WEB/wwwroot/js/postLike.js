function PostLike(articleNumber, courseId) {
    console.log(articleNumber + ' ' + courseId)
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "https://localhost:7163/api/Like/PostLike?articleNumber=" + articleNumber + "&courseId=" + courseId);
    xhr.onload = function () {
        if (xhr.status === 404) {
            var response = JSON.parse(xhr.responseText);
            console.log(response);
            // тут можна додатково обробити відповідь, наприклад, оновити стан елементів на сторінці
          
            document.getElementById('like').classList.add('liked');
            var countLike = document.getElementById('like-count').innerText;
            document.getElementById('like-count').innerText = parseInt(countLike) + 1;
        }
        if (xhr.status === 200) {
            document.getElementById('like').classList.remove('liked');
            var countLike = document.getElementById('like-count').innerText;
            document.getElementById('like-count').innerText = parseInt(countLike) - 1;
        }
    };
    xhr.send();
}