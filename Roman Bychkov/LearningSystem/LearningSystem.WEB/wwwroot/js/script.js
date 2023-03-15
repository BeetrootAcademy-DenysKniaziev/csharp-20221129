function RemoveActive(name) {
    const items = ['about', 'curses', 'privacy']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).classList.add('myactive');
        else
            document.getElementById(items[i]).classList.remove('myactive');
}
document.getElementById('about').addEventListener('click',
    () => {
        RemoveActive('about');
       
    });
document.getElementById('curses').addEventListener('click',
    () => {
        RemoveActive('curses');
     
    });
document.getElementById('privacy').addEventListener('click',
    () => {
        RemoveActive('privacy');
       
    });
