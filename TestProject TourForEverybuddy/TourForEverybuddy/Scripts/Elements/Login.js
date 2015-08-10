function ShowLoginDialog() {

    if ($(".loginDialog").css("display") === "none")
        $(".loginDialog").css("display", "block");
    else
        $(".loginDialog").css("display", "none");
}