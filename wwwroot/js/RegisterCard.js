$(function () {
    let registerModel = $("#UserRegistrationModal");
    console.log("This is register mOdle ==> " + registerModel);
    $(".card-click").on("click", function() {
        var categoryId = $(this).find("input").val();
        $.ajax({
            async: true,
            type: "POST",
            url: "https://localhost:44309/UsersToCategory/AssignCourseToUser?categoryId=" + categoryId,
            success: function (response, status, jqxhr) {
                if (response == 'Unauhorized') {
                    registerModel.modal("show");
                }
                else if (rseponse == 'false') {
                    
                }
                else {
                    // handle is success
                }
            },
            error: function (jqxhr, status, errorMessage) {

            }
            
        })
    });

})