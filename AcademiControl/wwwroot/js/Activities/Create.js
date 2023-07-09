$(document).ready(function () {
    var btnSubmit = $("#btnSubmit");
    btnSubmit.on("click", function () {
        var beginDate = new Date($('#BeginDate').val());
        var endDate = new Date($('#EndDate').val());
        var deliveryDate = new Date($('#DeliveryDate').val());

        var command = {
            ActivityName: $('#Name').val(),
            ActivityDescription: $('#Description').val(),
            ActivityBeginDate: beginDate.toISOString(),
            ActivityEndDate: endDate.toISOString(),
            ActivityDeliveryDate: deliveryDate.toISOString(),
            ActivityStatus: parseInt($('#Status').val()),
            ActivityOwner: $('#OwnerId').val()
        };

        console.log(command);
        console.log(JSON.stringify(command));

        $.ajax({
            url: '/Activities/Create',
            method: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(command),
            success: function () {
                alert('Sucesso ao criar a Atividade');
            },
            error: function (error) {
                console.log(error);
                alert("Não foi possível salvar o registro");
            }
        });

    });
});
