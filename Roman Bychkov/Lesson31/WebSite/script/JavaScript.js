var moonFlag = true;
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
        }
       
    });


var photo = document.getElementsByClassName("item-photo")[0];
photo.style.position = "relative";

function movePhoto(i) {
  
    if (i < 50) {
        photo.style.marginLeft = i * 7 + "px";
        setTimeout(() => movePhoto(++i), 1);
    }
}
movePhoto(1);

var item = document.getElementsByTagName("body")[0];
function opacityUp(i)
{
    if (i < 20)
    {
        item.style.opacity = 0.05 * i;
        setTimeout(() => opacityUp(++i), 50);
    }
}
opacityUp(1);






