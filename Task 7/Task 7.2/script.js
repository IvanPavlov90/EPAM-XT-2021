calculateExpression();

function calculateExpression () {
    let userInput = document.getElementById("userExpression");
    let getResult = document.getElementById("getResult");
    let output = document.getElementById("result");
    getResult.addEventListener("click", () => {
        let result = calculator (userInput.value);
        output.innerHTML = "Your result is " + result;
    });
}

function calculator (userExpression) {
    try {
        userExpression = checkExpression(userExpression);
        let ariphmeticSigns = getAriphmeticSigns(userExpression);
        let digitsArray = getDigits(userExpression);
        let result = getResult (digitsArray, ariphmeticSigns);
        return result;
    } catch (e) {
        alert(e.message);
        return "";
    }
}

/** This function checks if format of user's expression is correct or not. */

function checkExpression (expression) {
    const validExpression = /^([+-]{1}\s?)?([0-9]+(\.{1}[0-9]+)?\s?[\/\*+-]{1}\s?)+([0-9]+(\.{1}[0-9]+)?\s?){1}=$/;
    if (!validExpression.test(expression)) {
        throw new Error ("Your expression isn't valid.");
    } else {
        return expression;
    }
}   

function getAriphmeticSigns(expression) {
    const separators = ["+", "-", "/", "*"];
    let signs = Array.from(expression).filter(char => separators.includes(char));
    return signs;
}

function getDigits (expression) {
    let digitsArray = expression.split(/[\/\*+-]/);
    if (expression.startsWith("+") || expression.startsWith("-")) {
        digitsArray[0] = "0";
    }
    return digitsArray;
}

function getResult (digitsArray, ariphmeticSigns) {
    let result = 0;
    for (let i = 0; i < digitsArray.length; i++) {
        if (i === 0) {
            result += parseFloat(digitsArray[i]);  
        }
        else {
            switch (ariphmeticSigns[i-1]) {
                case "+":
                    result += parseFloat(digitsArray[i]);
                    break;
                case "-":
                    result -= parseFloat(digitsArray[i]);
                    break;
                case "*":
                    result *= parseFloat(digitsArray[i]);
                    break;
                case "/":
                    result /= parseFloat(digitsArray[i]);
                    break;
            }
        }
    }           
    return result.toFixed(2);
}