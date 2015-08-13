
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
});

function Agreement() {

}


var VerificationPassword = false;
var VerificationAgreement = false;
var Span = false;

function PreClickRegister() {

    RemoveAllSpan();

    validAgreement();
    PasswordCheckTheSimilarity();

    //if (VerificationAgreement && VerificationPassword)
    //    $("#ButtonCreate").removeClass("disabled");
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
        $("#PasswordConfirm").val().length === 0) {
        $("#ButtonCreate").addClass("disabled");
        return;
    }

    $(".text-danger").each(function () {
        if ($(this).text().length != 0) {
            Span = true;
            $("#ButtonCreate").addClass("disabled");
            console.log($(this));
        }
    });

    if (!Span)
        $("#ButtonCreate").removeClass("disabled");
}
