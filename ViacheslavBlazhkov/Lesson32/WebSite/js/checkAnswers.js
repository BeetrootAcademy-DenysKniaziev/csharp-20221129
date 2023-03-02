let answers = {
    quest1: 1,
    quest2: [1, 0, 0, 1],
    quest3: 1,
    quest4: "Porsche"
}

function checkAnswers() {
    let score = 0;
    let results = document.getElementById("results");
    results.innerHTML = "";
    let form = document.getElementById("contactForm");

    // Перевірка відповіді на перше питання
    let answer1 = form.elements["quest1"].value;
    if (answer1 == answers.quest1) {
        score++;
    }

    // Перевірка відповіді на друге питання
    let checkboxes = form.elements["quest2"];
    let forWrong = 0;
    let secScore = 0;
    for (let i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked && checkboxes[i].value != 1) {
            secScore -= 0.5;
            forWrong--;
        }
        if (checkboxes[i].checked && checkboxes[i].value == 1) {
            secScore += 0.5;
            forWrong++;
        }
    }
    if (secScore < 0) {
        secScore = 0;
    }
    score += secScore;

    //Перевірка відповіді на третє питання
    const selectElement = document.getElementById("quest3");
    const selectedValue = selectElement.value;

    if (selectedValue == 1) {
        score++;
    }

    //Перевірка відповіді на четверте питання
    let answer4 = form.elements["quest4"].value.trim().toLowerCase();
    if (answer4 == answers.quest4.toLowerCase()) {
        score++;
    }

    results.innerHTML = `Your score: ${score}`;
}