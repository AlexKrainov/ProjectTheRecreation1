function ShowLoginDialog() {

    if ($(".loginDialog").css("display") === "none")
        $(".loginDialog").css("display", "block");
    else
        $(".loginDialog").css("display", "none");
}

function Pre_ForgotThePassword(o) {
    var link = $(o).attr("href"); ///Home/ForgotThePassword?Length=7
    if (link.indexOf("?Length=7") != -1)
    {
        link = link.replace("?Length=7","");
    }

    var UserNameOrEmail = $("#NameOrEmail").val();

    //var name = $("#Name").val();
    //var email = $("#Email").val();
    //link = link + "?Name=" + name + "&Email=" + email;

    link = link + "?NameOrEmail=" + UserNameOrEmail;

    $(o).attr("href", link);
}


