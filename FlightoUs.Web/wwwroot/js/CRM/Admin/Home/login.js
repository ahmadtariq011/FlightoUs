$(document).ready(function () {
    $("#divLogin input").keyup(handler_enter_login);
});
function handler_enter_login(e) {
    var charCode;

    if (e && e.which) {
        charCode = e.which;
    } else if (window.event) {
        e = window.event;
        charCode = e.keyCode;
    }
    if (charCode == 13)
        Login();
}
function Login() {
    if (!Validate('#divLogin')) {
        return;
    }        

    $("#div_message").hide();
    $("#login-button").attr("disabled", true);

    var login = {
        Email: $("#txtEmail").val(),
        Password: $("#txtPassword").val(),
    };

    $.post("/api/AccountApi/AdminLogin", login, LoginCallBack);
}
function LoginCallBack(data) {
    $("#login-button").attr("disabled", false);
    
    if (data.isSucceeded) {
        $("#login-button").click(function (event) {
            event.preventDefault();

            $('form').fadeOut(500);
            $('.wrapper').addClass('form-success');
        });
        window.location.href = data.message;
    } else {
        $("#div_message").show();
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#span_message").html(data.Message);
    }
}

function SendForgotPasswordRequest() {
    if (!Validate('#divPassword'))
        return;

    $("#loader").show();
    $("#div_message").hide();
    $("#btnSubmit").attr("disabled", true);

    var login = {
        Email: $("#txtEmail").val()
    };

    $.post("/api/AccountApi/ForgotPassword", login, SendForgotPasswordRequestCallBack);
}

function SendForgotPasswordRequestCallBack(data) {
    $("#btnSubmit").attr("disabled", false);
    $("#loader").hide();
    if (data.IsSucceeded) {
        $("#divPassword").hide();
        $("#divConfirmation").show();
    } else {
        $("#div_message").show();
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#span_message").html(data.Message);
    }
}

function ResetPassword() {
    if (!Validate('#divPassword'))
        return;

    $("#loader").show();
    $("#div_message").hide();
    $("#btnSubmit").attr("disabled", true);

    var login = {
        Email: $("#hfEmail").val(),
        NewPassword: $("#txtNewPassword").val()        
    };

    $.post("/api/AccountApi/ResetPassword", login, SendForgotPasswordRequestCallBack);
}