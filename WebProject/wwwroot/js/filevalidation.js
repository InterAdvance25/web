"use strict";
document.querySelector(".emailValidation").addEventListener("focusout", function () {
    var value = this.value;
    if (value.length == 0) {
        document.querySelector(".spanEmailValidation").innerHTML = "Пустая строка";
        document.querySelector(".spanEmailValidation").classList.add("error");
    }
    else {
        document.querySelector(".spanEmailValidation").classList.remove("error");
        document.querySelector(".spanEmailValidation").innerHTML = "";
    }
});
document.querySelector(".passwordValidation").addEventListener("focusout", function () {
    var value = this.value;
    if (value.length == 0) {
        document.querySelector(".spanPasswordValidation").innerHTML = "Пустая строка";
        document.querySelector(".spanPasswordValidation").classList.add("error");
    }
    else {
        document.querySelector(".spanPasswordValidation").classList.remove("error");
        document.querySelector(".spanPasswordValidation").innerHTML = "";
    }
});
//# sourceMappingURL=filevalidation.js.map