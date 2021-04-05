
function openPage(pageName, elmnt, color) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].style.backgroundColor = "";
    }
    document.getElementById(pageName).style.display = "block";
    elmnt.style.backgroundColor = color;
}

// Get the element with id="defaultOpen" and click on it
document.getElementById("defaultOpen").click();
$(document).ready(function () {
    $("#aUsers").addClass("navbar_selected");
    $("#div_AddEdit input").keyup(handler_enter);
    $("#txtExpirationDate").datepicker({ dateFormat: 'mm/dd/yy' });

    $("#txtCreditCardNumber").keypress(DigitsOnly);
    $("#txtMonth").keypress(DigitsOnly);
    $("#txtYear").keypress(DigitsOnly);
    $("#txtCVV").keypress(DigitsOnly);
    $("#txtNumberOfAgents").keypress(DigitsOnly);
    LoadRemarksWithCount();

    //$(document).tooltip({
    //    content: function () {
    //        return $(this).prop('title');
    //    }
    //    , position: {
    //        my: "left top",
    //        at: "left bottom"
    //    }
    //    , show: {
    //        effect: "slideDown"
    //    }
    //    ,position: {
    //        my: "center bottom-20",
    //        at: "center top",
    //        using: function (position, feedback) {
    //            $(this).css(position);
    //            $("<div>")
    //                .addClass("arrow")
    //                .addClass(feedback.vertical)
    //                .addClass(feedback.horizontal)
    //                .appendTo(this);
    //        }
    //    }
    //});
});
function handler_enter(e) {
    var charCode;

    if (e && e.which) {
        charCode = e.which;
    } else if (window.event) {
        e = window.event;
        charCode = e.keyCode;
    }
    if (charCode == 13) {
        SaveLeads();
    }
}

function AddEditTicket(type) {
    if (type === 1) {

    }
    $("#TicketPanel").toggle();
}
function AddEditHotel(type) {
    if (type === 1) {

    }
    $("#HotelPanel").toggle();
}

function SaveLeads() {
    if (!Validate("#BasicInfo")) {
        return;
    }

    $("#div_message").hide();

    var User =
    {
        
        Id: $("#hfLeadId").val(),
        UserName: $.trim($("#txtUserName").val()),
        FirstName: $.trim($("#txtFirstName").val()),
        Telephone: $.trim($("#txtTelephone").val()),
        Email: $.trim($("#txtEmail").val()),
        CreatedBy: $.trim($("#txtCreatedBy").val()),
        Address: $.trim($("#txtAddress").val()),
        DepartureDate: $.trim($("#txtDepartureDateL").val()),
        ReturnDate: $.trim($("#txtArrivalDateL").val()),
        LeadTitle: $.trim($("#txtLeadTitle").val()),
        AssignToUser: $.trim($("#txtAssignTo").val()),
        ClassOfTravelName: $.trim($("#txtClassofTravel").val()),
        TripTypeName: $.trim($("#txttripType").val()),
        LeadStatusName: $.trim($("#txtLeadStatus").val()),
        LeadTypeName: $.trim($("#txtLeadTypeN").val()),
        CustomeTypeName: $.trim($("#txtCustomerType").val()),
    };

    $.post("/api/LeadsApi/SaveLeads", User, SaveLeadCallback);
}

function SaveLeadCallback(data) {
    $("#loader").hide();
    if (!data.isSucceeded) {
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#div_message").show();
        $("#span_message").html("Lead is Not Added ! Error Occur. Please Try Again !");
        return;
    }

    $("#div_message").removeClass("failure");
    $("#div_message").addClass("success");
    $("#div_message").show();
    $("#span_message").html("Lead is Successfully Addeed ");
}
function SaveTicket() {
    if (!Validate("#BasicInfo")) {
        return;
    }

    $("#div_message").hide();

    var ticket =
    {

        Id: $("#hfTicketId").val(),
        From: $.trim($("#txtFrom").val()),
        To: $.trim($("#txtTo").val()),
        DepartureDate: $.trim($("#txtDepartureDate").val()),
        NetValue: $.trim($("#txtNetValue").val()),
        TotalValue: $.trim($("#txtTotalValue").val()),
        PSF: $.trim($("#txtPSF").val()),
        TripTypeName: $.trim($("#txtTripType").val()),
        ArrivalDate: $.trim($("#txtArrivalDate").val()),
        Lead_Id: $.trim($("#hfLeadId").val()),
        User_Id: $.trim($("#txtTicketIssuedBy").val())
    };

    $.post("/api/TicketApi/SaveTicket", ticket, SaveTicketCallback);
}

