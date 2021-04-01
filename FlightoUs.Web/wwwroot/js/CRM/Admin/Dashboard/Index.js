function Logout(type) {
    var User =
    {
        Keyword: type
    };
    $.post("/api/UserAPI/Logout", User, logoutcallback);
}
function logoutcallback(data) {
    window.location.href = data.message;
}