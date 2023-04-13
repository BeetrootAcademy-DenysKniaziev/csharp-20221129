const form = document.querySelector('form');
const fileInput = document.querySelector('#file-input');


form.addEventListener('submit', (event) => {
    event.preventDefault();

    const file = fileInput.files[0];

    if (!file) {
        alert('Виберіть файл для завантаження');
        return;
    }

    const formData = new FormData(); 
    formData.append('uploads', file);

    fetch('upload', { 
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (!response.ok) { 
                return response.text().then(text => {
                    throw new Error(text);
                });
            }
            return response.text();
        })
        .then(text => {
            console.log("success");
        })
        .catch(error => {
            console.error(error); 
            alert(error.message); 
        });
});