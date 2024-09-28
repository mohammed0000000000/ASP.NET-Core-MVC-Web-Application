﻿//$(function () {
//    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);
//    function onUserLoginClick() {

//        var url = "Account/Login";
//        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();
//        //alert(antiForgeryToken);

//        var email = $("#UserLoginModal input[name='Email']").val();
//        var password = $("#UserLoginModal input[name='Password']").val();
//        var rememberMe = $("#UserLoginModal input[name='RememberMe']").val();

//        var userInput = {
//            __RequestVerificationToken: antiForgeryToken,
//            Email: email,
//            Password: password,
//            RememberMe: rememberMe
//        };

//        alert(email + " " + password + " " + rememberMe);

//        $.ajax(
//            {
//                type: "POST",
//                url: "http://localhost:44309/" +url,
//                data: userInput,
//                success: function (data) {
//                    var parsed = $.parseHTML(data);

//                    var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == 'true';
//                    if (hasErrors == true) {
//                        $("#UserLoginModel").html(data);

//                        userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);
//                    }
//                    else {
//                        location.href = "Category/Index";
//                    }
//                },
//                error: function (xhr, ajaxOptions, thrownError) {
//                    console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
//                }
//            }
//        )
//    }
//})
$(function () {

    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {

        var url = "Account/Login";

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };
        alert(`${userInput.Email}\t${userInput.Password}\t${userInput.RememberMe}`);
        $.ajax({
            async: true,
            type: "POST",
            url: "https://localhost:44309/" + url,
            data: userInput,
            success: function (data) {
                alert(data);
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserLoginModal").html(data);

                    $(document).on("click", "#UserLoginModal button[name='login']", onUserLoginClick);

                    //var form = $("#UserLoginForm");

                    //$(form).removeData("validator");
                    //$(form).removeData("unobtrusiveValidation");
                    //$.validator.unobtrusive.parse(form);

                }
                else {
                    location.href = '/Home/Index';

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                alert(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});