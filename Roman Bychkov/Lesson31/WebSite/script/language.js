document.getElementById('ua').addEventListener('click',
    () => {
        var name = ("<p><b>Ім'я: </b>Роман</p>");
        var lastname = ('<p><b>Прізвище: </b>Бичков</p>');
        var age = (" <p><b>Вік:</b> 23</p>");
        var country = (" <p><b>Країна:</b> Україна</p>");
        var town = (" <p><b>Місто:</b> Полтава</p>");
        var education = ('<p><b>Освіта:</b><a class="' + 'ahover"' + 'id="' + 'link"' + 'style="' + 'color' + ':gray"' + 'href="' + 'https://www.kpi.kharkov.ua/eng/department/department-of-systems-analysis-and-information-analytical-technologies/"' + '> НТУ "ХПІ" <br />Кафедра Системного аналізу та інформаційно-аналітичних технологій</a> </p>')
        var icons = document.getElementById("idDivIcon");
        document.getElementById("headerName").innerText = "Інформація про мене";
        document.getElementsByClassName("item")[0].innerHTML = name;
        document.getElementsByClassName("item")[0].innerHTML += lastname + age + country + town + education;
        document.getElementsByClassName("item")[0].appendChild(icons);

        document.getElementById("btnSkills").innerHTML = "<b>Навички</b>";
        document.getElementById("btnExtraInfo").innerHTML = "<b>Додаткова інформація</b>";
        document.getElementById("btnHobby").innerHTML = "<b>Захоплення</b>";

        document.getElementById("skills").getElementsByTagName("p")[0].innerHTML = "<b>Навички</b>"
        document.getElementById("hobby").getElementsByTagName("p")[0].innerHTML = "<b>Хобі</b>"
        document.getElementById("hobby").getElementsByTagName("p")[1].innerHTML = "Мені подобається грати з друзями в кооперативні відео ігри.<br/>Також граю в шахи."
        document.getElementById("extra").getElementsByTagName("p")[0].innerHTML = "<b>Додаткова інформація</b>"
        document.getElementById("extra").getElementsByTagName("p")[1].innerHTML = "Приймаю челенджи від життя."
    });
document.getElementById('eng').addEventListener('click',
    () => {
        var name = ("<p><b>Name: </b>Roman</p>");
        var lastname = ('<p><b>Last Name: </b>Bychkov</p>');
        var age = (" <p><b>Age:</b> 23</p>");
        var country = (" <p><b>Country:</b> Ukraine</p>");
        var town = (" <p><b>Town:</b> Poltava</p>");
        var education = ('<p><b>Education:</b><a class="' + 'ahover"' + 'id="' + 'link"' + 'style="' + 'color' + ':gray"' + 'href="' + 'https://www.kpi.kharkov.ua/eng/department/department-of-systems-analysis-and-information-analytical-technologies/"' + '> NTU "KhPI" <br />Department of systems analysis and information-analytical technologies</a> </p>')
        var icons = document.getElementById("idDivIcon");
        document.getElementById("headerName").innerText = "Info About Me";
        document.getElementsByClassName("item")[0].innerHTML = name;
        document.getElementsByClassName("item")[0].innerHTML += lastname + age + country + town + education;
        document.getElementsByClassName("item")[0].appendChild(icons);

        document.getElementById("btnSkills").innerHTML = "<b>Skills</b>";
        document.getElementById("btnExtraInfo").innerHTML = "<b>Extra information</b>";
        document.getElementById("btnHobby").innerHTML = "<b>Hobby</b>";

        document.getElementById("skills").getElementsByTagName("p")[0].innerHTML = "<b>Skills</b>"
        document.getElementById("hobby").getElementsByTagName("p")[0].innerHTML = "<b>Hobby</b>"
        document.getElementById("hobby").getElementsByTagName("p")[1].innerHTML = " I like to play cooperative video games with my friends.<br/>I also like to play chess."
        document.getElementById("extra").getElementsByTagName("p")[0].innerHTML = "<b>Extra Information</b>"
        document.getElementById("extra").getElementsByTagName("p")[1].innerHTML = "I accept challenges from life."
    });