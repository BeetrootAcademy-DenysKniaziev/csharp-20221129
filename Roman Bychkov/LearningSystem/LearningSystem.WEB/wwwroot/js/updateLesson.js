
const form = document.getElementById('FormLesson');
const submitBtn = document.getElementById('update-lesson');


submitBtn.addEventListener('click', (event) => {
 

    event.preventDefault();


    const formData = new FormData(form);

   
    const url = form.action;

  
    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(response.status);
            }
            else {
                const parentDiv = document.createElement("div");
                parentDiv.classList.add('alert-window');
                const childDiv = document.createElement("div");
                childDiv.classList.add('alert-ok');
                childDiv.innerText = "Оновлено!";
                parentDiv.appendChild(childDiv);

                const alert = document.getElementById('alert');
                alert.appendChild(parentDiv);

                setTimeout(function () {
                    parentDiv.remove();
                }, 3000);
            }
        })
        .then(data => {
           
          
            console.log(data);
        })
        .catch(error => {
            if (error.message === '404') {
             
            } else {
              
            }
        });
});