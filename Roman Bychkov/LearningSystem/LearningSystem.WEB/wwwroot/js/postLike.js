function PostLike(articleNumber, courseId) {
    console.log(articleNumber + ' ' + courseId)
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/api/Like/PostLike?articleNumber=" + articleNumber + "&courseId=" + courseId);
    xhr.onload = function () {
        if (xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);
            document.getElementById('like').classList.add('liked');
            var countLike = document.getElementById('like-count').innerText;
            document.getElementById('like-count').innerText = parseInt(countLike) + 1;
            document.getElementById('like-image').src ="/icon/liked.png"
        }
        if (xhr.status === 404) {
            document.getElementById('like').classList.remove('liked');
            var countLike = document.getElementById('like-count').innerText;
            document.getElementById('like-count').innerText = parseInt(countLike) - 1;
            document.getElementById('like-image').src = "/icon/like.png"
        }
        if (xhr.status === 400) {
            window.alert("Цієї статті вже не існує");
            window.location.href = "/Home/Index";
        }
        if (xhr.readyState === 4 && xhr.status === 401) {
            window.location.href = "/Account/Login";
        }
    };
    xhr.send();
}