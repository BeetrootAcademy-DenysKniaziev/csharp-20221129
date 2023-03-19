function DoVisible(name) {
    const items = ['FormLogin', 'FormRegistration']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).style.visibility = "visible";
        else
            document.getElementById(items[i]).style.visibility = "hidden";
}


document.getElementById('log-reg').addEventListener('click',
    () => {
        if (document.getElementById('log-reg').innerText == "Вхід")
        {
            DoVisible('FormLogin');
            document.getElementById('log-reg').innerText = 'Регістрація';
        }
        else
        {
            DoVisible('FormRegistration');
            document.getElementById('log-reg').innerText = 'Вхід';
        }
    });

