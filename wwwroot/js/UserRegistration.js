$(function () {
    var registrationButton = $("#UserRegistrationModal button[name = 'Register']").click(onUserRegistrationClick);
    function onUserRegistrationClick() {

        var url = "Account/Register";
        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        var password = $("#UserRegistrationModal input[name = 'Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name = 'ConfirmPassword']").val();
        var firstName = $("#UserRegistrationModal input[name = 'FirstName']").val();
        var lastName = $("#UserRegistrationModal input[name = 'LastName']").val();
        var address1 = $("#UserRegistrationModal input[name = 'Address1']").val();
        var address2 = $("#UserRegistrationModal input[name = 'Address2']").val();
        var postCode = $("#UserRegistrationModal input[name = 'PostCode']").val();
        var phoneNumber = $("#UserRegistrationModal input[name = 'PhoneNumber']").val();
        var acceptUserAgreement = $("#UserRegistrationModal input[name = 'acceptUserAgreement']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            LastName: lastName,
            Address: address1,
            Address2: address2,
            PostCode: postCode,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement: acceptUserAgreement,
        };
        alert(userInput.Email);

        $.ajax({
            async: true,
            type: "POST",
            url: "https://localhost:44309/" + url,
            data: userInput,
            success: function (data) {
                alert(data);
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == "true";
                if (hasErrors == true) {
                    $("#UserRegistrationModal").html(data);
                    $(document).on("click", "#UserRegistrationModal button[name='register']", onUserRegistrationClick);
                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidator");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    alert("Register Successfully");
                    location.href = "/Home/Index";
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        })
    }

})