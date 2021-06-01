function charSeparator (text) {
    let word = [];
    let repeats = [];
    textArray = text.split("");
    for (let i = 0; i < textArray.length; i++) {
        if (!charComparison(textArray[i])) {
            if (dataAnalysis(textArray[i], word)) {
                console.log(textArray[i]);
                repeats.push(textArray[i].toLowerCase());
            }
        } else {
            word = [];
        }
    }
    changeText(textArray, repeats);
}

function charComparison (letter) {
    const separators = [" ", ",", "?", "!", ".", ":", ";"];
    return separators.includes(letter);
}

function dataAnalysis (letter, word) {
    if (!word.includes(letter.toLowerCase())) {
        word.push(letter.toLowerCase());
    } else {
        return true;
    }
}

function changeText (textArray, repeats) {
    for (let i = 0; i < textArray.length; i++) {
        if (repeats.includes(textArray[i].toLowerCase())) {
            textArray.splice(i, 1);
            i = i - 1;
        }
    }
    console.log(textArray.join(""));
}

charSeparator("Локомотив сегодня выиграл у Спартака со счетом 3-1.");