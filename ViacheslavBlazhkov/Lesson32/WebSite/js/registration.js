let username;
let email;
let phone;
let birthdate;
let password;
let passwordConf;

let errors = [];

function registration() {
    console.clear();
    errors = [];
    getData();
    checkInfo();

    if (errors.length == 0) {

        console.log(" + Registration is successfully!");
        console.log("--- Your data ---");
        console.log(" Username: " + username);
        console.log(" Email: " + email);
        console.log(" Phone: " + phone);
        console.log(" Birthdate: " + birthdate);
        console.log(" Password: " + password);
    }
    else {
        console.log(" - You have several problems: ");
        for (i = 0; i < errors.length; i++) {
            console.log(i + 1 + ". " + errors[i]);
        }
    }
}

function getData() {
    username = document.getElementById('username').value;
    email = document.getElementById('email').value;
    phone = document.getElementById('phone').value;
    birthdate = document.getElementById('birthdate').value;
    password = document.getElementById('password').value;
    passwordConf = document.getElementById('passwordConfirm').value;
}

function checkInfo() {
    if (username.length < 2) {
        errors.push("User field must be longer than 2!");
    }
    if (email.length < 2) {
        errors.push("Email field must be longer than 2!");
    }
    if (phone.length < 2) {
        errors.push("Phone field must be longer than 2!");
    }
    if (birthdate.length < 2) {
        errors.push("Birtdate field must be longer than 2!");
    }


    if (password.length < 4) {
        errors.push("Passwords field must be longer than 4!");
    }
    if (password != passwordConf) {
        errors.push("Passwords don't match!");
    }

    return errors;
}