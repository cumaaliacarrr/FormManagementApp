$(document).ready(function () {
    
    $("#BtnLogin").click(function (e) {
        e.preventDefault();
        var userName = $('#txtUserName').val();
        var password = $('#txtPassword').val();
        if (userName === null)
        {
            $('#LoginNameError').removeClass();
        }
        if (password ===null)
        {
            $('#PasswordError').removeClass();
        }
        $.ajax({
            url: 'Home/Login',
            type: 'POST',
            dataType: 'json',
            data: { userName: userName, password: password },
            success: function (data) {
                if (data.ErrorStatus == false) {
                    window.location.href =data.Url;
                }
                else
                    $('#MsgError').removeClass();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    //$("#btnSearch").click(function (e) {
    //    e.preventDefault();
    //    var formSearch = $('#txtSearch').val();
    //    $.ajax({
    //        url: '/Form/List',
    //        type: 'Post',
    //        dataType: 'json',
    //        data: { txtSearch: formSearch },
    //        success: function (data) {
    //            console.log("buraya girdi ");
    //            if (data.ErrorStatus == false) {
    //                window.location.href = data.Url;
    //            }
    //            else
    //                $('#MsgError').removeClass();
    //        },
    //        error: function (hata) {
    //         //   alert(hata);
    //        }
    //    });
    //});

    $('#btnbtn').click(function (e) {
        
        //$('#mymodal').modal('show');
        $('#ornekModal').modal('show');
    });
    $('#MdlClose').click(function (e) {
        $('#ornekModal').modal('hide');
    });
    $('#MdlSave').click(function (e) {
        var obj = {
            Name: $('#formName').val(),
            Description: $('#formDescription').val(),
            CreatedBy: $('#formCreatedBy').val(),
            Ad: $('#name').val(),
            Soyad: $('#surname').val(),
            Yas: $('#yas').val()
        };
        if (name === null || name === 'undefined')
        {
            $('#NameError').removeClass();
            return;
        }
        if (surname === null || surname === 'undefined')
        {
            $('#SurNameError').removeClass();
            return;
        }
        
        $.ajax({
            url: '/Form/Add',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.ErrorStatus == false) {
                    window.location.href = data.Url;
                }
                else
                    $('#MsgError').removeClass();
            },
            error: function (error) {
                console.log(error);
            }
        });
        });
  
    
});