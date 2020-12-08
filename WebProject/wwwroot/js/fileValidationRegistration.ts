
document.querySelectorAll(".input-Validation").forEach(function (value, key: number) {
    let regex = new RegExp("[A-Zа-я a-zА-Я]");
    value.addEventListener("focusout", function () {
        let text: string = this.value;
        let error: string = "В поле должны быть только буквы"; 
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
})
function CheckForNumber(text: string): boolean {
    for (let item of text) {
        if (Number(item)) return true;  
    }
    return false;
}


document.querySelector(".email-Validation").addEventListener("focusout", function () {
    let value: string = this.value;
    if (value.length == 0) {
        document.querySelector(".field-email").innerHTML = "Пустая строка";
    }
    else if (value.indexOf("@mail.ru") !== -1) {
        document.querySelector(".field-email").innerHTML = "";
    }
    else {
        document.querySelector(".field-email").innerHTML = "Неккоректный email";
    }
})
document.querySelector(".password-Validation").addEventListener("focusout", function () {

    let value: string = this.value;
    if (value.length == 0) document.querySelector(".password_field-Validation").innerHTML = "Пустая строка";
    else if (value.length < 6) document.querySelector(".password_field-Validation").innerHTML = "Минимум 6 символов";
    else document.querySelector(".password_field-Validation").innerHTML = "";
});

document.querySelector(".phone_Number-Validation").addEventListener("focusout", function () {

    let phone: string = this.value;
    let regex = new RegExp("[^0-9]");
    if (phone.length == 0) document.querySelector(".field_phone_Number-Validation").innerHTML = "Пустая строка";
    else if (regex.test(phone)) document.querySelector(".field_phone_Number-Validation").innerHTML = "Только цифры";
    else {
        document.querySelector(".field_phone_Number-Validation").innerHTML = "";
    }
})