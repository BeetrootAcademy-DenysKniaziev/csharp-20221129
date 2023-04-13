function DoVisible(name) {
    const items = ['profile-likes', 'profile-comments','profile-courses'];
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
document.getElementById('cour').addEventListener('click',
    () => {
        DoVisible('profile-courses');
        
    });

const form = document.querySelector('form');
const fileInput = document.querySelector('#file-input');
const photo = document.querySelector('#photo');

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
            photo.src = text; 
        })
        .catch(error => {
            console.error(error); 
            alert(error.message);
        });
});