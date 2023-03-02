document.getElementById('FormLogin').addEventListener('submit',
    (event) => {
        var email = document.getElementById('emaillogin').value;
        alert('Hello '+email);
    });
document.getElementById('FormRegistration').addEventListener('submit',
    (event) => {
        var pass1 = document.getElementById('passwordRegistration1').value;
        var pass2 = document.getElementById('passwordRegistration2').value;
        if (pass1 === pass2)
            alert('Completed');
        else
        {
            alert('Passwords are not same');
            event.preventDefault();
        }
    });
document.getElementById('FormQuestion').addEventListener('submit',
    (event) =>
    {
            alert('Thank you!');
          }
);
document.getElementById('FormOrder').addEventListener('submit',
    (event) => {
        var result = confirm("Confirm?");
        if (!result)
            event.preventDefault();
    }
);