function SaveTicketCallback(data) {
    $("#loader").hide();
    if (!data.isSucceeded) {
        $("#div_message_Ticket").removeClass("success");
        $("#div_message_Ticket").addClass("failure");
        $("#div_message_Ticket").show();
        $("#span_message").html("Ticket Sale is Not Added ! Error Occur. Please Try Again !");
        return;
    }

    $("#div_message_Ticket").removeClass("failure");
    $("#div_message_Ticket").addClass("success");
    $("#div_message_Ticket").show();
    $("#span_message_Ticket").html("Ticket Sale is Successfully Added !");
}
function SaveHotel() {
    if (!Validate("#BasicInfo")) {
        return;
    }

    $("#div_message").hide();

    var hotel =
    {

        Id: $("#hfHotelId").val(),
        Name: $.trim($("#txtHotelName").val()),
        NetValue: $.trim($("#txtNetValueH").val()),
        TotalValue: $.trim($("#txtTotalValueH").val()),
        PSF: $.trim($("#txtPSFH").val()),
        City: $.trim($("#txtCityH").val()),
        Country: $.trim($("#txtCountryH").val()),
        Lead_Id: $.trim($("#hfLeadId").val()),
        User_Id: $.trim($("#txtHotelIssuedBy").val())
    };

    $.post("/api/HotelApi/SaveHotel", hotel, SaveHotelCallback);
}

function SaveHotelCallback(data) {
    $("#loader").hide();
    if (!data.isSucceeded) {
        $("#div_message_Hotel").removeClass("success");
        $("#div_message_Hotel").addClass("failure");
        $("#div_message_Hotel").show();
        $("#span_message").html("Hotel Sale is Not Added ! Error Occur. Please Try Again !");
        return;
    }

    $("#div_message_Hotel").removeClass("failure");
    $("#div_message_Hotel").addClass("success");
    $("#div_message_Hotel").show();
    $("#span_message_Hotel").html("Hotel Sale is Successfully Added !");
}

function LoadRemarksWithCount() {

    filters =
    {
        LeadId: $("#hfLeadId").val()
    };
    if (IsHTML5) {
        sessionStorage["CustomerFilters"] = JSON.stringify(filters);
    }
    debugger;
    $("#loader").show();
    $.post("/api/RemarksApi/GetAllRemarks", filters, LoadRemarksWithCountCallBack);
}
function LoadRemarksWithCountCallBack(data) {
    debugger;
    $("#loader").hide(); $("#divCustomerList").show();
    $("#tbl").show(); $("#div_no_found").hide(); $("#divPagerUsers").show();
    $("#spanTotalRecords").text("(" + data.totalCount + " records)");

    if (data.totalCount < 1) {
        $("#tbl").hide();
        $("#divPagerUsers").hide();
        $("#div_no_found").show();
        return;
    }
    $("#tbl tbody").html($("#ListTemplateCustomers").render(data.message));

    if (CustomersGridPager == null) {
        CustomersGridPager = $("#divPagerUsers").GridPager({
            TotalRecords: data.totalCount,
            ChangePageSize: ChangePageCustomerResults,
            NavigateToPage: CustomersPageNavigation
        });
    }

    CustomersGridPager.GridPager("SetPageIndexAndSize", filters.PageIndex, filters.PageSize);
    CustomersGridPager.GridPager("SetPager", data.TotalCount);
}




function UploadAgent() {
    if (!Validate("#UploadAgents"))
        return;

    $("#loader").show();
    $("#div_message").hide();

    $("#frmAgent").ajaxSubmit({
        url: '/api/BlogCategoryApi/UploadCategory',
        type: 'post',
        success: UploadAgentCallback,
        error: function (result) {
        }
    });
}


function UploadAgentCallback(data) {
    var result = $.parseJSON(data);

    ShowCallbackMessage(result.IsSucceeded, result.Message);
}

function ShowCallbackMessage(isSucceeded, message) {
    $("#loader").hide();
    if (isSucceeded) {
        $("#div_message").removeClass("failure");
        $("#div_message").addClass("success");
    }
    else {
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
    }
    $("#div_message").show();
    $("#span_message").html(message);
}



function carrierLimits() {
    var totalNoOfCarriers = $("#txtNumberOfCarriers").val();
    if (totalNoOfCarriers < $("input[name='chkCarriers']:checked").length) {
        alert("No of selected carriers is greater you are enter values here");
        $("#txtNumberOfCarriers").val($("input[name='chkCarriers']:checked").length);
    }
}

