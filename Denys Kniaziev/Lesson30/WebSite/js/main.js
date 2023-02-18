let counter = 0;

let counterText = document.getElementById('counter');
let tableHolder = document.getElementById('tableHolder');
let b1 = document.getElementById('button1');
let body = document.getElementsByTagName('body')[0];
let ifPageHolder = document.getElementById('ifPageHolder');
console.log(body);

b1.addEventListener('click',
    () => {
        counterText.innerText = 'Counter: ' + ++counter;
        let childElement = document.createElement('p');
        childElement.innerText = 'Inserter Child';
        tableHolder.appendChild(childElement);
        console.log(tableHolder.children);

        body.style.backgroundColor = '#' + Math.floor(Math.random() * 16777215).toString(16);
    });

document.getElementById('btnPage1').addEventListener('click',
    () => {
        ifPageHolder.src = 'page1.html';
    });

document.getElementById('btnPage2').addEventListener('click',
    () => {
        ifPageHolder.src = 'page2.html';
    });


let arrProducts = [[1, "Flowers", 100], [2, "Milk", 10], [3, "Tomato", 40]];
let tblProductsBody = document.getElementById('tblProductsBody');

arrProducts.forEach(product => {
    var tr = document.createElement('tr');
    console.log(product);
    for (var j = 0; j < 3; j++) {
        var td = document.createElement('td');
        td.innerText = product[j];
        tr.appendChild(td);
    }

    tblProductsBody.appendChild(tr);
});


console.log(tblProductsBody);

//let arr1 = [1, '2', ['b', 4], {a: 5 }];
//
//const obj = {
//    a: '1',
//    b: 2,
//    ['a']: 4,
//    c: {
//        a: [1, 2, 3]
//    }
//};
//
//console.log(obj);