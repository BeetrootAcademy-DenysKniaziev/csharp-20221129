const username = "blz.sl";
const email = "blz@gmail.com";
const phone = "888";
const password = "7289";

let loginInput;
let passwordInput;

function loginFunc() {
    getData();

    if (checkInfo()) {
        console.log(" + Log in is succesfull!");
        
    } else {
        console.log(" - Log in is incorrect!");
    }
}

function getData() {
    loginInput = document.getElementById('login').value;
    passwordInput = document.getElementById('password').value;
}

function checkInfo() {
    if ((loginInput == username || loginInput == email || loginInput == phone) && passwordInput == password) {
        return true;
    } else {
        return false;
    }
}