const form = document.querySelector('form');
const fileInput = document.querySelector('#file-input');


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
            console.log("success");//photo.src = text; // очищаємо src перед вставкою тексту
        })
        .catch(error => {
            console.error(error); // логуємо помилку у консоль
            alert(error.message); // повідомляємо користувача про помилку
        });
});