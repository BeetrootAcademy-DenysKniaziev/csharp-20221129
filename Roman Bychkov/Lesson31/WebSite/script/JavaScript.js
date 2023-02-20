var moonFlag = true;
var photo = document.getElementsByClassName("container")[0];
photo.style.position = "relative";

function movePhoto(i) {

    if (i > 0) {
        photo.style.marginRight = i + "%";
        setTimeout(() => movePhoto(--i), 15);
    }
}
function DoVisible(name) {
    const items = ['hobby', 'skills', 'extra']
    for (i = 0; i < items.length; ++i)
        if (items[i] == name)
            document.getElementById(name).style.visibility = "visible";
        else
            document.getElementById(items[i]).style.visibility = "hidden";
}


var item = document.getElementsByTagName("body")[0];
function opacityUp(i) {
    if (i < 20) {
        item.style.opacity = 0.05 * i;
        setTimeout(() => opacityUp(++i), 50);
    }
}

document.getElementById('moon').addEventListener('click',
    () => {
        if (moonFlag) {
            var head = document.getElementsByTagName("header")[0];
            head.style.backgroundColor = "#101010";
            head.style.color = "#FFFFFF";

            var body = document.getElementsByTagName("body")[0];
            body.style.backgroundColor = "#282828";
            body.style.color = "#FFFFFF";
            moonFlag = false;
            document.getElementById("moon").src = "photo/moonwhite.png";
            document.getElementById("giticon").src = "photo/giticonwhite.png";
            document.getElementById("link").style.color = "snow";
           
        }
        else {
            var head = document.getElementsByTagName("header")[0];
            head.style.backgroundColor = "#F6D8BA";
            head.style.color = "#000000";

            var body = document.getElementsByTagName("body")[0];
            body.style.backgroundColor = "#F7F4F1";
            body.style.color = "#000000";
            document.getElementById("moon").src = "photo/moon.png";
            document.getElementById("giticon").src = "photo/giticon.png";
            moonFlag = true;
            document.getElementById("link").style.color = "gray";
        }
       
    });
document.getElementById('btnHobby').addEventListener('click',
    () => {
        DoVisible('hobby');
    });
document.getElementById('btnExtraInfo').addEventListener('click',
    () => {
        DoVisible('extra');
    });
document.getElementById('btnSkills').addEventListener('click',
    () => {
        DoVisible('skills');
    });


movePhoto(40);
opacityUp(1);






