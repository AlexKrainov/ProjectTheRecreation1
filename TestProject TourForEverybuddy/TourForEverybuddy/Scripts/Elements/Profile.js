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

function CheckEmptyFildEdit() {
    var result = SetBorderForEmptyControls();

    if (result == false) {
        $("#ValidIsFailed").text("Same fields can not be empty.");
        $("#submitCreate").addClass("disabled");
        return false;
    }
    return true;
}
function SetBorderForEmptyControls()
{
    var result = true;
    if ($("#title").val().length == 0) {
        $("#title").css("border", "1px solid red");
        result = false;
    }else
    {
        $("#title").css("border", "");
    }

    if ($("#description").val().length == 0) {
        $("#description").css("border", "1px solid red");
        result = false;
    } else {
        $("#description").css("border", "");
    }

    if ($("#MaximumTravelers").val().length == 0) {
        $("#MaximumTravelers").css("border", "1px solid red");
        result = false;
    } else {
        $("#MaximumTravelers").css("border", "");
    }

    if ($("#price").val().length == 0) {
        $("#price").css("border", "1px solid red");
        result = false;
    } else {
        $("#price").css("border", "");
    }

    if ($("#DaysOfTheWeek").val().length == 0) {
        $(".imgsDays").css("border", "1px solid red");
        result = false;
    } else {
        $(".imgsDays").css("border", "");
    }

    if ($("#startsAt").val().length == 0 && $("#isAnyTime").prop("checked") == false) {
        $("#startsAt").css("border", "1px solid red");
        result = false;
    } else {
        $("#startsAt").css("border", "");
    }

    return result;
}


function TextBoxChange() {
    $("#ValidIsFailed").text("");
    $("#submitCreate").removeClass("disabled");
}

// EditTour Remove Picture
function SelectPicture(o) {
    if ($(o).css("opacity") == "1") {
        $(o).css("opacity", ".4");
    } else {
        $(o).css("opacity", "1");
    }
    AddHiddenID();
}

function AddHiddenID() {
    var array = "";
    $(".image").each(function () {
        if ($(this).css("opacity") != "1") {
            array += $(this).attr("id") + ",";
        }
    });

    $("#PictureArray").val(array);

    if ($("#PictureArray").val().length != 0) {
        $("#RemoveBtn").removeClass("disabled");
        $("#DeletePicture").text("");
    }
    else
        $("#RemoveBtn").addClass("disabled");
}

function RemovePicture(o) {
    if ($("#PictureArray").val().length == 0) {
        $(o).addClass("disabled");
        $("#DeletePicture").text("Please, select images for delete.");
        return false;
    } else {
        $(o).removeClass("disabled");
        $("#DeletePicture").text("");
        return true;
    }
    return false;
}

// End Remove Picutre

//Slide picture
$(document).ready(function () {
    $(".slideSelectors > li").attr("onclick", "pagePicture(this)");
});

function pagePicture(o) {
    var id = $(o).attr("id");
    var value = $(o).text();
    //Из расчета (<div> <img> <img> <ul> <li><li>$(o).css("margin", "-1px 1px 1px 10px"); </ul></div ) добираемся до div и получаем массив картинок

    var ul = $(o).parent();
    $(ul).children("li").attr("style", "");

    var arrayImg = $(o).parent().parent().children("img");

    for (var i = 0; i < arrayImg.length; i++) {
        if (i == id) {
            $(arrayImg[i]).css("display", "block");
            $(o).css("margin", "-1px 1px 1px 10px");
            $(o).css("background", "#777");
            $(o).css("width", "18px");
            $(o).css("height", "18px");
        }
        else {
            $(arrayImg[i]).css("display", "none"); // arrayImg[i].style = "display: none;";
        }
    }

    console.log($(o));
}

//end Slide picture

// Add tour 

$(document).ready(function () {
    if ($("#startsAt") != undefined) {
        $("#startsAt").val($("#startAtHidden").val());
    }
});

function AnyTimeClick(o) {
    if ($(o).prop("checked") == true) {
        $("#displayNameStartsAt").css("opacity", ".2");
        $("#startsAt").css("opacity", ".2");
    }else
    {
        $("#displayNameStartsAt").css("opacity", "1");
        $("#startsAt").css("opacity", "1");
    }
}

function SelectDaysOfTheWeek(o) {

    if($(o).css("opacity") != "1")
    {
        $(o).css("opacity", "1");
    }else
    {
        $(o).css("opacity", ".2");
    }

    AddHiddenIDEditTour();
}
function AddHiddenIDEditTour() {
    var array = "";
    $(".imgsDays").children().each(function () {
        if ($(this).css("opacity") == "1") {
            array += $(this).attr("id") + ",";
        }
    });
    $("#DaysOfTheWeek").val(array);

    //if ($("#DaysOfTheWeek").val().length != 0) {
    //  //  $("#RemoveBtn").removeClass("disabled");
    //    $("#DeletePicture").text("");
    //}
    //else
    //    $("#RemoveBtn").addClass("disabled");
}

//