
$(document).ready(function () {
    $("#Name").on("focusout", function () {
        CheckAllSpan();
    });
    $("#Age").on("focusout", function () {
        CheckAllSpan();
    });
    $("#Email").on("focusout", function () {
        CheckAllSpan();
    });
    $("#Age").on("click", function () {
        ChangeIndexAge($(this));
    });
});

function Agreement() {
    validAgreement();
    CheckAllSpan();
}


var VerificationPassword = false;
var VerificationAgreement = false;
var Span = false;

function PreClickRegister() {

    RemoveAllSpan();

    validAgreement();

    var result = CheckAllSpan();
    PasswordCheckTheSimilarity();

    return VerificationAgreement && VerificationPassword;
}

function validAgreement() {
    VerificationAgreement = $("#CheckAgreement").prop("checked");
}

function PasswordCheckTheSimilarity() {
    var pass1 = $("#Password").val();
    var pass2 = $("#PasswordConfirm").val();


    if (pass1 === pass2)
        VerificationPassword = true;
    else {
        VerificationPassword = false;
        $("#validPass").text("Password and confirmation password do not match.");
    }
}

function RemoveAllSpan() {
    $(".text-danger").each(function () {
        $(this).text("");
    });
}

function OnFocusOut() {
    validAgreement();
    CheckAllSpan();
}


function onFocusOutPassword() {
    var pass1 = $("#Password").val();
    var pass2 = $("#PasswordConfirm").val();

    if (pass1 === pass2) {
        $("#validPass").text("");
    }
    else
        $("#validPass").text("Password and confirmation password do not match.");

    CheckAllSpan();
}

function CheckAllSpan() {
    Span = false;

    if ($("#Name").val().length === 0 ||
        $("#Age").val().length === 0 ||
        $("#Password").val().length === 0 ||
        $("#PasswordConfirm").val().length === 0 ||
        !VerificationAgreement) {
        $("#ButtonCreate").addClass("disabled");
        return false;
    }

    $(".text-danger").each(function () {
        if ($(this).text().length != 0) {
            Span = true;
            $("#ButtonCreate").addClass("disabled");
            return false;
        }
    });

    if (!Span)
        $("#ButtonCreate").removeClass("disabled");
    return true;
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