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
            $(".images").append(" <img src='" + e.target.result + "' width='50' height='50' />");
        }
        reader.readAsDataURL(file);
    }
    $(".images").html(fileNames);

}