$("#loginBtn").click(function () {
    var input = {
        userName: $("#userNameTxt").val().trim(),
        password: $("#passwordTxt").val().trim(),
        rememberMe: false
    };
    if ($("input[name='selectedd']").is(':checked')) {
        input.hatirla = true;
    }
    $.ajax({
        type: 'POST',
        url: '/Login/Login',
        data: JSON.stringify(input),
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            if (result == "1")
                window.location.href = '/Customer/Index';
            else if (result == "0")
                swal("Error!", "Login failed!", "error");
        },
        error: function () {
            swal("Error!", "Login failed!", "error");
        }
    });
});