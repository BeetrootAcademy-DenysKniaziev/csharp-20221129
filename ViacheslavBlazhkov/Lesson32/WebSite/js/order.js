let fname;
let lname;
let phone;
let email;
let city;
let delivery;

let errors = [];

function regOrder() {
    console.clear();
    errors = [];
    getData();
    checkInfo();

    if (errors.length == 0) {

        console.log(" + Registration is successfully!");
        console.log("--- Your data ---");
        console.log(" First name: " + fname);
        console.log(" Last name: " + lname);
        console.log(" Phone: " + phone);
        console.log(" Email: " + email);
        console.log(" City: " + city);
        console.log(" Delivery: " + delivery);
    }
    else {
        console.log(" - You have several problems: ");
        for (i = 0; i < errors.length; i++) {
            console.log(i + 1 + ". " + errors[i]);
        }
    }
}

function getData() {
    fname = document.getElementById('fname').value;
    lname = document.getElementById('lname').value;
    phone = document.getElementById('phone').value;
    email = document.getElementById('email').value;
    city = document.getElementById('city').value;
    delivery = document.getElementById('delivery').value;
}

function checkInfo() {
    if (fname.length < 2) {
        errors.push("First name field must be longer than 2!");
    }
    if (lname.length < 2) {
        errors.push("Last name field must be longer than 2!");
    }
    if (phone.length < 2) {
        errors.push("Phone field must be longer than 2!");
    }
    if (city.length < 2) {
        errors.push("City field must be longer than 2!");
    }
    

    return errors;
}