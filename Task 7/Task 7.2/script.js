function mathCalculator (math) {
    ariphmeticSigns = getAriphmeticSigns(math);
    mathArray = getDigits(math);
    result = getResult (mathArray, ariphmeticSigns)
    console.log(mathArray, ariphmeticSigns);
    console.log(result);
}

function getAriphmeticSigns(math) {
    signs = [];
    separators = ["+", "-", "/", "*"];
    for (let i = 0; i < math.length; i ++) {
        if (separators.includes(math[i])) {
            signs.push(math[i]);
        }
    }
    return signs;
}

function getDigits (math) {
    mathArray = math.split(/[\/\*+-]/);
    return mathArray;
}

function getResult (mathArray, ariphmeticSigns) {
    result = 0;
    for (let i = 0; i < mathArray.length; i++) {
        if (i === 0) {
            result += parseFloat(mathArray[i]);  
        }
        else {
            switch (ariphmeticSigns[i-1]) {
                case "+":
                    result += parseFloat(mathArray[i]);
                    break;
                case "-":
                    result -= parseFloat(mathArray[i]);
                    break;
                case "*":
                    result *= parseFloat(mathArray[i]);
                    break;
                case "/":
                    result /= parseFloat(mathArray[i]);
                     break;
            }
        }
    }           
    return result.toFixed(2);
}
     
mathCalculator(" 2+ 2    + 2.1    -    6");