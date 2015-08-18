
$(document).ready(function () {
    $("#Name").on("keyup", function () {
        OnChange("#Name");
    });
    $("#Age").on("change", function () {
        OnChange("#Age");
    });
    $("#Email").on("keyup", function () {
        OnChange("#Email");
    });
    $("#Age").on("click", function () {
        ChangeIndexAge($(this));
    });
});

function Agreement() {
    validAgreement();
}


var VerificationPassword = false;
var VerificationAgreement = false;
var Span = false;

function PreClickRegister() {

    var nameResult = CheckFieldForEmpty("#Name");
    var ageResult = CheckFieldForEmpty("#Age");
    var emailResult = CheckFieldForEmpty("#Email");
    var passwordResultEmpty = CheckPasswordForEmpty();
    if (passwordResultEmpty)
        VerificationPassword = PasswordCheckTheSimilarity();
    var agreementResult = validAgreement();

    if (nameResult == true && ageResult == true && emailResult == true && passwordResultEmpty == true && VerificationPassword == true && agreementResult == true) {
        $("#ButtonCreate").removeClass("disabled");
        return true;
    }
    else {
        $("#ButtonCreate").addClass("disabled");
        return false;
    }
}

function CheckFieldForEmpty(o) {
    var el = $(o);
    if (el.val().length === 0) {
        el.css("border", "1px solid red");
        return false;
    }
    else {
        el.css("border", "");
        return true;
    }
}

function CheckPasswordForEmpty() {
    var result = false;
    var pass1 = $("#Password").val();
    var pass2 = $("#PasswordConfirm").val();

    if (pass1.length === 0) {
        $("#Password").css("border", "1px solid red");
        result = false;
    } else {
        $("#Password").css("border", "");
        result = true;
    }

    if (pass2.length === 0) {
        $("#PasswordConfirm").css("border", "1px solid red");
        result = false;
    } else {
        $("#Password").css("border", "");
        result = true;
    }

    return result;
}

function validAgreement() {
    VerificationAgreement = $("#CheckAgreement").prop("checked");

    if (!VerificationAgreement)
        $("#CheckAgreementValid").text("Required the agreement ...");

    return VerificationAgreement;
}

function PasswordCheckTheSimilarity() {
    var pass1 = $("#Password").val();
    var pass2 = $("#PasswordConfirm").val();


    if (pass1 === pass2) {
        $("#Password").css("border", "");
        $("#PasswordConfirm").css("border", "");
        $("#validPass").text("");
        return true;
    }
    else {
        $("#Password").css("border", "1px solid red");
        $("#PasswordConfirm").css("border", "1px solid red");
        $("#validPass").text("Password and confirmation password do not match.");
        return false;
    }
}

function onFocusOutPassword() {
    PasswordCheckTheSimilarity();
}

function OnChange(o) {
    var el = $(o);
    if (el.val().length === 0) {
        el.css("border", "1px solid red");
        return false;
    }
    else {
        el.css("border", "");
        return true;
    }
}


function AddChoiceLanguage() {
    console.log($(".ArrayLanguageList > select"));
    $(".ArrayLanguageList > select").each(function () {
        if ($(this).css("display") === "none") {
            console.log(($(this)));
            $(this).css("display", "block");
            return false;
        }
    })
}

function ChangeIndexAge(o) {
    if ($(o).val() < 1)
        $(o).val("1");
}