const RenderBikeInfos = (infos, container) => {
    container.empty();

    for (const info of infos) {
        container.append(
            `<div class="card border-secondary mb-3" style="max-width: 18rem;">
            <div class="card-header">${info.cost}</div>
            <div class="card-body">
                <h5 class="card-title">${info.info}</h5>
            </div>
           </div>`)
    }
}

const LoadBikeInfos = () => {
    const container = $("#infos")
    const bikeEncodedName = container.data("encodedName")

    $.ajax({
        url: `/Bike/${bikeEncodedName}/BikeInfo`,
        type: 'get',
        success: function (data) {
            if (!data.length) {
                container.html("There are no infos for this bike")
            } else {
                RenderBikeInfos(data, container)
            }
        },
        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}