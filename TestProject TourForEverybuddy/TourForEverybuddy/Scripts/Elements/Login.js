//$(document).ready(function () {
//    console.log(document.URL);
//    if(document.URL.indexOf("Password") != 0)
//    {
//        var start = document.URL.indexOf("&Password");
//        var finish = document.URL.indexOf("&RememberMe");
//        var oldParam = document.URL.slice(start, finish);
//        var newURL = document.URL.replace(oldParam, "");
//        window.location.href = newURL;
//    }
//});

function ShowLoginDialog() {

    if ($(".LoginDiv").css("display") === "none")
        $(".LoginDiv").css("display", "block");
    else
        $(".LoginDiv").css("display", "none");
}

function Pre_ForgotThePassword(o) {
    var link = $(o).attr("href"); ///Home/ForgotThePassword?Length=7
    if (link.indexOf("?Length=7") != -1) {
        link = link.replace("?Length=7", "");
    }

    var UserNameOrEmail = $("#NameOrEmail").val();

    link = link + "?NameOrEmail=" + UserNameOrEmail;

    $(o).attr("href", link);
}

function CheckTextBoxForEmpty() {
    if ($("#NameOrEmail").val() == 0 || $("#Pasword").val() == 0) {
        return false;
    }
    else {
        return true;
    }
}

