var CustomerList;
var filters;
var filters_customer;
var CustomersGridPager;
var is_pages_set = false;
var sortOption = ""; var sortOption_license = "";
//$("#navbarlist li a").click(function () {
//    $(this).parent().addClass('pageloadnavbar').siblings().removeClass('pageloadnavbar');

//});

$(document).ready(function () {
    //$(window).load(function () {
    //    $('#navbarlist li').click(function () {
    //        $(this).addClass("pageloadnavbar");
    //    });
    //});
    $("#txtSearch").keyup(handler_enter_search);
    AddSortingHeaders("#tbl");

    $("body").on("click", "#tbl thead th", function () {
        var th = $(this);
        if (!$(th).hasClass("gridSortingMenu")) {
            return
        }
        $(".gridSortingMenu").children("i").attr("class", "");
        if ($(this).hasClass("Asc")) {
            $(this).removeClass("Asc");

            $("#tbl thead th").removeClass("Asc");
            $("#tbl thead th").removeClass("Desc");
            $(this).addClass("Desc");


            sortOption = $(this).attr("datafield") + " Desc";

            th.children("i").attr("class", "fa fa-arrow-up");

        }
        else if ($(this).hasClass("Desc")) {
            $(this).removeClass("Desc");

            $("#tbl thead th").removeClass("Asc");
            $("#tbl thead th").removeClass("Desc");
            $(this).addClass("Asc");

            sortOption = $(this).attr("datafield") + " Asc";
            th.children("i").attr("class", "fa fa-arrow-down");
        }
        else {
            $(this).removeClass("Desc");
            $(this).addClass("Asc");
            sortOption = $(this).attr("datafield") + " Asc";
            th.children("i").attr("class", "fa fa-arrow-down");

        }
        filters.Sort = sortOption;
        LoadLeadsWithCount();
    });

    //if (IsHTML5 && sessionStorage["CustomerFilters"] != null) {
    //    filters = $.parseJSON(sessionStorage["CustomerFilters"]);     
    //    $("#txtSearch").val(filters.Keyword);   
    //    LoadCustomersWithCount();
    //    return;
    //}

    Searchleads();
});

function handler_enter_search(e) {
    var charCode;

    if (e && e.which) {
        charCode = e.which;
    } else if (window.event) {
        e = window.event;
        charCode = e.keyCode;
    }
    if (charCode == 13)
        Searchleads();
}
function Searchleads() {
    UpdateLeadsFilters();
    LoadLeadsWithCount();
}

function ResetUsers() {
    $("#txtSearch").val("");
    Searchleads();
}

function UpdateLeadsFilters() {
    filters =
    {
        Keyword: $("#txtSearch").val(),
        //UserType: 2,
        PageIndex: 1,
        PageSize: 10,
        Sort: sortOption
    };


}
function LoadLeadsWithCount() {
    if (IsHTML5) {
        sessionStorage["CustomerFilters"] = JSON.stringify(filters);
    }
    debugger;
    $("#loader").show();
    $.post("/api/LeadsApi/GetUsersWithCount", filters, LoadLeadsWithCountCallBack);
}
function LoadLeadsWithCountCallBack(data) {
    $("#loader").hide(); $("#divCustomerList").show();
    $("#tbl").show(); $("#div_no_found").hide(); $("#divPagerUsers").show();
    $("#spanTotalRecords").text("(" + data.TotalCount + " records)");

    if (data.TotalCount < 1) {
        $("#tbl").hide();
        $("#divPagerUsers").hide();
        $("#div_no_found").show();
        return;
    }
    $("#tbl tbody").html($("#ListTemplateCustomers").render(data.Message));

    if (CustomersGridPager == null) {
        CustomersGridPager = $("#divPagerUsers").GridPager({
            TotalRecords: data.TotalCount,
            ChangePageSize: ChangePageCustomerResults,
            NavigateToPage: CustomersPageNavigation
        });
    }

    CustomersGridPager.GridPager("SetPageIndexAndSize", filters.PageIndex, filters.PageSize);
    CustomersGridPager.GridPager("SetPager", data.TotalCount);
}

function LoadCustomerPagedCallBack(data) {
    $("#loader").hide();
    $("#tbl tbody").html($("#ListTemplateCustomers").render(data.Message));
}

function LoadCustomerPaged() {
    if (IsHTML5) {
        sessionStorage["CustomerFilters"] = JSON.stringify(filters);
    }
    $("#loader").show();
    $.post("/api/UserApi/GetUsers", filters, LoadCustomerPagedCallBack);
}

function ChangePageCustomerResults(pIndex, pSize) {
    filters.PageIndex = pIndex;
    filters.PageSize = pSize;
    LoadLeadsWithCount();
}

function CustomersPageNavigation(pIndex) {
    filters.PageIndex = pIndex;
    LoadCustomerPaged();
}

function LoadUsers() {

    $("#loader").show();
    filters =
    {
        Keyword: $("#txtSearch").val(),
        PageIndex: (pageIndex - 1),
        PageSize: pageSize
    };

    $.post("/api/UserApi/GetUsers", filters, LoadCustomersCallBack);
}
function LoadCustomersCallBack(data) {
    $("#loader").hide();
    $("#tbl tbody").html($("#ListTemplateCustomers").render(data.Message));
}

function DeleteUsers(CustomerId) {
    var r = confirm('Are you sure you want to delete?');
    if (!r)
        return;

    $("#loader").show();
    $("#div_message").hide();
    Customer =
    {
        Id: CustomerId
    };

    $.post("/api/UserApi/DeleteUser", Customer, DeleteUsersCallBack);
}
function DeleteUsersCallBack(data) {
    $("#loader").hide();
    if (data.IsSucceeded) {
        $("#div_message").show();
        $("#div_message").removeClass("failure");
        $("#div_message").addClass("success");
        $("#span_message").html("User has been successfully deleted.");
        LoadLeadsWithCount();
    } else {
        $("#div_message").show();
        $("#div_message").removeClass("success");
        $("#div_message").addClass("failure");
        $("#span_message").html(data.Message);
    }
}

function ResetUsers() {
    $("#txtSearch").val("");
    Searchleads();
}
