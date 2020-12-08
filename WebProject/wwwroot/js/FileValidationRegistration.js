document.querySelectorAll(".input-Validation").forEach(function (value, key) {
    var regex = new RegExp("[A-Zа-я a-zА-Я]");
    value.addEventListener("focusout", function () {
        var text = this.value;
        var error = "В поле должны быть только буквы";
        if (text.length == 0) {
            document.querySelectorAll(".field-Validation")[key].innerHTML = "Пустая строка";
        }
        else if (!regex.test(text)) {
            document.querySelectorAll(".field-Validation")[key].innerHTML = error;
        }
        else if (CheckForNumber(text)) {
            document.querySelectorAll(".field-Validation")[key].innerHTML = error;
        }
        else {
            document.querySelectorAll(".field-Validation")[key].innerHTML = "";
        }
    });
});
function CheckForNumber(text) {
    for (var _i = 0, text_1 = text; _i < text_1.length; _i++) {
        var item = text_1[_i];
        if (Number(item))
            return true;
    }
    return false;
}
document.querySelector(".email-Validation").addEventListener("focusout", function () {
    var value = this.value;
    if (value.length == 0) {
        document.querySelector(".field-email").innerHTML = "Пустая строка";
    }
    else if (value.indexOf("@mail.ru") !== -1) {
        document.querySelector(".field-email").innerHTML = "";
    }
    else {
        document.querySelector(".field-email").innerHTML = "Неккоректный email";
    }
});
document.querySelector(".password-Validation").addEventListener("focusout", function () {
    var value = this.value;
    if (value.length == 0)
        document.querySelector(".password_field-Validation").innerHTML = "Пустая строка";
    else if (value.length < 6)
        document.querySelector(".password_field-Validation").innerHTML = "Минимум 6 символов";
    else
        document.querySelector(".password_field-Validation").innerHTML = "";
});
document.querySelector(".phone_Number-Validation").addEventListener("focusout", function () {
    var phone = this.value;
    var regex = new RegExp("[^0-9]");
    if (phone.length == 0)
        document.querySelector(".field_phone_Number-Validation").innerHTML = "Пустая строка";
    else if (regex.test(phone))
        document.querySelector(".field_phone_Number-Validation").innerHTML = "Только цифры";
    else {
        document.querySelector(".field_phone_Number-Validation").innerHTML = "";
    }
});
//# sourceMappingURL=FileValidationRegistration.js.map