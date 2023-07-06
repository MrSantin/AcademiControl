$(document).ready(function () {
    var btnSubmit = $("#btnSubmit");
    btnSubmit.on("click", function () {
        alert('Antes do Command');
        var command = {
            ActivityName: $('#Name').val(),
            ActivityDescription: $('#Description').val(),
            ActivityBeginDate: $('#BeginDate').val(),
            ActivityEndDate: $('#EndDate').val(),
            ActivityDeliveryDate: $('#DeliveryDate').val(),
            ActivityStatus: $('#Status').val()

        };
        alert('Depois do Command');
        console.log(command);
        console.log(JSON.stringify(command));
        $.ajax({
            url: '/Activities/Create',
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(command),
            success: function () {
                alert('Sucesso ao criar a Atividade');
            },
            error: function (error) {
                console.log(error);
                alert("não foi possível salvar o registro");
            }
        });
    });
});
