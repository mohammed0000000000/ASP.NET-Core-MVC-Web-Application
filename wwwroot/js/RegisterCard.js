$(function () {
    let registerModel = $("#UserRegistrationModal");
    console.log("This is register mOdle ==> " + registerModel);
    $(".card-click").on("click", function () {
        var categoryId = $(this).data("id");
        console.log("this is id for card => " + categoryId)
        $.ajax({
            async: true,
            type: "POST",
            url: "https://localhost:44309/UsersToCategory/AssignCourseToUser?categoryId=" + categoryId,
            success: function (response, status, jqxhr) {
                console.log(response);
                if (response == 'Unauhorized') {
                    registerModel.modal("show");
                }
                else if (response == 'false') {
                    
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