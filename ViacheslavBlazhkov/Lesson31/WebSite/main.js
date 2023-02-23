function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}


var text = "VIACHESLAV BLAZHKOV";
var print_text = function (text) {
    
    var delay = 100;
    var elem = document.getElementById("result");

    if (text.length > 0) {
        elem.innerHTML += text[0];
        setTimeout(
            function () {
                print_text(text.slice(1), elem, delay);
            }, delay
        );
    }
}
print_text(text);


function changeColor() {
    document.body.style.backgroundColor = "grey";
}


function alertFunc() {
    alert("You are a cool man!");
}


function clearFunc() {
    document.body.innerHTML = '';
    document.write("It`s too better.")
}