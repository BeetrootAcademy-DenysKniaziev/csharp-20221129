const imgs = document.getElementsByClassName('cats');
const btn = document.getElementById('button');
const input = document.querySelector("input");
let body = document.getElementsByTagName('body')[0];



// стробував змінити клас у об'єкта
for (const img of imgs) {
    img.addEventListener('mouseout',
        () => {
            img.classList.add("cats")
            img.classList.remove("another_cats");
        });
    img.addEventListener('mouseover',
        () => {
            img.classList.remove("cats")
            img.classList.add("another_cats");
        });
}

btn.addEventListener('click',
    () => {
        const text = prompt("Enter information about Egor: ");
        var p = document.createElement('p');
        p.textContent = text;
        if (text) {
            const divText = document.getElementsByClassName('info')[0];
            divText.appendChild(p);
        } 
    });

input.addEventListener("input", event  => {
    body.style.background = '#' + Math.floor(Number(input.value / 100) * 16777215).toString(16);
})
