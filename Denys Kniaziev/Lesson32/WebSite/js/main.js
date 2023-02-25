let formAdd = document.getElementById('formAdd');
let inpName = document.getElementById('inpName');
let inpPrice = document.getElementById('inpPrice');
let tblProductsBody = document.getElementById('tblProductsBody');

let id = 0;

formAdd.addEventListener('submit',
    (event) => {
        var name = inpName.value;
        var price = inpPrice.value;

        var tr = document.createElement('tr');

        var td = document.createElement('td');
        td.innerText = ++id;
        tr.appendChild(td);

        var td = document.createElement('td');
        td.innerText = name;
        tr.appendChild(td);

        var td = document.createElement('td');
        td.innerText = price;
        tr.appendChild(td);

        tblProductsBody.appendChild(tr);

        confirm("?!!??");
        event.preventDefault();
    });