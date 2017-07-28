$(function () {
    $(".open").click(function () {
        $("#myModal").modal("show");
        $(".EditData").hide();
        $(".SaveData").show();
        $(".ImageLoader").hide();
    })
    $(".SaveData").click(function () {
        var sname = $("#sname").val();
        var sdes = $("#sdes").val();
        var blobFile = $('#ImageUplod')[0].files[0];
        var frm = new FormData();
        frm.append('sname', sname);
        frm.append('sdes', sdes);
        frm.append('img', blobFile);

        $.ajax({
            type : "POST",
            url: "/Home/InsertRecord",
            contentType: false,
            processData: false,
            data: frm,
            success: function (res) {
                location.reload();
            },
            Error : function (err) {
                console.log(Err);
            }
        })
    })

    $(".EditData").click(function () {
        var sname = $("#sname").val();
        var sdes = $("#sdes").val();
        var id = $("#StoreId").val();
        var blobFile = $('#ImageUplod')[0].files[0];
        var bolbname = $("#ImageLoader").val();
        var frm = new FormData();
        frm.append('sname', sname);
        frm.append('sdes', sdes);
        frm.append('id', id);

        if (blobFile != null) {
            frm.append('imgfile', blobFile);
        }
        else {
            frm.append('imgname', bolbname);
        }

        $.ajax({
            type: "POST",
            url: "/Home/UpdateRecord",
            contentType: false,
            processData: false,
            data: frm,
            success: function (res) {
                location.reload();
            },
            Error: function (err) {
                console.log(Err);
            }
        })

    })
    $("#ImageUplod").change(function () {
        $("#ImageLoader").val($(this).val());
    });

})