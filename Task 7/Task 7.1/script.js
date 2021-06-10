exampleFunction();

function exampleFunction () {
    let userInput = document.getElementById("userExpression");
    let btn = document.getElementById("getResult");
    let output = document.getElementById("result");
    btn.addEventListener("click", () => {
        let result = changeText (userInput.value);
        output.innerHTML = result;
    });
}

function changeText (userText) {
    try {
        checkText(userText);
        let repeatedLetters = new Set();
        let word2 = new Set();
        let textArray = Array.from(userText);
        for (let symbol of textArray) {
            if (!isSymbolSeparator(symbol)) {
                isSymbolRepeatedOrNot(symbol.toLowerCase(), word2, repeatedLetters);
            } else {
                word2.clear();
            }
        }
        return deleteDuplicates(textArray, repeatedLetters);
    } catch (e) {
        alert(e.message);
    }
}

function checkText (userText) {
    if (typeof userText !== "string") {
        throw new SyntaxError ("You can't put anything in variable userText beside string")
    }
}

/** This function checks if symbol repeats during word (word is a group of symbols)
    that are not separators) */

function isSymbolRepeatedOrNot (letter, word2, repeatedLetters) {
    if (!word2.has(letter)) {
        word2.add(letter);
    } else {
        repeatedLetters.add(letter);
    }
}

/** This function compares symbols from the sentence with separators. 
   Returns true if symbol is separator.*/
   
function isSymbolSeparator (letter) {
    const separators = [" ", ",", "?", "!", ".", ":", ";"];
    return separators.includes(letter);
}

/** This function search symbols in user's text that are in repeats array.
   Then it deletes such symbols from user's text.*/ 

function deleteDuplicates (textArray, repeats) {
    let textResult = textArray.filter(item => !repeats.has(item))
    return textResult.join("");
}