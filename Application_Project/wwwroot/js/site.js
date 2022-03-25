
// for details on configuring this project to bundle and minify static web assets.

const { error } = require("jquery");

// Write your JavaScript code.
showPopup = (url, title) => {
   
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res);
            $("#form-modal .modal-title").html("<b>"+title+"</b>");
            $("#form-modal").modal('show');
            $('.modal-backdrop').css("background-color","black");
            $('.modal-header').css("background-color","red");
            //$('..modal').css("border-radius","50px");
            $('.modal-title').css("color","white");
        }
        
    })

}



//function showPopup() {
//    alert("Hello");
//}