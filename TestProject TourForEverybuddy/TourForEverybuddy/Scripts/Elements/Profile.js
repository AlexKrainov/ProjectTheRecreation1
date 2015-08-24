//function NewTour() {
//    if ($("#tourDialog").css("display") == "none")
//        $("#tourDialog").css("display", "block");
//    else
//        $("#tourDialog").css("display", "none");
//}

//http://www.raymondcamden.com/2013/09/10/Adding-a-file-display-list-to-a-multifile-upload-HTML-control
function handleFileSelect(e) {

    //if (!e.files) return;
    if (!e.files || !window.FileReader) return;

    var files = e.files;
    var fileNames = "";
    var filesArr = Array.prototype.slice.call(files);

    for (var i = 0; i < filesArr.length; i++) {
        var file = files[i];
        if (!file.type.match("image.*")) {
            return;
        }
        var reader = new FileReader();
        //reader.onload = function (e) {
        //    $('#blah').attr('src', e.target.result);
        //}

        reader.onload = function (e) {
            $(".images").append(" <img class='arrayimg' src='" + e.target.result + "' width='50' height='50' />");
        }
        reader.readAsDataURL(file);
    }
    $(".images").html(fileNames);

}

function CheckEmptyFild() {
    if ($("#Title").val().length == 0 || $("#description").val().length == 0) {
        $("#ValidIsFailed").text("Field title or the message can not be empty.");
        $("#submitCreate").addClass("disabled");
        return false;
    }
    return true;
}
function TextBoxChange() {
    $("#ValidIsFailed").text("");
    $("#submitCreate").removeClass("disabled");
}