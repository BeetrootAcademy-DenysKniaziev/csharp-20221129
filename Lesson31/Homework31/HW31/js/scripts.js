let inpName = document.getElementById('inputName');
let login = document.getElementById('form2Example1');
//let inpGreating = document.getElementById('grt');
let grSubmit = document.getElementById('greatingForm');
let signIn = document.getElementById('signIn');
let regSubmit = document.getElementById('regForm');
let prodSubmit = document.getElementById('productSelector');
let element = document.getElementById("#services");
let grF = "pleb";

prodSubmit.addEventListener('submit', (event) => {
    event.preventDefault();
    var product = document.querySelector('input[name="prod"]:checked').value;
    alert("Dear " + grF +", You Just Selected Our Product,\n" + product + "\nOne Gazilion of Credits Already Debited From Your Sicret Account,\nAnd Our Very Special Team Coming To Your Den");
    console.log("Congratulation,\n" + grF + " " + name + "\nYour acount was add.")

});

regSubmit.addEventListener('submit', (event) => {
    event.preventDefault();
    var l = login.value;
    var logEl = document.getElementById('loginInfo');
    logEl.innerText = l;
    var name = inpName.value;
    alert("Congratulation,\n" + grF + " " + name + "\nYour acount was add.");
    console.log("Congratulation,\n" + grF + " " + name + "\nYour acount was add.")

});

signIn.addEventListener('submit', (event) => {
    event.preventDefault();
    var l = login.value;
    var logEl = document.getElementById('loginInfo');
    logEl.innerText = l;
    alert(grF + " You Are Loged In As " + l);
    console.log(grF + " You Are Loged In As " + l);
});

grSubmit.addEventListener('submit', (event) => {
    event.preventDefault();
    //grF = document.querySelector('input[name="great"]:checked').value;
    grF = document.getElementById("greating").value;

    alert(`Since Now We Will Great You As\n${grF}`);
    //alert('Since Now We Will Great You As ${ grF.value }')
    window.scrollTo(0, 500);

    //element.scrollIntoView({ behavior: "smooth" });

    //const link = document.createElement("a");
    //link.setAttribute("href", "#services");
    //link.textContent = "Link to #services";


    //grF = grSubmit.value;  
    //alert("Since now you are " + grF);
});
