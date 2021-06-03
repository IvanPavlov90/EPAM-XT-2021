let userText = "null or undefined";
console.log(changeText(userText));

function changeText (userText) {
    try {
        checkText(userText);
        let word = [];
        let repeats = [];
        let textArray = userText.split("");
        for (let i = 0; i < textArray.length; i++) {
            if (!comparisingWithSeparators(textArray[i])) {
                if (findRepetitiveSymbolsInWord(textArray[i], word)) {
                    if (!repeats.includes(textArray[i].toLowerCase())) {
                        repeats.push(textArray[i].toLowerCase());
                    }
                }
            } else {
                word = [];
            }
        } 
        return deleteDuplicates(textArray, repeats);
    } catch (e) {
        alert(e.message);
    }

}

function checkText (userText) {
    if (userText === null || userText === undefined) {
        throw new Error ("You can do nothing with null or undefined")
    }
}

/* This function compares symbols from the sentence with separators. 
   Returns true if symbol is separator. */
   
function comparisingWithSeparators (letter) {
    const separators = [" ", ",", "?", "!", ".", ":", ";"];
    return separators.includes(letter);
}

/* This function analyzes if letter from word repeats or not. 
   Returns true if symbol repeats inside word.*/

function findRepetitiveSymbolsInWord (letter, word) {
    if (!word.includes(letter.toLowerCase())) {
        word.push(letter.toLowerCase());
    } else {
        return true;
    }
}

/* This function search symbols in user's text that are in repeats array.
   Then it deletes such symbols from user's text. */ 

function deleteDuplicates (textArray, repeats) {
    for (let i = 0; i < textArray.length; i++) {
        if (repeats.includes(textArray[i].toLowerCase())) {
            textArray.splice(i, 1);
            i = i - 1;
        }
    }
    return textArray.join("");
}