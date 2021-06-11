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

/* This function checks if format of user's expression is correct or not. */

function checkExpression (expression) {
    expression = cutRightPartOfExpression(expression.trim());
    if (expression.startsWith("*") || expression.startsWith("/")) {
        throw new Error ("Your expression isn't valid.");
    } else {
        const regexp = /[0-9]/;
        const symbolsRegexp = /[A-Za-zА-Яа-яЁё]/;
        let index = expression.search(regexp);
        let symbolsIndex = expression.search(symbolsRegexp);
        if (index == -1 || index > 1 || symbolsIndex != -1) {
            throw new Error ("Your expression isn't valid.");
        }
        return expression;
    }
}

/* This method cuts everything that is located after sign "=" */

function cutRightPartOfExpression (expression) {
    let index = expression.indexOf("=");
    let result = expression.slice(0, index + 1);
    return result;
}

function getAriphmeticSigns(expression) {
    let signs = [];
    const separators = ["+", "-", "/", "*"];
    for (let i = 0; i < expression.length; i ++) {
        if (separators.includes(expression[i])) {
            signs.push(expression[i]);
        }
    }
    return signs;
}

function getDigits (expression) {
    try {
        let digitsArray = expression.split(/[\/\*+-]/);
        if (expression.startsWith("+") || expression.startsWith("-")) {
            digitsArray[0] = "0";
        }
        checkDigitsArray(digitsArray);
        return digitsArray;
    } catch (e) {
        throw e;
    }
}

/* This method provides protection on cases when there are no digits 
   between separators. Like 4/5++2= */

function checkDigitsArray(digitsArray) {
    const regexp = /[0-9]/;
    for (let i = 0; i < digitsArray.length; i++) {
        let index = digitsArray[i].search(regexp);
        if (index == -1) {
            throw new Error ("Your expression isn't valid.");
        }
    }
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