function varifyNoOfCarriers(v) {
    var totalNoOfCarriers = $("#txtNumberOfCarriers").val();
    if (totalNoOfCarriers < $("input[name='chkCarriers']:checked").length) {
        alert("No of selected carriers limit is exeeded");
        $(v).prop('checked', false);
    }
}

function VarifyBanyanClearView(sender) {
    if ($("#chkBanyan").is(":checked") && $("#chClearView").is(":checked")) {
        alert("You can't select Banyan and ClearView carriers at same time.");
        $(sender).prop('checked', false);
    }
}



function Cancel() {
    window.location.href = "/" + $("#hfUserType").val() + "/Customers";
}

function Reset(option) {
    if (option == "ReportSettings") {
        $("#ddlReportFrequncy").val('');
    }
    else if (option == "ListSettings") {
        $("#txtRemoveBlackIPAfterNdays").val('');
    }
    else if (option == "RedListSettings") {
        $("#ddlRedListOptions").val('');
        $("#txtRemoveRedIPAfterNdays").val('');
        $("#txtAuthAPIKey").val('');
    }
    else if (option == "EmailSettings") {
        $("#txtSMTP").val('');
        $("#txtSMTPort").val('');
        $("#txtUserName").val('');
        $("#txtPassword").val('');
        $("#chkEnableSsl").prop("checked", false);
    }
}

function OpenTab(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = $(".tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = $(".tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(tabName).style.display = "block";

    $("#btn" + tabName).addClass("active");
    //evt.currentTarget.className += " active";
}

function ShowHideShipLinkCentralCredential() {
    $("#divShipLinkCentralCredential").hide();
    $("#txtShipLinkCentralUsername").removeAttr("required");
    $("#txtShipLinkCentralPassword").removeAttr("required");

    if ($("#chkIsEndOfDay").is(":checked") == true) {
        $("#divShipLinkCentralCredential").show();
        $("#txtShipLinkCentralUsername").attr("required", "required");
        $("#txtShipLinkCentralPassword").attr("required", "required");
    }
}

function ShowHidePassword(sender, target) {
    var senderObj = $(sender);
    document.getElementById(target).type = senderObj.is(":checked") ? 'text' : 'password';
}

function ShowHidePasswordInLabel(sender, lblPassword, password) {
    var stars = password.replace(/./g, "*");

    var senderObj = $(sender);
    $("#" + lblPassword).text(senderObj.is(":checked") ? password : stars);
}

function Cancel() {
    window.location.href = 'Index';
}

function UpdateProfile() {
    if (!Validate("#BasicInfo")) {
        return;
    }

    $("#loader").show();
    $("#div_message").hide();

    var customer =
    {
        User_Id: $("#hfUserId").val(),
        Telephone: $.trim($("#txtTelephone").val()),
        Address: $("#txtAddress").val(),
        City: $("#txtCity").val(),
        State: $("#txtState").val(),
        NumberOfAgents: $("#txtNumberOfAgents").val(),
        ExpirationDate: $.trim($("#txtExpirationDate").val()),
        User:
        {
            Id: $("#hfUserId").val(),
            FirstName: $.trim($("#txtFirstName").val()),
            LastName: $.trim($("#txtLastName").val()),
            Email: $.trim($("#txtEmail").val()),
            UserId: $.trim($("#txtUserId").val()),
            Password: $.trim($("#txtPassword").val())
        }
    }

    $.post("/api/CustomerApi/UpdateProfile", customer, UpdateProfileCallBack);
}

function UpdateProfileCallBack(data) {
    $("#loader").hide();

    ShowCallbackMessage(data.IsSucceeded, data.Message);
}

function DigitsOnly(e) {
    //if the letter is not digit then display error and don't type anything
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
}

function SelectPackage() {
    if ($("#ddlPackage").val() == "") {
        $("#divPackageInfo").hide();
        return;
    }
    $("#divPackageInfo").show();
    $("#lblPackageDescription").text("$" + $("#ddlPackage option:selected").data("description"));
    $("#lblAmount").text("$" + $("#ddlPackage option:selected").data("amount"));
    $("#lblNumberOfAgents").text($("#ddlPackage option:selected").data("agents"));
}

function CalculatePrice() {
    if ($("#txtNumberOfAgents").val() == "") {
        $("#lblAmount").text("0");
        return;
    }
    var no_agents = parseInt($("#txtNumberOfAgents").val());
    var price = parseInt($("#hfAmount").val());

    var total_price = no_agents * price;

    $("#lblAmount").text(total_price);
}