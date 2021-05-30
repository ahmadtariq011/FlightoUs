
function ChnagePrice() {

}
function PrintRecipt() {
    var divToPrint = document.getElementById('Panel');

    var newWin = window.open('', 'Print-Window');

    newWin.document.open();

    newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

    newWin.document.close();

    setTimeout(function () { newWin.close(); }, 10);


}

function Adding() {
    var Added;
    var FirstOne = parseFloat($("#txtFirstOnePrice").val());
    var SecondOne = parseFloat($("#txtSecondOnePrice").val());
    var ThirdOne = parseFloat($("#txtThirdOnePrice").val());
    if ($("#txtFirstOnePrice").val().length) {
        Added = FirstOne;
    }
    if ($("#txtSecondOnePrice").val().length) {
        Added += SecondOne;
    }
    if ($("#txtThirdOnePrice").val().length) {
        Added += ThirdOne;
    }
    //Added = FirstOne + SecondOne + ThirdOne;
    $('#txtTotalAmount').attr('value', Added);


}
function CheckPaid() {
    if (!$("#txtPaid").val().length) {
        return;
    }
    var Minuesvalue;
    var Paidvalue = parseFloat($("#txtPaid").val());
    var TotalValue = parseFloat($("#txtTotalAmount").val());
    if (Paidvalue > TotalValue) {
        $('#txtbalanceAmount').attr('value', '0');
        return;
    }
    if ($("#txtTotalAmount").val().length) {
        if ($("#txtPaid").val().length) {      
            Minuesvalue = TotalValue - Paidvalue;
        }
        $('#txtbalanceAmount').attr('value', Minuesvalue);
    }
}
function makeRecipt() {
    if (!Validate("#BasicInfo")) {
        return;
    }
    $("#loader").show();

    $("#div_message").hide();

    var Recipt =
    {
        Lead_Id: $("#hfLeadId").val(),
        FirstServiceTitle: $.trim($("#txtFirstOne").val()),
        SecondServiceTitle: $.trim($("#txtSecondOne").val()),
        ThirdServiceTitle: $.trim($("#txtThirdOne").val()),
        FirstServicePrice: $.trim($("#txtFirstOnePrice").val()),
        SecondServicePrice: $.trim($("#txtSecondOnePrice").val()),
        ThirdServicePrice: $.trim($("#txtThirdOnePrice").val()),
        Remarks: $.trim($("#txtRemarks").val()),
        AmountPaid: $.trim($("#txtPaid").val()),
        TotalAmount: $.trim($("#txtTotalAmount").val()),
        Balance: $.trim($("#txtbalanceAmount").val()),
        CreatedBy: $.trim($("#UserId").val()),
        UserTypeLogin: $.trim($("#UserTypeLogin").val())
    };

    $.post("/api/ReciptApi/MakeRecipt", Recipt, makeReciptCallback);
}

function makeReciptCallback(data) {
    $("#loader").hide();
    if (!data.isSucceeded) {
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#div_message").show();
        $("#span_message").html("Recipt is Not Added ! Error Occur. Please Try Again !");
        return;
    }

    $("#div_message").removeClass("failure");
    $("#div_message").addClass("success");
    $("#div_message").show();
    $("#span_message").html("Recipt Is Added Successfully ");
}

function ApproveRecipt() {
    if (!Validate("#BasicInfo")) {
        return;
    }
    $("#loader").show();

    $("#div_message").hide();

    var Recipt =
    {
        Id: $("#txtReciptId").val(),
        UserName: $("#txtUserName").val(),
        Password: $("#txtPassword").val(),
    };

    $.post("/api/ReciptApi/AuthenticateUser", Recipt, ApproveReciptCallback);
}
function ApproveReciptCallback(data) {
    $("#loader").hide();
    if (!data.isSucceeded) {
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#div_message").show();
        $("#span_message").html(data.message);
        return;
    }

    $("#div_message").removeClass("failure");
    $("#div_message").addClass("success");
    $("#div_message").show();
    $("#span_message").html(data.message);
}
