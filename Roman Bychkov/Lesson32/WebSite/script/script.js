function DoVisible(name) {
    const items = ['login', 'registration', 'question','order']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).style.visibility = "visible";
        else
            document.getElementById(items[i]).style.visibility = "hidden";
}
function RemoveActive(name) {
    const items = ['liLogin', 'liRegistration', 'liQuestion', 'liOrder']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).classList.add('myactive');
        else
            document.getElementById(items[i]).classList.remove('myactive');
}
document.getElementById('liLogin').addEventListener('click',
    () => {
        RemoveActive('liLogin');
        DoVisible('login');
    });
document.getElementById('liRegistration').addEventListener('click',
    () => {
        RemoveActive('liRegistration');
        DoVisible('registration');
    });
document.getElementById('liQuestion').addEventListener('click',
    () => {
        RemoveActive('liQuestion');
        DoVisible('question');
    });
document.getElementById('liOrder').addEventListener('click',
    () => {
        RemoveActive('liOrder');
        DoVisible('order');
    });
d

