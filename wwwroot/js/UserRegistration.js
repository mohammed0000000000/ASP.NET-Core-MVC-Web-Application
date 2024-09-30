$(function () {

    // CheckBox Functionality
    var checkBox = $("#UserRegistrationModal #UserRegistrationForm input[type = 'checkbox']");
    var registrationButton = $("#UserRegistrationModal button[name = 'Register']");
    var emailInput = $("#UserRegistrationModal #UserRegistrationForm input[name = 'Email']");

    registrationButton.prop("disabled", true);

    checkBox.click(onAcceptUserArgreementClick);
    registrationButton.click(onUserRegistrationClick);
    emailInput.on('blur', onEmailChecker);

    //console.log(emailInput);
    function onEmailChecker() {
        let email = $(this).val();
        //console.log(email);
        $.ajax({
            async:true,
            type: "GET",
            url: "https://localhost:44309/" + `Account/UserNameExists?email=${email}`,
            success: function (data) {
                console.log(data);
                if (data == true) {
                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Email Error", "Email is already use");
                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (jqXHR, textStatus) {
                PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "", "Email Error");
            }
        })
    }
    function onAcceptUserArgreementClick() {
        if ($(this).is(':checked')) {
            registrationButton.prop("disabled", false);
        }
        else {
            registrationButton.prop("disabled", true);
        }
    }

    //var registrationButton = $("#UserRegistrationModal button[name = 'Register']").click(onUserRegistrationClick);
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
        $.ajax({
            async: true,
            type: "POST",
            url: "https://localhost:44309/" + url,
            data: userInput,
            success: function (data) {
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
                    location.href = "/Home/Index";
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Register Error", errorText
                );
            }
        })
    }

})