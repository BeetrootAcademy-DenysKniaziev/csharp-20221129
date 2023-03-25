function DoVisible(name) {
    const items = ['profile-likes', 'profile-comments'];
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).style.display = "block";
        else
            document.getElementById(items[i]).style.display = "none";
}

document.getElementById('likes').addEventListener('click',
    () => {
        DoVisible('profile-likes');
    });

document.getElementById('comments').addEventListener('click',
    () => {
        DoVisible('profile-comments');
    });

const form = document.querySelector('form');
const fileInput = document.querySelector('#file-input');
const photo = document.querySelector('#photo');

form.addEventListener('submit', (event) => {
    event.preventDefault(); // перехоплюємо стандартну поведінку форми

    const file = fileInput.files[0]; // отримуємо вибраний файл

    if (!file) {
        alert('Виберіть файл для завантаження');
        return;
    }

    const formData = new FormData(); // створюємо об'єкт FormData для відправки файлу
    formData.append('uploads', file);

    fetch('upload', { // відправляємо файл на сервер за допомогою fetch
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (!response.ok) { // якщо відповідь сервера не OK, повідомляємо про помилку
                return response.text().then(text => {
                    throw new Error(text);
                });
            }
            return response.text(); // отримуємо дані відповіді у вигляді тексту
        })
        .then(text => {
            photo.src = text; // очищаємо src перед вставкою тексту
        })
        .catch(error => {
            console.error(error); // логуємо помилку у консоль
            alert(error.message); // повідомляємо користувача про помилку
        });
});