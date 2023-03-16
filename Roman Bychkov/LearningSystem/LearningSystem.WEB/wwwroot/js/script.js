function RemoveActive(name) {
    const items = ['about', 'curses', 'privacy']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).classList.add('myactive');
        else
            document.getElementById(items[i]).classList.remove('myactive');
}
