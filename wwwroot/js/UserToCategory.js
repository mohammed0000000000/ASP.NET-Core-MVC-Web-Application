$(function () {
    var btn = $("button[name = 'SaveSelectedUsers']").prop("disabled", true);
    $("#CategoryId").on("change", function () {
        var categoryId = this.value;
        if (categoryId != 0) {
            $.ajax({
                async: true,
                type: "GET",
                url: "https://localhost:44309/" + `UsersToCategory/GetUsersForCategory?categoryId=${categoryId}`,
                success: function (data, status, jqxhr) {
                    $("#UsersCheckList").html(data);
                    btn.prop("disabled", false);
                },
                error: function (jqxhr, status, errorMessage) {
                    PresentClosableBootstrapAlert("#alert_placeholder", "danger", "An Error occured", `An Error has occured. An Administrator has been notified. Please Try Again Later`);
                    console.error("An error has occured" + errorMessage + " Status: " + status);
                }
            })
        }
        else {
            btn.prop("disabled", true);
            $("input[type='checkbox']").prop("checked", false);
            $("input[type='checkbox']").prop("disabled", true);
        }
    });
  
    $('#SaveSelectedUsers').click(function () {

        var url = "https://localhost:44309/" + "UsersToCategory/SaveSelectedUsers";
        var categoryId = $("#CategoryId").val();
        var antiForgeryToken = $("input[name='__RequestVerificationToken']").val();
        var usersSelected = [];
        DisableControls(true);

        $(".progress").show("fade");
        $('input[type=checkbox]:checked').each(function () {
            var userModel = {
                Id: $(this).attr("value")
            };
            usersSelected.push(userModel);
        });
        var usersSelectedForCategory = {
            __RequestVerificationToken: antiForgeryToken,
            CategoryId: categoryId,
            UsersSelected: usersSelected
        };
        $.ajax(
            {
                type: "POST",
                url: url,
                async: true,
                data: usersSelectedForCategory,
                success: function (data) {
                    $("#UsersCheckList").html(data);

                    $(".progress").hide("fade", function () {
                        $(".alert-success").fadeTo(2000, 500).slideUp(500, function () {
                            DisableControls(false);
                        });
                    });
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    $(".progress").hide("fade", function () {
                        PresentClosableBootstrapAlert("#alert_placeholder", "danger", "An error occurred!", errorText);
                        console.error("An error has occurred: " + thrownError + "Status: " + xhr.status + "\r\n" + xhr.responseText);
                        DisableControls(false);
                    });
                }
            }
        );
        function DisabledControls(disabled) {
            $("input[name='checkbox']").prop("disabled", disabled);
            $("#SaveSelectedUsers").prop("disabled", disabled);
            $('select').prop("disabled", disabled);
        }
    });
})