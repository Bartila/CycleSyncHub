$(document).ready(function () {

    LoadBikeInfos()

    $("#createBikeInfoModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created bike info")

                LoadBikeInfos()
            },
            error: function () {
                toastr["error"]("Something went wrong") 
            }
        })
    });
});