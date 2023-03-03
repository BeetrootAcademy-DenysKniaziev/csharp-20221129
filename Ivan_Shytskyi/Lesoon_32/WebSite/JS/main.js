let div2 = document.getElementById('myDiv');
let paragraph = document.createElement('p');
paragraph.innerText = "bla-bla-blaaaa";
div2.appendChild(paragraph);

let header = document.getElementsByTagName('header')[0];
let nav = document.getElementsByTagName('nav')[0];
let main = document.getElementsByTagName('main')[0];
let footer = document.getElementsByTagName('footer')[0];
let c = document.getElementById('bt3');
c.addEventListener('click', () => {
    header.style.backgroundColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
    nav.style.backgroundColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
    main.style.backgroundColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
    footer.style.backgroundColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
});

let count = 0;
let countText = document.getElementById('counter');
let b = document.getElementById('b2');
b.addEventListener('dblclick', () => { countText.innerText = 'Counter: ' + ++count; });

let a = document.getElementById('b1');
let tableHolder = document.getElementById('tableHolder');
a.addEventListener('click', () => {
    let childElement = document.createElement('u');
    childElement.innerText = 'Insert Child ';
    tableHolder.appendChild(childElement);
    console.log(tableHolder.children);
});