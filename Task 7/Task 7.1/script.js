function charSeparator (text) {
    let word = [];
    let repeats = [];
    textArray = text.split("");
    for (let i = 0; i < textArray.length; i++) {
        if (!charComparison(textArray[i])) {
            if (dataAnalysis(textArray[i], word)) {
                if (!repeats.includes(textArray[i].toLowerCase())) {
                    repeats.push(textArray[i].toLowerCase());
                }
            }
        } else {
            word = [];
        }
    }
    return changeText(textArray, repeats);
}

/* This function compares symbols from the sentence with separators. 
   Returns true if symbol is separator. */
   
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
    return textArray.join("");
}

console.log(charSeparator("Локомотив сегодня выиграл у Спартака со счетом 3-1."));